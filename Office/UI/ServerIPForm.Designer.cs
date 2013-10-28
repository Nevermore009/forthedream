namespace UI
{
    partial class ServerIPForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerIPForm));
            this.btnSubmmit = new System.Windows.Forms.Button();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.IPAddress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSubmmit
            // 
            this.btnSubmmit.Location = new System.Drawing.Point(111, 102);
            this.btnSubmmit.Name = "btnSubmmit";
            this.btnSubmmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmmit.TabIndex = 16;
            this.btnSubmmit.Text = "提   交";
            this.btnSubmmit.UseVisualStyleBackColor = true;
            this.btnSubmmit.Click += new System.EventHandler(this.btnSubmmit_Click);
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(60, 55);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(141, 21);
            this.txtIpAddress.TabIndex = 13;
            // 
            // IPAddress
            // 
            this.IPAddress.AutoSize = true;
            this.IPAddress.Location = new System.Drawing.Point(10, 59);
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.Size = new System.Drawing.Size(53, 12);
            this.IPAddress.TabIndex = 10;
            this.IPAddress.Text = "IP地址：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("仿宋", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(64, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "服务器IP管理";
            // 
            // txtport
            // 
            this.txtport.Location = new System.Drawing.Point(223, 55);
            this.txtport.Name = "txtport";
            this.txtport.Size = new System.Drawing.Size(52, 21);
            this.txtport.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(203, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "：";
            // 
            // ServerIPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 137);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtport);
            this.Controls.Add(this.btnSubmmit);
            this.Controls.Add(this.txtIpAddress);
            this.Controls.Add(this.IPAddress);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(303, 175);
            this.MinimumSize = new System.Drawing.Size(303, 175);
            this.Name = "ServerIPForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务器IP管理";
            this.Load += new System.EventHandler(this.ServerIPForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmmit;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.Label IPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtport;
        private System.Windows.Forms.Label label2;
    }
}