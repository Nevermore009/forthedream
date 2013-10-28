using System;
using System.Collections.Generic;
using Common;

public partial class title : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            string routeid = Request["id"];
            if (routeid != null && routeid != "null")
            {
                lbid.Text = routeid;
            }
            string title = Request["title"];
            if (title != null && title != "null")
            {
                txttitle.Text = title;
            }
            string remark = Request["description"];
            if (remark != null && title != "null")
            {
                txtremark.Text = remark;
            }

        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {  
        /*
        //处理基本路线在编辑基站
        if (Request.QueryString["remark"] == null)
        {
            if (txttitle.Text.ToString()=="")
            {
                return;
            }
            BaseStation baseStation = new BaseStation() { Num = int.Parse(Request.QueryString["Num"]), Lat = double.Parse(Request.QueryString["lat"]), Lng = double.Parse(Request.QueryString["lng"]), RouteID = int.Parse(Request.QueryString["routeID"]),Staionname=txttitle.Text.ToString(),Remark=txtremark.Text.ToString() };
            List<BaseStation> lis = Session["list"] as List<BaseStation>;
            //当之前已经添加了某条线路中的其中一个基站的信息时按照他们的num进行排序
            if (lis != null)
            {    
                for (int i = 0; i < lis.Count; i++)
                {
                    if (baseStation.Num < lis[i].Num)
                    {
                        list.Insert(i, baseStation);
                    }
                }
            }
            else
            {
                list.Add(baseStation);
            }
            Session["list"]= list;
            return;
        }*/
       // 处理标准路线
        if (!string.IsNullOrEmpty(lbid.Text))
        {
           
            string title = txttitle.Text.ToString();
            string remark = txtremark.Text.ToString();
            int id = int.Parse(lbid.Text);
            BLL.RouteInfo rbll = new BLL.RouteInfo();
            if (!rbll.ModifyRouteInfoById(id,title,remark))
            {
                MessageBox.Show(this.Page, "更新失败!");
                return;
            }
            else
            {
                txttitle.Enabled = false;
                txtremark.Enabled = false;
                btnsubmit.Enabled = false;
            }
        }
         
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        if (btnsubmit.Enabled == false)
        {
            txttitle.Enabled = true;
            txtremark.Enabled = true;
            btnsubmit.Enabled = true;
        }
    }
}

