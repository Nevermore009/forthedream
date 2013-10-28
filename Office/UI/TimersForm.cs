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
using System.Configuration;

namespace UI
{
    public partial class TimersForm : Form
    {
        private Equipment Euipmentbll = new Equipment();
        private static BLL.Group groupmgr = new BLL.Group();
        private static Room room = new Room();
        private static TimerMgr timermgr = new TimerMgr();
        public static string InfoIDPass = "";
        public TimersForm()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        public string passValueTimer
        {
            get { return InfoIDPass; }
        }

        #region Form_Load事件
        private void Timers_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            DataTable alldt = Euipmentbll.GetEquipmentTreeList();    //所有房间列表
            TreeNode root = new TreeNode("所有房间");
            treeView1.Invoke((MethodInvoker)delegate() { treeView1.Nodes.Add(root); });
            ParentAndChild[] pandc = new ParentAndChild[] { new ParentAndChild(null, "floorid", "floorname"), new ParentAndChild("floorid", "RoomID", "roomname"), new ParentAndChild("RoomID", "InfoID", "EquipmentName") };
            Common.BindTreeView(alldt, root.Nodes, null, pandc, 0);
            root.Expand();

            TreeNode grouproot = new TreeNode("群组");
            treeView1.Nodes.Add(grouproot);
            DataTable groupdt = groupmgr.GetGroupListEquipment();
            pandc = new ParentAndChild[] { new ParentAndChild(null, "groupID", "groupName"), new ParentAndChild("groupID", "RoomID", "RoomName"), new ParentAndChild("RoomID", "InfoID", "EquipmentName") };
            Common.BindTreeView(groupdt, grouproot.Nodes, null, pandc, 0);
            grouproot.Expand();
            DataTable dttimers = timermgr.GetAvailableTimer();
            BindgrvTimers(dttimers);
        }

        #endregion

        #region 添加定时管理
        private void btnadd_Click(object sender, EventArgs e)
        {
            string startTime = dateTimePicker1.Text;
            string stopTime = dateTimePicker2.Text;

            if (MessageBox.Show("确定要批量添加定时管理吗?", "确认消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                TreeNode tn;
                Stack stack = new Stack();
                foreach (TreeNode node in treeView1.Nodes)
                {
                    stack.Push(node);
                }
                while (stack.Count != 0)
                {
                    tn = (TreeNode)stack.Pop();
                    if (tn.Level == 3 && tn.Checked == true)
                    {
                        string infoidCheck = tn.Name.ToString();
                        DataTable dt = new TimerMgr().GetInfoIDExist(infoidCheck);
                        if (dt.Rows.Count > 0)
                        {
                            DataTable dtGetByInfoID = new Equipment().GetEquipmentByInfoID(infoidCheck);
                            string floorName = dtGetByInfoID.Rows[0]["FloorName"].ToString();
                            string roomName = dtGetByInfoID.Rows[0]["RoomName"].ToString();
                            MessageBox.Show("【" + floorName + "】的【" + roomName + "】已经存在设备开启定时，不可以重复定时，请直接点击编辑修改即可！");
                            return;
                        }
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
                        new TimerMgr().TimerEquipmentOffer(startTime, stopTime, tn.Name, timerRepeat);
                        continue;
                    }
                    for (int i = 0; i < tn.Nodes.Count; i++)
                    {
                        stack.Push(tn.Nodes[i]);
                    }
                }
                MessageBox.Show(this, "设备定时管理成功！");
                DataTable dttimers = timermgr.GetAvailableTimer();
                BindgrvTimers(dttimers);
            }
            else
            {
                return;
            }
        }

        #endregion

        #region 绑定TreeView


        /// <summary>
        /// 绑定TreeView（利用TreeNodeCollection）
        /// </summary>
        /// <param name="tnc">TreeNodeCollection（TreeView的节点集合）</param>
        /// <param name="pid">父节点ID</param>
        /// <param name="id">节点ID</param>
        /// <param name="text">节点显示值</param>
        private void Bind_Tv(DataTable dt, TreeNodeCollection tnc, string pid_val, ParentAndChild[] pandc, int level)
        {
            DataView dv = new DataView(dt);
            TreeNode tn;
            if (!string.IsNullOrEmpty(pandc[level].Pid))
            {
                dv.RowFilter = string.Format(pandc[level].Pid + "='{0}'", pid_val);
            }

            dv = new DataView(dv.ToTable(true, pandc[level].ID, pandc[level].Name));

            foreach (DataRowView drv in dv)
            {
                if (string.IsNullOrEmpty(drv[pandc[level].ID].ToString()))
                    continue;
                tn = new TreeNode();
                tn.Name = drv[pandc[level].ID].ToString();
                tn.Text = drv[pandc[level].Name].ToString();
                tnc.Add(tn);
                if (level + 1 < pandc.Length)
                    Bind_Tv(dt, tn.Nodes, tn.Name, pandc, level + 1);
            }
        }

        #endregion

        #region 绑定datagridview

        private void BindgrvTimers(DataTable dt)
        {
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = dt;
        }

        #endregion

        #region AfterCheck
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            foreach (TreeNode c in node.Nodes)
            {
                c.Checked = node.Checked;
            }
        }
        #endregion

