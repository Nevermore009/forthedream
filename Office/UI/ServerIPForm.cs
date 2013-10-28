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
    public partial class ServerIPForm : Form
    {
        public string successInfoID = "";
        public string failInfoID = "";

        #region 窗体初始化事件
        public ServerIPForm()
        {
            InitializeComponent();
            DataTable dtShow = new ServerIP().SelectServerIP();
            if (dtShow.Rows.Count > 0)
            {
                txtIpAddress.Text = dtShow.Rows[0]["IPAddress"].ToString();
                txtport.Text = dtShow.Rows[0]["port"].ToString();
            }
            else
            {
                txtIpAddress.Text = "";
            }
        }
        private void ServerIPForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region 客户端响应控制回调函数
        public void SetSuccess(string infoID, object e)
        {
            DataTable dtInfoID = new Equipment().SelectOtherMsg(infoID);
            string room = dtInfoID.Rows[0]["RoomName"].ToString();
            string euipmentName = dtInfoID.Rows[0]["EquipmentName"].ToString();
            string infoIDMsg = room + euipmentName;
            successInfoID = successInfoID + infoIDMsg + ",";
            if (successInfoID.Length > 0 && failInfoID.Length > 0)
            {
                MessageBox.Show("【" + successInfoID.Substring(0, successInfoID.Length - 1) + "】发送服务器IP成功，【" + failInfoID.Substring(0, failInfoID.Length - 1) + "】发送服务器IP失败！");
            }
            if (successInfoID.Length > 0 && failInfoID.Length <= 0)
            {
                MessageBox.Show("【" + successInfoID.Substring(0, successInfoID.Length - 1) + "】发送服务器IP成功，没有任何设备发送服务器IP失败！");
            }
            if (successInfoID.Length <= 0 && failInfoID.Length > 0)
            {
                MessageBox.Show("没有任何设备发送服务器IP成功，【" + failInfoID.Substring(0, failInfoID.Length - 1) + "】发送服务器IP失败！");
            }
            if (successInfoID.Length <= 0 && failInfoID.Length <= 0)
            {
                MessageBox.Show("所有设备发送服务器Ip均失败！");
            }
        }
        public void SetFail(string infoID, object e)
        {
            DataTable dtInfoID = new Equipment().SelectOtherMsg(infoID);
            string room = dtInfoID.Rows[0]["RoomName"].ToString();
            string euipmentName = dtInfoID.Rows[0]["EquipmentName"].ToString();
            string infoIDMsg = room + euipmentName;
            failInfoID = failInfoID + infoIDMsg + ",";
            if (successInfoID.Length > 0 && failInfoID.Length > 0)
            {
                MessageBox.Show("【" + successInfoID.Substring(0, successInfoID.Length - 1) + "】发送服务器IP成功，【" + failInfoID.Substring(0, failInfoID.Length - 1) + "】发送服务器IP失败！");
            }
            if (successInfoID.Length > 0 && failInfoID.Length <= 0)
            {
                MessageBox.Show("【" + successInfoID.Substring(0, successInfoID.Length - 1) + "】发送服务器IP成功，没有任何设备发送服务器IP失败！");
            }
            if (successInfoID.Length <= 0 && failInfoID.Length > 0)
            {
                MessageBox.Show("没有任何设备发送服务器IP成功，【" + failInfoID.Substring(0, failInfoID.Length - 1) + "】发送服务器IP失败！");
            }
            if (successInfoID.Length <= 0 && failInfoID.Length <= 0)
            {
                MessageBox.Show("所有设备发送服务器Ip均失败！");
            }
        }

        #endregion

        #region 提交修改服务器IP
        private void btnSubmmit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要修改服务器的IP吗？如果修改失败会导致失去通讯！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string ipAddress = txtIpAddress.Text.ToString();
                string port = txtport.Text.Trim();
                string subnetMask = "";
                string gateway = "";
                DataTable dtSelect = new ServerIP().SelectServerIP();
                if (dtSelect.Rows.Count > 0)
                {
                    new ServerIP().UpdateServerIP(ipAddress, port, subnetMask, gateway);
                }
                else
                {
                    new ServerIP().InsertServerIP(ipAddress, port, subnetMask, gateway);
                }
                DataTable dtInfo = new ServerIP().SelectInfo();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    string infoID = dtInfo.Rows[i]["InfoID"].ToString();
                    Controller.SetServerIP(infoID, SetSuccess, SetFail, ipAddress + "." + port);
                }
                this.Close();
            }
            else
            {
                return;
            }
        }
        #endregion

    }
}
