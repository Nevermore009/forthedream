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
    public partial class UserAddForm : Form
    {
        public UserAddForm()
        {
            InitializeComponent();
            cmbSex.Text = "男";
        }

        private void btnSubmmit_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.ToString();
            string realName = txtRealName.Text.ToString();
            string sex = cmbSex.Text.ToString();
            string phoneNumber = txtPhone.Text.ToString();
            string password = txtPassword.Text.ToString();
            string passwordConfirm = txtPasswordConfirm.Text.ToString();
            if (userName==""||password==""||realName=="")
            {
                MessageBox.Show("用户名、真实姓名和密码为必填！");
                return;
            }
            if (password != passwordConfirm)
            {
                MessageBox.Show("两次密码输入不一致，请重新输入！");
                return;
            }
            else
            {
                password = AES.codeEncrypt(password);
                bool insertSuccess = new User().InsertMsg(userName, realName, sex, phoneNumber, password);
                if (insertSuccess)
                {
                    MessageBox.Show("用户添加成功！");
                    this.Close();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("用户添加失败！");
                    return;
                }
            }

        }
    }
}
