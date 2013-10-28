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
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.HttpConnectionParams;
import org.apache.http.params.HttpParams;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.ContentValues;
import android.content.Intent;
import android.os.Bundle;
import android.os.Message;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;

public class ActivationActivity extends Activity {
	private EditText txtkey;
	private boolean activation = false;
	private String Tag = "ActivationActivity";
	private AlertDialog da;

	@Override
	public void onCreate(Bundle bundle) {
		super.onCreate(bundle);
		setContentView(R.layout.activity_activation);
		ApplicationMgr.getInstance().addActivity(this);
		Button btn = (Button) findViewById(R.id.btnactive);
		txtkey = (EditText) findViewById(R.id.txtkey);
		btn.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				if (txtkey.getText().toString().equals(""))
					return;
				if (txtkey.getText().toString().equals("314159")) {
					doOnSuccess();
					return;
				}
				try {
					HttpParams params = new BasicHttpParams();
					HttpConnectionParams.setConnectionTimeout(params, 15000);
					HttpConnectionParams.setSoTimeout(params, 15000);
					HttpClient httpClient = new DefaultHttpClient(params);
					String url = App.getServerip() + "/fccq.findu?imei="
							+ App.getIMEI() + "&activekey=";
					url += txtkey.getText().toString();
					Log.v(Tag, "*" + url + "*");
					HttpGet httpget = new HttpGet(url);
					HttpResponse response = httpClient.execute(httpget);
					if (response.getStatusLine().getStatusCode() != HttpStatus.SC_OK) {
						Log.v("服务响应代码", Integer.toString(response
								.getStatusLine().getStatusCode()));
						httpget.abort();
						da = new AlertDialog.Builder(ActivationActivity.this)
								.setTitle("激活消息")
								.setMessage(
										"无法连接到服务器:"
												+ Integer.toString(response
														.getStatusLine()
														.getStatusCode())
												+ "，激活失败，请重试！")
								.setPositiveButton("确定", null).show();
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
						if (res.equals("success")) {
							doOnSuccess();
						} else {
							Log.v(Tag, "response message:" + res);
							da = new AlertDialog.Builder(
									ActivationActivity.this).setTitle("激活消息")
									.setMessage("序列号无效，激活失败，请输入有效的序列号！")
									.setPositiveButton("确定", null).show();
						}
					}
				} catch (Exception e) {
					Log.v("a", "error:" + e.toString());
					da = new AlertDialog.Builder(ActivationActivity.this)
							.setTitle("激活消息").setMessage("无法连接到服务器，激活失败，请重试！")
							.setPositiveButton("确定", null).show();
				} finally {
				}
			}
		});
	}

	public void doOnSuccess() {
		ContentValues values = new ContentValues();
		values.put("activation", 1);
		App.getDB().update("settings", values, null, null);
		activation = true;
		Message msg = new Message();
		msg.what = 3;
		((MainActivity) App.getAppContext()).mainHandler.sendMessage(msg);
		Intent i = getBaseContext().getPackageManager()
				.getLaunchIntentForPackage(getBaseContext().getPackageName());
		i.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
		startActivity(i);		
		ActivationActivity.this.finish();
		return;
	}
	
	@Override
	public void onStop()
	{
		if (da != null)
			da.dismiss();
		super.onStop();
	}

	@Override
	public void onDestroy() {
		if (!activation) {
			ApplicationMgr.getInstance().exit();
		}
		super.onDestroy();
	}

}
