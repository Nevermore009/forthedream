using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.IO;

namespace Common
{
    /// <summary>
    ///YoukuVideo 的摘要说明
    /// </summary>
    public class YoukuVideo
    {
        public YoukuVideo()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 根据视频种子，解析优酷Youku无广告视频播放
        /// </summary>
        /// <param name="url">Youku视频路径</param>
        /// <returns>返回无广告的Youku视频地址</returns>
        public string GetYoukuVideoUrl(string url)
        {
            string FlvPath = "";
            string tmp = "";
            int FindStart = 0;
            int FindFlv = 1;
            int PathCount = 0;

            string _videoUrl = url;
            if (_videoUrl.Length > 0)
            {
                string UrlStr = _videoUrl.ToString();
                if (UrlStr.IndexOf("http://player.youku.com/player.php/sid/", 0) >= 0)//如果找到标识字符串
                {
                    int sidStart = 0;
                    string Fid = "";

                    try
                    {
                        sidStart = UrlStr.IndexOf("sid/", 0);
                        Fid = UrlStr.Substring(sidStart + 4, 13);
                        //string strUrl = "http://www.flvcd.com/parse.php?flag=&format=&kw=http%3A%2F%2Fv.youku.com%2Fv_show%2Fid_XMjUxNDk3Mjky";
                        //创建请求
                        string strUrl = "http://www.flvcd.com/parse.php?flag=&format=&kw=http%3A%2F%2Fv.youku.com%2Fv_show%2Fid_" + Fid;

                        WebRequest CmcnUrl = WebRequest.Create(strUrl);
                        CmcnUrl.UseDefaultCredentials = false;
                        CmcnUrl.Timeout = 5000;     //过期时间
                        WebResponse WebRe = CmcnUrl.GetResponse();
                        HttpWebResponse res = (HttpWebResponse)CmcnUrl.GetResponse();
                        //判断当前请求是否成功
                        {
                            Stream strCmcn = WebRe.GetResponseStream();
                            StreamReader stRCmcnHtml = new StreamReader(strCmcn);
                            string tmp_path = stRCmcnHtml.ReadToEnd();
                            strCmcn.Close();
                            WebRe.Close();
                            stRCmcnHtml.Close();
                            //将数据关闭
                            //2012-8-16修改的解析代码，先找到 "<form action="get_m3u.php" method="post" name="m3uForm">" 这个标志后，再进行解码的定位。
                            FindFlv = tmp_path.IndexOf("<form action=\"get_m3u.php\" method=\"post\" name=\"m3uForm\">", FindStart);   //先找到标志，然后从标志后进行解码

                            if (FindFlv >= 0)
                            {
                                FindStart = FindFlv;//
                            }

                            //以下为原始代码段。
                            while (FindFlv >= 0)
                            {
                                // FindFlv = tmp_path.IndexOf("<U>http://f.youku.com/player/getFlvPath/sid", FindStart);   //原代码，此处处理相关数据，解析成功，返回临时的真实地址
                                FindFlv = tmp_path.IndexOf("http://f.youku.com/player/getFlvPath/sid", FindStart);   //2012-8-16修改，此处处理相关数据，解析成功，返回临时的真实地址
                                //  FlvStart = -1;  //假设失败，测试用的

                                if (FindFlv >= 0)
                                {
                                    //tmp = tmp_path.Substring(FindFlv + 3, 154);原代码
                                    tmp = tmp_path.Substring(FindFlv, 154);  //2012-8-16修改
                                    tmp = tmp + ".flv";
                                    tmp.Trim();
                                    PathCount += 1; //加一个
                                    FlvPath += tmp;
                                    FindStart = FindFlv + 154;
                                    //  GetFlag.Value = "1";                               //返回成功标志
                                    // TxtFlvPath.Value = FlvPath;                       //返回真实的地址；
                                }
                            }
                            //以上为原始代码段。

                            if (PathCount == 0)  //如果从返回的页面中查不到解析出来的地址，则调用YOUKU原地址
                            {
                                FlvPath = "http://player.youku.com/player.php/sid/" + Fid + "/v.swf";
                            }
                        }
                    }//try                                             
                    catch (Exception ex)  //如果访问网站失败，则加载YOUKU原始地址。
                    {
                        FlvPath = "http://player.youku.com/player.php/sid/" + Fid + "/v.swf";
                    }
                    //Response.Write("<script>alert(FlvPath)</script>");
                    //  Response.Write(FlvPath);
                    //  Response.End();

                }//if  找到字符串            
            }
            return FlvPath;
        }

    }
}