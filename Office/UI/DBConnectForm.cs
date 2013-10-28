using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Advanced_Encryption_Standard;
using System.Configuration;
using System.Xml;

namespace UI
{
    public partial class DBConnectForm : Form
    {
        private ConnectionMgr conmgr = new ConnectionMgr();
        public DBConnectForm()
        {
            InitializeComponent();
        }

        private void DBConnect_Load(object sender, EventArgs e)
        {
            this.FindForm().Icon = new Icon(ConfigurationManager.AppSettings["logo"]);
            string[] settings = ConfigurationManager.ConnectionStrings["connection"].ConnectionString.Split(';');
            foreach (string set in settings)
            {
                string[] keyvalue = set.Split('=');
                if (keyvalue.Length >= 2)
                {
                    switch (keyvalue[0])
                    {
                        case "server":
                            txtserver.Text = keyvalue[1];
                            break;
                        case "user":
                            txtuser.Text = keyvalue[1];
                            break;
                        case "password":
                            txtpassword.Text = keyvalue[1];
                            break;
                    }
                }
            }
            txtserver.Focus();
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定打开连接吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (conmgr.IsConnectionAvailable(txtserver.Text, txtuser.Text, txtpassword.Text))
                {
                    MessageBox.Show("连接成功!");
                }
                else
                    MessageBox.Show("连接失败，请检查您的设置!");
            }
            else
            {
                return;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (conmgr.IsConnectionAvailable(txtserver.Text, txtuser.Text, txtpassword.Text) || MessageBox.Show("当前设置不可用，确定保存吗?", "确认消息", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                XmlDataDocument doc = new XmlDataDocument();
                string nowpath = System.Windows.Forms.Application.ExecutablePath + ".config";
                doc.Load(nowpath);
                XmlNode node = doc.SelectSingleNode("//connectionStrings");//获取connectionStrings节点
                try
                {
                    XmlElement element = (XmlElement)node.SelectSingleNode("//add[@name=\"connection\"]");
                    if (element != null)
                    {
                        element.SetAttribute("connectionString", string.Format("server={0};user={1};password={2};database={3}", txtserver.Text, txtuser.Text, txtpassword.Text, "EnergyConservation"));
                    }
                    else
                    {
                        MessageBox.Show("保存失败,配置文件损坏");
                    }
                    doc.Save(nowpath);
                }
                catch
                {
                    throw;
                }
                MessageBox.Show("保存成功");
                this.FindForm().Close();
            }
        }
    }
}
