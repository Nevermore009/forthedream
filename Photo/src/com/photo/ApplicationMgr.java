package com.photo;

import java.util.LinkedList;
import java.util.List;

import android.app.Activity;
import android.app.Application;

public class ApplicationMgr extends Application {

	public static List<Activity> activityList = new LinkedList<Activity>();

	private static ApplicationMgr instance;

	private ApplicationMgr() {
	}

	// ����ģʽ�л�ȡΨһ��ExitApplication ʵ��
	public static ApplicationMgr getInstance() {
		if (null == instance) {
			instance = new ApplicationMgr();
		}
		return instance;
	}

	// ���Activity ��������
	public void addActivity(Activity activity) {
		activityList.add(activity);
	}

	// ��������Activity ��finish
	public void exit() {
		for (Activity activity : activityList) {
			activity.finish();
		}		
		System.exit(0);
	}

}