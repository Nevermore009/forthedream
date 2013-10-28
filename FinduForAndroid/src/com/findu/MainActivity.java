package com.findu;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.HashMap;
import java.util.Map;
import java.util.Timer;
import java.util.TimerTask;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.ActivityNotFoundException;
import android.content.ComponentName;
import android.content.ContentValues;
import android.content.Context;
import android.content.DialogInterface;
import android.content.DialogInterface.OnCancelListener;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.graphics.Bitmap;
import android.location.GpsStatus;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.telephony.TelephonyManager;
import android.util.Log;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

@SuppressLint("HandlerLeak")
public class MainActivity extends Activity {
	private Location curlocation;
	private String curprovider;
	private LocationManager manager;
	private TextView txtwarning;
	private int latlngid; // ���ݿ�������¼ID
	private TelephonyManager TelephonyMgr;
	private String Tag = "MainActivity";
	private Thread datapostthread;
	private int isactive = 0;
	private boolean isstart = false; // ����Ѳ�컹����ͣ
	private boolean isonplan = false;
	private boolean isbinding = false;
	private Button btnmain;
	private Button btnstart;
	private Button btnstop;
	private Button btnbind;
	private Button btnphoto;
	private boolean immediately = false;
	private boolean islocate = false;
	private boolean onlistening = false;
	private Timer timer;
	public static Bitmap photo;
	private int RequestCode = 1;
	public static String remark;
	private ProgressDialog pdfinish;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		Log.i(Tag, "onCreate");
		setContentView(R.layout.activity_main);
		// ����δ�����쳣
		// ��ȡ��service
		CrashHandler handler = CrashHandler.getInstance();
		handler.init(getApplicationContext());
		Thread.setDefaultUncaughtExceptionHandler(handler);
		ApplicationMgr.getInstance().addActivity(this);
		setTitle(R.string.App_Description);
		setBasicInfo();
		if (ControlService.cmdThread == null)
			startControlService();

