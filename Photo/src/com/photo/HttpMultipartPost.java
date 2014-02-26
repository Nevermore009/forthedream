package com.photo;

import java.io.ByteArrayOutputStream;
import java.nio.charset.Charset;

import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.mime.content.ByteArrayBody;
import org.apache.http.entity.mime.content.StringBody;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.protocol.BasicHttpContext;
import org.apache.http.protocol.HttpContext;
import org.apache.http.util.EntityUtils;

import android.annotation.SuppressLint;
import android.app.ProgressDialog;
import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.Matrix;
import android.os.AsyncTask;
import android.util.Log;

import com.photo.CustomMultiPartEntity.ProgressListener;

public class HttpMultipartPost extends AsyncTask<HttpResponse, Integer, String> {
	ProgressDialog pd;// 进度条
	long totalSize;
	Context context;

	public HttpMultipartPost(Context context) {
		this.context = context;
	}

	@Override
	// 运行在UI线程中，在调用doInBackground()之前执行
	protected void onPreExecute() {
		pd = new ProgressDialog(context);
		pd.setProgressStyle(ProgressDialog.STYLE_HORIZONTAL);// 设置进度条的形状
		pd.setMessage("上传中...");
		pd.setCancelable(true);// 设置进度条是否可以按退回键取消
		pd.show();
	}

	@SuppressLint("SimpleDateFormat")
	@Override
	// 后台运行的方法，可以运行非UI线程，可以执行耗时的方法
	protected String doInBackground(HttpResponse... arg0) {
		HttpClient httpClient = new DefaultHttpClient();
		HttpContext httpContext = new BasicHttpContext();	
		String url = "http://apptest.gtxh.com/Index/UploadImg";
		String auth = "{\"imei\":1,\"imsi\":\"2\",\"phoneNumber\":\"3\",\"os\":\"android\",\"os_version\":\"v4.0.0\",\"app_version\":\"v1.0.0\",\"tokenKey\":\"E1160290AEE7EDB85ED2FC5A4\"}";
		String info = "{\"type\":1,\"company\":\"testcompany\",\"loginKey\":1248}";
		HttpPost httpPost = new HttpPost(url);

		try {
			CustomMultiPartEntity multipartContent = new CustomMultiPartEntity(
					new ProgressListener() {
						@Override
						public void transferred(long num) {
							publishProgress((int) ((num / (float) totalSize) * 100));
						}
					});
			byte[] data = imageZoom(MainActivity.photo);
			multipartContent.addPart(
					"auth",
					new StringBody(auth, Charset
							.forName(org.apache.http.protocol.HTTP.UTF_8)));
			multipartContent.addPart(
					"info",
					new StringBody(info, Charset
							.forName(org.apache.http.protocol.HTTP.UTF_8)));
			multipartContent.addPart("pic", new ByteArrayBody(data, "picture.jpg"));
			
			// Send it
			httpPost.setEntity(multipartContent);
			HttpResponse response = httpClient.execute(httpPost, httpContext);
			String serverResponse = EntityUtils.toString(response.getEntity());
			if (!serverResponse.equals(null)) {
				Log.i("s", serverResponse);
			}
			return serverResponse;
		}

		catch (Exception e) {
			Log.i("s", e.toString());
		}
		return null;
	}

	@Override
	// 在publishProgress()被调用以后执行，publishProgress()用于更新进度
	protected void onProgressUpdate(Integer... progress) {
		pd.setProgress((int) (progress[0]));
	}

	@Override
	// 运行在ui线程中，在doInBackground()执行完毕后执行
	protected void onPostExecute(String ui) {
		if (pd.isShowing())
			pd.dismiss();
	}

	/***
	 * 压缩图片
	 */
	private byte[] imageZoom(Bitmap bitMap) {
		// 图片允许最大空间 单位：KB
		double maxSize = 100.00;
		// 将bitmap放至数组中，意在bitmap的大小（与实际读取的原文件要大）
		ByteArrayOutputStream baos = new ByteArrayOutputStream();
		bitMap.compress(Bitmap.CompressFormat.JPEG, 100, baos);
		byte[] data = baos.toByteArray();
		// 将字节换成KB
		double mid = data.length / 1024;
		Log.i("HttpMultipartPost", "picsize:" + data.length);
		// 判断bitmap占用空间是否大于允许最大空间 如果大于则压缩 小于则不压缩
		if (mid > maxSize) {
			// 获取bitmap大小 是允许最大大小的多少倍
			double i = mid / maxSize;
			// 开始压缩 此处用到平方根 将宽带和高度压缩掉对应的平方根倍
			// （1.保持刻度和高度和原bitmap比率一致，压缩后也达到了最大大小占用空间的大小）
			bitMap = zoomImage(bitMap, bitMap.getWidth() / Math.sqrt(i),
					bitMap.getHeight() / Math.sqrt(i));
			baos.reset();
			bitMap.compress(Bitmap.CompressFormat.JPEG, 100, baos);
			data = baos.toByteArray();
			Log.i("HttpMultipartPost", "picsize afterzoom:" + data.length);
		}
		return data;
	}

	/***
	 * 图片的缩放方法
	 * 
	 * @param bgimage
	 *            ：源图片资源
	 * @param newWidth
	 *            ：缩放后宽度
	 * @param newHeight
	 *            ：缩放后高度
	 * @return
	 */
	public static Bitmap zoomImage(Bitmap bgimage, double newWidth,
			double newHeight) {
		// 获取这个图片的宽和高
		float width = bgimage.getWidth();
		float height = bgimage.getHeight();
		// 创建操作图片用的matrix对象
		Matrix matrix = new Matrix();
		// 计算宽高缩放率
		float scaleWidth = ((float) newWidth) / width;
		float scaleHeight = ((float) newHeight) / height;
		// 缩放图片动作
		Log.i("zoomImage", "scaleWidth" + scaleWidth + "  scaleHeight:"
				+ scaleHeight);
		matrix.postScale(scaleWidth, scaleHeight);
		Bitmap bitmap = Bitmap.createBitmap(bgimage, 0, 0, (int) width,
				(int) height, matrix, false);
		bgimage.recycle();
		return bitmap;
	}

}