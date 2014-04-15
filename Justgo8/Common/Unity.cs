using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Data;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.Globalization;
using System.IO;

namespace Common
{
    public class Unity
    {
        /// <summary>
        /// 转换日期格式
        /// </summary>
        /// <returns></returns>
        public static DateTime FormatDate(DateTime dtime)
        {
            string dt = dtime.ToString("yyyy/MM/dd HH:mm:ss.ffff", DateTimeFormatInfo.InvariantInfo);
            DateTime date = DateTime.Parse(dt);
            return date;
        }

        /// <summary>
        /// 设置程序开机启动
        /// 或取消开机启动
        /// </summary>
        /// <param name="started">设置开机启动，或者取消开机启动</param>
        /// <param name="exeName">注册表中程序的名字</param>
        /// <param name="path">开机启动的程序路径</param>
        /// <returns>开启或停用是否成功</returns>
        public static bool runWhenStart(bool started, string exeName, string path)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//打开注册表子项
            if (key == null)//如果该项不存在的话，则创建该子项
            {
                key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            }
            if (started == true)
            {
                try
                {
                    key.SetValue(exeName, path);//设置为开机启动
                    key.Close();
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    key.DeleteValue(exeName);//取消开机启动
                    key.Close();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 实现图片黑白效果
        /// </summary>
        public static Bitmap ChangePhoto(Image old)
        {
            int Height = old.Height;
            int Width = old.Width;
            Bitmap newBitmap = new Bitmap(Width, Height);
            Bitmap oldBitmap = new Bitmap(old);
            Color pixel;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    pixel = oldBitmap.GetPixel(x, y);
                    int r, g, b, Result = 0;
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    //实例程序以加权平均值法产生黑白图像
                    int iType = 2;
                    switch (iType)
                    {
                        case 0://平均值法
                            Result = ((r + g + b) / 3);
                            break;
                        case 1://最大值法
                            Result = r > g ? r : g;
                            Result = Result > b ? Result : b;
                            break;
                        case 2://加权平均值法
                            Result = ((int)(0.7 * r) + (int)(0.2 * g) + (int)(0.1 * b));
                            break;
                    }
                    newBitmap.SetPixel(x, y, Color.FromArgb(Result, Result, Result));
                }
            }
            return newBitmap;
        }

        /// <summary>
        /// 序列化DataTable
        /// </summary>
        /// <param name="pDt">包含数据的DataTable</param>
        /// <returns>序列化的DataTable</returns>
        public static string SerializeDataTableXml(DataTable pDt)
        {
            // 序列化DataTable
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);
            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
            serializer.Serialize(writer, pDt);
            writer.Close();
            return sb.ToString();
        }

        /// <summary>
        /// 反序列化DataTable
        /// </summary>
        /// <param name="pXml">序列化的DataTable</param>
        /// <returns>DataTable</returns> 
        public DataTable DeserializeDataTable(string pXml)
        {
            StringReader strReader = new StringReader(pXml);
            XmlReader xmlReader = XmlReader.Create(strReader);
            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
            DataTable dt = serializer.Deserialize(xmlReader) as DataTable;
            return dt; 
        }
    }
}
