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

    public partial class IPSetting : Form
    {
        public static string infoID = "";
        public IPSetting()
        {
            InitializeComponent();
        }

        private void IPSetting_Load(object sender, EventArgs e)
        {
            BindDataGridView();
        }
        public void BindDataGridView()
        {
            DataTable dt = new IPManager().GetAllEquipment();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt.DefaultView;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                infoID = dataGridView1.Rows[e.RowIndex].Cells["equipmentid"].Value.ToString();
                EditIPAddress ipEdit = new EditIPAddress();
                //用于传值
                ipEdit.Owner = this;
                //用于传值
                ipEdit.Show();
            }
        }

        #region 用于传值
        public string passValue
        {
            get { return infoID; }
        }

        #endregion

        #region  终端响应更改回调查函数
        public void ClientIPChangedSuccess(string infoID, object e)
        {
            string[] para = e.ToString().Split('|');
            string ipAddress = para[0];
            string duankou = para[1];
            string netMask = para[2];
            string gateWay = para[3];
            string macAddress = para[4];
            bool flag = new IPManager().UpdateIp(infoID, ipAddress, duankou, netMask, gateWay, macAddress);
            DataTable dt = new Equipment().GetEquipmentById(infoID);
            string equipment = dt.Rows[0]["FloorName"].ToString() + dt.Rows[0]["RoomName"].ToString() + "房间的" + dt.Rows[0]["EquipmentName"].ToString();
            if (flag)
                MessageBox.Show("[" + equipment + "]IP设置成功");
            else
                MessageBox.Show("[" + equipment + "]IP设置失败！");
            BindDataGridView();
        }

        public void ClientIPChangedFailed(string infoID, object e)
        {
            DataTable dt = new Equipment().GetEquipmentById(infoID);
            string equipment = dt.Rows[0]["FloorName"].ToString() + dt.Rows[0]["RoomName"].ToString() + "房间的" + dt.Rows[0]["EquipmentName"].ToString();
            MessageBox.Show("[" + equipment + "]IP设置失败！");
        }

        #endregion

    }
}
