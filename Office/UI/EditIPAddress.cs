using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class EditIPAddress : Form
    {
        public EditIPAddress()
        {
            InitializeComponent();
        }

        private void EditIPAddress_Load(object sender, EventArgs e)
        {
            string infoID = ((IPSetting)this.Owner).passValue;
            DataTable dt = new IPManager().SelectInfoID(infoID);
            if (dt.Rows.Count > 0)
            {
                txtIpAddress.Text = dt.Rows[0]["IPAddress"].ToString();
                txtduankou.Text = dt.Rows[0]["Port"].ToString();
                txtSubNetMask.Text = dt.Rows[0]["NetMask"].ToString();
                txtDateWay.Text = dt.Rows[0]["Gateway"].ToString();
                txtMacAddress.Text = dt.Rows[0]["MacAddress"].ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要修改IP吗？如果修改失败会导致失去通讯！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                IPSetting parent = (IPSetting)this.Owner;
                string infoID = parent.passValue;
                string ipAddress = txtIpAddress.Text.ToString();
                string netMask = txtSubNetMask.Text.ToString();
                string gateWay = txtDateWay.Text.ToString();
                string macAddress = txtMacAddress.Text.ToString();
                string duankou = txtduankou.Text.ToString();
                if (macAddress.Length < 17)
                {
                    MessageBox.Show("Mac地址格式不正确！");
                    return;
                }
                if (cklocal.Checked)   //只修改本地,直接给父窗体发成功命令
                {
                    string ip = ipAddress + "|" + duankou + "|" + netMask + "|" + gateWay + "|" + macAddress + "|";
                    parent.ClientIPChangedSuccess(infoID, ip);
                }
                else
                {
                    Controller.SetClientIP(infoID, parent.ClientIPChangedSuccess, parent.ClientIPChangedFailed, ipAddress, duankou, netMask, gateWay, macAddress);
                }
            }
            else
            {
                return;
            }
            this.Close();
        }

        private void cklocal_CheckedChanged(object sender, EventArgs e)
        {
            if (cklocal.Checked && MessageBox.Show("这将只对本地IP进行更改，而不修改远程终端IP，请谨慎操作，要继续吗?", "注意", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                cklocal.Checked = false;
            }
        }

        private void txtMacAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtMacAddress.Text.Length > 17)
            {
                MessageBox.Show("最多可以输入十七位");
                return;
            }
        }
    }
}
