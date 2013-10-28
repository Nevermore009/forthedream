namespace UI
{
    partial class EditIPAddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditIPAddress));
            this.txtDateWay = new System.Windows.Forms.TextBox();
            this.txtSubNetMask = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cklocal = new System.Windows.Forms.CheckBox();
            this.txtMacAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtduankou = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDateWay
            // 
            this.txtDateWay.Location = new System.Drawing.Point(85, 82);
            this.txtDateWay.Name = "txtDateWay";
            this.txtDateWay.Size = new System.Drawing.Size(207, 21);
            this.txtDateWay.TabIndex = 14;
            // 
            // txtSubNetMask
            // 
            this.txtSubNetMask.Location = new System.Drawing.Point(85, 47);
            this.txtSubNetMask.Name = "txtSubNetMask";
            this.txtSubNetMask.Size = new System.Drawing.Size(207, 21);
            this.txtSubNetMask.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "默认网关：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "子网掩码：";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(121, 183);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 26);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(85, 14);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(141, 21);
            this.txtIpAddress.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP地址：";
            // 
            // cklocal
            // 
            this.cklocal.AutoSize = true;
            this.cklocal.Location = new System.Drawing.Point(130, 154);
            this.cklocal.Name = "cklocal";
            this.cklocal.Size = new System.Drawing.Size(72, 16);
            this.cklocal.TabIndex = 15;
            this.cklocal.Text = "本地修改";
            this.cklocal.UseVisualStyleBackColor = true;
            this.cklocal.CheckedChanged += new System.EventHandler(this.cklocal_CheckedChanged);
            // 
            // txtMacAddress
            // 
            this.txtMacAddress.Location = new System.Drawing.Point(86, 119);
            this.txtMacAddress.Name = "txtMacAddress";
            this.txtMacAddress.Size = new System.Drawing.Size(206, 21);
            this.txtMacAddress.TabIndex = 17;
            this.txtMacAddress.TextChanged += new System.EventHandler(this.txtMacAddress_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "Mac地址：";
            // 
            // txtduankou
            // 
            this.txtduankou.Location = new System.Drawing.Point(245, 14);
            this.txtduankou.Name = "txtduankou";
            this.txtduankou.Size = new System.Drawing.Size(47, 21);
            this.txtduankou.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "：";
            // 
            // EditIPAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 222);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtduankou);
            this.Controls.Add(this.txtMacAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cklocal);
            this.Controls.Add(this.txtDateWay);
            this.Controls.Add(this.txtSubNetMask);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtIpAddress);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(332, 260);
            this.MinimumSize = new System.Drawing.Size(332, 260);
            this.Name = "EditIPAddress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IP修改及添加";
            this.Load += new System.EventHandler(this.EditIPAddress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDateWay;
        private System.Windows.Forms.TextBox txtSubNetMask;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cklocal;
        private System.Windows.Forms.TextBox txtMacAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtduankou;
        private System.Windows.Forms.Label label5;
    }
}