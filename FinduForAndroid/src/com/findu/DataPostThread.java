package com.findu;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.text.MessageFormat;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.HttpStatus;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.HttpConnectionParams;
import org.apache.http.params.HttpParams;
import org.apache.http.protocol.HTTP;

import android.content.ContentValues;
import android.os.Handler;
import android.os.Message;
import android.util.Log;

public class DataPostThread extends Thread {
	private static String Tag = "DataPostThread";
	private static boolean running = false;
	public static Handler DataPostThreadhandle = new Handler() {
		@Override
		public void handleMessage(Message msg) {
			switch (msg.what) {
			case 1:
				running = true;
				break;
			case 2:
				running = false;
				break;
			case 3:
				Log.i(Tag, "message recived 3");
				break;
			default:
				Log.i(Tag, "message recived >3");
				break;
			}
		}
	};

	@Override
	public void run() {
		while (true) {
			if (!running) {
				try {
					Thread.sleep(500);
				} catch (InterruptedException e) {
					e.printStackTrace();
				}
				continue;
			}
			Log.i(Tag, "beginning");
			String doc = "<root>";
			String data = "";
			ContentValues[] cv = App.getDB()
					.query("latandlon",
							new String[] { "ID", "Lat", "Lon", "Locatetime",
									"Isauto" ,"Remark"}, null, null, null, null,
							" locatetime asc");
			for (int i = 0; cv != null && i < cv.length; i++) {
				data += MessageFormat
						.format("<LatAndLon id=\"{0}\" lat=\"{1}\" lon=\"{2}\" locatetime=\"{3}\" remark=\"{4}\" ",
								cv[i].get("ID"), cv[i].get("Lat"),
								cv[i].get("Lon"), cv[i].get("Locatetime"),cv[i].get("Remark"));
				if (cv[i].getAsString("Isauto").equals("0")) {
					data += MessageFormat.format(" isauto=\"{0}\"", "false");// 标志手动定位
				}
				data += " />";
				Log.i(Tag, data);
			}
			if (data.equals("")) {
				Log.i(Tag, "no data");
				try {
					Thread.sleep(App.getInterval());
				} catch (InterruptedException e) {
					e.printStackTrace();
				}
				continue;
			}
			doc += data + "</root>";
			Log.i(Tag, "sending data");
			try {
				HttpParams params = new BasicHttpParams();
				HttpConnectionParams.setConnectionTimeout(params, 18 * 1000);
				HttpConnectionParams.setSoTimeout(params, 18 * 1000);
				HttpClient httpClient = new DefaultHttpClient(params);
				String url = App.getServerip() + "/fccq.sky?imei="
						+ App.getIMEI();
				Log.i(Tag, "url:" + url);
				HttpPost httppost = new HttpPost(url);

				StringEntity se = new StringEntity(doc, HTTP.UTF_8);
				se.setContentType("application/xml");
				httppost.setEntity(se);
				HttpResponse response = httpClient.execute(httppost);
				if (response.getStatusLine().getStatusCode() != HttpStatus.SC_OK) {
					Log.v(Tag,
							"Server responseCode"
									+ Integer.toString(response.getStatusLine()
											.getStatusCode()));
					httppost.abort();
				} else {
					HttpEntity entity = response.getEntity();
					InputStream inputStream = entity.getContent();
					BufferedReader br = new BufferedReader(
							new InputStreamReader(inputStream));
					String res = "";
					String line = "";
					while ((line = br.readLine()) != null) {
						res += line;
					}
					if (res.length() > 0 && res.startsWith("gettedid:")) {
						String ids = res
								.substring(res.indexOf("gettedid:") + 9);
						int b = App.getDB().delete("latandlon",
								"id in(" + ids + ")", null);
						Log.v(Tag, String.valueOf(b) + " rows deleted");
						Log.v(Tag, "record " + ids + " deleted");
					} else
						Log.v(Tag, "unknowned response string:" + res);
				}
			} catch (Exception e) {
				Log.e(Tag, "error:" + e.toString());
				continue;
			} finally {
				// 释放连接
			}
			Log.v(Tag, "go on");
			try {
				Thread.sleep(App.getInterval());
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		}
	}
}
