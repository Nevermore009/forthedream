﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Common;

namespace Justgo8.Manage
{
    public partial class AddDetail : System.Web.UI.Page
    {
        private static DataTable cityinfo = new DataTable();
        private static DataTable picdt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTravelType();
                BindJourneydays();
                BindRule(0, dropadultrule);
                BindRule(1, dropchildrule);
                if (!String.IsNullOrEmpty(Request["travelid"]))
                {
                    try
                    {
                        lbid.Text = Request["travelid"];
                        DataTable dt = Bll.BTravelDetail.DetailInfo(int.Parse(Request["travelid"]));
                        if (dt.Rows.Count > 0)
                        {
                            txtserialno.Text = dt.Rows[0]["serialno"].ToString();
                            txttitle.Text = dt.Rows[0]["title"].ToString();
                            txtdescription.Text = dt.Rows[0]["description"].ToString();
                            txttransportation.Text = dt.Rows[0]["transportation"].ToString();
                            txtgeneralprice.Text = dt.Rows[0]["generalprice"].ToString();
                            txtadultprice.Text = dt.Rows[0]["adultprice"].ToString();
                            txtchildprice.Text = dt.Rows[0]["childprice"].ToString();
                            cbfixed.Checked = bool.Parse(dt.Rows[0]["isfixed"].ToString());
                            txtstartdate.Text = dt.Rows[0]["startdate"].ToString();
                            txtenddate.Text = dt.Rows[0]["enddate"].ToString();
                            txttraveldate.Text = dt.Rows[0]["departuretime"].ToString();
                            fckbillinclude.Value = dt.Rows[0]["billinclude"].ToString();
                            fckbillbeside.Value = dt.Rows[0]["billbeside"].ToString();
                            fckfeature.Value = dt.Rows[0]["features"].ToString();
                            fckjourney.Value = dt.Rows[0]["journey"].ToString();
                            fckpresentation.Value = dt.Rows[0]["presentation"].ToString();
                            fckservicestandard.Value = dt.Rows[0]["servicestandard"].ToString();
                            fckcontact.Value = dt.Rows[0]["contact"].ToString();
                            dropjourneydays.SelectedValue = dt.Rows[0]["journeydays"].ToString();
                            droptraveltype.SelectedValue = dt.Rows[0]["traveltypeid"].ToString();
                            dropadultrule.SelectedValue = dt.Rows[0]["adultruleid"].ToString();
                            dropchildrule.SelectedValue = dt.Rows[0]["childruleid"].ToString();
                        }
                        else
                        {
                            MessageBox.ResponseScript(this.Page, "alert('没有找到相应的信息');window.location.href='TravelManager.aspx'");
                        }
                        droptraveltype.Enabled = false;
                        BindDestination(Bll.BDestination.DestinationInfo(int.Parse(lbid.Text)));
                        BindPic(Bll.BTravelPicture.PictureInfo(int.Parse(lbid.Text)));
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.AddErrorLog(ex.ToString());
                        MessageBox.ResponseScript(this.Page, "alert('错误');window.location.href='TravelManager.aspx'");
                    }
                }
                else
                {
                    if (cityinfo.Columns.Count <= 0)
                    {
                        cityinfo.Columns.Add("id");
                        cityinfo.Columns.Add("areaid");
                        cityinfo.Columns.Add("areaname");
                        cityinfo.Columns.Add("cityid");
                        cityinfo.Columns.Add("cityname");
                    }
                    if (picdt.Columns.Count <= 0)
                    {
                        picdt.Columns.Add("pic");
                        picdt.Columns.Add("picid");
                    }
                    picdt.Rows.Clear();
                    cityinfo.Rows.Clear();
                }
            }
        }

        protected void BindTravelType()
        {
            DataTable dt = new DataTable();
            dt = Bll.BTravelType.TravelTypeInfo();
            if (dt.Rows.Count > 0)
            {
                droptraveltype.DataSource = dt.DefaultView;
                droptraveltype.DataValueField = "traveltypeid";
                droptraveltype.DataTextField = "traveltypename";
                droptraveltype.DataBind();

                dropdestinationtraveltype.DataSource = dt.DefaultView;
                dropdestinationtraveltype.DataValueField = "traveltypeid";
                dropdestinationtraveltype.DataTextField = "traveltypename";
                dropdestinationtraveltype.DataBind();
                dropdestinationtraveltype.Items.Insert(0, "--请选择--");
            }
            else
            {
                droptraveltype.DataSource = null;
                droptraveltype.DataBind();

                dropdestinationtraveltype.DataSource = null;
                dropdestinationtraveltype.DataBind();
            }
        }

        protected void BindJourneydays()
        {
            dropjourneydays.Items.Clear();
            for (int i = 1; i <= 30; i++)
            {
                dropjourneydays.Items.Add(new ListItem(i + "天", i.ToString()));
            }
        }

        protected void BindDestination(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                repeaterdestination.DataSource = dt;
                repeaterdestination.DataBind();
            }
            else
            {
                repeaterdestination.DataSource = null;
                repeaterdestination.DataBind();
            }
        }

        protected void BindPic(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                repeaterpic.DataSource = dt;
                repeaterpic.DataBind();
            }
            else
            {
                repeaterpic.DataSource = null;
                repeaterpic.DataBind();
            }
        }

        protected void BindRule(int ruletype, DropDownList drop)
        {
            DataTable dt = new DataTable();
            dt = Bll.BRule.RulesOfType(ruletype);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (r["content"].ToString().Length > 50)
                    {
                        r["content"] = r["content"].ToString().Substring(0, 50) + "...";
                    }
                }
                drop.DataSource = dt.DefaultView;
                drop.DataTextField = "content";
                drop.DataValueField = "id";
                drop.DataBind();
            }
            else
            {
                drop.DataSource = null;
                drop.DataBind();
            }
            drop.Items.Insert(0, new ListItem("不区分", "0"));
        }

        protected void RPlank_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("del"))
            {
                if (String.IsNullOrEmpty(lbid.Text))
                {
                    cityinfo.Rows.RemoveAt(e.Item.ItemIndex);
                    BindDestination(cityinfo);
                }
                else
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    int res = Bll.BDestination.del(id);
                    if (res == 1)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "alert('删除成功')", true);
                        BindDestination(Bll.BDestination.DestinationInfo(int.Parse(lbid.Text)));
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "alert('删除失败')", true);
                    }
                }
            }
        }

        protected void dropdestinationtraveltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropdestinationtraveltype.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                dt = Bll.BArea.AreaOfTravelType(int.Parse(dropdestinationtraveltype.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    droparea.DataSource = dt.DefaultView;
                    droparea.DataValueField = "areaid";
                    droparea.DataTextField = "areaname";
                    droparea.DataBind();
                    droparea.Items.Insert(0, "--请选择--");
                }
                else
                {
                    droparea.Items.Clear();
                }
            }
        }

        protected void droparea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (droparea.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                dt = Bll.BCity.CityOfArea(int.Parse(droparea.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    dropcity.DataSource = dt.DefaultView;
                    dropcity.DataValueField = "cityid";
                    dropcity.DataTextField = "cityname";
                    dropcity.DataBind();
                    dropcity.Items.Insert(0, "--请选择--");
                }
                else
                {
                    dropcity.Items.Clear();
                }
            }
        }

        protected void btnrefreshadultrule_Click(object sender, EventArgs e)
        {
            BindRule(0, dropadultrule);
        }

        protected void btnrefreshchildrule_Click(object sender, EventArgs e)
        {
            BindRule(1, dropchildrule);
        }

        protected void btnadddestination_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(lbid.Text))
                {
                    if (droparea.SelectedIndex > 0)
                    {
                        int cityid = 0;
                        string cityname = "";
                        if (dropcity.SelectedIndex > 0)
                        {
                            cityid = int.Parse(dropcity.SelectedValue);
                            cityname = dropcity.SelectedItem.Text;
                        }
                        DataRow row = cityinfo.NewRow();
                        row["areaid"] = droparea.SelectedValue;
                        row["areaname"] = droparea.SelectedItem.Text;
                        row["cityid"] = cityid;
                        row["cityname"] = cityname;
                        cityinfo.Rows.Add(row);
                        BindDestination(cityinfo);
                    }
                }
                else
                {
                    if (droparea.SelectedIndex > 0)
                    {
                        int cityid = 0;
                        if (dropcity.SelectedIndex > 0)
                        {
                            cityid = int.Parse(dropcity.SelectedValue);
                        }
                        if (Bll.BDestination.add(int.Parse(lbid.Text), int.Parse(droparea.SelectedValue), cityid) > 0)
                        {
                            BindDestination(Bll.BDestination.DestinationInfo(int.Parse(lbid.Text)));
                        }
                        else
                        {
                            MessageBox.Show(this.Page, "添加失败!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog(ex.ToString());
                MessageBox.Show(this.Page, "添加失败!");
            }
        }

        protected void btnaddpic_Click(object sender, EventArgs e)
        {
            try
            {
                if (!fileuploadpic.HasFile)
                {
                    MessageBox.Show(this.Page, "请选择要上传的文件!");
                    return;
                }
                string url = FileUpLoad.Upload(Request.Files);
                if (String.IsNullOrEmpty(lbid.Text))
                {
                    DataRow row = picdt.NewRow();
                    row["pic"] = url;
                    picdt.Rows.Add(row);
                    BindPic(picdt);
                }
                else
                {
                    if (Bll.BTravelPicture.add(int.Parse(lbid.Text), url) > 0)
                    {
                        BindPic(Bll.BTravelPicture.PictureInfo(int.Parse(lbid.Text)));
                    }
                    else
                    {
                        MessageBox.Show(this.Page, "添加失败!");
                    }

                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog(ex.ToString());
                MessageBox.Show(this.Page, "添加失败!");
            }
        }

        protected void Repeaterpic_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("del"))
            {
                if (String.IsNullOrEmpty(lbid.Text))
                {
                    picdt.Rows.RemoveAt(e.Item.ItemIndex);
                    BindPic(picdt);
                }
                else
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    int res = Bll.BTravelPicture.del(id);
                    if (res == 1)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "alert('删除成功')", true);
                        BindPic(Bll.BTravelPicture.PictureInfo(int.Parse(lbid.Text)));
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "alert('删除失败')", true);
                    }
                }
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dropadultrule.SelectedIndex < 0)
                {
                    MessageBox.Show(this.Page, "请选择成人界定规则！");
                    return;
                }
                if (dropchildrule.SelectedIndex < 0)
                {
                    MessageBox.Show(this.Page, "请选择儿童界定规则！");
                    return;
                }
                if (String.IsNullOrEmpty(lbid.Text))
                {
                    int detailid = Bll.BTravelDetail.add(txtserialno.Text, txttitle.Text, txtdescription.Text, float.Parse(txtgeneralprice.Text), float.Parse(txtadultprice.Text), float.Parse(txtchildprice.Text), cbfixed.Checked, txtstartdate.Text, txtenddate.Text, txttraveldate.Text, fckfeature.Value, fckbillinclude.Value, fckbillbeside.Value, fckservicestandard.Value, fckpresentation.Value, fckjourney.Value, fckcontact.Value, int.Parse(droptraveltype.SelectedValue), int.Parse(dropjourneydays.SelectedValue), txttransportation.Text, int.Parse(dropadultrule.SelectedValue), int.Parse(dropchildrule.SelectedValue));
                    try
                    {
                        for (int i = 0; i < cityinfo.Rows.Count; i++)
                        {
                            Bll.BDestination.add(detailid, int.Parse(cityinfo.Rows[i]["areaid"].ToString()), int.Parse(cityinfo.Rows[i]["cityid"].ToString()));
                        }
                        cityinfo.Rows.Clear();
                    }
                    catch (Exception x)
                    {
                        ErrorLog.AddErrorLog(x.ToString());
                    }
                    try
                    {
                        for (int i = 0; i < picdt.Rows.Count; i++)
                        {
                            Bll.BTravelPicture.add(detailid, picdt.Rows[i]["pic"].ToString());
                        }
                        picdt.Rows.Clear();
                    }
                    catch (Exception x)
                    {
                        ErrorLog.AddErrorLog(x.ToString());
                    }

                    MessageBox.ResponseScript(this.Page, "if(confirm('添加成功!要继续添加吗?')){window.location.href='AddDetail.aspx';}else{window.location.href='TravelManager.aspx'}");
                }
                else
                {
                    if (Bll.BTravelDetail.update(txtserialno.Text, txttitle.Text, txtdescription.Text, float.Parse(txtgeneralprice.Text), float.Parse(txtadultprice.Text), float.Parse(txtchildprice.Text), cbfixed.Checked, txtstartdate.Text, txtenddate.Text, txttraveldate.Text, fckfeature.Value, fckbillinclude.Value, fckbillbeside.Value, fckservicestandard.Value, fckpresentation.Value, fckjourney.Value, fckcontact.Value, int.Parse(dropjourneydays.SelectedValue), txttransportation.Text, int.Parse(dropadultrule.SelectedValue), int.Parse(dropchildrule.SelectedValue), int.Parse(lbid.Text)) > 0)
                    {
                        MessageBox.ResponseScript(this.Page, "alert('修改成功!');window.location.href='TravelManager.aspx'");
                    }
                    else
                    {
                        MessageBox.Show(this.Page, "保存失败!");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog(ex.ToString());
                MessageBox.Show(this.Page, "保存失败!");
            }
        }

    }
}