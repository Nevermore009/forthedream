using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Advanced_Encryption_Standard;

namespace UI
{
    public partial class UserMsgForm : Form
    {
        public UserMsgForm()
        {
            InitializeComponent();
            txtUserName.Text = Program.userName;
            DataTable dtUsers = new User().UserMsg(Program.userName);
            txtRealName.Text = dtUsers.Rows[0]["RealName"].ToString();
            cmbSex.Text = dtUsers.Rows[0]["Gender"].ToString();
            txtPhone.Text = dtUsers.Rows[0]["PhoneNumber"].ToString();
            txtCreateTime.Text = dtUsers.Rows[0]["CreateTime"].ToString();
            txtPassword.Text = "******";
            btnSubmmit.Enabled = false;
            txtUserName.Enabled = false;
            txtRealName.Enabled = false;
            cmbSex.Enabled = false;
            txtPhone.Enabled = false;
            txtCreateTime.Enabled = false;
            txtPassword.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSubmmit.Enabled = true;
            btnUpdate.Enabled = false;
           // txtUserName.Enabled = true;
            txtRealName.Enabled = true;
            cmbSex.Enabled = true;
            txtPhone.Enabled = true;
            txtPassword.Enabled = true;
            txtPassword.Text = "";
        }

        private void btnSubmmit_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text=="")
            {
                MessageBox.Show("密码不能够为空！");
                return;
            }
            btnSubmmit.Enabled = false;
            btnUpdate.Enabled = true;
            txtUserName.Enabled = false;
            txtRealName.Enabled = false;
            cmbSex.Enabled = false;
            txtPhone.Enabled = false;
            txtCreateTime.Enabled = false;
            txtPassword.Enabled = false;
            string userName = txtUserName.Text.ToString();
            string realName = txtRealName.Text.ToString();
            string sex = cmbSex.Text.ToString();
            string phoneNumber = txtPhone.Text.ToString();
            string password =AES.codeEncrypt(txtPassword.Text.ToString());
            bool updateSuccess = new User().UpdateMsg(userName, realName, sex, phoneNumber, password);
            if (updateSuccess)
            {
                MessageBox.Show("个人信息更新成功！");
                DataTable dtUsers = new User().UserMsg(Program.userName);
                txtRealName.Text = dtUsers.Rows[0]["RealName"].ToString();
                cmbSex.Text = dtUsers.Rows[0]["Gender"].ToString();
                txtPhone.Text = dtUsers.Rows[0]["PhoneNumber"].ToString();
                txtCreateTime.Text = dtUsers.Rows[0]["CreateTime"].ToString();
                txtPassword.Text = "******";
            }
            else
            {
                MessageBox.Show("个人信息更新失败！");
                return;
            }
           
        }
    }
}
