using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BLL;

namespace UI
{
    public partial class HelpForm : Form
    {
        private string[] titles;
        private HelpText helpbll = new HelpText();
        public HelpForm(params string[] titles)
        {
            InitializeComponent();
            this.FindForm().Icon = new Icon(ConfigurationManager.AppSettings["logo"]);
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            DataTable dt = null;
            if (titles != null)
            {
                DataTable temp = null;
                foreach (string title in titles)
                {
                    temp = helpbll.GetHelpByTitle(title);
                    if (dt == null)
                    {
                        dt = temp;
                        continue;
                    }
                    foreach (DataRow r in temp.Rows)
                    {
                        dt.ImportRow(r);
                    }
                }
            }
            else
            {
                dt = helpbll.GetHelpList();
            }
            StringBuilder text = new StringBuilder();
            foreach (DataRow r in dt.Rows)
            {
                text.AppendLine("问:" + r["title"].ToString());
                text.Append("答:" + r["content"].ToString() + "\r\n");
                text.AppendLine("");
            }
            if (text.ToString() == "")

                lbhelptext.Text = "没有找到符合条件的帮助信息!";
            else
                lbhelptext.Text = text.ToString();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                titles = new string[] { textBox1.Text };
            }
            else
            {
                titles = null;
            }
            InitData();
        }
    }
}
