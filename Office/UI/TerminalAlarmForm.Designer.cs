namespace UI
{
    partial class TerminalAlarmForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TerminalAlarmForm));
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.FloorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinTemperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxTemperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AskTemp = new System.Windows.Forms.DataGridViewButtonColumn();
            this.InfoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localIPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FloorName,
            this.roomname,
            this.EquipmentName,
            this.MinTemperature,
            this.MaxTemperature,
            this.Update,
            this.AskTemp,
            this.InfoID,
            this.localIPAddress});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(808, 485);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // FloorName
            // 
            this.FloorName.DataPropertyName = "FloorName";
            this.FloorName.HeaderText = "楼层";
            this.FloorName.Name = "FloorName";
            // 
            // roomname
            // 
            this.roomname.DataPropertyName = "roomname";
            this.roomname.HeaderText = "房间";
            this.roomname.Name = "roomname";
            // 
            // EquipmentName
            // 
            this.EquipmentName.DataPropertyName = "EquipmentName";
            this.EquipmentName.HeaderText = "设备名称";
            this.EquipmentName.Name = "EquipmentName";
            // 
            // MinTemperature
            // 
            this.MinTemperature.DataPropertyName = "MinTemperature";
            this.MinTemperature.HeaderText = "最低温度";
            this.MinTemperature.Name = "MinTemperature";
            // 
            // MaxTemperature
            // 
            this.MaxTemperature.DataPropertyName = "MaxTemperature";
            this.MaxTemperature.HeaderText = "最高温度";
            this.MaxTemperature.Name = "MaxTemperature";
            // 
            // Update
            // 
            this.Update.HeaderText = "控制机温度";
            this.Update.Name = "Update";
            this.Update.Text = "修改";
            this.Update.UseColumnTextForButtonValue = true;
            // 
            // AskTemp
            // 
            this.AskTemp.HeaderText = "当前温度";
            this.AskTemp.Name = "AskTemp";
            this.AskTemp.Text = "获取";
            this.AskTemp.UseColumnTextForButtonValue = true;
            // 
            // InfoID
            // 
            this.InfoID.DataPropertyName = "InfoID";
            this.InfoID.HeaderText = "InfoID";
            this.InfoID.Name = "InfoID";
            this.InfoID.Visible = false;
            // 
            // localIPAddress
            // 
            this.localIPAddress.DataPropertyName = "localIPAddress";
            this.localIPAddress.HeaderText = "IP地址";
            this.localIPAddress.Name = "localIPAddress";
            this.localIPAddress.Visible = false;
            // 
            // TerminalAlarmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 485);
            this.Controls.Add(this.dataGridView2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(824, 523);
            this.MinimumSize = new System.Drawing.Size(824, 523);
            this.Name = "TerminalAlarmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "终端报警温度管理";
            this.Load += new System.EventHandler(this.TerminalAlarmForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FloorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomname;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinTemperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxTemperature;
        private System.Windows.Forms.DataGridViewButtonColumn Update;
        private System.Windows.Forms.DataGridViewButtonColumn AskTemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn InfoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn localIPAddress;
    }
}