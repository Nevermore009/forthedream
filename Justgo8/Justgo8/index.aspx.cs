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
                BindHotZyx();
                BindZyx();
                BindHotPeriphery();
                BindPeriphery();
                BindInlandshow();
                BindInlandshow1();
                BindInlandshow2();
                BindOutlandshow();
                BindOutlandshow1();
                BindOutlandshow2();
                BindZyxshow1();
                BindZyxshow2();
                BindPeripheryshow();
                BindPeripheryshow1();
                BindPeripheryshow2();
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

        static int DisplayHotAreaCount = 10;
        static int DisplayDetailCount = 10;

        protected void BindHotInland()
        {
            RepeaterHotInland.DataSource = Bll.BArea.HotArea(Bll.BTravelType.Inland, DisplayHotAreaCount);
            RepeaterHotInland.DataBind();
        }

        protected void BindInland()
        {
            RepeaterInland.DataSource = Bll.BArea.HotArea(Bll.BTravelType.Inland, int.MaxValue);
            RepeaterInland.DataBind();
        }

        protected void BindHotOutland()
        {
            RepeaterHotOutland.DataSource = Bll.BArea.HotArea(Bll.BTravelType.Outland, DisplayHotAreaCount);
            RepeaterHotOutland.DataBind();
        }

        protected void BindOutland()
        {
            RepeaterOutland.DataSource = Bll.BArea.HotArea(Bll.BTravelType.Outland, int.MaxValue);
            RepeaterOutland.DataBind();
        }

        protected void BindHotZyx()
        {
            repeaterhotzyx.DataSource = Bll.BArea.HotArea(Bll.BTravelType.Zyx, DisplayHotAreaCount);
            repeaterhotzyx.DataBind();
        }

        protected void BindZyx()
        {
            repeaterzyx.DataSource = Bll.BArea.HotArea(Bll.BTravelType.Zyx, int.MaxValue);
            repeaterzyx.DataBind();
        }

        protected void BindHotPeriphery()
        {
            repeaterhotperiphery.DataSource = Bll.BArea.HotArea(Bll.BTravelType.Periphery, DisplayHotAreaCount);
            repeaterhotperiphery.DataBind();
        }

        protected void BindPeriphery()
        {
            repeaterperiphery.DataSource = Bll.BArea.HotArea(Bll.BTravelType.Periphery, int.MaxValue);
            repeaterperiphery.DataBind();
        }

        protected void BindInlandshow()
        {
            repeaterinlandshow.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Inland, 10);
            repeaterinlandshow.DataBind();
        }
        protected void BindInlandshow1()
        {
            repeaterinlandshow1.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Inland, 0, DisplayDetailCount);
            repeaterinlandshow1.DataBind();
        }
        protected void BindInlandshow2()
        {
            repeaterinlandshow2.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Inland, 1, DisplayDetailCount);
            repeaterinlandshow2.DataBind();
        }

        protected void BindOutlandshow()
        {
            repeateroutlandshow.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Outland, 10);
            repeateroutlandshow.DataBind();
        }
        protected void BindOutlandshow1()
        {
            repeateroutlandshow1.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Outland, 0, DisplayDetailCount);
            repeateroutlandshow1.DataBind();
        }
        protected void BindOutlandshow2()
        {
            repeateroutlandshow2.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Outland, 1, DisplayDetailCount);
            repeateroutlandshow2.DataBind();
        }

        protected void BindZyxshow1()
        {
            repeaterzyxshow1.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Zyx, 0, DisplayDetailCount);
            repeaterzyxshow1.DataBind();
        }
        protected void BindZyxshow2()
        {
            repeaterzyxshow2.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Zyx, 1, DisplayDetailCount);
            repeaterzyxshow2.DataBind();
        }

        protected void BindPeripheryshow()
        {
            repeaterperipheryshow.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Periphery, 10);
            repeaterperipheryshow.DataBind();
        }

        protected void BindPeripheryshow1()
        {
            repeaterperipheryshow1.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Periphery, 0, DisplayDetailCount);
            repeaterperipheryshow1.DataBind();
        }

        protected void BindPeripheryshow2()
        {
            repeaterperipheryshow2.DataSource = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Periphery, 1, DisplayDetailCount);
            repeaterperipheryshow2.DataBind();
        }

        protected void BindCustomize()
        {

        }

    }
}