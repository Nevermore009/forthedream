﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Justgo8
{
    public partial class IndexMaster : System.Web.UI.MasterPage
    {
        private DataTable data = null;
        public string pageName = "index.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            pageName = Request.FilePath.Substring(Request.FilePath.LastIndexOf("/") + 1); ;
            BindQuestions();
        }

        protected void BindQuestions()
        {
            data = Bll.BQuestion.GetQuestionList();
            DataView dv = new DataView(data);
            DataTable dt = dv.ToTable(true, "groupname", "groupid");
            rpgroup.DataSource = dt;
            rpgroup.DataBind();
        }

        protected void rpgroup_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (data != null)
            {
                HiddenField groupid = (HiddenField)e.Item.FindControl("lbgroupid");
                string id = groupid.Value;
                if (!string.IsNullOrEmpty(id))
                {
                    DataView dv = new DataView(data);
                    dv.RowFilter = "groupid=" + id;
                    Repeater rp = (Repeater)e.Item.FindControl("rpitem");
                    rp.DataSource = dv.ToTable();
                    rp.DataBind();
                }
            }
        }
    }
}