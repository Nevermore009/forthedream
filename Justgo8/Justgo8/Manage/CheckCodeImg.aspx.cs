using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

namespace SSD.Manage
{
    public partial class CheckCodeImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string VNum = RandomNum(4);
            Session["VNum"] = VNum;
            ValidateCode(VNum);
        }

        public string RandomNum(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";

            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                randomCode += rand.Next(9);
            }
            return randomCode;
        }

        public void ValidateCode(string VNum)
        {
            int Gheight = (int)(VNum.Length * 10);
            //gheight为图片宽度,根据字符长度自动更改图片宽度
            System.Drawing.Bitmap Img = new System.Drawing.Bitmap(Gheight, 20);
            Graphics g = Graphics.FromImage(Img);
            g.DrawString(VNum, new System.Drawing.Font("宋体", 12), new System.Drawing.SolidBrush(Color.Red), 3, 3);
            //在矩形内绘制字串（字串，字体，画笔颜色，左上x.左上y） 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            Response.ClearContent(); //需要输出图象信息 要修改HTTP头 
            Response.ContentType = "image/Png";
            Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            Img.Dispose();
            Response.End();
        }
    }
}