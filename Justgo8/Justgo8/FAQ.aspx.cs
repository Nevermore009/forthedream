using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Justgo8
{
    public partial class FAQ1 : System.Web.UI.Page
    {
        private DataTable data = null;
        public string title = string.Empty;
        public string content = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindQuestions();
                BindContent(Request["id"]);
            }
        }

        protected void BindContent(string strid)
        {
            int id;
            if (int.TryParse(strid, out id))
            {
                DataTable dt = Bll.BQuestion.GetQuestionByID(id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    title = dt.Rows[0]["title"].ToString();
                    content = dt.Rows[0]["answer"].ToString();
                }
            }
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