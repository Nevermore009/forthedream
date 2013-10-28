namespace UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.roomtree = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.房间控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.定时控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.skinset = new System.Windows.Forms.ToolStripMenuItem();
            this.PageColor1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CalmnessColor2 = new System.Windows.Forms.ToolStripMenuItem();
            this.DeepOrange = new System.Windows.Forms.ToolStripMenuItem();
            this.WarmColor1 = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.个人信息ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.用户添加ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iP设置及查看 = new System.Windows.Forms.ToolStripMenuItem();
            this.楼层批量供电ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.服务器IPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.终端报警温度管理ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.用电记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用电历史ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用电日报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.月报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.季度报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.年度报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpdiscription = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnstop = new System.Windows.Forms.Button();
            this.btnstart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLessMin = new System.Windows.Forms.Label();
            this.lblBeyondMax = new System.Windows.Forms.Label();
            this.cmbFloorName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStateColor = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start = new System.Windows.Forms.DataGridViewButtonColumn();
            this.stop = new System.Windows.Forms.DataGridViewButtonColumn();
            this.InfoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.tabpanel = new System.Windows.Forms.TabControl();
            this.roompage = new System.Windows.Forms.TabPage();
            this.grouppage = new System.Windows.Forms.TabPage();
            this.grouptree = new System.Windows.Forms.TreeView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbstate = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClocked = new System.Windows.Forms.Timer(this.components);
            this.timeFlash = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.HideApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabpanel.SuspendLayout();
            this.roompage.SuspendLayout();
            this.grouppage.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "light.gif");
            this.imageList1.Images.SetKeyName(1, "lightbulb.gif");
            this.imageList1.Images.SetKeyName(2, "unknow.png");
            this.imageList1.Images.SetKeyName(3, "onebit_06.png");
            this.imageList1.Images.SetKeyName(4, "room.png");
            // 
            // roomtree
            // 
            this.roomtree.AllowDrop = true;
            this.roomtree.BackColor = System.Drawing.SystemColors.Window;
            this.roomtree.CheckBoxes = true;
            this.roomtree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomtree.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.roomtree.ImageIndex = 2;
            this.roomtree.ImageList = this.imageList1;
            this.roomtree.Location = new System.Drawing.Point(3, 3);
            this.roomtree.Margin = new System.Windows.Forms.Padding(4);
            this.roomtree.Name = "roomtree";
            this.roomtree.SelectedImageIndex = 4;
            this.roomtree.Size = new System.Drawing.Size(204, 485);
            this.roomtree.TabIndex = 0;
            this.roomtree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.RoomTree_AfterCheck);
            this.roomtree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.roomtree.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.roomtree.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.menuStrip1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.房间控制ToolStripMenuItem,
            this.用电记录ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1197, 26);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 房间控制ToolStripMenuItem
            // 
            this.房间控制ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.定时控制ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.skinset,
            this.用户管理ToolStripMenuItem1,
            this.iP设置及查看,
            this.楼层批量供电ToolStripMenuItem,
            this.服务器IPToolStripMenuItem,
            this.终端报警温度管理ToolStripMenuItem1,
            this.退出系统ToolStripMenuItem1});
            this.房间控制ToolStripMenuItem.Name = "房间控制ToolStripMenuItem";
            this.房间控制ToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.房间控制ToolStripMenuItem.Text = "系统设置(&X)";
            // 
            // 定时控制ToolStripMenuItem
            // 
            this.定时控制ToolStripMenuItem.Image = global::UI.Properties.Resources.alarm;
            this.定时控制ToolStripMenuItem.Name = "定时控制ToolStripMenuItem";
            this.定时控制ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.定时控制ToolStripMenuItem.Text = "定时控制";
            this.定时控制ToolStripMenuItem.Click += new System.EventHandler(this.定时控制ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::UI.Properties.Resources.group;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem1.Text = "创建群组";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // skinset
            // 
            this.skinset.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PageColor1,
            this.CalmnessColor2,
            this.DeepOrange,
            this.WarmColor1});
            this.skinset.Image = global::UI.Properties.Resources.skin;
            this.skinset.Name = "skinset";
            this.skinset.Size = new System.Drawing.Size(172, 22);
            this.skinset.Text = "皮肤设置";
            // 
            // PageColor1
            // 
            this.PageColor1.Image = global::UI.Properties.Resources.green;
            this.PageColor1.Name = "PageColor1";
            this.PageColor1.Size = new System.Drawing.Size(124, 22);
            this.PageColor1.Text = "页面绿";
            this.PageColor1.Click += new System.EventHandler(this.ChangeSkin);
            // 
            // CalmnessColor2
            // 
            this.CalmnessColor2.Image = global::UI.Properties.Resources.black;
            this.CalmnessColor2.Name = "CalmnessColor2";
            this.CalmnessColor2.Size = new System.Drawing.Size(124, 22);
            this.CalmnessColor2.Text = "刚铁黑";
            this.CalmnessColor2.Click += new System.EventHandler(this.ChangeSkin);
            // 
            // DeepOrange
            // 
            this.DeepOrange.Image = global::UI.Properties.Resources.orange;
            this.DeepOrange.Name = "DeepOrange";
            this.DeepOrange.Size = new System.Drawing.Size(124, 22);
            this.DeepOrange.Text = "酷炫橙";
            this.DeepOrange.Click += new System.EventHandler(this.ChangeSkin);
            // 
            // WarmColor1
            // 
            this.WarmColor1.Image = global::UI.Properties.Resources.warm1;
            this.WarmColor1.Name = "WarmColor1";
            this.WarmColor1.Size = new System.Drawing.Size(124, 22);
            this.WarmColor1.Text = "温馨暖";
            this.WarmColor1.Click += new System.EventHandler(this.ChangeSkin);
            // 
            // 用户管理ToolStripMenuItem1
            // 
            this.用户管理ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人信息ToolStripMenuItem1,
            this.用户添加ToolStripMenuItem1});
            this.用户管理ToolStripMenuItem1.Image = global::UI.Properties.Resources.User;
            this.用户管理ToolStripMenuItem1.Name = "用户管理ToolStripMenuItem1";
            this.用户管理ToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.用户管理ToolStripMenuItem1.Text = "用户管理";
            // 
            // 个人信息ToolStripMenuItem1
            // 
            this.个人信息ToolStripMenuItem1.Image = global::UI.Properties.Resources.CheckUsres;
            this.个人信息ToolStripMenuItem1.Name = "个人信息ToolStripMenuItem1";
            this.个人信息ToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.个人信息ToolStripMenuItem1.Text = "个人信息";
            this.个人信息ToolStripMenuItem1.Click += new System.EventHandler(this.个人信息ToolStripMenuItem1_Click);
            // 
            // 用户添加ToolStripMenuItem1
            // 
            this.用户添加ToolStripMenuItem1.Image = global::UI.Properties.Resources.add_user;
            this.用户添加ToolStripMenuItem1.Name = "用户添加ToolStripMenuItem1";
            this.用户添加ToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.用户添加ToolStripMenuItem1.Text = "用户添加";
            this.用户添加ToolStripMenuItem1.Click += new System.EventHandler(this.用户添加ToolStripMenuItem1_Click);
            // 
            // iP设置及查看
            // 
            this.iP设置及查看.Image = global::UI.Properties.Resources.Terminal;
            this.iP设置及查看.Name = "iP设置及查看";
            this.iP设置及查看.Size = new System.Drawing.Size(172, 22);
            this.iP设置及查看.Text = "终端IP管理";
            this.iP设置及查看.Click += new System.EventHandler(this.iP设置及查看_Click);
            // 
            // 楼层批量供电ToolStripMenuItem
            // 
            this.楼层批量供电ToolStripMenuItem.Image = global::UI.Properties.Resources.light;
            this.楼层批量供电ToolStripMenuItem.Name = "楼层批量供电ToolStripMenuItem";
            this.楼层批量供电ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.楼层批量供电ToolStripMenuItem.Text = "批量供、断电";
            this.楼层批量供电ToolStripMenuItem.Click += new System.EventHandler(this.楼层批量供电ToolStripMenuItem_Click);
            // 
            // 服务器IPToolStripMenuItem
            // 
            this.服务器IPToolStripMenuItem.Image = global::UI.Properties.Resources.server;
            this.服务器IPToolStripMenuItem.Name = "服务器IPToolStripMenuItem";
            this.服务器IPToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.服务器IPToolStripMenuItem.Text = "服务器IP管理";
            this.服务器IPToolStripMenuItem.Click += new System.EventHandler(this.服务器IPToolStripMenuItem_Click);
            // 
            // 终端报警温度管理ToolStripMenuItem1
            // 
            this.终端报警温度管理ToolStripMenuItem1.Image = global::UI.Properties.Resources.temperature;
            this.终端报警温度管理ToolStripMenuItem1.Name = "终端报警温度管理ToolStripMenuItem1";
            this.终端报警温度管理ToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.终端报警温度管理ToolStripMenuItem1.Text = "终端温度管理";
            this.终端报警温度管理ToolStripMenuItem1.Click += new System.EventHandler(this.终端温度管理ToolStripMenuItem1_Click);
            // 
            // 退出系统ToolStripMenuItem1
            // 
            this.退出系统ToolStripMenuItem1.Image = global::UI.Properties.Resources.exit;
            this.退出系统ToolStripMenuItem1.Name = "退出系统ToolStripMenuItem1";
            this.退出系统ToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.退出系统ToolStripMenuItem1.Text = "退出系统";
            this.退出系统ToolStripMenuItem1.Click += new System.EventHandler(this.退出系统ToolStripMenuItem1_Click);
            // 
            // 用电记录ToolStripMenuItem
            // 
            this.用电记录ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用电历史ToolStripMenuItem,
            this.用电日报表ToolStripMenuItem,
            this.月报表ToolStripMenuItem,
            this.季度报表ToolStripMenuItem,
            this.年度报表ToolStripMenuItem});
            this.用电记录ToolStripMenuItem.Name = "用电记录ToolStripMenuItem";
            this.用电记录ToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.用电记录ToolStripMenuItem.Text = "报表查看(&R)";
            // 
            // 用电历史ToolStripMenuItem
            // 
            this.用电历史ToolStripMenuItem.Image = global::UI.Properties.Resources.view1;
            this.用电历史ToolStripMenuItem.Name = "用电历史ToolStripMenuItem";
            this.用电历史ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.用电历史ToolStripMenuItem.Text = "用电历史";
            this.用电历史ToolStripMenuItem.Click += new System.EventHandler(this.用电历史ToolStripMenuItem_Click);
            // 
            // 用电日报表ToolStripMenuItem
            // 
            this.用电日报表ToolStripMenuItem.Image = global::UI.Properties.Resources.view1;
            this.用电日报表ToolStripMenuItem.Name = "用电日报表ToolStripMenuItem";
            this.用电日报表ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.用电日报表ToolStripMenuItem.Text = "日报表";
            this.用电日报表ToolStripMenuItem.Click += new System.EventHandler(this.用电日报表ToolStripMenuItem_Click);
            // 
            // 月报表ToolStripMenuItem
            // 
            this.月报表ToolStripMenuItem.Image = global::UI.Properties.Resources.view1;
            this.月报表ToolStripMenuItem.Name = "月报表ToolStripMenuItem";
            this.月报表ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.月报表ToolStripMenuItem.Text = "月报表";
            this.月报表ToolStripMenuItem.Click += new System.EventHandler(this.月报表ToolStripMenuItem_Click);
            // 
            // 季度报表ToolStripMenuItem
            // 
            this.季度报表ToolStripMenuItem.Image = global::UI.Properties.Resources.view1;
            this.季度报表ToolStripMenuItem.Name = "季度报表ToolStripMenuItem";
            this.季度报表ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.季度报表ToolStripMenuItem.Text = "季度报表";
            this.季度报表ToolStripMenuItem.Click += new System.EventHandler(this.季度报表ToolStripMenuItem_Click);
            // 
            // 年度报表ToolStripMenuItem
            // 
            this.年度报表ToolStripMenuItem.Image = global::UI.Properties.Resources.view1;
            this.年度报表ToolStripMenuItem.Name = "年度报表ToolStripMenuItem";
            this.年度报表ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.年度报表ToolStripMenuItem.Text = "年度报表";
            this.年度报表ToolStripMenuItem.Click += new System.EventHandler(this.年度报表ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpdiscription,
            this.关于ToolStripMenuItem1});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.帮助ToolStripMenuItem.Text = "帮助(&H)";
            // 
            // helpdiscription
            // 
            this.helpdiscription.Image = global::UI.Properties.Resources.help;
            this.helpdiscription.Name = "helpdiscription";
            this.helpdiscription.Size = new System.Drawing.Size(140, 22);
            this.helpdiscription.Text = "帮助手册";
            this.helpdiscription.Click += new System.EventHandler(this.helpdiscription_Click);
            // 
            // 关于ToolStripMenuItem1
            // 
            this.关于ToolStripMenuItem1.Image = global::UI.Properties.Resources.未标题_1;
            this.关于ToolStripMenuItem1.Name = "关于ToolStripMenuItem1";
            this.关于ToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.关于ToolStripMenuItem1.Text = "关于";
            this.关于ToolStripMenuItem1.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // btnstop
            // 
            this.btnstop.AllowDrop = true;
            this.btnstop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnstop.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnstop.Location = new System.Drawing.Point(81, 557);
            this.btnstop.Name = "btnstop";
            this.btnstop.Size = new System.Drawing.Size(57, 32);
            this.btnstop.TabIndex = 2;
            this.btnstop.Text = "断电";
            this.btnstop.UseVisualStyleBackColor = true;
            this.btnstop.Click += new System.EventHandler(this.btnstop_Click);
            this.btnstop.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnstop_DragDrop);
            this.btnstop.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnstart_DragEnter);
            // 
            // btnstart
            // 
            this.btnstart.AllowDrop = true;
            this.btnstart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnstart.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnstart.Location = new System.Drawing.Point(4, 557);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(57, 32);
            this.btnstart.TabIndex = 2;
            this.btnstart.Text = "供电";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            this.btnstart.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnstart_DragDrop);
            this.btnstart.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnstart_DragEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblLessMin);
            this.groupBox1.Controls.Add(this.lblBeyondMax);
            this.groupBox1.Controls.Add(this.cmbFloorName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblStateColor);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(216, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(981, 563);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "所有设备列表";
            // 
            // lblLessMin
            // 
            this.lblLessMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLessMin.AutoSize = true;
            this.lblLessMin.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLessMin.Location = new System.Drawing.Point(14, 540);
            this.lblLessMin.Name = "lblLessMin";
            this.lblLessMin.Size = new System.Drawing.Size(83, 12);
            this.lblLessMin.TabIndex = 13;
            this.lblLessMin.Text = "温度过低设备:";
            // 
            // lblBeyondMax
            // 
            this.lblBeyondMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBeyondMax.AutoSize = true;
            this.lblBeyondMax.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBeyondMax.Location = new System.Drawing.Point(14, 512);
            this.lblBeyondMax.Name = "lblBeyondMax";
            this.lblBeyondMax.Size = new System.Drawing.Size(83, 12);
            this.lblBeyondMax.TabIndex = 12;
            this.lblBeyondMax.Text = "温度过高设备:";
            // 
            // cmbFloorName
            // 
            this.cmbFloorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFloorName.FormattingEnabled = true;
            this.cmbFloorName.Location = new System.Drawing.Point(105, 26);
            this.cmbFloorName.Name = "cmbFloorName";
            this.cmbFloorName.Size = new System.Drawing.Size(182, 24);
            this.cmbFloorName.TabIndex = 11;
            this.cmbFloorName.SelectedIndexChanged += new System.EventHandler(this.cmbFloorName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "请选择楼层：";
            // 
            // lblStateColor
            // 
            this.lblStateColor.AutoSize = true;
            this.lblStateColor.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStateColor.ForeColor = System.Drawing.Color.Red;
            this.lblStateColor.Location = new System.Drawing.Point(349, 31);
            this.lblStateColor.Name = "lblStateColor";
            this.lblStateColor.Size = new System.Drawing.Size(477, 15);
            this.lblStateColor.TabIndex = 6;
            this.lblStateColor.Text = "注：[绿色]为供电状态，[红色]为断电状态，[灰色]为未知状态！";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.floor,
            this.roomname,
            this.EquipmentName,
            this.Start,
            this.stop,
            this.InfoID});
            this.dataGridView1.Location = new System.Drawing.Point(11, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(964, 443);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // floor
            // 
            this.floor.DataPropertyName = "FloorName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.floor.DefaultCellStyle = dataGridViewCellStyle2;
            this.floor.HeaderText = "楼层";
            this.floor.Name = "floor";
            this.floor.ReadOnly = true;
            // 
            // roomname
            // 
            this.roomname.DataPropertyName = "RoomName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.roomname.DefaultCellStyle = dataGridViewCellStyle3;
            this.roomname.HeaderText = "房间名称";
            this.roomname.Name = "roomname";
            this.roomname.ReadOnly = true;
            // 
            // EquipmentName
            // 
            this.EquipmentName.DataPropertyName = "EquipmentName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EquipmentName.DefaultCellStyle = dataGridViewCellStyle4;
            this.EquipmentName.HeaderText = "设备名称";
            this.EquipmentName.Name = "EquipmentName";
            this.EquipmentName.ReadOnly = true;
            // 
            // Start
            // 
            this.Start.HeaderText = "开始供电";
            this.Start.Name = "Start";
            this.Start.ReadOnly = true;
            this.Start.Text = "供电";
            this.Start.UseColumnTextForButtonValue = true;
            // 
            // stop
            // 
            this.stop.HeaderText = "停止供电";
            this.stop.Name = "stop";
            this.stop.ReadOnly = true;
            this.stop.Text = "断电";
            this.stop.UseColumnTextForButtonValue = true;
            // 
            // InfoID
            // 
            this.InfoID.DataPropertyName = "InfoID";
            this.InfoID.HeaderText = "Column1";
            this.InfoID.Name = "InfoID";
            this.InfoID.ReadOnly = true;
            this.InfoID.Visible = false;
            // 
            // btnrefresh
            // 
            this.btnrefresh.AllowDrop = true;
            this.btnrefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnrefresh.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnrefresh.Location = new System.Drawing.Point(157, 557);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(57, 32);
            this.btnrefresh.TabIndex = 2;
            this.btnrefresh.Text = "刷新";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // tabpanel
            // 
            this.tabpanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tabpanel.Controls.Add(this.roompage);
            this.tabpanel.Controls.Add(this.grouppage);
            this.tabpanel.Location = new System.Drawing.Point(0, 30);
            this.tabpanel.Name = "tabpanel";
            this.tabpanel.SelectedIndex = 0;
            this.tabpanel.Size = new System.Drawing.Size(218, 521);
            this.tabpanel.TabIndex = 4;
            this.tabpanel.Tag = "";
            // 
            // roompage
            // 
            this.roompage.Controls.Add(this.roomtree);
            this.roompage.Location = new System.Drawing.Point(4, 26);
            this.roompage.Name = "roompage";
            this.roompage.Padding = new System.Windows.Forms.Padding(3);
            this.roompage.Size = new System.Drawing.Size(210, 491);
            this.roompage.TabIndex = 0;
            this.roompage.Text = "所有房间";
            this.roompage.UseVisualStyleBackColor = true;
            // 
            // grouppage
            // 
            this.grouppage.Controls.Add(this.grouptree);
            this.grouppage.Location = new System.Drawing.Point(4, 26);
            this.grouppage.Name = "grouppage";
            this.grouppage.Padding = new System.Windows.Forms.Padding(3);
            this.grouppage.Size = new System.Drawing.Size(210, 491);
            this.grouppage.TabIndex = 1;
            this.grouppage.Text = "群组";
            this.grouppage.UseVisualStyleBackColor = true;
            // 
            // grouptree
            // 
            this.grouptree.CheckBoxes = true;
            this.grouptree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grouptree.ImageIndex = 2;
            this.grouptree.ImageList = this.imageList1;
            this.grouptree.Location = new System.Drawing.Point(3, 3);
            this.grouptree.Name = "grouptree";
            this.grouptree.SelectedImageIndex = 0;
            this.grouptree.Size = new System.Drawing.Size(204, 485);
            this.grouptree.TabIndex = 4;
            this.grouptree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.RoomTree_AfterCheck);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbstate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 596);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1197, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbstate
            // 
            this.lbstate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbstate.Name = "lbstate";
            this.lbstate.Size = new System.Drawing.Size(105, 17);
            this.lbstate.Text = "准备就绪......";
            this.lbstate.TextChanged += new System.EventHandler(this.lbstate_TextChanged);
            // 
            // timerClocked
            // 
            this.timerClocked.Enabled = true;
            this.timerClocked.Interval = 300000;
            this.timerClocked.Tick += new System.EventHandler(this.timerClocked_Tick);
            // 
            // timeFlash
            // 
            this.timeFlash.Enabled = true;
            this.timeFlash.Interval = 1000;
            this.timeFlash.Tick += new System.EventHandler(this.timeFlash_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "办公室节能管理系统";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HideApplication,
            this.ShowApplication,
            this.ExitApplication});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 70);
            // 
            // HideApplication
            // 
            this.HideApplication.Name = "HideApplication";
            this.HideApplication.Size = new System.Drawing.Size(152, 22);
            this.HideApplication.Text = "最小化窗口";
            this.HideApplication.Click += new System.EventHandler(this.HideApplication_Click);
            // 
            // ShowApplication
            // 
            this.ShowApplication.Name = "ShowApplication";
            this.ShowApplication.Size = new System.Drawing.Size(152, 22);
            this.ShowApplication.Text = "最大化窗口";
            this.ShowApplication.Click += new System.EventHandler(this.ShowApplication_Click);
            // 
            // ExitApplication
            // 
            this.ExitApplication.Name = "ExitApplication";
            this.ExitApplication.Size = new System.Drawing.Size(152, 22);
            this.ExitApplication.Text = "退出该系统";
            this.ExitApplication.Click += new System.EventHandler(this.ExitApplication_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 618);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabpanel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnstart);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.btnstop);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "办公室节能系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabpanel.ResumeLayout(false);
            this.roompage.ResumeLayout(false);
            this.grouppage.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView roomtree;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 房间控制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 定时控制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用电记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用电历史ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用电日报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 月报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 季度报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 年度报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpdiscription;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem1;
        private System.Windows.Forms.Button btnstop;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.TabControl tabpanel;
        private System.Windows.Forms.TabPage roompage;
        private System.Windows.Forms.TabPage grouppage;
        private System.Windows.Forms.TreeView grouptree;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbstate;
        private System.Windows.Forms.Timer timerClocked;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem iP设置及查看;
        private System.Windows.Forms.ToolStripMenuItem 终端报警温度管理ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem skinset;
        private System.Windows.Forms.ToolStripMenuItem PageColor1;
        private System.Windows.Forms.ToolStripMenuItem CalmnessColor2;
        private System.Windows.Forms.ToolStripMenuItem DeepOrange;
        private System.Windows.Forms.ToolStripMenuItem WarmColor1;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 个人信息ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 用户添加ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 服务器IPToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn floor;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomname;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentName;
        private System.Windows.Forms.DataGridViewButtonColumn Start;
        private System.Windows.Forms.DataGridViewButtonColumn stop;
        private System.Windows.Forms.DataGridViewTextBoxColumn InfoID;
        private System.Windows.Forms.Label lblStateColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 楼层批量供电ToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbFloorName;
        private System.Windows.Forms.Label lblLessMin;
        private System.Windows.Forms.Label lblBeyondMax;
        private System.Windows.Forms.Timer timeFlash;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem HideApplication;
        private System.Windows.Forms.ToolStripMenuItem ShowApplication;
        private System.Windows.Forms.ToolStripMenuItem ExitApplication;
    }
}