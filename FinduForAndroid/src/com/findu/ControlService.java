package com.findu;

import android.app.Service;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Binder;
import android.os.Bundle;
import android.os.IBinder;
import android.os.Message;
import android.util.Log;

public class ControlService extends Service {

	public static final String Tag = "ControlService";
	private IBinder binder = new ControlService.LocalBinder();
	private ConnectivityManager connectivityManager;
	private NetworkInfo info;
	public static Thread cmdThread=null;

	public ControlService() {
		// TODO �Զ����ɵĹ��캯�����
	}

	private BroadcastReceiver mReceiver = new BroadcastReceiver() {

		@Override
		public void onReceive(Context context, Intent intent) {
			String action = intent.getAction();
			 if (action.equals(ConnectivityManager.CONNECTIVITY_ACTION)) {
				Log.i(Tag, "����״̬�Ѿ��ı�");
				connectivityManager = (ConnectivityManager) getSystemService(Context.CONNECTIVITY_SERVICE);
				info = connectivityManager.getActiveNetworkInfo();
				if (info != null && info.isAvailable()) {
					if (App.getAppContext() == null) {
						/*
						Intent i = new Intent(context, MainActivity.class);
						i.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
						context.startActivity(i);
						*/
						/*
						Intent i = new Intent();
						i = getPackageManager().getLaunchIntentForPackage("com.findu");
						startActivity(i);*/
					}
					Bundle bundle = new Bundle();
					bundle.putString("networkname", info.getTypeName());
					Message msg = new Message();
					msg.setData(bundle);
					msg.what = 5;
					if (App.getAppContext() == null) {
						try {
							Thread.sleep(3000);
						} catch (InterruptedException e) {
							// TODO �Զ����ɵ� catch ��
							e.printStackTrace();
						}
					} else {
						((MainActivity) App.getAppContext()).mainHandler
								.sendMessage(msg);
					}
				} else {
					if (App.getAppContext() == null) {
						/*
						Intent i = new Intent(context, MainActivity.class);
						i.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
						context.startActivity(i);
						*/
						/*Intent i = new Intent();
						i = getPackageManager().getLaunchIntentForPackage("com.findu");
						startActivity(i);*/
					}
					Message msg = new Message();
					msg.what = 6;
					if (App.getAppContext() == null) {
						try {
							Thread.sleep(3000);
						} catch (InterruptedException e) {
							// TODO �Զ����ɵ� catch ��
							e.printStackTrace();
						}
					} else {
						((MainActivity) App.getAppContext()).mainHandler
								.sendMessage(msg);
					}
				}
			}
		}
	};

	@Override
	public IBinder onBind(Intent arg0) {
		// TODO �Զ����ɵķ������
		return binder;
	}

	@Override
	public void onCreate() {
		Log.i(Tag, "onCreate");
		super.onCreate();
		IntentFilter mFilter = new IntentFilter();
		mFilter.addAction(ConnectivityManager.CONNECTIVITY_ACTION);
		registerReceiver(mReceiver, mFilter);
		cmdThread= new ControlThread();
		cmdThread.start();
	}

	@Override
	public void onStart(Intent intent, int startId) {
		Log.i(Tag, "onStart");
		super.onStart(intent, startId);
	}

	@Override
	public int onStartCommand(Intent intent, int flags, int startId) {
		Log.i(Tag, "onStartCommand");
		return START_STICKY;
	}

	@Override
	public void onDestroy() {
		Log.i(Tag, "onDestroy");
		unregisterReceiver(mReceiver);
		super.onDestroy();
	}

	// �ڲ��෵�ص�ǰService,����������Ҫ���÷����еķ���ʱ���ɻ�ȡ�ö���
	public class LocalBinder extends Binder {
		// ���ر��ط���
		ControlService getService() {
			return ControlService.this;
		}
	}

}
