using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data;


namespace BLL
{
    /// <summary>
    /// 与终端通信
    /// </summary>
    public class Communicate
    {
        private static IPEndPoint ipLocalPoint;         //本地IP和端口号
        private static EndPoint RemotePoint;           //远程网络地址标识
        private static Socket mySocket;                    //Socket
        private static bool RunningFlag = false;      //接收线程运行标志
        private static Thread SendThread;               //消息发送线程
        private static int MSGID = 1;
        private static CRC32 Crc32 = new CRC32();  //

        private static Equipment EquipmentBLL = new Equipment();

        #region 发送消息处理
        //增加发送编号
        private static String GetMsgID()
        {
            if (MSGID == 10000)
                MSGID = 0;
            return (MSGID++).ToString("0000");
        }

        public static void DoMsg()
        {
            while (true)
            {
                lock (Controller.MessageList.SyncRoot)
                {
                    int listsize = Controller.MessageList.Count;
                    for (int i = 0; i < listsize; i++)
                    {
                        Message m = (Message)Controller.MessageList[i];
                        if (m.Count > 2)
                        {
                            m.Fail(m.infoID, null);
                            Controller.MessageList.RemoveAt(i);
                            i--;
                            listsize--;
                            continue;
                        }
                    }
                }
                lock (Controller.MessageList.SyncRoot)
                {
                    foreach (Message Msg in Controller.MessageList)
                    {
                        double x = (new TimeSpan((DateTime.Now - Msg.SendTime).Ticks)).TotalSeconds;
                        if (x < 3)
                            continue;
                        string id = GetMsgID();
                        string identifier = int.Parse(Msg.infoID).ToString("0000");
                        DataTable dt = EquipmentBLL.GetIPByID(Msg.infoID);
                        string ip = dt.Rows[0][0].ToString();
                        int port = int.Parse(dt.Rows[0][1].ToString());
                        string content;
                        switch (Msg.Command)
                        {
                            case CommandType.ElectricityOn:
                                content = string.Format("&BGSJZDNGLXTA{0}#{1}", id, identifier);
                                break;
                            case CommandType.ElectricityOff:
                                content = string.Format("&BGSJZDNGLXTH{0}#{1}", id, identifier);
                                break;
                            case CommandType.GetTemperature:
                                content = string.Format("&BGSJZDNGLXTG{0}#{1}", id, identifier);
                                break;
                            case CommandType.ReadElectricity:
                                content = string.Format("&BGSJZDNGLXTB{0}#{1}", id, identifier);
                                break;
                            case CommandType.ReadState:
                                content = string.Format("&BGSJZDNGLXTC{0}#{1}", id, identifier);
                                break;
                            case CommandType.SetClientIP:
                                string clientip = Msg.Content.Replace('|', '.').Replace(" ", "");
                                content = string.Format("&BGSJZDNGLXTD{0}{1}${2}#", id, identifier, clientip);
                                break;
                            case CommandType.SetServerIP:
                                string localip = Msg.Content;
                                content = string.Format("&BGSJZDNGLXTE{0}${1}#{2}", id, localip, identifier);
                                break;
                            case CommandType.SetTemperature:
                                string temperate = Msg.Content;
                                content = string.Format("&BGSJZDNGLXTF{0}${1}#{2}", id, temperate, identifier);
                                break;
                            case CommandType.ResetMeter:
                                content = string.Format("&BGSJZDNGLXTI{0}#{1}", id, identifier);
                                break;
                            // case CommandType.UpdateTemperature:
                            //    string cen
                            default:
                                continue;
                        }
                        string CrcCheck = Crc32.GetCRC32Str(content).ToString("X8");
                        SendMsg(ip, port, content + CrcCheck);
                        Msg.ID = id;
                        Msg.SendTime = DateTime.Now;
                        Msg.Count++;
                    }
                }
                Thread.Sleep(200);
            }
        }

        #endregion

        #region 启用通信模块
        public static void Start()
        {
            BindSocket();
            ReceiveMsg();
            SendThread = new Thread(new ThreadStart(DoMsg));
            SendThread.Start();
            uint IOC_IN = 0x80000000;
            uint IOC_VENDOR = 0x18000000;
            uint SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12;
            mySocket.IOControl((int)SIO_UDP_CONNRESET, new byte[] { Convert.ToByte(false) }, null);

        }
        #endregion

        #region 停止通信模块
        public static void Stop()
        {
            RunningFlag = false;
            mySocket.Close();
            SendThread.Abort();
        }
        #endregion

