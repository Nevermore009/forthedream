package com.findu;

import android.content.Context;

public class App {
	private static String IMEI;
	private static Context appContext;
	private static DataBaseHelper DB;
	private static int interval;
	private static String serverip;
	
	public App() {
	}

	public static String getIMEI() {
		return IMEI;
	}

	public static void setIMEI(String iMEI) {
		IMEI = iMEI;
	}

	public static Context getAppContext() {
		return appContext;
	}

	public static void setAppContext(Context appContext) {
		App.appContext = appContext;
	}

	public static DataBaseHelper getDB() {
		return DB;
	}

	public static void setDB(DataBaseHelper db) {
		App.DB = db;
	}

	public static int getInterval() {
		return interval;
	}

	public static void setInterval(int interval) {
		App.interval = interval;
	}

	public static String getServerip() {
		return serverip;
	}

	public static void setServerip(String serverip) {
		App.serverip = serverip;
	}
	

}
