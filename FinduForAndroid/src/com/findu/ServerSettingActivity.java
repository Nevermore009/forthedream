package com.findu;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.ContentValues;
import android.content.DialogInterface;
import android.content.DialogInterface.OnCancelListener;
import android.os.Bundle;
import android.os.Message;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;

public class ServerSettingActivity extends Activity {
	private Button btnsave;
	private EditText txtserverip;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_server_setting);
		txtserverip = (EditText) findViewById(R.id.server_setting_txtip);
		btnsave = (Button) findViewById(R.id.server_setting_btnsave);
		final DialogInterface.OnClickListener saveDialogListener = new DialogInterface.OnClickListener() {

			@Override
			public void onClick(DialogInterface dialog, int which) {
				switch (which) {
				case DialogInterface.BUTTON_POSITIVE:
					String ip = txtserverip.getText().toString();
					if (!ip.equals("")) {
						ContentValues content = new ContentValues();
						content.put("serverip", ip);
						App.getDB().update("settings", content, null, null);
						App.setServerip(ip);
						Message msg = new Message();
						msg.what = 1;
						Bundle bundle = new Bundle();
						bundle.putString("ip", ip);
						msg.setData(bundle);
						ControlThread.mHandler.sendMessage(msg);
						dialog.dismiss();
						new AlertDialog.Builder(ServerSettingActivity.this)
								.setTitle("保存成功!")
								.setPositiveButton("确定",
										new DialogInterface.OnClickListener() {
											@Override
											public void onClick(
													DialogInterface d, int which) {
												d.dismiss();
												finish();

											}
										}).show();
					}
					break;
				case DialogInterface.BUTTON_NEGATIVE:
					dialog.dismiss();
					break;
				default:
					break;
				}

			}

		};
		btnsave.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				new AlertDialog.Builder(ServerSettingActivity.this)
						.setTitle("确定要保存吗?")
						.setPositiveButton("确定", saveDialogListener)
						.setNegativeButton("取消", saveDialogListener).show();
			}
		});
		final EditText txtpassword = new EditText(ServerSettingActivity.this);
		DialogInterface.OnClickListener passwordDialogListener = new DialogInterface.OnClickListener() {

			@Override
			public void onClick(DialogInterface dialog, int which) {
				switch (which) {
				case DialogInterface.BUTTON_POSITIVE:
					if (txtpassword.getText().toString()
							.equals(App.getIMEI().substring(0, 4))) {
						txtserverip.setVisibility(EditText.VISIBLE);
						btnsave.setVisibility(Button.VISIBLE);
					} else {
						txtpassword.setText("");
					}
					break;
				case DialogInterface.BUTTON_NEGATIVE:
					finish();
					break;
				default:
					break;
				}
			}
		};		
		new AlertDialog.Builder(ServerSettingActivity.this).setTitle("请输入二级密码")
				.setIcon(android.R.drawable.ic_dialog_info)
				.setView(txtpassword)
				.setPositiveButton("确定", passwordDialogListener)
				.setNegativeButton("取消", passwordDialogListener)
				.setOnCancelListener(new OnCancelListener() {
					@Override
					public void onCancel(DialogInterface dialog) {
						finish();
					}
				}).show();
		
	}
}
