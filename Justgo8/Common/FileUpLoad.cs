using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Configuration;

namespace Common
{
    /// <summary>
    /// 上传文件操作类
    /// </summary>
    public class FileUpLoad
    {
        /// <summary>
        /// 文件上传（成功返回文件url，失败返回 fail，超过指定大小返回 over）
        /// </summary>
        /// <param name="flies">上传文件集合</param>
        /// <param name="url">旧图片Url(删除旧图片必填)</param>
        /// <returns>图片Url</returns>
        public static string Upload(HttpFileCollection flies, string url = "")
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "upload/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            int fileSize = Convert.ToInt32(ConfigurationManager.AppSettings["fileSize"]);
            foreach (string upload in flies)
            {
                if (flies[upload] != null && flies[upload].ContentLength > 0)
                {
                    double size = flies[upload].ContentLength; //限制上传文件的大小
                    if (size / 1024 / 1024 >= fileSize)
                        return "over";

                    string filesupport = ".jpeg,.jpg,.gif,.png,.bmp";
                    string extension = Path.GetExtension(flies[upload].FileName);
                    int ifcheck = filesupport.IndexOf(extension.ToLower());
                    if (ifcheck > 0)
                    {
                        string filename = Guid.NewGuid().ToString() + extension;
                        string filepath = Path.Combine(path, filename); //文件本地地址
                        flies[upload].SaveAs(filepath);
                        return "/upload/" + filename;
                    }
                }
            }
            return url;
        }
    }
}