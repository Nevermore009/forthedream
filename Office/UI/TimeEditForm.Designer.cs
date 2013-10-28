namespace UI
{
    partial class TimeEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeEditForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.chkBox7 = new System.Windows.Forms.CheckBox();
            this.chkBox6 = new System.Windows.Forms.CheckBox();
            this.chkBox5 = new System.Windows.Forms.CheckBox();
            this.chkBox4 = new System.Windows.Forms.CheckBox();
            this.chkBox3 = new System.Windows.Forms.CheckBox();
            this.chkBox2 = new System.Windows.Forms.CheckBox();
            this.chkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文楷体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(67, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "定时控制设备编辑";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "定时开始时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "定时结束时间：";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "HH:mm:ss";
            this.dateTimePicker2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(133, 117);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(165, 26);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "HH:mm:ss";
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(133, 78);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(165, 26);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // chkBox7
            // 
            this.chkBox7.AutoSize = true;
            this.chkBox7.Location = new System.Drawing.Point(254, 230);
            this.chkBox7.Name = "chkBox7";
            this.chkBox7.Size = new System.Drawing.Size(60, 16);
            this.chkBox7.TabIndex = 22;
            this.chkBox7.Text = "星期日";
            this.chkBox7.UseVisualStyleBackColor = true;
            // 
            // chkBox6
            // 
            this.chkBox6.AutoSize = true;
            this.chkBox6.Location = new System.Drawing.Point(169, 230);
            this.chkBox6.Name = "chkBox6";
            this.chkBox6.Size = new System.Drawing.Size(60, 16);
            this.chkBox6.TabIndex = 21;
            this.chkBox6.Text = "星期六";
            this.chkBox6.UseVisualStyleBackColor = true;
            // 
            // chkBox5
            // 
            this.chkBox5.AutoSize = true;
            this.chkBox5.Location = new System.Drawing.Point(89, 230);
            this.chkBox5.Name = "chkBox5";
            this.chkBox5.Size = new System.Drawing.Size(60, 16);
            this.chkBox5.TabIndex = 20;
            this.chkBox5.Text = "星期五";
            this.chkBox5.UseVisualStyleBackColor = true;
            // 
            // chkBox4
            // 
            this.chkBox4.AutoSize = true;
            this.chkBox4.Location = new System.Drawing.Point(17, 230);
            this.chkBox4.Name = "chkBox4";
            this.chkBox4.Size = new System.Drawing.Size(60, 16);
            this.chkBox4.TabIndex = 19;
            this.chkBox4.Text = "星期四";
            this.chkBox4.UseVisualStyleBackColor = true;
            // 
            // chkBox3
            // 
            this.chkBox3.AutoSize = true;
            this.chkBox3.Location = new System.Drawing.Point(254, 182);
            this.chkBox3.Name = "chkBox3";
            this.chkBox3.Size = new System.Drawing.Size(60, 16);
            this.chkBox3.TabIndex = 18;
            this.chkBox3.Text = "星期三";
            this.chkBox3.UseVisualStyleBackColor = true;
            // 
            // chkBox2
            // 
            this.chkBox2.AutoSize = true;
            this.chkBox2.Location = new System.Drawing.Point(169, 182);
            this.chkBox2.Name = "chkBox2";
            this.chkBox2.Size = new System.Drawing.Size(60, 16);
            this.chkBox2.TabIndex = 17;
            this.chkBox2.Text = "星期二";
            this.chkBox2.UseVisualStyleBackColor = true;
            // 
            // chkBox1
            // 
            this.chkBox1.AutoSize = true;
            this.chkBox1.Location = new System.Drawing.Point(89, 182);
            this.chkBox1.Name = "chkBox1";
            this.chkBox1.Size = new System.Drawing.Size(60, 16);
            this.chkBox1.TabIndex = 16;
            this.chkBox1.Text = "星期一";
            this.chkBox1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "重复周期：";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(135, 272);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // TimeEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 317);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkBox7);
            this.Controls.Add(this.chkBox6);
            this.Controls.Add(this.chkBox5);
            this.Controls.Add(this.chkBox4);
            this.Controls.Add(this.chkBox3);
            this.Controls.Add(this.chkBox2);
            this.Controls.Add(this.chkBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimeEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时编辑";
            this.Load += new System.EventHandler(this.TimeEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox chkBox7;
        private System.Windows.Forms.CheckBox chkBox6;
        private System.Windows.Forms.CheckBox chkBox5;
        private System.Windows.Forms.CheckBox chkBox4;
        private System.Windows.Forms.CheckBox chkBox3;
        private System.Windows.Forms.CheckBox chkBox2;
        private System.Windows.Forms.CheckBox chkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdate;
    }
}