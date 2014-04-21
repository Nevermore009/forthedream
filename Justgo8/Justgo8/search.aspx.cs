using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Common;

namespace Justgo8
{
    public partial class search : System.Web.UI.Page
    {
        public string journeydates = "";
        public string adultprice = "";
        public string traveltype = "";
        public string destinationarea = "";
        public string destinationcity = "";
        public string titlekey = "";
        public string startdate = "";
        public string enddate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDates();
                BindTravelType();
                DataTable dt = Bll.BArea.AreaInfo();
                BindArea(dt);
                BindAreaInfo(dt);
                if (!string.IsNullOrEmpty(Request["journeydates"]))
                {
                    journeydates = Request["journeydates"];
                }
                if (!string.IsNullOrEmpty(Request["adultprice"]))
                {
                    adultprice = Request["adultprice"];
                }
                if (!string.IsNullOrEmpty(Request["traveltype"]))
                {
                    traveltype = Request["traveltype"];
                }
                if (!string.IsNullOrEmpty(Request["destinationarea"]))
                {
                    destinationarea = Request["destinationarea"];
                }
                if (!string.IsNullOrEmpty(Request["destinationcity"]))
                {
                    destinationcity = Request["destinationcity"];
                }
                if (!string.IsNullOrEmpty(Request["titlekey"]))
                {
                    titlekey = Request["titlekey"];
                }
                if (!string.IsNullOrEmpty(Request["journeydates"]))
                {
                    journeydates = Request["journeydates"];
                }
                if (!string.IsNullOrEmpty(Request["journeydates"]))
                {
                    journeydates = Request["journeydates"];
                }
            }
        }

        protected void BindDates()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("value");
            for (int i = 1; i <= 15; i++)
            {
                dt.Rows.Add(i);
            }
            repeaterDates.DataSource = dt;
            repeaterDates.DataBind();
        }

        protected void BindTravelType()
        {
            DataTable dt = new DataTable();
            dt = Bll.BTravelType.TravelTypeInfo();
            if (dt.Rows.Count > 0)
            {
                repeaterTravelType.DataSource = dt;
                repeaterTravelType.DataBind();
            }
            else
            {
                repeaterTravelType.DataSource = dt;
                repeaterTravelType.DataBind();
            }
        }

        protected void BindArea(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                RepeaterArea.DataSource = dt;
                RepeaterArea.DataBind();
            }
            else
            {
                RepeaterArea.DataSource = dt;
                RepeaterArea.DataBind();
            }
        }

        protected void BindAreaInfo(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                RepeaterAreaInfo.DataSource = dt;
                RepeaterAreaInfo.DataBind();
            }
            else
            {
                RepeaterAreaInfo.DataSource = dt;
                RepeaterAreaInfo.DataBind();
            }
        }

        protected void RepeaterAreaInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
                int areaid = Convert.ToInt32(rowv["areaid"]); //获取填充子类的id 

                //绑定热门地区
                Repeater rep = e.Item.FindControl("RepeaterCity") as Repeater;//找到里层的repeater对象
                DataTable dt = Bll.BCity.CityOfArea(areaid);
                if (dt.Rows.Count > 0)
                {
                    rep.DataSource = dt;
                    rep.DataBind();
                }
            }
        }

        protected void traveltype_click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Page, "");
        }

        protected void BindDetail(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                repeaterdetail.DataSource = dt;
                repeaterdetail.DataBind();
            }
            else
            {
                repeaterdetail.DataSource = null;
                repeaterdetail.DataBind();
            }
        }


        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                journeydates = Request.Form["c_journeydates"];
                adultprice = Request.Form["c_adultprice"];
                traveltype = Request.Form["c_type"];
                destinationarea = Request.Form["c_area"];
                destinationcity = Request.Form["c_city"];
                titlekey = Request.Form["txttitlekey"];
                startdate = Request.Form["txtstartdate"];
                enddate = Request.Form["txtenddate"];
                string startprice = "", endprice = "";
                if (!string.IsNullOrEmpty(adultprice))
                {
                    startprice = adultprice.Split('-')[0];
                    endprice = adultprice.Split('-')[1];
                }
                DataTable dt = Bll.BTravelDetail.TravelInfoByCondition(journeydates, startprice, endprice, traveltype, destinationarea, destinationcity, titlekey, startdate, enddate, 0, 100, "", false);
                BindDetail(dt);
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog(ex.ToString());
            }
        }
    }
}