        #region 编辑设备定时
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && dataGridView2.Columns[e.ColumnIndex].Name == "Update")
            {
                TimeEditForm editTime = new TimeEditForm();
                InfoIDPass = dataGridView2.Rows[e.RowIndex].Cells["InfoID"].Value.ToString();
                editTime.Owner = this;
                editTime.Show();
            }
            if (e.ColumnIndex != -1 && dataGridView2.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("确定要删除该设备定时吗？", "确认消息", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string infoIDDelete = dataGridView2.Rows[e.RowIndex].Cells["InfoID"].Value.ToString();
                    new TimerMgr().DeleteTimers(infoIDDelete);
                    MessageBox.Show("该设备定时删除成功！");
                    DataTable dttimers = timermgr.GetAvailableTimer();
                    BindgrvTimers(dttimers);
                }
            }
        }
        #endregion

        #region 合并相同列
        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == 1 || e.ColumnIndex == 0) && e.RowIndex != -1)
            {
                using (Brush gridBrush = new SolidBrush(this.dataGridView2.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        // 清除单元格
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                        // 画 Grid 边线（仅画单元格的底边线和右边线）
                        // 如果下一行和当前行的数据不同，则在当前的单元格画一条底边线
                        if (e.RowIndex < dataGridView2.Rows.Count - 1 && dataGridView2.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value.ToString() != e.Value.ToString())
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left + 2, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                        //画最后一条记录的底线
                        if (e.RowIndex == dataGridView2.Rows.Count - 1)
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left + 2, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                        // 画右边线
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                        // 画左边线
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left + 2, e.CellBounds.Top, e.CellBounds.Left + 2, e.CellBounds.Bottom);
                        // 画（填写）单元格内容，相同的内容的单元格只填写第一个
                        if (e.Value != null)
                        {
                            if (e.RowIndex > 0 && dataGridView2.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value.ToString() == e.Value.ToString())
                            {

                            }
                            else
                            {
                                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault);
                            }
                        }
                        e.Handled = true;
                    }
                }
            }

        }

        #endregion

        #region 初始化所有定时设备
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要初始化设备定时吗?该操作会清空所有设备定时状况，请谨慎操作", "确认消息", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                new TimerMgr().DeleteAllTimers();
                MessageBox.Show("初始化所有定时设备成功！");
                DataTable dttimers = timermgr.GetAvailableTimer();
                BindgrvTimers(dttimers);
            }
            else
            {
                return;
            }
        }
        #endregion

        #region 绑定所有已经定时的设备
        public void BindTimerEquipment()
        {
            DataTable dttimers = timermgr.GetAvailableTimer();
            BindgrvTimers(dttimers);
        }
        #endregion
    }
}
