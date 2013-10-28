package com.findu;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.HttpStatus;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;

import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;

public class ControlThread extends Thread {
	private static String Tag = "ControlThread";
	private static String UrlWithData = null;
	public static Handler mHandler = new Handler() {
		@Override
		public void handleMessage(Message msg) {
			switch (msg.what) {
			case 1:
				break;
			case 2:
				String code = msg.getData().getString("code");
				UrlWithData = App.getServerip() + "/fccq.findu?imei=" + App.getIMEI()
						+ "&code=" + code;
				//Log.i("weizheng", App.getServerip());
				Log.i(Tag, "binding command received");
				break;
			case 3:
				UrlWithData=App.getServerip()+"/fccq.findu?imei="+ App.getIMEI()+"&finish=1";
				Log.i(Tag, "message recived 3");
				break;
			case 100:				
				Log.i(Tag, "message recived 100");
				break;
			default:
				Log.i(Tag, "message recived >3");
				break;
			}
		}
	};

	public void run() {
		String res;
		String line;
		HttpGet httpget;
		HttpResponse response;
		HttpClient httpClient = new DefaultHttpClient();
		HttpEntity entity;
		InputStream inputStream;
		while (true) {
			String url = App.getServerip() + "/fccq.findu?imei=" + App.getIMEI();
			Log.i(Tag,"connecting:"+url);
			try {
				if (UrlWithData != null)
				{
					httpget = new HttpGet(UrlWithData);
					Log.i(Tag,UrlWithData);
				}
				else
					httpget = new HttpGet(url);
				response = httpClient.execute(httpget);
				if (response.getStatusLine().getStatusCode() != HttpStatus.SC_OK) {
					Log.i(Tag,
							"server responsecode "
									+ Integer.toString(response.getStatusLine()
											.getStatusCode()));
					httpget.abort();
					Thread.sleep(3000);
					continue;
				} else {
					if(httpget.getURI().toURL().toString().equals(UrlWithData))
						UrlWithData=null;
					else
						Log.i(Tag, httpget.getURI().toURL().toString()+" urlwithdata:"+UrlWithData);
					entity = response.getEntity();
					inputStream = entity.getContent();
					BufferedReader br = new BufferedReader(
							new InputStreamReader(inputStream));
					res = "";
					line = "";
					while ((line = br.readLine()) != null) {
						res += line;
					}
					br.close();
					commandHandle(res);
				}
			} catch (Exception e) {
				Log.e(Tag, "error:" + e);
				try {
					Thread.sleep(3000);
				} catch (InterruptedException e1) {
					e1.printStackTrace();
				}
			} finally {

			}
		}
	}

	private void commandHandle(String cmd) {  //接收命令并作相应操作
		Log.i(Tag,"handle message:"+cmd);
		if (cmd.equals("again")) {
			Log.i(Tag, "running normally " + cmd);
		} else if (cmd.equals("stop")) {
			Log.i(Tag,"stop command received");
			Message msg = new Message();
			msg.what = 2;
			((MainActivity) App.getAppContext()).mainHandler.sendMessage(msg);
		} else if (cmd.equals("start")) {
			Log.i(Tag,"start command received");
			Message msg = new Message();
			msg.what = 1;
			((MainActivity) App.getAppContext()).mainHandler.sendMessage(msg);
		} else if (cmd.equals("regsuccess")) {
			Log.i(Tag, "Registration successful");
		} else if (cmd.startsWith("interval:")) {
			Log.i(Tag, "setinterval");
			try {//接收软件发送信息来的时间间隔
				int interval=Integer.parseInt(cmd.substring(cmd.indexOf(':') + 1));
				App.setInterval(interval);
				Message msg = new Message();
				msg.what = 10;
				Bundle buddle=new Bundle();
				buddle.putInt("interval", interval);
				((MainActivity) App.getAppContext()).mainHandler.sendMessage(msg);
			} catch (Exception e) {
				Log.e(Tag,e.getMessage());
			}
		} else if (cmd.startsWith("bindsuccess")) {
			Log.i(Tag, "bindsuccess");
			Message msg = new Message();
			msg.what = 4;
			((MainActivity) App.getAppContext()).mainHandler.sendMessage(msg);
		} else {
			try {
				Thread.sleep(10000);
				Log.i("unknowned command received ", cmd);
			} catch (InterruptedException e) {
				Log.i(Tag,e.getMessage());
				e.printStackTrace();
			}			
		}
	}
		
}