		String mode = SettingManager.getSetting(MainActivity.this,
				Constant.Settingfile, "startmode");
		if (mode != null) {
			if (mode.equals("view")) {
				try {
					btnstop.setVisibility(View.GONE);
					btnstart.setVisibility(View.GONE);
					btnmain.setVisibility(View.VISIBLE);
					txtwarning.setVisibility(View.GONE);
					//App.setInterval(1000000000);
				} catch (Exception e) {
				}
			} else if (mode.equals("patrol")) {
				try {
					btnstop.setVisibility(View.VISIBLE);
					btnstart.setVisibility(View.VISIBLE);
					btnmain.setVisibility(View.GONE);
					txtwarning.setVisibility(View.VISIBLE);
				} catch (Exception e) {
				}
			} else {
				ModeSelect();
			}
		} else {
			ModeSelect();
		}
		// δ������뼤�����
		if (isactive == 0) {
			Intent intent = new Intent(this, ActivationActivity.class);
			startActivity(intent);
		} else {
			doBegin();
			Log.v(Tag, App.getServerip());
		}
	}

	private void doBegin() {
		startDataPostThread();
		manager = (LocationManager) MainActivity.this
				.getSystemService(LOCATION_SERVICE);
		curprovider = LocationManager.GPS_PROVIDER;
		// SetListener();
		if (!manager.isProviderEnabled(curprovider)) {
			OpenTheGPS();
		}
	}

	private void setBasicInfo() {
		txtwarning = (TextView) findViewById(R.id.txtwarning);
		TelephonyMgr = (TelephonyManager) this
				.getSystemService(TELEPHONY_SERVICE);
		App.setAppContext(this);
		App.setIMEI(TelephonyMgr.getDeviceId());

		// �������ݿ⣬���ʧ���˳�����
		try {
			DataBaseHelper dbhelper = new DataBaseHelper(MainActivity.this,
					"sky");
			App.setDB(dbhelper);
		} catch (Exception e) {
			new AlertDialog.Builder(MainActivity.this)
					.setTitle("����")
					.setMessage("��������������Ҫ�˳�,����������,�����ʧ������ϵ����Ա!")
					.setPositiveButton("ȷ��",
							new DialogInterface.OnClickListener() {

								@Override
								public void onClick(DialogInterface dialog,
										int which) {
									ApplicationMgr.getInstance().exit();
								}
							})
					.setOnCancelListener(
							new DialogInterface.OnCancelListener() {

								@Override
								public void onCancel(DialogInterface arg0) {
									ApplicationMgr.getInstance().exit();
								}
							});
		}

		try {
			// ��ȡ���ݼ�¼���ID

			ContentValues[] cv = App.getDB().query("latandlon",
					new String[] { "ID" }, null, null, null, null, "ID desc");
			if (cv != null && cv[0].size() > 0) {
				latlngid = Integer.valueOf(cv[0].get("ID").toString());
			} else {
				latlngid = 1;
			}
			cv = App.getDB().query(
					"settings",
					new String[] { "interval", "serverip", "activation",
							"binding", "onplan", "isstart" });
			if (cv != null && cv[0].size() > 0) {
				App.setInterval(cv[0].getAsInteger("interval"));
				App.setServerip(cv[0].getAsString("serverip"));
				Constant.ServiceURL = cv[0].getAsString("serverip");
				isactive = Integer.valueOf(cv[0].get("activation").toString());
				isonplan = cv[0].getAsInteger("onplan") == 1 ? true : false;
				isbinding = cv[0].getAsInteger("binding") == 1 ? true : false;
				isstart = cv[0].getAsInteger("isstart") == 1 ? true : false;
			} else {
				App.setInterval(20000);
				App.setServerip("http://58.221.58.195:88");
			}
		} catch (Exception e) {
		}
		btnmain = (Button) findViewById(R.id.btnmain);

		btnmain.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				showDialog(1);
			}
		});
		btnstart = (Button) findViewById(R.id.btnstart);
		if (isonplan) {
			if (isstart) {
				SetListener();
				txtwarning.setText(R.string.onpatroltext);
				btnstart.setText(R.string.btnpause);
			} else {
				txtwarning.setText(R.string.onpausetext);
			}
		}
		btnstart.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				if (isstart) {
					btnstart.setText(R.string.btnstart);
					RemoveListener();
					stopDataPostThread();
					isstart = false;
					ContentValues content = new ContentValues();
					content.put("isstart", "0");
					App.getDB().update("settings", content);
					txtwarning.setText(R.string.onpausetext);
				} else {
					isstart = true;
					SetListener();
					startDataPostThread();
					btnstart.setText(R.string.btnpause);
					ContentValues content = new ContentValues();
					if (!isonplan) {
						content.put("onplan", "1");
						isonplan = true;
					}
					content.put("isstart", "1");
					App.getDB().update("settings", content);
					txtwarning.setText(R.string.onpatroltext);
				}
			}
		});
		btnstop = (Button) findViewById(R.id.btnstop);
		btnstop.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				new AlertDialog.Builder(MainActivity.this)
						.setTitle("��ʾ��Ϣ")
						.setMessage("ȷ��Ҫ���μƻ��������?")
						.setPositiveButton("ȷ��",
								new DialogInterface.OnClickListener() {
									@Override
									public void onClick(DialogInterface dialog,
											int which) {
										dialog.dismiss();
										doFinishWork();
									}
								})
						.setNegativeButton("ȡ��",
								new DialogInterface.OnClickListener() {
									@Override
									public void onClick(DialogInterface dialog,
											int which) {
										dialog.dismiss();
									}
								}).show();
			}
		});
		btnbind = (Button) findViewById(R.id.btnbind);
		if (isbinding)
			btnbind.setVisibility(8);
		else {
			btnbind.setOnClickListener(new OnClickListener() {
				@Override
				public void onClick(View v) {
					Bundle bundle = new Bundle();
					String code = String.valueOf((int) Math.floor(Math.random() * 10000));
					bundle.putString("code", code);
					Message msg = new Message();
					msg.what = 2;
					msg.setData(bundle);
					ControlThread.mHandler.sendMessage(msg);
					new AlertDialog.Builder(MainActivity.this)
							.setTitle("����Ϣ")
							.setMessage("�ѳɹ����Ͱ�����������Ϊ��" + code)
							.setPositiveButton("ȷ��",
									new DialogInterface.OnClickListener() {
										@Override
										public void onClick(
												DialogInterface dialog,
												int which) {
											dialog.dismiss();
										}
									}).show();
				}
			});
		}

		btnphoto = (Button) findViewById(R.id.btngetphoto);
		btnphoto.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				takePhotoes();
			}
		});

		// ���Ӷ�λ�ļ�ʱ��
		timer = new Timer(true);
		timer.schedule(task, 10000, 40000);

	}

	public void doFinishWork() {
		btnstart.setText(R.string.btnstart);
		RemoveListener();
		stopDataPostThread();
		isstart = false;

		pdfinish = new ProgressDialog(MainActivity.this);
		pdfinish.setCancelable(false);
		pdfinish.setMessage("�����ύ��������,���Ժ�...");
		pdfinish.show();

		new Thread() {
			@Override
			public void run() {
				Map<String, String> map = new HashMap<String, String>();
				map.put("IMEI", App.getIMEI());
				String result = WebService.exec(Constant.FINISH, map);
				Log.i(Tag, result);

				Bundle b = new Bundle();
				b.putString("result", result);
				Message msg = new Message();
				msg.what = 11;
				msg.setData(b);
				mainHandler.sendMessage(msg);

			}
		}.start();
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		menu.add(0, 1, 1, "����������").setIcon(android.R.drawable.ic_menu_edit);
		menu.add(0, 2, 2, "�л�ģʽ").setIcon(android.R.drawable.ic_menu_edit);
		// menu.add(0, 2, 2, "����°汾");
		return super.onCreateOptionsMenu(menu);
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		if (item.getItemId() == 1) {
			Intent intent = new Intent(this, ServerSettingActivity.class);
			startActivity(intent);
		} else if (item.getItemId() == 2) {
			ModeSelect();
		}
		return true;
	}

	private void startControlService() {
		Intent intent = new Intent(this, ControlService.class);
		startService(intent);
	}

	private void startDataPostThread() {
		if (datapostthread == null) {
			datapostthread = new DataPostThread();
			datapostthread.start();
		}
		Message msg = new Message();
		msg.what = 1;
		DataPostThread.DataPostThreadhandle.sendMessage(msg);
	}

	private void stopDataPostThread() {
		Message msg = new Message();
		msg.what = 2;
		DataPostThread.DataPostThreadhandle.sendMessage(msg);
	}

	private void doOnError(Exception e) {
		ContentValues content = new ContentValues();
		content.put("content", e.toString());
		App.getDB().insert("errorlog", content);
	}

	@SuppressLint("HandlerLeak")
	public Handler mainHandler = new Handler() { // ���߳���Ϣ����
		@Override
		public void handleMessage(Message msg) {
			switch (msg.what) {
			case 1: // ����GPSλ�ü���
				isstart = true;
				SetListener();
				break;
			case 2: // �ر�GPSλ�ü���
				RemoveListener();
				isstart = false;
				break;
			case 3: // ��������
				doBegin();
				break;
			case 4:
				ContentValues content = new ContentValues();
				content.put("binding", "1");
				App.getDB().update("settings", content);
				Log.i(Tag, "binding success");
				btnbind.setVisibility(8);
				break;
			case 5:
				if (isstart) {
					SetListener();
					startDataPostThread();
					txtwarning.setText(R.string.onpatroltext);
				} else {
					if (isonplan)
						txtwarning.setText(R.string.onpausetext);
				}
				break;
			case 6:
				RemoveListener();
				stopDataPostThread();
				txtwarning.setText("�������Ӳ�����, ������������!");
				break;
			case 7:
				if (isstart && !islocate) {
					SetListener();
					startDataPostThread();
				}
				break;
			case 8:
				Toast.makeText(MainActivity.this, "ͼƬ�ϴ��ɹ�", Toast.LENGTH_SHORT)
						.show();
				break;
			case 9:
				Toast.makeText(MainActivity.this, "�ϴ�ʧ��", Toast.LENGTH_SHORT)
						.show();
				break;
			case 10: // �޸Ķ�λ���
				RemoveListener();// 2012-07-09�޸�
				SetListener();// 2012-07-09�޸�
				int interval = msg.getData().getInt("interval");
				ContentValues c = new ContentValues();
				c.put("interval", interval);
				App.getDB().update("settings", c);
				break;
			case 11: // ��ɼƻ�
				if (pdfinish != null)
					pdfinish.dismiss();
				Bundle b = msg.getData();
				String result = b.getString("result");
				if (result.equals("true")) {
					Toast.makeText(MainActivity.this, "�ύ�ɹ�",
							Toast.LENGTH_SHORT).show();
					txtwarning.setText("����Ѳ�������!");
					ContentValues content1 = new ContentValues();
					if (isonplan) {
						content1.put("onplan", "0");
						isonplan = false;
					}
					content1.put("isstart", "0");
					App.getDB().update("settings", content1);

				} else {
					new AlertDialog.Builder(MainActivity.this)
							.setTitle("�ύʧ��!")
							.setIcon(android.R.drawable.ic_dialog_info)
							.setPositiveButton("����",
									new DialogInterface.OnClickListener() {
										@Override
										public void onClick(
												DialogInterface dialog,
												int which) {
											dialog.dismiss();
											doFinishWork();
										}
									})
							.setNegativeButton("ȡ��",
									new DialogInterface.OnClickListener() {
										@Override
										public void onClick(
												DialogInterface dialog,
												int which) {
											dialog.dismiss();
										}
									}).show();
				}

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
		RemoveListener();
		super.onDestroy();
	}

	@Override
	public void onResume() {
		super.onResume();
	}

	public static boolean isConnect(Context context) {
		if (context != null) {
			ConnectivityManager mConnectivityManager = (ConnectivityManager) context
					.getSystemService(Context.CONNECTIVITY_SERVICE);
			NetworkInfo mNetworkInfo = mConnectivityManager
					.getActiveNetworkInfo();
			if (mNetworkInfo != null && mNetworkInfo.isAvailable())
				return true;
			NetworkInfo mWiFiNetworkInfo = mConnectivityManager
					.getNetworkInfo(ConnectivityManager.TYPE_WIFI);
			if (mWiFiNetworkInfo != null && mWiFiNetworkInfo.isConnected())
				return true;
		}
		return false;
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

	// �����¼�������
	private final LocationListener locationListener = new LocationListener() {
		public void onLocationChanged(Location location) {
			if (location != null) {
				if (curlocation != null
						&& (curlocation.getLatitude() == location.getLatitude() && curlocation
								.getLongitude() == location.getLongitude())) {
					Log.i(Tag,
							"location is already exist:" + "lat:"
									+ Double.toString(location.getLatitude())
									+ ",lng:"
									+ Double.toString(location.getLongitude()));
					return;
				}
				curlocation = location;
				String latlng = "lat:"
						+ Double.toString(curlocation.getLatitude()) + ",lng:"
						+ Double.toString(curlocation.getLongitude());
				Log.v(Tag, "new location:" + latlng);
				islocate = true;
				if (immediately) {
					addNewLocation(false);
					immediately = false;
				RemoveListener();
				
				} else
					addNewLocation(true); // ���µ�λ�ò��뵽���ݿ�
			}
		}

		public void onProviderDisabled(String provider) {
			Log.i(Tag, "onProviderDisabled:");
			if (provider.equals(LocationManager.GPS_PROVIDER)) {
				Toast.makeText(MainActivity.this, "GPSδ����,�޷����ж�λ,���GPS!",
						Toast.LENGTH_SHORT).show();
				RemoveListener();
			}
		}

		public void onProviderEnabled(String provider) {
			Log.i(Tag, "onProviderEnabled:");
			if (provider.equals(LocationManager.GPS_PROVIDER)) {
				curprovider = LocationManager.GPS_PROVIDER;
				if (isstart)
					SetListener();
			}
		}

		public void onStatusChanged(String provider, int status, Bundle extras) {
			if (status == GpsStatus.GPS_EVENT_STOPPED) {
				Log.i(Tag, "gps status stoped");
			}
		}
	};

	@SuppressLint("SimpleDateFormat")
	public void addNewLocation(boolean Isauto) {
		ContentValues values = new ContentValues();
		String time = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
				.format(Calendar.getInstance().getTime());
		values.put("id", latlngid);
		values.put("lat", Double.toString(curlocation.getLatitude()));
		values.put("lon", Double.toString(curlocation.getLongitude()));
		values.put("locatetime", time);
		values.put("Isauto", Isauto ? 1 : 0);
		values.put("remark", remark);
		try {
			App.getDB().insert("latandlon", values);
			remark = "";
		} catch (Exception e) {
			doOnError(e);
		}
		latlngid++;
	}

	// ���д�GPS���ý���
	public void OpenTheGPS() {
		Toast.makeText(this, "�뿪��GPS��", Toast.LENGTH_SHORT).show();
		Intent intent = new Intent("android.settings.LOCATION_SOURCE_SETTINGS");
		startActivity(intent);

		/*
		 * boolean gpsEnabled = Settings.Secure.isLocationProviderEnabled(
		 * getContentResolver(), LocationManager.GPS_PROVIDER); if (gpsEnabled)
		 * { // �ر�GPS // Settings.Secure.setLocationProviderEnabled(
		 * getContentResolver(), // LocationManager.GPS_PROVIDER, false ); }
		 * else { // ��GPS
		 * Settings.Secure.setLocationProviderEnabled(getContentResolver(),
		 * LocationManager.GPS_PROVIDER, true); }
		 */
	}

	public void SetListener() {
		if (!onlistening && manager != null && locationListener != null
				&& curprovider != null) {
			manager.requestLocationUpdates(curprovider, App.getInterval(), 0,
					locationListener);
			curlocation = manager.getLastKnownLocation(curprovider);
			Log.i(Tag, (isstart ? "isstart:true" : "isstart:false")
					+ " onlistening:" + onlistening);
			onlistening = true;
		}
	}

	public void RemoveListener() {
		if (manager != null && locationListener != null) {
			manager.removeUpdates(locationListener);
			Log.i(Tag, "listener removed" + " onlistening:" + onlistening);
			onlistening = false;
		}
	}

	TimerTask task = new TimerTask() {
		public void run() {
			Message message = new Message();
			message.what = 7;
			if (mainHandler != null)
				mainHandler.sendMessage(message);
		}
	};

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
						RemoveListener();
						immediately = true;
//						if (!isstart) {
//							btnstart.setText(R.string.btnpause);
//							isstart = true;
//							ContentValues content = new ContentValues();
//							if (!isonplan) {
//								content.put("onplan", "1");
//							}
//							content.put("isstart", "1");
//							App.getDB().update("settings", content);
//							txtwarning.setText(R.string.onpatroltext);
//						}
						SetListener();
						startDataPostThread();
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

	private void ModeSelect() {
		Intent i = new Intent(MainActivity.this, WelComeActivity.class);
		startActivity(i);
	}

}
