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
        /// ��һ���ļ����͵������������������ļ��ķ��ʵ�ַ
        /// a-action ����  t-type ���ͣ����洢Ŀ¼ n-name�ļ����ơ�
        /// ���ò�����s-save�������  d-deleteɾ������ u-update�����ļ����� l-look��ȡ�ļ����ļ����б�
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="del">�Ƿ�ɾ�������ļ�</param>
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
                ErrorLog.AddErrorLog("�ϴ�ͼƬʧ�ܣ�" + ex);
                return "fail";
            }
        }
        /// <summary>
        /// ��Զ�̷�������ɾ��һ���ļ�
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="type">�ļ������ĸ���Ŀ������磨Ӫҵִ�ա����ͼƬ�ȣ�</param>
        /// <returns></returns>
        public static string DelFile(string fname,string type)
        {
            WebClient wc = new WebClient();
            return Encoding.UTF8.GetString(wc.DownloadData(string.Format("{0}?a=d&t={1}&n={2}", ConfigurationManager.AppSettings["publicSite"], type, fname)));
        }
        /// <summary>
        /// ��ȡĿ¼�е��ļ���Ϣ��
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
