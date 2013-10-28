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
    public partial class GroupForm : Form
    {
        private Equipment equipmentbll = new Equipment();
        private Room roommgr = new Room();
        private BLL.Group groupmgr = new BLL.Group();
        private string onchangegroupid = null;
        private bool IsEdit = false;

        public GroupForm()
        {
            InitializeComponent();
        }
        public GroupForm(string groupID)
        {
            onchangegroupid = groupID;
            IsEdit = true;
            InitializeComponent();
        }

        private void Group_Load(object sender, EventArgs e)
        {
            DataTable alldt = equipmentbll.GetEquipmentTreeList();    //所有设备列表
            ParentAndChild[] pandc = new ParentAndChild[] { new ParentAndChild(null, "floorid", "floorname"), new ParentAndChild("floorid", "RoomID", "roomname"), new ParentAndChild("RoomID", "InfoID", "EquipmentName") };
            Common.BindTreeView(alldt, treeView1.Nodes, null, pandc, 0);


            if (IsEdit)
            {
                DataTable dt = groupmgr.GetGroupByID(onchangegroupid);
                txtgroupname.Text = dt.Rows[0]["groupname"].ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string equipmentname = "["+dt.Rows[i]["RoomName"].ToString()+"]"+dt.Rows[i]["EquipmentName"].ToString();
                    memberlist.Items.Add(new ListItem { InfoID = dt.Rows[i]["InfoID"].ToString(), EquipmentName =equipmentname });
                }
            }
        }

        /// <summary>
        /// 绑定TreeView（利用TreeNodeCollection）
        /// </summary>
        /// <param name="tnc">TreeNodeCollection（TreeView的节点集合）</param>
        /// <param name="pid">父节点ID</param>
        /// <param name="id">节点ID</param>
        /// <param name="text">节点显示值</param>       
        #region 添加群组
        private void btnadd_Click(object sender, EventArgs e)
        {
            memberlist.SelectedItems.Clear();
            if (treeView1.SelectedNode == null)
            {
                return;
            }
            else if (treeView1.SelectedNode.Level == 0)
            {

                foreach (TreeNode n in treeView1.SelectedNode.Nodes)
                {
                    foreach (TreeNode m in n.Nodes)
                    {
                        ListItem item = new ListItem { InfoID = m.Name, EquipmentName = "[" + m.Parent.Text + "]" + m.Text };
                        AddItemToList(item);
                    }
                }
            }
            else if (treeView1.SelectedNode.Level == 1)
            {
                foreach (TreeNode n in treeView1.SelectedNode.Nodes)
                {
                    ListItem item = new ListItem { InfoID = n.Name, EquipmentName = "[" + n.Parent.Text + "]" + n.Text };
                    AddItemToList(item);
                }
            }
            else
            {
                ListItem item = new ListItem { InfoID = treeView1.SelectedNode.Name, EquipmentName = "[" + treeView1.SelectedNode.Parent.Text + "]" + treeView1.SelectedNode.Text };
                AddItemToList(item);
            }
        }
        #endregion

        private void AddItemToList(ListItem item)
        {
            int count = memberlist.Items.Count;
            bool isexist = false;
            for (int i = 0; i < count; i++)
            {
                if (((ListItem)memberlist.Items[i]).InfoID == item.InfoID)
                {
                    isexist = true;
                    memberlist.SelectedItems.Add(memberlist.Items[i]);
                }
            }
            if (!isexist)
            {
                memberlist.Items.Add(item);
                memberlist.SelectedItems.Add(item);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            object[] selected = new object[memberlist.SelectedItems.Count];
            memberlist.SelectedItems.CopyTo(selected, 0);
            foreach (object item in selected)
                memberlist.Items.Remove(item);
        }

        class ListItem
        {
            public string EquipmentName { set; get; }
            public string InfoID { set; get; }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtgroupname.Text == "")
            {
                MessageBox.Show("请输入组名称！", "提示消息");
                return;
            }
            if (memberlist.Items.Count <= 0)
            {
                MessageBox.Show("您还没有选择任何房间！", "提示消息");
                return;
            }
            string[] infoID = new string[memberlist.Items.Count];
            for (int i = 0; i < memberlist.Items.Count; i++)
            {
                ListItem item = (ListItem)memberlist.Items[i];
                infoID[i] = item.InfoID;
            }
            if (IsEdit)
            {
                groupmgr.ChangeGroupByID(onchangegroupid, txtgroupname.Text, infoID);
            }
            else
            {
                groupmgr.Add(txtgroupname.Text, infoID);
            }
            ((MainForm)this.Owner).InitGroupTree();
            MessageBox.Show("保存成功!", "消息");            
            this.FindForm().Close();
        }

    }
}
