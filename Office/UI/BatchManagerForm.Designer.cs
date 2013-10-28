namespace UI
{
    partial class BatchManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchManagerForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFloor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEquipmentName = new System.Windows.Forms.ComboBox();
            this.btnSetOn = new System.Windows.Forms.Button();
            this.btnSetOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文楷体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(47, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "楼层批量供、断电";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "请选择楼层：";
            // 
            // cmbFloor
            // 
            this.cmbFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFloor.FormattingEnabled = true;
            this.cmbFloor.Location = new System.Drawing.Point(89, 49);
            this.cmbFloor.Name = "cmbFloor";
            this.cmbFloor.Size = new System.Drawing.Size(215, 20);
            this.cmbFloor.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "设备类型：";
            // 
            // cmbEquipmentName
            // 
            this.cmbEquipmentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEquipmentName.FormattingEnabled = true;
            this.cmbEquipmentName.Items.AddRange(new object[] {
            "照明",
            "空调"});
            this.cmbEquipmentName.Location = new System.Drawing.Point(89, 83);
            this.cmbEquipmentName.Name = "cmbEquipmentName";
            this.cmbEquipmentName.Size = new System.Drawing.Size(215, 20);
            this.cmbEquipmentName.TabIndex = 4;
            // 
            // btnSetOn
            // 
            this.btnSetOn.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetOn.Location = new System.Drawing.Point(27, 130);
            this.btnSetOn.Name = "btnSetOn";
            this.btnSetOn.Size = new System.Drawing.Size(98, 40);
            this.btnSetOn.TabIndex = 5;
            this.btnSetOn.Text = "供  电";
            this.btnSetOn.UseVisualStyleBackColor = true;
            this.btnSetOn.Click += new System.EventHandler(this.btnSetOn_Click);
            // 
            // btnSetOff
            // 
            this.btnSetOff.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetOff.Location = new System.Drawing.Point(183, 130);
            this.btnSetOff.Name = "btnSetOff";
            this.btnSetOff.Size = new System.Drawing.Size(98, 40);
            this.btnSetOff.TabIndex = 6;
            this.btnSetOff.Text = "断  电";
            this.btnSetOff.UseVisualStyleBackColor = true;
            this.btnSetOff.Click += new System.EventHandler(this.btnSetOff_Click);
            // 
            // BatchManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 197);
            this.Controls.Add(this.btnSetOff);
            this.Controls.Add(this.btnSetOn);
            this.Controls.Add(this.cmbEquipmentName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbFloor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(344, 235);
            this.MinimumSize = new System.Drawing.Size(344, 235);
            this.Name = "BatchManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量供、断电";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFloor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEquipmentName;
        private System.Windows.Forms.Button btnSetOn;
        private System.Windows.Forms.Button btnSetOff;
    }
}