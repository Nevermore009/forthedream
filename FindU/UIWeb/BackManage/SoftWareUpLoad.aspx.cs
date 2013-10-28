using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Common;

public partial class Admin_SoftWareUpLoad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    } 
   
    #region 文件上传
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string _Title = "";
        string _Remark = txtRemark.Text.Trim();
        string version=txtVersion.Text.ToString();
        string _FilePath = "";
        string _Path = "";
        HttpFileCollection files = HttpContext.Current.Request.Files;
        try
        {
            for (int iFile = 0; iFile < files.Count; iFile++)
            {
                //访问单独文件
                HttpPostedFile postedFile = files[iFile];
                string fileName, fileExtension;
                fileName = System.IO.Path.GetFileName(postedFile.FileName);
                _Title = fileName;
                 if (fileName != "")
                 {   
                     double size = Convert.ToDouble((postedFile.ContentLength / (1024 * 1024)).ToString());
                     if (size > 40)
                     {
                         LableMessage.Visible = true;
                         LableMessage.Text = "提示：您上传的文件超出了允许的最大值40M，请上传范围之内的文件";
                         return;
                     }
                     fileExtension = System.IO.Path.GetExtension(fileName);
                     string[] allowFile = { ".apk" };
                     for (int i = 0; i < allowFile.Length; i++)
                     {
                         if (fileExtension == allowFile[i])
                         {
                            // string _date = DateTime.Now.ToString("yyyyMMdd");
                            // string _newFileName = _date + fileName;
                             string _newFileName =fileName;
                             _FilePath = Server.MapPath(@"~/software/") + _newFileName;
                             postedFile.SaveAs(_FilePath);
                             _Path = "../software/" + _newFileName;//保存到数据库中的文件路径
                             BLL.SoftWare sbll = new BLL.SoftWare();
                             sbll.Add(_Title, _Path, _Remark,version);
                             MessageBox.Show(this.Page, "上传成功!");
                             Response.AddHeader("Refresh", "0");
                         }
                         else
                         {
                             LableMessage.Visible = true;
                             LableMessage.Text = "提示：您上传的文件格式不符合要求！只能上传文件格式：apk";
                             return;
                         }
                     }
                 }
                 else
                 {
                     LableMessage.Visible = true;
                     LableMessage.Text = "请选择要上传的手机软件文件！";
                     return;
                 }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtRemark.Text = "";
    }
    #endregion
   
}