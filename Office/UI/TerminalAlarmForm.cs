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
    public partial class TerminalAlarmForm : Form
    {
        public static string maxTemp;
        public static string ipAddress;
        public static string minTemp;
        string successInfoID = "";
        string failInfoID = "";
        public TerminalAlarmForm()
        {
            InitializeComponent();
        }

        private void TerminalAlarmForm_Load(object sender, EventArgs e)
        {
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = new TerminalAlarm().GetAllAirCondition();
        }

        #region 客户端回调函数

        public void SetTempSuccess(string InfoID, object e)
        {
            successInfoID = "";
            new TerminalAlarm().UpdateTemperature(minTemp, maxTemp, ipAddress);
            DataTable dtInfoID = new Equipment().SelectOtherMsg(InfoID);
            string room = dtInfoID.Rows[0]["RoomName"].ToString();
            string euipmentName = dtInfoID.Rows[0]["EquipmentName"].ToString();
            string infoIDMsg = room + euipmentName;
            successInfoID = successInfoID + infoIDMsg;
            MessageBox.Show("【" + successInfoID + "】温度修改成功！");
        }
        public void SetTempFail(string InfoID, object e)
        {
            failInfoID = "";
            DataTable dtInfoID = new Equipment().SelectOtherMsg(InfoID);
            string room = dtInfoID.Rows[0]["RoomName"].ToString();
            string euipmentName = dtInfoID.Rows[0]["EquipmentName"].ToString();
            string infoIDMsg = room + euipmentName;
            failInfoID = failInfoID + infoIDMsg;
            MessageBox.Show("【" + failInfoID + "】温度修改失败！");
        }
        public void GetTempSuccess(string infoID, object e)
        {
            successInfoID = "";
            DataTable dtInfoID = new Equipment().SelectOtherMsg(infoID);
            string room = dtInfoID.Rows[0]["RoomName"].ToString();
            string euipmentName = dtInfoID.Rows[0]["EquipmentName"].ToString();
            string infoIDMsg = room + euipmentName;
            successInfoID = successInfoID + infoIDMsg;
            double currentTemperature = Convert.ToDouble(e);
            double maxTemp = Convert.ToDouble(dtInfoID.Rows[0]["MaxTemperature"]);
            double minTemp = Convert.ToDouble(dtInfoID.Rows[0]["MinTemperature"]);
            if (currentTemperature > maxTemp)
            {
                MessageBox.Show("【" + successInfoID + "】当前温度是【" + currentTemperature + "°C】,已经大于温度的最大值！");
            }
            if (currentTemperature < minTemp)
            {
                MessageBox.Show("【" + successInfoID + "】当前温度是【" + currentTemperature + "°C】,已经小于温度的最小值！");
            }
            if (currentTemperature >= minTemp && currentTemperature <= maxTemp)
            {
                MessageBox.Show("【" + successInfoID + "】当前温度是【" + currentTemperature + "°C】！");
            }
        }
        public void GetTempFail(string infoID, object e)
        {
            failInfoID = "";
            DataTable dtInfoID = new Equipment().SelectOtherMsg(infoID);
            string room = dtInfoID.Rows[0]["RoomName"].ToString();
            string euipmentName = dtInfoID.Rows[0]["EquipmentName"].ToString();
            string infoIDMsg = room + euipmentName;
            failInfoID = failInfoID + infoIDMsg;
            MessageBox.Show("【" + failInfoID + "】温度获取失败！");
        }

        #endregion

        #region 点击DataGridView事件
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            #region 修改温度
            if (e.ColumnIndex == 5)
            {
                if (MessageBox.Show("确定要修改设备温度吗?", "确认消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    DataGridViewRow column = dataGridView2.Rows[e.RowIndex];
                    string infoID = column.Cells["InfoID"].Value.ToString();
                    ipAddress = column.Cells["localIPAddress"].Value.ToString();
                    minTemp = column.Cells["MinTemperature"].Value.ToString();
                    maxTemp = column.Cells["MaxTemperature"].Value.ToString();
                    string temp = maxTemp + "." + minTemp + ".";
                    Controller.SetTemperate(infoID, SetTempSuccess, SetTempFail, temp);
                }
                else
                {
                    return;
                }
            }
            #endregion

            #region 询问当前温度
            if (e.ColumnIndex == 6)
            {
                if (MessageBox.Show("确定要询问设备温度吗?", "确认消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    DataGridViewRow column = dataGridView2.Rows[e.RowIndex];
                    string _infoID = column.Cells["InfoID"].Value.ToString();
                    string _ipAddress = column.Cells["localIPAddress"].Value.ToString();
                    Controller.GetTemperate(_infoID, GetTempSuccess, GetTempFail);
                }
                else
                {
                    return;
                }
            }
            #endregion

        }
        #endregion

    }
}
