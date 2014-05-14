using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Advanced_Encryption_Standard;
using System.Net.Mail;
using System.Data;

namespace Justgo8
{
    public partial class detail : System.Web.UI.Page
    {
        public string adultrule = "";
        public string childrule = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request["id"]))
            {
                Response.Redirect("index.aspx");
                return;
            }
            if (!IsPostBack)
            {
                BindDetail();
                BindPic();
            }
        }

        protected void BindDetail()
        {
            try
            {
                DataTable dt = Bll.BTravelDetail.DetailInfo(int.Parse(Request["id"]));
                if (dt.Rows.Count > 0)
                {
                    lbtitle.Text = dt.Rows[0]["title"].ToString();
                    lbtitle2.Text = dt.Rows[0]["title"].ToString();
                    bool isfixed = bool.Parse(dt.Rows[0]["isfixed"].ToString());
                    lbadultprice.Text = dt.Rows[0]["adultprice"].ToString() + (isfixed ? "" : "起");
                    lbchildprice.Text = dt.Rows[0]["childprice"].ToString() + (isfixed ? "" : "起");
                    lbgeneralprice.Text = dt.Rows[0]["generalprice"].ToString();
                    lbdeparturetime.Text = dt.Rows[0]["departuretime"].ToString();
                    divfeatures.InnerHtml = dt.Rows[0]["features"].ToString();
                    divjourney.InnerHtml = dt.Rows[0]["journey"].ToString();
                    divbillinclude.InnerHtml = dt.Rows[0]["billinclude"].ToString();
                    divbillbeside.InnerHtml = dt.Rows[0]["billbeside"].ToString();
                    divservicestandard.InnerHtml = dt.Rows[0]["servicestandard"].ToString();
                    divpresentation.InnerHtml = dt.Rows[0]["presentation"].ToString();
                    divcontact.InnerHtml = dt.Rows[0]["contact"].ToString();
                    int adultruleid = int.Parse(dt.Rows[0]["adultruleid"].ToString());
                    int childruleid = int.Parse(dt.Rows[0]["childruleid"].ToString());
                    adultrule = GetRule(adultruleid);
                    childrule = GetRule(childruleid);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog(ex.ToString());
                MessageBox.ResponseScript(this.Page, "alert('获取数据失败');this.history.go(-1)");
            }
        }

        protected void BindPic()
        {
            try
            {
                DataTable dt = Bll.BTravelPicture.PictureInfo(int.Parse(Request["id"]));
                if (dt.Rows.Count > 0)
                {
                    repeaterdetailpic.DataSource = dt;
                    repeaterdetailpic.DataBind();
                }
                else
                {
                    repeaterdetailpic.DataSource = null;
                    repeaterdetailpic.DataBind();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog("图片获取失败:" + ex.ToString());
            }
        }

        public string GetRule(int id)
        {
            try
            {
                DataTable dt = Bll.BRule.RuleInfo(id);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["content"].ToString();
                }
                else
                    return "";
            }
            catch
            {
                return "";
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime departuretime = DateTime.Now;
                int adultnum, childnum;
                if (Session["username"] == null)
                {
                    string returnurl = "";
                    try
                    {
                        returnurl = "detail.aspx?id=" + Request["id"];
                    }
                    catch { }
                    string url = "login.aspx" + (returnurl == "" ? "" : ("?returnurl=" + returnurl));
                    MessageBox.ResponseScript(this.Page, "alert('请先登录后预订!');window.location.href='" + url + "'");
                }
                else if (String.IsNullOrEmpty(Request.Form["departuretime"]) || !DateTime.TryParse(Request.Form["departuretime"], out departuretime))
                {
                    MessageBox.Show(this.Page, "出发日期不正确!");
                    return;
                }
                else if (String.IsNullOrEmpty(txtadultnum.Text) || !int.TryParse(txtadultnum.Text, out adultnum) || String.IsNullOrEmpty(txtchildnum.Text) || !int.TryParse(txtchildnum.Text, out childnum))
                {
                    MessageBox.Show(this.Page, "人数填写不正确!");
                    return;
                }
                else
                {
                    if (Bll.BOrders.add(int.Parse(Request["id"]), Session["username"].ToString(), float.Parse(lbgeneralprice.Text == "" ? "0" : lbgeneralprice.Text), float.Parse(lbadultprice.Text == "" ? "0" : lbadultprice.Text), float.Parse(lbchildprice.Text == "" ? "0" : lbchildprice.Text), int.Parse(txtadultnum.Text), int.Parse(txtchildnum.Text), departuretime) > 0)
                    {
                        try
                        {
                            System.Net.Mail.SmtpClient client = new SmtpClient("smtp.qq.com");
                            client.UseDefaultCredentials = false;
                            client.Credentials = new System.Net.NetworkCredential("869366502@qq.com", "897074818.");
                            client.DeliveryMethod = SmtpDeliveryMethod.Network;
                            MailAddress sendermail = new MailAddress("869366502@qq.com", "da-ge");
                            System.Net.Mail.MailMessage message = new MailMessage();
                            message.From = sendermail;
                            message.Sender = sendermail;
                            message.To.Add(new MailAddress("896412338@qq.com", "小雅"));
                            message.To.Add(new MailAddress("2773150840@qq.com", "小玲"));
                            message.BodyEncoding = System.Text.Encoding.UTF8;
                            message.Body = string.Format("下单人:{0}<br />联系电话:{1}<br />线路名称:{2}<br />日期:{5},成人人数:{3},儿童人数:{4}<br />详情:<a href='http://www.justgo8.com/detail.aspx?id={5}'>http://www.justgo8.com/detail.aspx?id={5}</a>", Session["username"].ToString(), Session["phone"].ToString(), lbtitle.Text, txtadultnum.Text, txtchildnum.Text, Request["id"], departuretime.ToString("yyyy-MM-dd"));
                            message.IsBodyHtml = true;
                            message.Subject = "有人下订单了";
                            client.Send(message);
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.AddErrorLog("邮件发送失败:" + ex.ToString());
                        }
                        string msg = string.Format("alert('您已成功预订{3}日【{0}】,成人数:{1},儿童数:{2},您的联系电话是{4},稍后将会有工作人员与您联系,请保持电话畅通!');window.reload();", lbtitle.Text, txtadultnum.Text, txtchildnum.Text, departuretime.ToString("yyyy-MM-dd"), Session["phone"].ToString());
                        // ErrorLog.AddErrorLog(msg);
                        MessageBox.ResponseScript(this.Page, msg);
                    }
                    else
                    {
                        MessageBox.Show(this.Page, "预订失败");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog(ex.ToString());
                MessageBox.Show(this.Page, "预订失败");
            }
        }
    }
}