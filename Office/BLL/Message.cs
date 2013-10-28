using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Message
    {
        public string ID { set; get; }
        public string infoID
        {
            set;
            get;
        }
        public WorkDone Success
        {
            set;
            get;
        }
        public WorkDone Fail
        {
            set;
            get;
        }
        public CommandType Command
        {
            get;
            set;
        }
        public String Content
        {
            get;
            set;
        }
        public DateTime SendTime
        { get; set; }

        /// <summary>
        /// 该消息发送的次数
        /// </summary>
        public int Count
        {
            get;
            set;
        }   
    }

    public enum CommandType
    {
        ElectricityOn,
        ReadElectricity,
        ReadState,
        SetClientIP,
        SetServerIP,
        SetTemperature,
        GetTemperature,
        ElectricityOff,
        ResetMeter
    }
}
