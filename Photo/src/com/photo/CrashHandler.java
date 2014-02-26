package com.photo;

import java.io.PrintWriter;
import java.io.StringWriter;
import java.io.Writer;
import java.lang.Thread.UncaughtExceptionHandler;
import java.lang.reflect.Field;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.HttpStatus;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;

import android.content.Context;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.os.Build;
import android.telephony.TelephonyManager;
import android.util.Log;

public class CrashHandler implements UncaughtExceptionHandler {

	@Override
	public void uncaughtException(Thread thread, Throwable ex) {
		System.out.println("程序挂掉了 ");
		// 1.获取当前程序的版本号. 版本的id
		String versioninfo = getVersionInfo();

		// 2.获取手机的硬件信息.
		String mobileInfo = getMobileInfo();

		// 3.把错误的堆栈信息 获取出来
		String errorinfo = getErrorInfo(ex);

		// 4.把所有的信息 还有信息对应的时间 提交到服务器

		TelephonyManager TelephonyMgr = (TelephonyManager) this.context
				.getSystemService(Context.TELEPHONY_SERVICE);
		String IMEI = TelephonyMgr.getDeviceId();
		String content = "IMEI:" + IMEI + "|versioninfo:" + versioninfo
				+ "|mobileinfo:" + mobileInfo + "|errorinfo:" + errorinfo;
		Log.i("application error", content);
		HttpPost httppost;
		HttpResponse response;
		HttpClient httpClient = new DefaultHttpClient();
		String url = "http://58.221.58.195:88/fccq.error?imei=" + IMEI;
		// String url = "http://10.0.2.2:4829/UIWeb/fccq.error?imei=" + IMEI;
		while (true) {
			try {
				httppost = new HttpPost(url);
				StringEntity entity = new StringEntity(content);
				httppost.setEntity(entity);
				response = httpClient.execute(httppost);
				if (response.getStatusLine().getStatusCode() != HttpStatus.SC_OK) {
					httppost.abort();
					Thread.sleep(3000);
					continue;
				} else {
					HttpEntity resEntity = response.getEntity(); // DEBUG
					if (resEntity != null) {
						try {
							String responsetext = EntityUtils
									.toString(resEntity);
							if (responsetext.equals("getted")) {
								Log.i("CrashHandler", "error send success");
								ApplicationMgr.getInstance().exit();
								return;
							}
						} catch (Exception e) {
							continue;
						}
					} else
						continue;
				}
			} catch (Exception e) {
				ApplicationMgr.getInstance().exit();
			} finally {
			}
		}
	}

	private static CrashHandler myCrashHandler;
	private Context context;

	// 1.私有化构造方法
	private CrashHandler() {

	}

	public static synchronized CrashHandler getInstance() {
		if (myCrashHandler != null) {
			return myCrashHandler;
		} else {
			myCrashHandler = new CrashHandler();
			return myCrashHandler;
		}
	}

	public void init(Context context) {
		this.context = context;
		// this.service = service;
	}

	/**
	 * 获取错误的信息
	 * 
	 * @param arg1
	 * @return
	 */
	private String getErrorInfo(Throwable arg1) {
		Writer writer = new StringWriter();
		PrintWriter pw = new PrintWriter(writer);
		arg1.printStackTrace(pw);
		pw.close();
		String error = writer.toString();
		return error;
	}

	/**
	 * 获取手机的硬件信息
	 * 
	 * @return
	 */
	private String getMobileInfo() {
		StringBuffer sb = new StringBuffer();
		// 通过反射获取系统的硬件信息
		try {

			Field[] fields = Build.class.getDeclaredFields();
			for (Field field : fields) {
				// 暴力反射 ,获取私有的信息
				field.setAccessible(true);
				String name = field.getName();
				String value = field.get(null).toString();
				sb.append(name + "=" + value);
				sb.append("\n");
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		return sb.toString();
	}

	/**
	 * 获取手机的版本信息
	 * 
	 * @return
	 */
	private String getVersionInfo() {
		try {
			PackageManager pm = context.getPackageManager();
			PackageInfo info = pm.getPackageInfo(context.getPackageName(), 0);
			return info.versionName;
		} catch (Exception e) {
			e.printStackTrace();
			return "版本号未知";
		}
	}

}
