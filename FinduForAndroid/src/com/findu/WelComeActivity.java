package com.findu;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class WelComeActivity extends Activity {
	private Button btnviewmode;
	private Button btnpatrolmode;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_welcome);
		ApplicationMgr.getInstance().addActivity(this);
		btnviewmode = (Button) findViewById(R.id.btnviewmode);
		btnpatrolmode = (Button) findViewById(R.id.btnpatrolmode);

		btnviewmode.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				SettingManager.addSetting(WelComeActivity.this, Constant.Settingfile, "startmode", "view");
				Intent i = new Intent(WelComeActivity.this, MainActivity.class);				
				startActivity(i);
				finish();
			}
		});
		btnpatrolmode.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				SettingManager.addSetting(WelComeActivity.this, Constant.Settingfile, "startmode", "patrol");
				Intent i = new Intent(WelComeActivity.this, MainActivity.class);
				startActivity(i);
				finish();
			}
		});
	}

}
