using System;
using BLL;
using Common;

public partial class Admin_StaffAdd : System.Web.UI.Page
{
    private Staff staffbll = new Staff();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (txtstaffname.Text != "")
            if (staffbll.Add(txtstaffname.Text))
            {
                MessageBox.Show(this.Page, "添加成功!");
            }
            else
            {
                MessageBox.Show(this.Page, "添加失败!");
            }
    }
}
