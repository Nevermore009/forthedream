using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Configuration;

namespace Common
{
    public class RemoteFileManage
    {
        /// <summary>
        /// 将一个文件发送到公共服务器并返回文件的访问地址
        /// a-action 操作  t-type 类型，即存储目录 n-name文件名称。
        /// 可用操作：s-save保存操作  d-delete删除操作 u-update更新文件操作 l-look获取文件及文件夹列表
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="del">是否删除本地文件</param>
        public static string UpFile(string filePath,string action,string type,string saveName,bool del)
        {
            try
            {

                File.ReadAllBytes(filePath);
                WebClient wc = new WebClient();
                string re = Encoding.UTF8.GetString(wc.UploadFile(string.Format("{0}?a={1}&t={2}&n={3}", ConfigurationManager.AppSettings["publicSite"]+"/img.aspx", action, type, saveName), filePath));
                if (del)
                {
                    File.SetAttributes(filePath, FileAttributes.Normal);
                    File.Delete(filePath);
                }
                return re;
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog("上传图片失败：" + ex);
                return "fail";
            }
        }
        /// <summary>
        /// 从远程服务器上删除一个文件
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="type">文件属于哪个栏目下面的如（营业执照、广告图片等）</param>
        /// <returns></returns>
        public static string DelFile(string fname,string type)
        {
            WebClient wc = new WebClient();
            return Encoding.UTF8.GetString(wc.DownloadData(string.Format("{0}?a=d&t={1}&n={2}", ConfigurationManager.AppSettings["publicSite"], type, fname)));
        }
        /// <summary>
        /// 获取目录中的文件信息。
        /// </summary>
        /// <param name="directyName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetDirectImfor(string directyName, string type)
        {
            WebClient wc = new WebClient();
            return Encoding.UTF8.GetString(wc.DownloadData(string.Format("{0}?a=l&t={1}&n={2}", ConfigurationManager.AppSettings["publicSite"], type, directyName)));
        }
    }
}
