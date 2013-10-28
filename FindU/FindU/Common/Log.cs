using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Log
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">错误日志文件所放位置</param>
        /// <param name="error"></param>
        public static void AddError(string path,string error,string IP)
        {
            //独占方式，因为文件只能由一个进程写入
            System.IO.StreamWriter writer = null;
            try
            {
                //写入日志
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string filename = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                //如果目录不存在则创建
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                System.IO.FileInfo file = new System.IO.FileInfo(path + "\\" + filename);
                //文件不存在就创建，true表示追加
                writer = new System.IO.StreamWriter(file.FullName, true);
                writer.WriteLine("用户IP：" + IP);
                writer.WriteLine("时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                writer.WriteLine(error);
                writer.WriteLine("--------------------------------------------------------------------------------------");
                writer.WriteLine("");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                }
            }
        }
    }
}
