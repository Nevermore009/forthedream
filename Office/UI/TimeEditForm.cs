using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using System.Collections;

namespace UI
{
    public partial class TimeEditForm : Form
    {
        public TimeEditForm()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void TimeEditForm_Load(object sender, EventArgs e)
        {
            string infoID = ((TimersForm)this.Owner).passValueTimer;
            DataTable dttimers = new TimerMgr().GetAvailableTimerByInfoID(infoID);
            dateTimePicker1.Text=dttimers.Rows[0]["Starttime"].ToString();
            dateTimePicker2.Text = dttimers.Rows[0]["Stoptime"].ToString();
            string repeatTime = dttimers.Rows[0]["RepeatTimes"].ToString();
            if (repeatTime.Contains("1"))
            {
                chkBox1.Checked = true;
            }
            if (repeatTime.Contains("2"))
            {
                chkBox2.Checked = true;
            }
            if (repeatTime.Contains("3"))
            {
                chkBox3.Checked = true;
            }
            if (repeatTime.Contains("4"))
            {
                chkBox4.Checked = true;
            }
            if (repeatTime.Contains("5"))
            {
                chkBox5.Checked = true;
            }
            if (repeatTime.Contains("6"))
            {
                chkBox6.Checked = true;
            }
            if (repeatTime.Contains("7"))
            {
                chkBox7.Checked = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string infoID = ((TimersForm)this.Owner).passValueTimer;
            string startTime = dateTimePicker1.Text;
            string stopTime = dateTimePicker2.Text;
            if (MessageBox.Show("确定要修改定时管理吗?", "确认消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                ArrayList arrayList = new ArrayList();
                if (chkBox1.Checked == true)
                {
                    arrayList.Add("1");
                }
                if (chkBox2.Checked == true)
                {
                    arrayList.Add("2");
                }
                if (chkBox3.Checked == true)
                {
                    arrayList.Add("3");
                }
                if (chkBox4.Checked == true)
                {
                    arrayList.Add("4");
                }
                if (chkBox5.Checked == true)
                {
                    arrayList.Add("5");
                }
                if (chkBox6.Checked == true)
                {
                    arrayList.Add("6");
                }
                if (chkBox7.Checked == true)
                {
                    arrayList.Add("7");
                }
                string timerRepeat = "";
                for (int i = 0; i < arrayList.Count; i++)
                {
                    timerRepeat += arrayList[i] + ",";
                }
                if (timerRepeat.Length == 0)
                {
                    timerRepeat = "0,";
                }
                new TimerMgr().UpdateTimers(infoID, startTime, stopTime, timerRepeat);
            }
            ((TimersForm)this.Owner).BindTimerEquipment();
            MessageBox.Show(this, "设备定时更新成功!");
            this.Close();
        }
    }
}
