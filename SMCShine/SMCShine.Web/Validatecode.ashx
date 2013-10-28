<%@ WebHandler Language="C#" Class="Validatecode" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Drawing;

public class Validatecode : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        int imgWidth = 60;//图片宽度 
        int imgHeight = 24;//图片高度 
        string answer;
        string validateCode = CreateValidateCode(out answer);//生成验证码 
        context.Session["validateCode"] = answer;
        Bitmap bitmap = new Bitmap(imgWidth, imgHeight);//生成Bitmap图像 
        DisturbBitmap(bitmap); //图像背景 
        DrewValidateCode(bitmap, validateCode);//绘制验证码图像 
        bitmap.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);//保存图像，等待输出 
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    private string Getcode()
    {
        return null;
    }


    private string CreateValidateCode(out string answer) //生成验证码 
    {
        int codeLen = 4;//验证码长度 
        string validateCode = "";
        Random random = new Random();// 随机数对象 
        for (int i = 0; i < codeLen; i++)//循环生成每位数值 
        {
            int n = random.Next(10);//数字 
            validateCode += n.ToString();
        }
        answer = validateCode;
        return validateCode;
        /*
        string validateCode = "";
        Random random = new Random();// 随机数对象 
        int x=random.Next(100);
        int y = random.Next(100);
        validateCode += x.ToString() + "+" + y.ToString() + "=";
        answer = (x + y).ToString();
        return validateCode;// 返回验证码 
         */ 
    }
    private void DisturbBitmap(Bitmap bitmap)//图像背景 
    {
        int fineness = 85;//图片清晰度 

        Random random = new Random();//通过随机数生成 
        for (int i = 0; i < bitmap.Width; i++)//通过循环嵌套，逐个像素点生成 
        {
            for (int j = 0; j < bitmap.Height; j++)
            {
                if (random.Next(90) <= fineness)
                    bitmap.SetPixel(i, j, Color.LightGray);
            }
        }
    }
    private void DrewValidateCode(Bitmap bitmap, string validateCode)//绘制验证码图像 
    {
        string fontFamily = "Times New Roman";//字体名称 
        int fontSize = 14;//字体大小 
        int posX = 0;//绘制起始坐标X 
        int posY = 0;//绘制坐标Y 
        Graphics g = Graphics.FromImage(bitmap);//获取绘制器对象 
        Font font = new Font(fontFamily, fontSize, FontStyle.Bold);//设置绘制字体 
        g.DrawString(validateCode, font, Brushes.Black, posX, posY);//绘制验证码图像 
    }

}

