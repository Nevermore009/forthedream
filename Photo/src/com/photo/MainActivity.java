package com.photo;

import com.findu.R;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.content.ActivityNotFoundException;
import android.content.ComponentName;
import android.content.DialogInterface;
import android.content.DialogInterface.OnCancelListener;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

@SuppressLint("HandlerLeak")
public class MainActivity extends Activity {
	private String Tag = "MainActivity";
	private Button btnphoto;
	public static Bitmap photo;
	private int RequestCode = 1;
	public static String remark;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		Log.i(Tag, "onCreate");
		setContentView(R.layout.activity_main);
		CrashHandler handler = CrashHandler.getInstance();
		handler.init(getApplicationContext());
		Thread.setDefaultUncaughtExceptionHandler(handler);
		ApplicationMgr.getInstance().addActivity(this);
		setTitle(R.string.App_Description);
		btnphoto = (Button) findViewById(R.id.btngetphoto);
		btnphoto.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				takePhotoes();
			}
		});	
	}



	@SuppressLint("HandlerLeak")
	public Handler mainHandler = new Handler() { // ���߳���Ϣ����
		@Override
		public void handleMessage(Message msg) {
			switch (msg.what) {			
			case 8:
				Toast.makeText(MainActivity.this, "ͼƬ�ϴ��ɹ�", Toast.LENGTH_SHORT)
						.show();
				break;
			case 9:
				Toast.makeText(MainActivity.this, "�ϴ�ʧ��", Toast.LENGTH_SHORT)
						.show();
				break;			
			default:
				break;
			}
		}
	};

	@Override
	public void onStart() {
		super.onStart();
	}

	@Override
	public void onPause() {
		super.onPause();
	}

	@Override
	public void onDestroy() {
		Log.i(Tag, "onDestroy");
		super.onDestroy();
	}

	@Override
	public void onResume() {
		super.onResume();
	}


	// ���back��̨
	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {
		PackageManager pm = getPackageManager();
		ResolveInfo homeInfo = pm.resolveActivity(
				new Intent(Intent.ACTION_MAIN)
						.addCategory(Intent.CATEGORY_HOME), 0);
		if (keyCode == KeyEvent.KEYCODE_BACK) {
			ActivityInfo ai = homeInfo.activityInfo;
			Intent startIntent = new Intent(Intent.ACTION_MAIN);
			startIntent.addCategory(Intent.CATEGORY_LAUNCHER);
			startIntent
					.setComponent(new ComponentName(ai.packageName, ai.name));
			startActivitySafely(startIntent);
			return true;
		} else
			return super.onKeyDown(keyCode, event);
	}

	private void startActivitySafely(Intent intent) {
		intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
		try {
			startActivity(intent);
		} catch (ActivityNotFoundException e) {
			Toast.makeText(this, "not found error", Toast.LENGTH_SHORT).show();
		} catch (SecurityException e) {
			Toast.makeText(this, "security error", Toast.LENGTH_SHORT).show();
		}
	}
	
	// ---�����ϴ����ܿ�ʼ
	private void takePhotoes() {
		destoryBimap();// ���������������֮ǰ����ʱ��ռ�õ��ڴ�
		Intent i = new Intent("android.media.action.IMAGE_CAPTURE");
		startActivityForResult(i, RequestCode);// �������
	}

	@Override
	// ������֮���Զ���������¼�
	public void onActivityResult(int requestCode, int resultCode, Intent data) {
		if (requestCode == RequestCode && resultCode != RESULT_CANCELED) {// resultCode�ǻش��ı��
			data.setClass(this, Remark.class);
			startActivity(data);
		}
	}

	/**
	 * ����ͼƬ�ļ�
	 */
	private void destoryBimap() {
		if (photo != null && !photo.isRecycled()) {
			photo.recycle();
			photo = null;
		}
	}

	/**
	 * ����Dialog��http://blog.csdn.net/aomandeshangxiao/article/details/7282272
	 */
	@Override
	protected Dialog onCreateDialog(int id) {
		switch (id) {
		case 1: {
			final EditText remarkText = new EditText(MainActivity.this);
			DialogInterface.OnClickListener remarkDialogListener = new DialogInterface.OnClickListener() {

				@Override
				public void onClick(DialogInterface dialog, int which) {
					switch (which) {
					case DialogInterface.BUTTON_POSITIVE:
						remark = remarkText.getText().toString();
						remarkText.setText("");
						dialog.dismiss();
						break;
					case DialogInterface.BUTTON_NEGATIVE:
						dialog.dismiss();
						break;
					default:
						break;
					}
				}
			};
			Dialog remarkdialog = new AlertDialog.Builder(MainActivity.this)
					.setTitle("��ӱ�ע��Ϣ")
					.setIcon(android.R.drawable.ic_dialog_info)
					.setView(remarkText)
					.setPositiveButton("ȷ��", remarkDialogListener)
					.setNegativeButton("ȡ��", remarkDialogListener)
					.setOnCancelListener(new OnCancelListener() {
						@Override
						public void onCancel(DialogInterface dialog) {
							dialog.dismiss();
						}
					}).create();
			return remarkdialog;
		}
		default:
			return null;
		}
	}

}
