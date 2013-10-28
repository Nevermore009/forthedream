using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using System.Collections;
using System.Configuration;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace UI
{
    public partial class MainForm : Form
    {

        #region 变量的定义
        private Electricity electricitybll = new Electricity();
        private Equipment equipmentbll = new Equipment();
        private Room roommgr = new Room();
        private Floor floormgr = new Floor();
        private BLL.Group groupmgr = new BLL.Group();
        List<string> openSuccess = new List<string>();     //初始化时获取到状态为供电的ID列表
        List<string> closeSuccess = new List<string>();     //初始化时获取到状态为断电的ID列表
        List<string> fail = new List<string>();                    //初始化时获取状态失败的设备ID列表
        private static int count;                                          //设备总数，初始读取状态时使用
        private static Boolean needFresh = false;               //当需要刷新datagridview1时将其设为true,再由定时器来刷新,以避免多线程操作datagridview而产生的错误
        ProgressBar pgb = new ProgressBar();
        ArrayList tempAlarmMax = new ArrayList();
        ArrayList tempAlarmMin = new ArrayList();
        #endregion

        #region MainForm
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            pgb.Show();
            pgb.TopMost = true;
            timerClocked.Start();
            DataTable dtUsers = new User().UserMsg(Program.userName);
        }
        #endregion

        #region Form事件
        private void Main_Load(object sender, EventArgs e)
        {
            this.FindForm().Text = ConfigurationManager.AppSettings["applicationname"];
            this.FindForm().Icon = new Icon(ConfigurationManager.AppSettings["logo"]);
            SkinInit();
            Communicate.Start();
            count = new BLL.Equipment().EquipmentCount();//获取设备总数
            this.dataGridView1.Columns["EquipmentName"].DefaultCellStyle.ForeColor = Color.Black;
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitRoomTree();
            InitGroupTree();
            InitEquipmentState();
            Bind_dataGridView1();
            BindAllFloorName();
        }

       
        #endregion

        #region 绑定楼层号码
        public void BindAllFloorName()
        {
            Common.BindCombobox(cmbFloorName, new Floor().GetAllFloor(), "FloorName", "FloorName", "全部楼层");
        }
        #endregion

        #region 所有数据刷新（初始化）

        private void InitRoomTree()
        {
            roomtree.Nodes.Clear();
            DataTable alldt = equipmentbll.GetEquipmentTreeList();    //所有房间列表
            TreeNode root = new TreeNode("所有房间");
            roomtree.Invoke((MethodInvoker)delegate() { roomtree.Nodes.Add(root); });
            ParentAndChild[] pandc = new ParentAndChild[] { new ParentAndChild(null, "floorid", "floorname"), new ParentAndChild("floorid", "RoomID", "roomname"), new ParentAndChild("RoomID", "InfoID", "EquipmentName") };
            Common.BindTreeView(alldt, root.Nodes, null, pandc, 0);
            root.Expand();
            AddMenu(root);
        }

        public void InitGroupTree()
        {
            grouptree.Nodes.Clear();
            TreeNode grouproot = new TreeNode("群组");
            grouptree.Nodes.Add(grouproot);
            DataTable groupdt = groupmgr.GetGroupListEquipment();
            ParentAndChild[] pandc = new ParentAndChild[] { new ParentAndChild(null, "groupID", "groupName"), new ParentAndChild("groupID", "RoomID", "RoomName"), new ParentAndChild("RoomID", "InfoID", "EquipmentName") };
            Common.BindTreeView(groupdt, grouproot.Nodes, null, pandc, 0);
            grouproot.Expand();
            AddGroupMenu(grouproot);
        }

        protected void InitEquipmentState()   //读取房间状态
        {
            DataTable equipmentdt = equipmentbll.GetEquipmentList();
            foreach (DataRow dr in equipmentdt.Rows)
            {
                BLL.Message msg = new BLL.Message();
                string infoid = dr["infoid"].ToString();
                Controller.ReadState(infoid, GetStateSuccess, GetStateFailed);
            }
        }

        protected void InitStateImage()
        {
            DataTable equipmentdt = equipmentbll.GetEquipmentList();
            TreeNode tn;
            Stack stack = new Stack();
            foreach (TreeNode n in roomtree.Nodes)
            {
                stack.Push(n);
            }
            foreach (TreeNode n in grouptree.Nodes)
            {
                stack.Push(n);
            }
            while (stack.Count > 0)
            {
                tn = (TreeNode)stack.Pop();
                if (tn.Level == 3)
                {
                    DataRow[] rows = equipmentdt.Select("infoid=" + tn.Name);
                    foreach (DataRow r in rows)
                    {
                        if (r["equipmentstate"].ToString() == "0")
                            tn.ImageIndex = 0;
                        else if (r["equipmentstate"].ToString() == "1")
                            tn.ImageIndex = 1;
                        else
                            tn.ImageIndex = 2;
                    }
                }
                else
                {
                    tn.ImageIndex = 3;
                }
                foreach (TreeNode n in tn.Nodes)
                    stack.Push(n);
            }
            pgb.Close();
            this.WindowState = FormWindowState.Normal;
            pgb.Visible = false;

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            InitRoomTree();
            InitGroupTree();
            InitStateImage();
            Bind_dataGridView1();
            lbstate.Text = "已刷新";

        }

        #endregion

        #region 主题皮肤初始化
        private void SkinInit()
        {
            foreach (ToolStripMenuItem item in skinset.DropDownItems)
            {
                string skin = ConfigurationManager.AppSettings["skin"].TrimStart("skin/".ToCharArray()).TrimEnd(".ssk".ToCharArray());
                if (item.Name == skin)
                {
                    item.Checked = true;
                    break;
                }
            }
        }
        #endregion

        #region 绑定所有单元格的颜色
        public void BindDataColor()
        {
            string floorName = cmbFloorName.Text.ToString();
            DataTable dt = new DataTable();
            if (floorName == "全部楼层")
            {
                dt = new Equipment().GetEquipmentsByState();
            }
            if (floorName.Length > 0 && floorName != "全部楼层")
            {
                dt = new Equipment().GetEquipmentByFloor(floorName);
            }
            if (dt.Rows.Count > 0)
            {
                this.dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dt;
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int index = 0;
                    string infoID = dt.Rows[i]["InfoID"].ToString();
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        if (infoID == dataGridView1.Rows[j].Cells["InfoID"].Value.ToString())
                        {
                            index = j;
                        }
                    }
                    string equipmengState = dt.Rows[i]["EquipmentState"].ToString();
                    if (equipmengState == "0")
                    {
                        //断电成功
                        dataGridView1.Rows[index].Cells["EquipmentName"].Style.BackColor = Color.FromArgb(252, 92, 88);
                    }
                    if (equipmengState == "1")
                    {
                        //供电成功
                        dataGridView1.Rows[index].Cells["EquipmentName"].Style.BackColor = Color.FromArgb(106, 192, 56);
                    }
                    if (equipmengState == "2")
                    {
                        //未知状态
                        dataGridView1.Rows[index].Cells["EquipmentName"].Style.BackColor = Color.FromArgb(199, 200, 202);
                    }
                }
            }
            else
            {
                return;
            }
        }

        #endregion

        #region 添加设备
        /// <summary>
        /// 添加设备
        /// </summary>
        public bool AddEquipment(string EquipmentName, string roomid)
        {
            if (MessageBox.Show("确定要添加" + EquipmentName + "吗? ", "提示 ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // bool isExist = equipmentbll.IsExist(roomid, EquipmentName);
                // if (isExist)
                // {
                //     MessageBox.Show(EquipmentName + "已经存在，请勿重复添加！");
                //     return false;
                // }
                equipmentbll.AddEquipment(roomid, EquipmentName);
                MessageBox.Show(this, "添加" + EquipmentName + "成功！");
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region TreeView事件

        private void RoomTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            foreach (TreeNode c in node.Nodes)
            {
                c.Checked = node.Checked;
            }
        }
        private void AddGroupMenu(TreeNode rootNode)    //添加群组右键快捷菜单
        {
            ContextMenuStrip menu = null;

            TreeNode tn = null;
            Stack stack = new Stack();
            stack.Push(rootNode);
            while (stack.Count != 0)
            {
                tn = (TreeNode)stack.Pop();
                if (tn.ContextMenu != null)
                {
                    continue;
                }
                else if (tn.Level == 3)
                {
                    menu = new ContextMenuStrip();
                    menu.Items.Add("供电", null, (object sender, EventArgs e) =>
                    {
                        if (MessageBox.Show("确定要打开该设备吗? ", "提示 ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            ToolStripMenuItem item = (ToolStripMenuItem)sender;
                            string infoID = item.Owner.Name;
                            Controller.SetOn(infoID, OfferSuccess, OfferFailed);
                            lbstate.Text = "已发送供电请求";
                        }
                        else
                        {
                            lbstate.Text = "已取消";
                            return;
                        }
                    });
                    menu.Items.Add("断电", null, (object sender, EventArgs e) =>
                    {
                        if (MessageBox.Show("确定要断电该设备吗? ", "提示 ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            ToolStripMenuItem item = (ToolStripMenuItem)sender;
                            string infoID = item.Owner.Name;
                            Controller.SetOn(infoID, BreakSuccess, BreakFailed);
                        }
                        else
                        {
                            return;
                        }
                    });
                }
                else if (tn.Level == 1)
                {
                    menu = new ContextMenuStrip();
                    menu.Items.Add("编辑", null, (object sender, EventArgs e) =>
                    {
                        ToolStripMenuItem item = (ToolStripMenuItem)sender;
                        GroupForm gf = new UI.GroupForm(item.Owner.Name);
                        gf.Owner = this.FindForm();
                        gf.Show();
                        ReFlashSuccess();
                    });
                    menu.Items.Add("删除", null, (object sender, EventArgs e) =>
                    {
                        ToolStripMenuItem item = (ToolStripMenuItem)sender;
                        string groupID = item.Owner.Name;
                        if (MessageBox.Show("确定要删除该组吗?", "提示消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            bool flag = new Group().DeleteGroup(groupID);
                            if (flag)
                            {
                                MessageBox.Show("群组删除成功！");
                                InitGroupTree();
                                ReFlashSuccess();

                            }
                            else
                            {
                                MessageBox.Show("群组删除失败！");
                                return;
                            }
                        }
                    });
                }
                else if (tn.Level == 0)
                {
                    menu = new ContextMenuStrip();
                    menu.Items.Add("创建群组", null, (object sender, EventArgs e) =>
                    {
                        GroupForm gf = new UI.GroupForm();
                        gf.Owner = this.FindForm();
                        gf.Show();
                    });
                }
                else
                {
                    menu = new ContextMenuStrip();
                }

                menu.Name = tn.Name;
                tn.ContextMenuStrip = menu;
                for (int i = 0; i < tn.Nodes.Count; i++)
                {
                    stack.Push(tn.Nodes[i]);
                }
            }
        }

        /// <summary>
        /// 添加设备以后刷新
        /// </summary>
        public void ReFlashSuccess()
        {
            InitRoomTree();
            InitGroupTree();
            InitStateImage();
            Bind_dataGridView1();
        }
        /// <summary>
        /// 添加右键菜单
        /// </summary>
        private void AddMenu(TreeNode rootNode)
        {
            ContextMenuStrip menu = null;
            TreeNode tn = null;
            Stack stack = new Stack();
            stack.Push(rootNode);
            while (stack.Count != 0)
            {
                tn = (TreeNode)stack.Pop();
                if (tn.ContextMenu != null)
                {
                    continue;
                }
                else if (tn.Level == 2)
                {
                    menu = new ContextMenuStrip();
                    menu.Items.Add("添加空调", null, (object sender, EventArgs e) =>
                    {
                        ToolStripMenuItem item = (ToolStripMenuItem)sender;
                        string roomid = item.Owner.Name;
                        if (AddEquipment("空调", roomid))
                        {
                            ReFlashSuccess();
                            lbstate.Text = "添加成功";
                        }
                    });
                    menu.Items.Add("添加照明", null, (object sender, EventArgs e) =>
                    {
                        ToolStripMenuItem item = (ToolStripMenuItem)sender;
                        string roomid = item.Owner.Name;
                        if (AddEquipment("照明", roomid))
                        {
                            ReFlashSuccess();
                            lbstate.Text = "添加成功";
                        }
                    });
                    menu.Items.Add("添加插板", null, (object sender, EventArgs e) =>
                    {
                        ToolStripMenuItem item = (ToolStripMenuItem)sender;
                        string roomid = item.Owner.Name;
                        if (AddEquipment("插板", roomid))
                        {
                            ReFlashSuccess();
                            lbstate.Text = "添加成功";
                        }
                    });
                    //menu.Items.Add("删除房间", null, (object sender, EventArgs e) =>
                    //{
                    //    if (MessageBox.Show("确定要删除该房间吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    //    {
                    //        ToolStripMenuItem item = (ToolStripMenuItem)sender;
                    //        string roomID = item.Owner.Name;
                    //        bool deleteRoom = new DelFRE().DeleteRoom(roomID);
                    //        if (deleteRoom)
                    //        {
                    //            MessageBox.Show("房间删除成功！");
                    //        }
                    //        else
                    //        {
                    //            MessageBox.Show("房间删除失败！");
                    //            return;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        return;
                    //    }
                    //});
                    menu.Items.Add("重命名", null, (object sender, EventArgs e) =>
                    {
                        ToolStripMenuItem item = (ToolStripMenuItem)sender;
                        TreeNode[] node = rootNode.TreeView.Nodes[0].Nodes.Find(item.Owner.Name, true);
                        if (node == null || node.Length <= 0)
                        {
                            MessageBox.Show("操作失败!");
                            return;
                        }
                        string roomname = Interaction.InputBox("请输入新的房间名称：", "重命名房间[" + node[0].Text + "]", "新的房间名称", -1, -1);
                        if (roomname != "")
                        {

                            if (roommgr.ChangeNameByID(node[0].Name, roomname))
                            {
                                node[0].Text = roomname;
                                rootNode.TreeView.Refresh();
                                MessageBox.Show("修改成功");
                            }
                            else
                            {
                                MessageBox.Show("保存失败");
                                return;
                            }
                        }
                    });

                }
                else if (tn.Level == 3)
                {
                    menu = new ContextMenuStrip();
                    menu.Items.Add("供电", null, (object sender, EventArgs e) =>
                    {
                        if (MessageBox.Show("确定要打开该设备吗? ", "提示 ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            ToolStripMenuItem item = (ToolStripMenuItem)sender;
                            string infoID = item.Owner.Name;
                            Controller.SetOn(infoID, OfferSuccess, OfferFailed);
                            lbstate.Text = "已发送供电请求";
                        }
                        else
                        {
                            lbstate.Text = "已取消";
                            return;
                        }
                    });
                    menu.Items.Add("断电", null, (object sender, EventArgs e) =>
                    {
                        if (MessageBox.Show("确定要断电该设备吗? ", "提示 ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            ToolStripMenuItem item = (ToolStripMenuItem)sender;
                            string infoID = item.Owner.Name;
                            Controller.SetOn(infoID, BreakSuccess, BreakFailed);
                            lbstate.Text = "已发送断电请求";
                        }
                        else
                        {
                            lbstate.Text = "已取消";
                            return;
                        }
                    });
                    //menu.Items.Add("重置电表", null, (object sender, EventArgs e) =>
                    //{
                    //    if (MessageBox.Show("确定要重置电表吗? ", "提示 ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    //    {
                    //        ToolStripMenuItem item = (ToolStripMenuItem)sender;
                    //        string infoID = item.Owner.Name;
                    //        Controller.ResetMeter(infoID, ResetMeterSuccess, ResetMeterFailed);
                    //        lbstate.Text = "正在清零电表...";
                    //    }
                    //    else
                    //    {
                    //        lbstate.Text = "已取消";
                    //        return;
                    //    }
                    //});
                    menu.Items.Add("删除设备", null, (object sender, EventArgs e) =>
                    {
                        if (MessageBox.Show("确定要删除该设备吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            ToolStripMenuItem item = (ToolStripMenuItem)sender;
                            string infoID = item.Owner.Name;
                            bool deleteEquipment = new DelFRE().DeleteEquipment(infoID);
                            if (deleteEquipment)
                            {
                                MessageBox.Show("删除设备成功！");
                                ReFlashSuccess();
                            }
                            else
                            {
                                MessageBox.Show("删除设备失败！");
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    });
                }
                else if (tn.Level == 1)
                {
                    menu = new ContextMenuStrip();
                    menu.Items.Add("添加房间", null, (object sender, EventArgs e) =>
                    {
                        ToolStripMenuItem item = (ToolStripMenuItem)sender;
                        TreeNode[] node = rootNode.TreeView.Nodes[0].Nodes.Find(item.Owner.Name, true);
                        if (node == null || node.Length <= 0)
                        {
                            MessageBox.Show("操作失败!");
                            return;
                        }
                        string roomname = Interaction.InputBox("请输入新房间的名称：", "添加房间到[" + node[0].Text + "]", "输入新房间的名称", -1, -1);
                        if (roomname != "")
                        {
                            string roomid = roommgr.Add(roomname, node[0].Name);
                            if (roomid != null)
                            {
                                TreeNode newroom = new TreeNode();
                                newroom.Text = roomname;
                                newroom.Name = roomid;
                                node[0].Nodes.Add(newroom);
                                AddMenu(newroom);
                                MessageBox.Show("添加成功");

                            }
                            else
                            {
                                MessageBox.Show("保存失败");
                                return;
                            }
                        }
                    });
                    //menu.Items.Add("删除楼层", null, (object sender, EventArgs e) =>
                    //{
                    //    ToolStripMenuItem item = (ToolStripMenuItem)sender;
                    //    TreeNode[] node = rootNode.TreeView.Nodes[0].Nodes.Find(item.Owner.Name, true);
                    //    string floorID = node[0].Name;
                    //    bool deleteFloor = new DelFRE().DeleteFloor(floorID);
                    //    if (deleteFloor)
                    //    {
                    //        MessageBox.Show("楼层删除成功！");
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("楼层删除失败！");
                    //        return;
                    //    }
                    //});

                    menu.Items.Add("重命名", null, (object sender, EventArgs e) =>
                    {
                        ToolStripMenuItem item = (ToolStripMenuItem)sender;
                        TreeNode[] node = rootNode.TreeView.Nodes[0].Nodes.Find(item.Owner.Name, true);
                        if (node == null || node.Length <= 0)
                        {
                            MessageBox.Show("操作失败!");
                            return;
                        }
                        string floorname = Interaction.InputBox("请输入新的楼层名称：", "[" + node[0].Text + "]重命名", "输入新的楼层名称", -1, -1);
                        if (floorname != "")
                        {

                            if (floormgr.ChangeNameByID(node[0].Name, floorname))
                            {
                                node[0].Text = floorname;
                                MessageBox.Show("修改成功");
                            }
                            else
                            {
                                MessageBox.Show("保存失败");
                                return;
                            }
                        }
                    });
                }
                else if (tn.Level == 0)
                {
                    menu = new ContextMenuStrip();
                    menu.Items.Add("添加楼层", null, (object sender, EventArgs e) =>
                    {
                        string floorname = Interaction.InputBox("请输入楼层名称：", "添加楼层", "输入新楼层的名称", -1, -1);
                        if (floorname != "")
                        {
                            bool addFloor = new Floor().AddFloor(floorname);
                            if (addFloor)
                            {
                                MessageBox.Show("楼层添加成功！");
                                BindAllFloorName();
                                ReFlashSuccess();
                            }
                            else
                            {
                                MessageBox.Show("楼层添加失败！");
                                return;
                            }
                        }
                    });

                    menu.Items.Add("展开全部", null, (object sender, EventArgs e) =>
                    {
                        rootNode.TreeView.ExpandAll();
                    });
                    menu.Items.Add("折叠全部", null, (object sender, EventArgs e) =>
                    {
                        rootNode.TreeView.CollapseAll();
                    });
                }
                else
                {
                    menu = new ContextMenuStrip();
                }
                menu.Name = tn.Name;
                tn.ContextMenuStrip = menu;
                for (int i = 0; i < tn.Nodes.Count; i++)
                {
                    stack.Push(tn.Nodes[i]);
                }
            }
            needFresh = true;
        }

        #endregion

        #region gridview事件

        private void Bind_dataGridView1()
        {
            string floorName = cmbFloorName.Text.ToString();
            DataTable dtSelectDataByFloorID = new DataTable();
            if (floorName == "全部楼层")
            {
                dtSelectDataByFloorID = new Equipment().GetEquipmentsByState();
            }
            if (floorName.Length > 0 && floorName != "全部楼层")
            {
                dtSelectDataByFloorID = new Equipment().GetEquipmentByFloor(floorName);
            }
            dataGridView1.DataSource = null;
            if (dtSelectDataByFloorID.Rows.Count > 0)
            {
                this.dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dtSelectDataByFloorID;
            }
            else
            {
                return;
            }
            BindDataColor();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                needFresh = true;
                return;
            }
            if (e.ColumnIndex != -1 && dataGridView1.Columns[e.ColumnIndex].Name == "Start")
            {
                string equipmentName = dataGridView1.Rows[e.RowIndex].Cells["EquipmentName"].Value.ToString();
                if (MessageBox.Show("确定要打开该" + equipmentName + "的电吗?", "确认消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string infoID = dataGridView1.Rows[e.RowIndex].Cells["InfoID"].Value.ToString();
                    Controller.SetOn(infoID, OfferSuccess, OfferFailed);
                    needFresh = true;
                }
            }
            if (e.ColumnIndex != -1 && dataGridView1.Columns[e.ColumnIndex].Name == "stop")
            {
                string equipmentName = dataGridView1.Rows[e.RowIndex].Cells["EquipmentName"].Value.ToString();
                if (MessageBox.Show("确定要断开该" + equipmentName + "的电吗?", "确认消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string infoID = dataGridView1.Rows[e.RowIndex].Cells["InfoID"].Value.ToString();
                    Controller.SetOff(infoID, BreakSuccess, BreakFailed);
                    needFresh = true;
                }
            }
        }

        #endregion

        #region 供电、停电
        private void btnstart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要对选中设备进行供电吗?", "ConfirmMsg", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TreeNode tn;
                Stack stack = new Stack();
                foreach (TreeNode node in roomtree.Nodes)
                {
                    stack.Push(node);
                }
                foreach (TreeNode node in grouptree.Nodes)
                {
                    stack.Push(node);
                }

                while (stack.Count != 0)
                {
                    tn = (TreeNode)stack.Pop();
                    if (tn.Checked == true && tn.Level == 3)
                    {
                        Controller.SetOn(tn.Name, OfferSuccess, OfferFailed);
                        lbstate.Text = "正在请求供电...";
                        continue;
                    }
                    for (int i = 0; i < tn.Nodes.Count; i++)
                    {
                        stack.Push(tn.Nodes[i]);
                    }
                }

            }
            else
                return;
        }
        private void btnstop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要对选中设备进行断电吗?", "确认消息", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TreeNode tn;
                Stack stack = new Stack();
                foreach (TreeNode node in roomtree.Nodes)
                {
                    stack.Push(node);
                }
                while (stack.Count != 0)
                {
                    tn = (TreeNode)stack.Pop();
                    if (tn.Level == 3 && tn.Checked == true)
                    {
                        Controller.SetOff(tn.Name, BreakSuccess, BreakFailed);
                        lbstate.Text = "正在请求断电...";
                        continue;
                    }
                    for (int i = 0; i < tn.Nodes.Count; i++)
                    {
                        stack.Push(tn.Nodes[i]);
                    }
                }

            }
        }

        public void SetPowerOn(string infoid)
        {
            equipmentbll.UpdateEquipmentState("1", infoid);
            TreeNode LRState = FindNodeByName(infoid, grouptree);
            if (LRState != null)
            {
                LRState.ImageIndex = 1;
            }

            TreeNode tn = FindNodeByName(infoid, roomtree);
            tn.ImageIndex = 1;
            tn.Checked = false;
            string equipmentName = "[" + tn.Parent.Text + "]房间" + tn.Text;
            lbstate.Text = equipmentName + " 供电成功！";

            #region 清除温度报警状态
            //如果该设备已经供电，需要在lblLessMin和lblBeyondMax去掉该设备
            DataTable dtGetEByInfoID = new Equipment().GetEquipmentByInfoID(infoid);
            string floorName1 = dtGetEByInfoID.Rows[0]["FloorName"].ToString();
            string roomName1 = dtGetEByInfoID.Rows[0]["RoomName"].ToString();
            string equipmentNameByInfoID = "[" + floorName1 + roomName1 + "],";
            if (tempAlarmMax.Contains(equipmentNameByInfoID))
            {
                tempAlarmMax.Remove(equipmentNameByInfoID);
            }
            if (tempAlarmMin.Contains(equipmentNameByInfoID))
            {
                tempAlarmMin.Remove(equipmentNameByInfoID);
            }
            lblBeyondMax.Text = "温度过高设备：";
            lblLessMin.Text = "温度过低设备：";
            foreach (var beyondTempByInfoid1 in tempAlarmMax)
            {
                lblBeyondMax.Text += beyondTempByInfoid1.ToString();
            }
            foreach (var lessTempByInofid1 in tempAlarmMin)
            {
                lblLessMin.Text += lessTempByInofid1.ToString();
            }
            //如果该设备已经供电，需要在lblLessMin和lblBeyondMax去掉该设备 
            #endregion
            needFresh = true;

        }

        public void SetPowerOff(string infoID)
        {
            equipmentbll.UpdateEquipmentState("0", infoID);
            TreeNode LRState = FindNodeByName(infoID, grouptree);
            if (LRState != null)
            {
                LRState.ImageIndex = 0;
            }

            TreeNode tn = FindNodeByName(infoID, roomtree);
            tn.ImageIndex = 0;
            tn.Checked = false;
            string equipmentName = "[" + tn.Parent.Text + "]房间" + tn.Text;
            lbstate.Text = equipmentName + " 断电成功！";

            #region 报警状态清除
            //如果该设备已经断电，需要在lblLessMin和lblBeyondMax去掉该设备
            DataTable dtGetEByInfoID = new Equipment().GetEquipmentByInfoID(infoID);
            string floorName1 = dtGetEByInfoID.Rows[0]["FloorName"].ToString();
            string roomName1 = dtGetEByInfoID.Rows[0]["RoomName"].ToString();
            string equipmentNameByInfoID = "[" + floorName1 + roomName1 + "],";
            if (tempAlarmMax.Contains(equipmentNameByInfoID))
            {
                tempAlarmMax.Remove(equipmentNameByInfoID);
            }
            if (tempAlarmMin.Contains(equipmentNameByInfoID))
            {
                tempAlarmMin.Remove(equipmentNameByInfoID);
            }
            lblBeyondMax.Text = "温度过高设备：";
            lblLessMin.Text = "温度过低设备：";
            foreach (var beyondTempByInfoid1 in tempAlarmMax)
            {
                lblBeyondMax.Text += beyondTempByInfoid1.ToString();
            }
            foreach (var lessTempByInofid1 in tempAlarmMin)
            {
                lblLessMin.Text += lessTempByInofid1.ToString();
            }
            //如果该设备已经断电，需要在lblLessMin和lblBeyondMax去掉该设备 
            #endregion

            needFresh = true;
        }
        #endregion

        #region 客户端响应控制回调函数
        public void OfferSuccess(string InfoID, object e)
        {
            SetPowerOn(InfoID);
        }

        public void OfferFailed(string InfoID, object e)
        {
            TreeNode tn = FindNodeByName(InfoID, roomtree);
            string equipmentName = tn.Text;
            string roomName = tn.Parent.Text;
            equipmentName = "[" + roomName + "]房间" + equipmentName;
            lbstate.Text = equipmentName + " 供电失败！";
        }

        public void BreakSuccess(string InfoID, object e)
        {
            SetPowerOff(InfoID);
        }

        public void BreakFailed(string InfoID, object e)
        {
            TreeNode tn = FindNodeByName(InfoID, roomtree);
            string equipmentName = tn.Text;
            string roomName = tn.Parent.Text;
            equipmentName = "[" + roomName + "]房间" + equipmentName;
            lbstate.Text = equipmentName + " 断电失败！";
        }

        public void GetStateSuccess(string infoID, object e)
        {
            string state = e.ToString();
            if (state == "0")
            {
                closeSuccess.Add(infoID);
            }
            else if (state == "1")
            {
                openSuccess.Add(infoID);
            }
            else
            {
                fail.Add(infoID);
            }
            int length = openSuccess.Count + closeSuccess.Count + fail.Count;
            if (length == count)
            {
                StringBuilder strOpenSuccess = new StringBuilder();
                StringBuilder strCloseSuccess = new StringBuilder();
                StringBuilder strFail = new StringBuilder();
                if (openSuccess.Count > 0)
                {
                    for (int i = 0; i < openSuccess.Count; i++)
                    {
                        strOpenSuccess.Append(openSuccess[i] + ",");
                    }
                    equipmentbll.UpdateEquipmentState("1", strOpenSuccess.ToString(0, strOpenSuccess.Length - 1));
                }
                if (closeSuccess.Count > 0)
                {
                    for (int i = 0; i < closeSuccess.Count; i++)
                    {
                        strCloseSuccess.Append(closeSuccess[i] + ",");
                    }
                    equipmentbll.UpdateEquipmentState("0", strCloseSuccess.ToString(0, strCloseSuccess.Length - 1));
                }
                if (fail.Count > 0)
                {
                    for (int i = 0; i < fail.Count; i++)
                    {
                        strFail.Append(fail[i] + ",");
                    }
                    equipmentbll.UpdateEquipmentState("2", strFail.ToString(0, strFail.Length - 1));
                }
                InitStateImage();
                needFresh = true;
            }
        }

        public void GetStateFailed(string infoID, object e)
        {
            fail.Add(infoID);
            int length = openSuccess.Count + closeSuccess.Count + fail.Count;
            if (length == count)
            {
                StringBuilder strOpenSuccess = new StringBuilder();
                StringBuilder strCloseSuccess = new StringBuilder();
                StringBuilder strFail = new StringBuilder();
                if (openSuccess.Count > 0)
                {
                    for (int i = 0; i < openSuccess.Count; i++)
                    {
                        strOpenSuccess.Append(openSuccess[i] + ",");
                    }
                    equipmentbll.UpdateEquipmentState("1", strOpenSuccess.ToString(0, strOpenSuccess.Length - 1));
                }
                if (closeSuccess.Count > 0)
                {
                    for (int i = 0; i < closeSuccess.Count; i++)
                    {
                        strCloseSuccess.Append(closeSuccess[i] + ",");
                    }
                    equipmentbll.UpdateEquipmentState("0", strCloseSuccess.ToString(0, strCloseSuccess.Length - 1));
                }
                if (fail.Count > 0)
                {
                    for (int i = 0; i < fail.Count; i++)
                    {
                        strFail.Append(fail[i] + ",");
                    }
                    equipmentbll.UpdateEquipmentState("2", strFail.ToString(0, strFail.Length - 1));
                }
                InitStateImage();
                needFresh = true;
            }
        }

        public void ResetMeterSuccess(string infoID, object e)
        {
            electricitybll.Add(infoID, float.Parse(e.ToString()));
            lbstate.Text = "电表已清零";
        }

        public void ResetMeterFailed(string infoID, object e)
        {
            lbstate.Text = "电表清零失败";
        }

        #endregion

        #region 在treeview中查找对应节点

        protected TreeNode FindNodeByName(string name, TreeView t)
        {
            Stack stack = new Stack();
            TreeNode tn;
            foreach (TreeNode n in t.Nodes)
            {
                stack.Push(n);
            }
            while (stack.Count != 0)
            {
                tn = (TreeNode)stack.Pop();
                if (tn.Name == name)
                    return tn;
                for (int i = 0; i < tn.Nodes.Count; i++)
                {
                    stack.Push(tn.Nodes[i]);
                }
            }
            return null;
        }

        #endregion

        #region 菜单按钮事件

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GroupForm gfrm = new GroupForm();
            gfrm.Owner = this;
            gfrm.Show();
        }

        private void 用电历史ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new HistoryForm()).Show();
        }

        private void 定时控制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new TimersForm()).Show();
        }

        private void 用电日报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new ReportsForm()).Show();
        }

        private void 月报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new MonthReportForm()).Show();
        }

        private void 季度报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new QuarterReportForm()).Show();
        }

        private void 年度报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new YearReportForm()).Show();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutForm()).Show();
        }

        private void ChangeSkin(object sender, EventArgs e) //更改皮肤
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            string skinfile = "skin/" + menu.Name + ".ssk";
            ConfigurationManager.AppSettings["skin"] = skinfile;
            Program.se.SkinFile = skinfile;
            foreach (ToolStripMenuItem item in skinset.DropDownItems)
            {
                if (!item.Equals(menu))
                    item.Checked = false;
            }
        }

        private void helpdiscription_Click(object sender, EventArgs e)
        {
            (new HelpForm()).Show();
        }

        #endregion

        #region 拖拽操作事件
        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            /*
            if (e.Data.GetDataPresent(typeof(TreeNode)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
             */
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            // MessageBox.Show("treeView1_DragDrop");
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void btnstart_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode tn = (TreeNode)e.Data.GetData(typeof(TreeNode));
                //LightMgr.SetOn(tn.Name, success, failed);
            }
        }

        private void btnstart_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void btnstop_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode tn = (TreeNode)e.Data.GetData(typeof(TreeNode));
                //LightMgr.SetOff(tn.Name, success, failed);
            }
        }

        #endregion

        #region 状态栏
        private void lbstate_TextChanged(object sender, EventArgs e)
        {
            if (lbstate.Text == "")
            {
                lbstate.Text = "就绪";
            }
        }
        #endregion

        #region 定时提醒
        private void timerClocked_Tick(object sender, EventArgs e)
        {
            timerClocked.Enabled = true;
            timerClocked.Interval = 300000;

        }

        #endregion

        #region 菜单选项

        private void 退出系统ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出本系统吗? ", "提示 ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void 个人信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new UserMsgForm()).Show();
        }

        private void 用户添加ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new UserAddForm()).Show();
        }

        private void iP设置及查看_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("终端IP一旦修改失败会导致失去通讯，你确定要修改吗?", "警告消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                (new IPSetting()).Show();
            }
        }

        private void 服务器IPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("修改服务器IP一旦修改失败会导致失去通讯，你确定要修改吗?", "警告消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                (new ServerIPForm()).Show();
            }
        }

        private void 终端温度管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new TerminalAlarmForm()).Show();
        }

        private void 数据库连接管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new DBConnectForm()).Show();
        }
        private void 楼层批量供电ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BatchManagerForm form = new BatchManagerForm();
            form.Owner = this;
            form.Show();
        }
        #endregion

        #region 合并第一、第二列
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // 对第1,2列相同单元格进行合并
            if ((e.ColumnIndex == 1 || e.ColumnIndex == 0) && e.RowIndex != -1)
            {
                using (Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        // 清除单元格
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                        // 画 Grid 边线（仅画单元格的底边线和右边线）
                        // 如果下一行和当前行的数据不同，则在当前的单元格画一条底边线
                        if (e.RowIndex < dataGridView1.Rows.Count - 1 && dataGridView1.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value.ToString() != e.Value.ToString())
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left + 2, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                        //画最后一条记录的底线
                        if (e.RowIndex == dataGridView1.Rows.Count - 1)
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left + 2, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                        // 画右边线
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                        // 画左边线
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left + 2, e.CellBounds.Top, e.CellBounds.Left + 2, e.CellBounds.Bottom);
                        // 画（填写）单元格内容，相同的内容的单元格只填写第一个
                        if (e.Value != null)
                        {
                            if (e.RowIndex > 0 && dataGridView1.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value.ToString() == e.Value.ToString())
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

        #region 筛选楼层
        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        // //DataTable dtAllFloor = new Equipment().GetEquipmentsByState();
        // //if (dtAllFloor.Rows.Count > 0)
        // //{
        // //    dataGridView1.AutoGenerateColumns = false;
        // //    dataGridView1.DataSource = dtAllFloor;
        // //    BindDataColor();
        // //}
        // //needFresh = true;
        //// string floorName = textBox1.Text.ToString();
        // string floorName = cmbFloorName.Text.ToString();
        // DataTable dtSelectByFloorName = new DataTable();
        // if (floorName == "全部楼层")
        // {
        //     dtSelectByFloorName = new Equipment().GetEquipmentsByState();
        // }
        // else
        // {
        //     dtSelectByFloorName = new Equipment().GetEquipmentByFloor(floorName);
        // }
        // dtSelectByFloorName = new Equipment().GetEquipmentsByState();
        // if (dtSelectByFloorName.Rows.Count > 0)
        // {
        //     dataGridView1.AutoGenerateColumns = false;
        //     dataGridView1.DataSource = dtSelectByFloorName;
        //     BindDataColor();
        // }
        // else
        // {
        //     //MessageBox.Show("没有可供查询的数据，请检测查询条件！");
        //     return;
        // }
        // SendKeys.Send("{END}+{HOME}");
        // needFresh = true;
        //}
        //private void textBox1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        btnSearch_Click(sender, e);
        //    }
        //}
        #endregion

        #region TextBox事件
        //public void BindTextBoxFloorName()
        //{
        //    DataTable dtSelectFloorName = new Floor().BindAllFloorName();
        //    string[] arr = new string[dtSelectFloorName.Rows.Count];
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        arr[i] = dtSelectFloorName.Rows[i]["FloorName"].ToString();
        //    }
        //    textBox1.AutoCompleteCustomSource.AddRange(arr);
        //    textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //}

        //private void textBox1_Click(object sender, EventArgs e)
        //{
        //    textBox1.Text = "";
        //}
        #endregion

        #region FloorName_Selected

        private void cmbFloorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string floorName = cmbFloorName.Text.ToString();
            DataTable dtSelectByFloorName = new DataTable();
            if (floorName == "全部楼层")
            {
                dtSelectByFloorName = new Equipment().GetEquipmentsByState();
            }
            else if (floorName.Length > 0 && floorName != "全部楼层")
            {
                dtSelectByFloorName = new Equipment().GetEquipmentByFloor(floorName);
            }
            if (dtSelectByFloorName.Rows.Count > 0)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dtSelectByFloorName;
                BindDataColor();
            }
            else
            {
                //MessageBox.Show("没有可供查询的数据，请检测查询条件！");
                return;
            }
            //SendKeys.Send("{END}+{HOME}");
            needFresh = true;
        }

        #endregion

        #region 截取真实IP
        public string GetTrueIP(string ipAddress)
        {
            string[] str = ipAddress.Split('.');
            for (int i = 0; i < 4; i++)
            {
                if (str[i].StartsWith("0"))
                {
                    str[i] = str[i].Substring(1, 2);
                    if (str[i].StartsWith("0"))
                    {
                        str[i] = str[i].Substring(1, 1);
                    }
                }
            }
            string aaa = "";
            for (int i = 0; i < 4; i++)
            {
                aaa += str[i] + ".";
            }
            aaa = aaa.Substring(0, aaa.Length - 1);
            return aaa;
        }
        #endregion

        #region 一秒钟执行的定时器
        private void timeFlash_Tick(object sender, EventArgs e)
        {
            timeFlash.Enabled = true;
            timeFlash.Interval = 1000;


            #region 定时刷新
            if (needFresh == true)
            {
                Bind_dataGridView1();
                needFresh = false;
            }
            else
            {

            }
            #endregion
        }
        #endregion

        #region 定时任务
        private void timer1_Tick(object sender, EventArgs e)
        {
            #region 定时任务
            string nowTime = DateTime.Now.ToString("HH:mm:ss");
            int n = (int)DateTime.Now.DayOfWeek;
            DataTable dtStartTime = new TimerMgr().GetStartTime(nowTime);
            if (dtStartTime.Rows.Count > 0)
            {
                for (int i = 0; i < dtStartTime.Rows.Count; i++)
                {
                    string startTimeInfo = dtStartTime.Rows[i]["InfoID"].ToString();
                    string repeatTime = dtStartTime.Rows[i]["RepeatTimes"].ToString();
                    if (repeatTime.Contains(n.ToString()))
                    {
                        Controller.SetOn(startTimeInfo, OfferSuccess, OfferFailed);

                    }
                }

            }

            DataTable dtStopTime = new TimerMgr().GetStopTime(nowTime);
            if (dtStopTime.Rows.Count > 0)
            {
                for (int i = 0; i < dtStopTime.Rows.Count; i++)
                {
                    string stopTimeInfo = dtStopTime.Rows[i]["InfoID"].ToString();
                    string repeatTime = dtStartTime.Rows[i]["RepeatTimes"].ToString();
                    if (repeatTime.Contains(n.ToString()))
                    {
                        Controller.SetOff(stopTimeInfo, BreakSuccess, BreakFailed);
                    }
                }
            }
            needFresh = true;
            #endregion

            #region   设置实时监测温度异常
            string infoIDAndTemp = Communicate.DrivingMessage();
            if (infoIDAndTemp.Length <= 1)
            {
                return;
            }
            string[] idAndTemp = infoIDAndTemp.Split('.');
            string infoID = idAndTemp[0];
            int temp = int.Parse(idAndTemp[1]);
            DataTable dtGetByInfoID = new Equipment().GetEquipmentByInfoID(infoID);
            if (dtGetByInfoID.Rows.Count <= 0)
            {
                return;
            }
            else
            {
                double maxTemp1 = Convert.ToDouble(dtGetByInfoID.Rows[0]["MaxTemperature"].ToString());
                double minTemp1 = Convert.ToDouble(dtGetByInfoID.Rows[0]["MinTemperature"].ToString());
                string floorName1 = dtGetByInfoID.Rows[0]["FloorName"].ToString();
                string roomName1 = dtGetByInfoID.Rows[0]["RoomName"].ToString();
                string equipmentNameByIP = "[" + floorName1 + roomName1 + "],";
                if (temp > maxTemp1)
                {
                    if (tempAlarmMax.Contains(equipmentNameByIP))
                    {
                        return;
                    }
                    lblBeyondMax.Text = "温度过高设备:";
                    tempAlarmMax.Add(equipmentNameByIP);
                    foreach (var beyondTempE in tempAlarmMax)
                    {
                        lblBeyondMax.Text += beyondTempE.ToString();
                    }
                }
                if (temp < minTemp1)
                {
                    if (tempAlarmMin.Contains(equipmentNameByIP))
                    {
                        return;
                    }
                    lblLessMin.Text = "温度过低设备：";
                    tempAlarmMin.Add(equipmentNameByIP);
                    foreach (var lessTempE in tempAlarmMin)
                    {
                        lblLessMin.Text += lessTempE.ToString();
                    }
                }
            }
            #endregion
        }
        #endregion

        #region 任务栏最小化
        #region 点击窗口最小化自动进入通知栏
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide(); //或者是this.Visible = false;
                this.notifyIcon1.Visible = true;
            }
        }
        #endregion

        #region 通知栏退出
        private void ExitApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要退出办公室节能管理系统吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                notifyIcon1.Visible = false;
                Process p = Process.GetCurrentProcess();
                if (p.HasExited == false)
                {
                    p.Kill();
                }
            }
            else
            {
                return;
            }
        }
        #endregion

        #region 通知栏最小化
        private void HideApplication_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

        #region 通知栏最大化
        private void ShowApplication_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
        #endregion

        #region 双击最大化
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;

                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }
        #endregion

        #endregion

        #region 退出办公室节能管理系统
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("你确定要退出办公室节能管理系统吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                notifyIcon1.Visible = false;
                Process p = Process.GetCurrentProcess();
                if (p.HasExited == false)
                {
                    p.Kill();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion
    }
}