        #region 发送消息
        private static void SendMsg(String Ip, int Port, string Msg)
        {
            try
            {
                RemotePoint = SetRemotePoint(Ip, Port);
                byte[] data = Encoding.Default.GetBytes(Msg);
                mySocket.SendTo(data, data.Length, SocketFlags.None, RemotePoint);
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region 获得本机局域网IP地址
        private static String GetLocalIP()
        {
            IPAddress[] AddressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
            if (AddressList.Length < 1)
            {
                return "";
            }

            else if (AddressList.Length >= 1)
            {
                // string aaa = AddressList[0].ToString();
                return AddressList[0].ToString(); //一般为win7或更高版本
            }
            else
            {
                return AddressList[1].ToString();//xp下取此值
            }
        }
        #endregion

        #region 绑定套接字
        private static void BindSocket()
        {
            ipLocalPoint = new IPEndPoint(IPAddress.Parse(GetLocalIP()), 51888);
            mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            mySocket.Bind(ipLocalPoint);
        }
        #endregion

        #region 绑定远程IP和端口
        private static EndPoint SetRemotePoint(string Ip, int endport)
        {
            int Port = endport;
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(Ip), Port);
            RemotePoint = (EndPoint)(ipep);
            return RemotePoint;
        }
        #endregion

        #region 用线程接收消息
        private static void ReceiveMsg()
        {
            RunningFlag = true;
            Thread thread = new Thread(new ThreadStart(ReceiveHandle));
            thread.Start();
        }
        #endregion

        #region 处理接收的消息
        private static void ReceiveHandle()
        {
            //接收数据处理线程
            string msg;
            byte[] data = new byte[1024];
            while (RunningFlag)
            {
                if (mySocket == null || mySocket.Available < 1)
                {
                    Thread.Sleep(200);
                    continue;
                }
                //跨线程调用控件
                int rlen = mySocket.ReceiveFrom(data, ref RemotePoint);
                msg = Encoding.Default.GetString(data, 0, rlen);
                if (msg.Length < 8)
                {
                    return;
                }
                else
                {
                    string crcCode = msg.Substring(msg.Length - 8, 8);
                    string msgCode = msg.Substring(0, msg.Length - 8);
                    string crcCheck = Crc32.GetCRC32Str(msgCode).ToString("X8").ToLower();
                    if (crcCheck != crcCode.ToString().ToLower())
                    {
                        return;
                    }
                }
                HandleMsg(msg);
            }
        }

        private static string TargetID;
        private static string TargetTemperature;

        private static void HandleMsg(string msg)
        {
            if (msg.Length<12)
            {
                return;
            }
            else
            {
                if (msg.Substring(0, 12).ToString() != "&BGSJZDNGLXT")
                    return;                
            }
            string ID = msg.Substring(13, 4);
            Message Msg = FindMessageByID(ID);
            if (Msg == null)       //被动接收传来的温度
            {
                try
                {
                    string x = msg.Substring(16, 4);
                    TargetID = int.Parse(x).ToString();
                    TargetTemperature = int.Parse(msg.Substring(13, 2)).ToString();
                    DrivingMessage();
                }
                catch (Exception)
                {
                    return;
                }
                
                return;
            } 
            switch (Msg.Command)
            {
                case CommandType.ElectricityOn:
                    Msg.Success(Msg.infoID, null);
                    break;
                case CommandType.ElectricityOff:
                    Msg.Success(Msg.infoID, null);
                    break;
                case CommandType.GetTemperature:
                    string Temp = msg.Substring(17, 2);
                    Msg.Success(Msg.infoID, Temp);
                    break;
                case CommandType.ReadElectricity:
                    string Ele = msg.Substring(17, 7);
                    Msg.Success(Msg.infoID, Ele);
                    break;
                case CommandType.ReadState:
                    string sta = msg.Substring(17, 1);
                    Msg.Success(Msg.infoID, sta);
                    break;
                case CommandType.SetClientIP:
                    Msg.Success(Msg.infoID, Msg.Content);//将IP地址信息返回给回调函数
                    break;
                case CommandType.SetServerIP:
                    Msg.Success(Msg.infoID, null);
                    break;
                case CommandType.SetTemperature:
                    Msg.Success(Msg.infoID, null);
                    break;
                case CommandType.ResetMeter:
                    string metervalue = msg.Substring(17, 7);
                    Msg.Success(Msg.infoID, metervalue);
                    break;
                default:                    
                    return;
            }
            Controller.RemoveMessage(Msg);
        }

        private static Message FindMessageByID(string id)
        {
            foreach (Message Msg in Controller.MessageList)
            {
                if (Msg.ID == id)
                {
                    return Msg;
                }
            }
            return null;
        }

        public static string DrivingMessage()
        {
            return (TargetID +"."+ TargetTemperature);
        }
        #endregion


    }
}
