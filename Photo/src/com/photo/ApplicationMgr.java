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

	// 单例模式中获取唯一的ExitApplication 实例
	public static ApplicationMgr getInstance() {
		if (null == instance) {
			instance = new ApplicationMgr();
		}
		return instance;
	}

	// 添加Activity 到容器中
	public void addActivity(Activity activity) {
		activityList.add(activity);
	}

	// 遍历所有Activity 并finish
	public void exit() {
		for (Activity activity : activityList) {
			activity.finish();
		}		
		System.exit(0);
	}

}