using System;
using System.Threading;
using Common;

public partial class server : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsend_Click(object sender, EventArgs e)
    {
        Message msg = new Message { Source = "server", Content = content.Text, Destination = target.Text.Trim() };
        bool flag = false;
        for (int i = 3; i > 0; i--)
        {
            if (LongpollingHandle.ConnManager.SendMessage(msg))
            {
                flag = true;
                break;
            }
            else
            {
                Thread.Sleep(1000);
                continue;
            }
        }
        if (flag)
        {
            MessageBox.Show(this.Page, "send success!");
        }
        else
        {
            MessageBox.Show(this.Page, "send failed!");
        }
    }
}
