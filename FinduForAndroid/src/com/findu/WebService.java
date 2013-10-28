package com.findu;

import java.io.IOException;
import java.util.Iterator;
import java.util.Map;
import java.util.Set;
import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;
import org.xmlpull.v1.XmlPullParserException;

import android.util.Log;

public class WebService {
	public static String exec(String Method, Map<String, String> map) {
		String uri = Constant.ServiceURL + Constant.ServiceName;
		Log.i("WebService",uri);
		HttpTransportSE http = new HttpTransportSE(uri);
		http.debug = true;
		SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
				SoapEnvelope.VER11);
		SoapObject object = new SoapObject(Constant.NAME_SPACE, Method);
		Set<String> set = map.keySet();
		Iterator<String> it = set.iterator();
		while (it.hasNext()) {
			String str = it.next();
			object.addProperty(str, map.get(str));
		}

		envelope.bodyOut = object;
		envelope.dotNet = true;
		envelope.setOutputSoapObject(object);
		String str = "";
		try {
			http.call(Constant.NAME_SPACE + Method, envelope);
			str = envelope.getResponse().toString();
		} catch (IOException e) {
			e.printStackTrace();
		} catch (XmlPullParserException e) {
			e.printStackTrace();
		}
		return str;
	}
}
