using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Common;

public partial class Webmanager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        System.Drawing.Image img = System.Drawing.Image.FromStream(fileindex.PostedFile.InputStream);
        switch (btn.CommandArgument)
        {
            case "index":
                //长度:0-600px 高度44px 文件路径:images/title.png  最好使用png图片
                if (img.Width > 600 || img.Width <= 10 || img.Height != 44)
                {
                    MessageBox.Show(this.Page, "图片大小不符合要求!");
                    return;
                }
                img.Save(Server.MapPath("~/images/title.png"));
                break;
            case "logo":
                if (img.Width !=71 || img.Height != 69)
                {
                    MessageBox.Show(this.Page, "图片大小不符合要求!");
                    return;
                }
                img.Save(Server.MapPath("~/images/mainframe/logo.png"));
                //71*69px images/mainframe/logo.png 
                break;
            case "title":
                if (img.Width != 500 || img.Height != 67)
                {
                    MessageBox.Show(this.Page, "图片大小不符合要求!");
                    return;
                }
                img.Save(Server.MapPath("~/images/mainframe/title.png"));
                //500*67px images/mainframe/title.png
                break;
            default:
                break;
        }
    }
}
