package com.findu;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Toast;

@SuppressLint("HandlerLeak")
public class Remark extends Activity {

	private EditText remarkText;
	public static String remark;
	private ImageView imageView;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_remarkable);
		remarkText = (EditText) this.findViewById(R.id.remark);
		imageView = (ImageView) this.findViewById(R.id.imageView);
		Button button = (Button) this.findViewById(R.id.btnSave);

		Intent data = getIntent();
		Uri uri = data.getData();// ��ȡͼƬ��Uri
		if (uri != null) {// ֱ������ͼƬ
			MainActivity.photo = BitmapFactory.decodeFile(uri.getPath());
		}
		if (MainActivity.photo == null) {
			Bundle bundle = data.getExtras();// �õ�data����������
			if (bundle != null) {
				MainActivity.photo = (Bitmap) bundle.get("data");// ���bitmap����
			} else {
				Toast.makeText(Remark.this,
						getString(R.string.msg_get_photo_failure),
						Toast.LENGTH_LONG).show();
				return;
			}
		}
		if (MainActivity.photo != null) {
			imageView.setImageBitmap(MainActivity.photo);
		}

		button.setOnClickListener(new ButtonClickListener());
	}

	private final class ButtonClickListener implements View.OnClickListener {
		public void onClick(View v) {
			remark = remarkText.getText().toString();
			upLoadPhotoes();
		}
	}

	/**
	 * �ϴ���������
	 */

	private void upLoadPhotoes() {
		if (MainActivity.photo != null && !MainActivity.photo.isRecycled()) {
			HttpMultipartPost task = new HttpMultipartPost(this);
			task.execute();
		}
	}

	@SuppressLint("HandlerLeak")
	public Handler uploadHandler = new Handler() {
		@SuppressLint("HandlerLeak")
		@Override
		public void handleMessage(Message msg) {
			switch (msg.what) {
			case 1:
				Toast.makeText(Remark.this, "ͼƬ�ϴ��ɹ�", Toast.LENGTH_SHORT)
						.show();
				finish();
				break;
			case 2:
				String responseText = msg.getData().getString("responseText");
				Log.i("Remark", responseText);
				Toast.makeText(Remark.this, "�ϴ�ʧ��,������!", Toast.LENGTH_SHORT)
						.show();
				break;
			default:
				break;
			}
		}
	};

}
