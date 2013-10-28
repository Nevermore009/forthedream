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
    public partial class BatchManagerForm : Form
    {
        public static string floorID;
        public static string equipmentName;
        public static string floorName;
        private Equipment equipmentbll = new Equipment();
        public BatchManagerForm()
        {
            InitializeComponent();
            BindAllFloor();
            BindAllEquipmentName();
        }

        #region 绑定楼层和设备
        public void BindAllFloor()
        {
            Common.BindCombobox(cmbFloor, new Floor().GetAllFloor(), "FloorName", "FloorID", "全部楼层");
        }
        public void BindAllEquipmentName()
        {
            Common.BindCombobox(cmbEquipmentName, new Floor().GetAllEquipmentName(), "EquipmentName", "EquipmentName", "空调和照明");
        }
        #endregion

        #region 供电
        private void btnSetOn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
             floorID = cmbFloor.SelectedValue.ToString();
             equipmentName = cmbEquipmentName.SelectedValue.ToString();
             floorName = cmbFloor.Text.ToString();
            if (MessageBox.Show("确定要给【" + floorName + "】的【" + equipmentName + "】供电吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (floorName == "全部楼层")
                {
                    if (equipmentName == "空调和照明")
                    {
                        dt = new BatchSet().NFandNE();
                    }
                    else
                    {
                        dt = new BatchSet().NFandYE(equipmentName);
                    }
                }
                else
                {
                    if (equipmentName == "空调和照明")
                    {
                        dt = new BatchSet().YFandNE(floorID);
                    }
                    else
                    {
                        dt = new BatchSet().YFandYE(floorID, equipmentName);
                    }
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string infoID = dt.Rows[i]["InfoID"].ToString();
                    Controller.SetOn(infoID, OfferSuccess, OfferFailed);
                }
            }
            else
            {
                MessageBox.Show("您取消了【" + floorName + "】的【" + equipmentName + "】供电！");
                return;
            }

        }
        #endregion

        #region 断电
        private void btnSetOff_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string floorID = cmbFloor.SelectedValue.ToString();
            string equipmentName = cmbEquipmentName.SelectedValue.ToString();
            string floorName = cmbFloor.Text.ToString();
            if (MessageBox.Show("确定要给【" + floorName + "】的【" + equipmentName + "】断电吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (floorName == "全部楼层")
                {
                    if (equipmentName == "空调和照明")
                    {
                        dt = new BatchSet().NFandNE();
                    }
                    else
                    {
                        dt = new BatchSet().NFandYE(equipmentName);
                    }
                }
                else
                {
                    if (equipmentName == "空调和照明")
                    {
                        dt = new BatchSet().YFandNE(floorID);
                    }
                    else
                    {
                        dt = new BatchSet().YFandYE(floorID, equipmentName);
                    }
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string infoID = dt.Rows[i]["InfoID"].ToString();
                    Controller.SetOff(infoID, BreakSuccess, BreakFailed);
                }
            }
            else
            {
                MessageBox.Show("您取消了【" + floorName + "】的【" + equipmentName + "】断电！");
                return;
            }
        }
        #endregion

        #region 客户端回调函数
        public void OfferSuccess(string InfoID, object e)
        {
            SetPowerOn(InfoID);
        }
        public void OfferFailed(string InfoID, object e)
        {
        }
        public void SetPowerOn(string infoid)
        {
            equipmentbll.UpdateEquipmentState("1", infoid);
            MessageBox.Show("【" + floorName + "】的【" + equipmentName + "】供电成功！");
            MainForm parent = (MainForm)this.Owner;
            parent.ReFlashSuccess();
        }
        public void BreakSuccess(string InfoID, object e)
        {
            SetPowerOff(InfoID);
        }

        public void BreakFailed(string InfoID, object e)
        {
        }
        public void SetPowerOff(string infoID)
        {
            equipmentbll.UpdateEquipmentState("0", infoID);
            MessageBox.Show("【" + floorName + "】的【" + equipmentName + "】断电成功！");
            MainForm parent = (MainForm)this.Owner;
            parent.ReFlashSuccess();
        }
        #endregion
    }
}
