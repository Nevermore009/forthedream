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
	ProgressDialog pd;// ������
	long totalSize;
	Context context;

	public HttpMultipartPost(Context context) {
		this.context = context;
	}

	@Override
	// ������UI�߳��У��ڵ���doInBackground()֮ǰִ��
	protected void onPreExecute() {
		pd = new ProgressDialog(context);
		pd.setProgressStyle(ProgressDialog.STYLE_HORIZONTAL);// ���ý���������״
		pd.setMessage("�ϴ���...");
		pd.setCancelable(true);// ���ý������Ƿ���԰��˻ؼ�ȡ��
		pd.show();
	}

	@SuppressLint("SimpleDateFormat")
	@Override
	// ��̨���еķ������������з�UI�̣߳�����ִ�к�ʱ�ķ���
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
	// ��publishProgress()�������Ժ�ִ�У�publishProgress()���ڸ��½���
	protected void onProgressUpdate(Integer... progress) {
		pd.setProgress((int) (progress[0]));
	}

	@Override
	// ������ui�߳��У���doInBackground()ִ����Ϻ�ִ��
	protected void onPostExecute(String ui) {
		if (pd.isShowing())
			pd.dismiss();
	}

	/***
	 * ѹ��ͼƬ
	 */
	private byte[] imageZoom(Bitmap bitMap) {
		// ͼƬ�������ռ� ��λ��KB
		double maxSize = 100.00;
		// ��bitmap���������У�����bitmap�Ĵ�С����ʵ�ʶ�ȡ��ԭ�ļ�Ҫ��
		ByteArrayOutputStream baos = new ByteArrayOutputStream();
		bitMap.compress(Bitmap.CompressFormat.JPEG, 100, baos);
		byte[] data = baos.toByteArray();
		// ���ֽڻ���KB
		double mid = data.length / 1024;
		Log.i("HttpMultipartPost", "picsize:" + data.length);
		// �ж�bitmapռ�ÿռ��Ƿ�����������ռ� ���������ѹ�� С����ѹ��
		if (mid > maxSize) {
			// ��ȡbitmap��С ����������С�Ķ��ٱ�
			double i = mid / maxSize;
			// ��ʼѹ�� �˴��õ�ƽ���� ������͸߶�ѹ������Ӧ��ƽ������
			// ��1.���̶ֿȺ͸߶Ⱥ�ԭbitmap����һ�£�ѹ����Ҳ�ﵽ������Сռ�ÿռ�Ĵ�С��
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
	 * ͼƬ�����ŷ���
	 * 
	 * @param bgimage
	 *            ��ԴͼƬ��Դ
	 * @param newWidth
	 *            �����ź���
	 * @param newHeight
	 *            �����ź�߶�
	 * @return
	 */
	public static Bitmap zoomImage(Bitmap bgimage, double newWidth,
			double newHeight) {
		// ��ȡ���ͼƬ�Ŀ�͸�
		float width = bgimage.getWidth();
		float height = bgimage.getHeight();
		// ��������ͼƬ�õ�matrix����
		Matrix matrix = new Matrix();
		// ������������
		float scaleWidth = ((float) newWidth) / width;
		float scaleHeight = ((float) newHeight) / height;
		// ����ͼƬ����
		Log.i("zoomImage", "scaleWidth" + scaleWidth + "  scaleHeight:"
				+ scaleHeight);
		matrix.postScale(scaleWidth, scaleHeight);
		Bitmap bitmap = Bitmap.createBitmap(bgimage, 0, 0, (int) width,
				(int) height, matrix, false);
		bgimage.recycle();
		return bitmap;
	}

}