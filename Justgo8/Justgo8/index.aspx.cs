using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Justgo8
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Welcome();
                BindTravelType();
                BindHotInland();
                BindInland();
                BindHotOutland();
                BindOutland();
            }
        }

        private void Welcome()
        {
            DataTable dt = new DataTable();
            dt = Bll.BPatent.info();
            if (dt.Rows.Count > 0)
            {
                RepeaterWelcomePic.DataSource = dt;
                RepeaterWelcomePic.DataBind();
                RepeaterWelcomeWord.DataSource = dt;
                RepeaterWelcomeWord.DataBind();
            }
        }

        private void BindTravelType()
        {
            DataTable dt = Bll.BTravelType.TravelTypeInfo();
            RepeaterTraveltype.DataSource = dt;
            RepeaterTraveltype.DataBind();
        }


        protected void RepeaterTraveltype_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //判断里层repeater处于外层repeater的哪个位置（ AlternatingItemTemplate，FooterTemplate，
            //HeaderTemplate，，ItemTemplate，SeparatorTemplate）
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
                int typeid = Convert.ToInt32(rowv["traveltypeid"]); //获取填充子类的id 

                //绑定热门地区
                Repeater rep = e.Item.FindControl("RepeaterHotArea") as Repeater;//找到里层的repeater对象
                rep.DataSource = Bll.BArea.HotArea(typeid, 4);
                rep.DataBind();

                //绑定所有地区
                Repeater rep2 = e.Item.FindControl("RepeaterArea") as Repeater;//找到里层的repeater对象
                rep2.DataSource = Bll.BArea.AreaOfTravelType(typeid);
                rep2.DataBind();
            }
        }

        protected void RepeaterArea_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //判断里层repeater处于外层repeater的哪个位置（ AlternatingItemTemplate，FooterTemplate，
            //HeaderTemplate，，ItemTemplate，SeparatorTemplate）
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
                int areid = Convert.ToInt32(rowv["areaid"]); //获取填充子类的id 

                //绑定城市
                Repeater rep = e.Item.FindControl("RepeaterCity") as Repeater;//找到里层的repeater对象
                rep.DataSource = Bll.BCity.CityOfArea(areid);
                rep.DataBind();
            }
        }

        protected void BindHotInland()
        {
            RepeaterHotInland.DataSource = Bll.BArea.HotArea(Bll.BTravelType.Inland, 8);
            RepeaterHotInland.DataBind();
        }

        protected void BindInland()
        {
            RepeaterInland.DataSource = Bll.BArea.AreaOfTravelType(Bll.BTravelType.Inland);
            RepeaterInland.DataBind();
        }

        protected void BindHotOutland()
        {
            RepeaterHotOutland.DataSource = Bll.BArea.HotArea(Bll.BTravelType.Outland, 8);
            RepeaterHotOutland.DataBind();
        }

        protected void BindOutland()
        {
            RepeaterOutland.DataSource = Bll.BArea.AreaOfTravelType(Bll.BTravelType.Outland);
            RepeaterOutland.DataBind();
        }

        protected void BindInlandshow()
        {
            repeaterinlandshow.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Inland, 10);
            repeaterinlandshow.DataBind();
        }
        protected void BindInlandshow1()
        {
            repeaterinlandshow1.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Inland, 10);
            repeaterinlandshow1.DataBind();
        }
        protected void BindInlandshow2()
        {
            repeaterinlandshow2.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Inland, 10);
            repeaterinlandshow2.DataBind();
        }

        protected void BindOutlandshow()
        {
            repeateroutlandshow.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Outland, 10);
            repeateroutlandshow.DataBind();
        }
        protected void BindOutlandshow1()
        {
            repeateroutlandshow1.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Outland, 10);
            repeateroutlandshow1.DataBind();
        }
        protected void BindOutlandshow2()
        {
            repeateroutlandshow2.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Outland, 10);
            repeateroutlandshow2.DataBind();
        }

        protected void BindPeripheryshow()
        {
            repeaterperipheryshow.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Periphery, 10);
            repeaterperipheryshow.DataBind();
        }

        protected void BindCustomize()
        {
            
        }

    }
}