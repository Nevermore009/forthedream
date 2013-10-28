package com.findu;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteDatabase.CursorFactory;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

public class DataBaseHelper extends SQLiteOpenHelper {

	private static final int Version = 1;
	private static final String DB_NAME = "sky";
	private final static byte[] dbLock = new byte[0];

	public DataBaseHelper(Context context, String name, CursorFactory factory,
			int version) {
		super(context, name, factory, version);
		SQLiteDatabase db = getWritableDatabase();
		db.close();
	}

	public DataBaseHelper(Context context, String name, int version) {
		this(context, name, null, version);
	}

	public DataBaseHelper(Context context, String name) {
		this(context, name, null, Version);
	}

	public DataBaseHelper(Context context) {
		this(context, DB_NAME, null, Version);
	}

	@Override
	public void onCreate(SQLiteDatabase db) {
		// isauto是否自动定位，0false,1true
		db.execSQL("create table latandlon(ID integer primary key,Lat varchar(50),Lon varchar(50),Locatetime varchar(100),Isauto integer,Remark varchar(500))");
		db.execSQL("create table errorlog(ID integer primary key,content varchar(256), logtime TIMESTAMP default (datetime('now', 'localtime')))");
		// interval定位间隔,activation是否激活软件,binding是否已绑定到服务器，onplan是否在执行计划
		db.execSQL("create table settings(interval integer,serverip varchar(50),activation integer,binding interger,onplan interger,isstart interger)");
		ContentValues values = new ContentValues();
		values.put("interval", 20000);
		// values.put("serverip", "http://211.143.0.85:99/UIWeb");
		// values.put("serverip", "http://10.0.2.2:1051/UIWeb");
		// values.put("serverip", "http://218.76.27.114:81");
		values.put("serverip", "http://58.221.58.195:88");
		values.put("activation", 1);
		values.put("binding", 0);
		values.put("onplan", 0);
		values.put("isstart", 0);
		db.insert("settings", null, values);
		Log.v("DataBaseHelper", "database created");
	}

	@Override
	public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
	}

	public long insert(String tableName, ContentValues values) {
		long rowID;
		synchronized (dbLock) {
			SQLiteDatabase db = getWritableDatabase();
			rowID = db.insert(tableName, null, values);
			db.close();
		}
		return rowID;
	}

	public int update(String table, ContentValues values, String whereClause,
			String[] whereArgs) {
		int effectRowCount;
		synchronized (dbLock) {
			SQLiteDatabase db = getWritableDatabase();
			effectRowCount = db.update(table, values, whereClause, whereArgs);
			db.close();
		}
		return effectRowCount;
	}

	public int update(String table, ContentValues values) {
		return update(table, values, null, null);
	}

	public int delete(String table, String whereClause, String[] whereArgs) {
		int effectRowCount;
		synchronized (dbLock) {
			SQLiteDatabase db = getWritableDatabase();
			effectRowCount = db.delete(table, whereClause, whereArgs);
			db.close();
		}
		return effectRowCount;
	}

	public ContentValues[] query(String tableName, String[] columns,
			String selection, String[] selectionArgs, String groupBy,
			String having, String orderBy) {
		ContentValues[] cv = null;
		synchronized (dbLock) {
			SQLiteDatabase db = getReadableDatabase();
			Cursor c = db.query(tableName, columns, selection, selectionArgs,
					groupBy, having, orderBy);
			if (c.getCount() > 0) {
				cv = new ContentValues[c.getCount()];
				for (int k = 0; c.moveToNext(); k++) {
					cv[k] = new ContentValues();
					for (int i = 0; i < columns.length; i++) {
						cv[k].put(columns[i],
								c.getString(c.getColumnIndex(columns[i])));
					}
				}
			}
			c.close();
			db.close();
		}
		return cv;
	}

	public ContentValues[] query(String tableName, String[] columns) {
		return query(tableName, columns, null, null, null, null, null);
	}
}
