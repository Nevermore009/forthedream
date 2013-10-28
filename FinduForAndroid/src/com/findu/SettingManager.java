package com.findu;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Properties;

import android.annotation.SuppressLint;
import android.content.Context;
import android.util.Log;

public class SettingManager {

	public static void addSetting(Context context, String fileName, String key,
			String value) {
		try {
			Properties properties = readFile(context, fileName);
			properties.setProperty(key, value);
			writeFile(context, fileName, properties);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	}

	@SuppressLint("WorldWriteableFiles")
	public static void writeFile(Context context, String fileName,
			Properties properties) throws IOException {
		try {
			FileOutputStream fout = context.openFileOutput(fileName,
					Context.MODE_WORLD_WRITEABLE);
			properties.store(fout, "");
		} catch (FileNotFoundException e) {
			Log.i("FileManager", "writefile-->" + e.toString());
		} catch (IOException e) {
			Log.i("FileManager", "writefile-->" + e.toString());
		} catch (Exception e) {
			Log.i("FileManager", "writefile-->" + e.toString());
		}
	}

	// 璇绘暟鎹�
	public static Properties readFile(Context context, String fileName)
			throws IOException {
		Properties properties = new Properties();
		try {
			FileInputStream fin = context.openFileInput(fileName);
			properties.load(fin);
		} catch (Exception e) {
			Log.i("FileManager", "readFile-->" + e.toString());
		}
		return properties;
	}

	public static String getSetting(Context context, String fileName, String key) {
		Properties properties;
		try {
			properties = readFile(context, fileName);
			return properties.getProperty(key);
		} catch (IOException e) {
			Log.i("FileManager", "getSetting-->" + e.toString());
		}
		return null;
	}
}
