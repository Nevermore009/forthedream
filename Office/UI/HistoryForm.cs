using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using System.Data.SqlClient;
using System.Configuration;

namespace UI
{
    public partial class HistoryForm : Form
    {
        private static Electricity electricity = new Electricity();
        private static Floor floorbll = new Floor();
        private static Room room = new Room();
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void History_Load(object sender, EventArgs e)
        {
            this.FindForm().Icon = new Icon(ConfigurationManager.AppSettings["logo"]);
            BindDropFloor();
            DataTable dt = electricity.GetAllHistory();
            BindgrvHistory(dt);

        }

        private void BindgrvHistory(DataTable dt)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }

        private void BindDropFloor()
        {
            DataTable dt = floorbll.GetFloorList();
            Common.BindCombobox(cmbfloor, dt, "FloorName", "FloorId", "--请选择--");
        }

        private void cmbfloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbfloor.SelectedIndex == 0)
            {
                btnsearch.Enabled = false;
            }    
            if (cmbfloor.SelectedIndex > 0)
            {
                DataTable dt = room.GetRoomByFloorID(cmbfloor.SelectedValue.ToString());
                Common.BindCombobox(cmbroom, dt, "roomname", "roomid", "--全部--");
                btnsearch.Enabled = true;
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string conditions = " 3=3 ";
            List<SqlParameter> paralist = new List<SqlParameter>();
            if (cmbfloor.SelectedIndex > 0)
            {
                conditions += " and t4.floorid=@floorid";
                paralist.Add(new SqlParameter("@floorid", cmbfloor.SelectedValue));
            }
            if (cmbroom.SelectedIndex==0)
            {
                conditions += " and  convert(date,t1.createtime) between @sdate and @edate ";
                paralist.Add(new SqlParameter("@sdate", dateTimePicker1.Text));
                paralist.Add(new SqlParameter("@edate", dateTimePicker2.Text));
                DataTable dt = electricity.GetHistoryByCondition(conditions, paralist.ToArray());
                BindgrvHistory(dt);
            }
            if (cmbroom.SelectedIndex > 0)
            {
                conditions += " and  t3.roomid=@roomid";
                paralist.Add(new SqlParameter("@roomid", cmbroom.SelectedValue));
                conditions += " and  convert(date,t1.createtime) between @sdate and @edate ";
                paralist.Add(new SqlParameter("@sdate", dateTimePicker1.Text));
                paralist.Add(new SqlParameter("@edate", dateTimePicker2.Text));
                DataTable dt = electricity.GetHistoryByCondition(conditions, paralist.ToArray());
                BindgrvHistory(dt);
            }
        }
    }
}
