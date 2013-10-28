namespace UI
{
    partial class IPSetting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPSetting));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubNetMask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateWay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MacAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.equipmentid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.IPAddress,
            this.Port,
            this.SubNetMask,
            this.DateWay,
            this.MacAddress,
            this.Edit,
            this.equipmentid});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1054, 563);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // floor
            // 
            this.floor.DataPropertyName = "Floorname";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.floor.DefaultCellStyle = dataGridViewCellStyle2;
            this.floor.FillWeight = 54.33273F;
            this.floor.HeaderText = "楼层";
            this.floor.Name = "floor";
            this.floor.ReadOnly = true;
            // 
            // roomname
            // 
            this.roomname.DataPropertyName = "roomname";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.roomname.DefaultCellStyle = dataGridViewCellStyle3;
            this.roomname.FillWeight = 54.33273F;
            this.roomname.HeaderText = "房间名称";
            this.roomname.Name = "roomname";
            this.roomname.ReadOnly = true;
            // 
            // EquipmentName
            // 
            this.EquipmentName.DataPropertyName = "EquipmentName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EquipmentName.DefaultCellStyle = dataGridViewCellStyle4;
            this.EquipmentName.FillWeight = 54.33273F;
            this.EquipmentName.HeaderText = "设备名称";
            this.EquipmentName.Name = "EquipmentName";
            this.EquipmentName.ReadOnly = true;
            // 
            // IPAddress
            // 
            this.IPAddress.DataPropertyName = "IPAddress";
            this.IPAddress.FillWeight = 67.91591F;
            this.IPAddress.HeaderText = "IP地址";
            this.IPAddress.Name = "IPAddress";
            // 
            // Port
            // 
            this.Port.DataPropertyName = "Port";
            this.Port.FillWeight = 40F;
            this.Port.HeaderText = "端口";
            this.Port.Name = "Port";
            // 
            // SubNetMask
            // 
            this.SubNetMask.DataPropertyName = "NetMask";
            this.SubNetMask.FillWeight = 67.91591F;
            this.SubNetMask.HeaderText = "子网掩码";
            this.SubNetMask.Name = "SubNetMask";
            // 
            // DateWay
            // 
            this.DateWay.DataPropertyName = "GateWay";
            this.DateWay.FillWeight = 67.91591F;
            this.DateWay.HeaderText = "默认网关";
            this.DateWay.Name = "DateWay";
            // 
            // MacAddress
            // 
            this.MacAddress.DataPropertyName = "MacAddress";
            this.MacAddress.FillWeight = 81.4991F;
            this.MacAddress.HeaderText = "Mac地址";
            this.MacAddress.Name = "MacAddress";
            // 
            // Edit
            // 
            this.Edit.FillWeight = 67.91591F;
            this.Edit.HeaderText = "编  辑";
            this.Edit.Name = "Edit";
            this.Edit.Text = "编  辑";
            this.Edit.UseColumnTextForButtonValue = true;
            // 
            // equipmentid
            // 
            this.equipmentid.DataPropertyName = "InfoID";
            this.equipmentid.HeaderText = "Column1";
            this.equipmentid.Name = "equipmentid";
            this.equipmentid.Visible = false;
            // 
            // IPSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 587);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IPSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IP设置及查看";
            this.Load += new System.EventHandler(this.IPSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn floor;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomname;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubNetMask;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateWay;
        private System.Windows.Forms.DataGridViewTextBoxColumn MacAddress;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentid;

    }
}