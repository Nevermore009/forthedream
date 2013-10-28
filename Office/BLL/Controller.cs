using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BLL
{
    /// <summary>
    /// 终端回复消息后回调委托
    /// </summary>
    /// <param name="infoID">设备ID</param>
    /// <param name="agr"></param>
    public delegate void WorkDone(string infoID, object agr);

    /// <summary>
    /// 终端控制类
    /// </summary>
    public class Controller
    {
        public static ArrayList MessageList = new ArrayList();

        public static void AddMessage(Message msg)
        {
            lock (MessageList.SyncRoot)
            {
                MessageList.Add(msg);
            }
        }

        public static void RemoveMessage(Message msg)
        {
            lock (MessageList.SyncRoot)
            {
                MessageList.Remove(msg);
            }
        }

        public static void SetOn(string infoid, WorkDone success, WorkDone failed)
        {
            Message msg = new Message() { infoID = infoid, Success = success, Fail = failed, Command = CommandType.ElectricityOn };
            AddMessage(msg);
             //success(infoid, true);
        }
        public static void SetOff(string infoid, WorkDone success, WorkDone failed)
        {
            Message msg = new Message() { infoID = infoid, Success = success, Fail = failed, Command = CommandType.ElectricityOff };
            AddMessage(msg);
            ReadElectricity(infoid, (string id, object e) => { new Electricity().Add(id, float.Parse((e.ToString()))); }, (string s, object e) => { });
           // success(infoid, true);
        }
        public static void ReadElectricity(string infoid, WorkDone success, WorkDone failed)
        {
            Message msg = new Message() { infoID = infoid, Success = success, Fail = failed, Command = CommandType.ReadElectricity };
            AddMessage(msg);
            // success(infoid, true);
        }
        public static void ReadState(string infoid, WorkDone success, WorkDone failed)
        {
            Message msg = new Message() { infoID = infoid, Success = success, Fail = failed, Command = CommandType.ReadState };
            AddMessage(msg);
            // success(infoid, true);
        }
        public static void SetClientIP(string infoid, WorkDone success, WorkDone failed, string ipAddress,string duankou, string netMask, string gateWay, string macAddress)
        {
            string content = string.Format("{0}|{1}|{2}|{3}|{4}|", ipAddress, duankou,netMask, gateWay, macAddress);
            Message msg = new Message() { infoID = infoid, Success = success, Fail = failed, Command = CommandType.SetClientIP, Content = content };
            AddMessage(msg);
            //success(infoid, content);
        }
        public static void SetClientIP(string infoid, WorkDone success, WorkDone failed, string ip)
        {
            Message msg = new Message() { infoID = infoid, Success = success, Fail = failed, Command = CommandType.SetClientIP, Content = ip };
            AddMessage(msg);
            //success(infoid, true);
        }
        public static void SetServerIP(string infoid, WorkDone success, WorkDone failed, string ip)
        {
            ip = ip + ".";
            Message msg = new Message() { infoID = infoid, Success = success, Fail = failed, Command = CommandType.SetServerIP, Content = ip };
            AddMessage(msg);
            //success(infoid, true);
        }
        public static void SetTemperate(string infoid, WorkDone success, WorkDone failed, string temperate)
        {
            Message msg = new Message() { infoID = infoid, Success = success, Fail = failed, Command = CommandType.SetTemperature, Content = temperate };
            AddMessage(msg);
            //success(infoid, true);
        }
        public static void GetTemperate(string infoid, WorkDone success, WorkDone failed)
        {
            Message msg = new Message() { infoID = infoid, Success = success, Fail = failed, Command = CommandType.GetTemperature };
            AddMessage(msg);
            //success(infoid,true);
        }

        public static void ResetMeter(string infoid, WorkDone success, WorkDone failed)
        {
            Message msg = new Message() { infoID = infoid, Success = success, Fail = failed, Command = CommandType.ResetMeter };
            AddMessage(msg);
            //success(infoid, true);
        }
    }
}
