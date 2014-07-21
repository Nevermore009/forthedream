using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.CommonAPIs;

namespace Justgo8.wx
{
    public partial class MenuCreate : System.Web.UI.Page
    {
        private string access_key = "forthedream";
        private string appId = "";
        private string secret = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request["key"] != access_key)
                    {
                        Response.Write("身份验证未通过！");
                        return;
                    }

                    GetMenuResultFull resultFull = new GetMenuResultFull()
                    {
                        menu = new MenuFull_ButtonGroup()
                        {
                            button = new List<MenuFull_RootButton>() { 
                            new MenuFull_RootButton() {
                                key="viewhot",name="看信息",sub_button=new List<MenuFull_RootButton>() {
                                      new MenuFull_RootButton(){
                                          name="今日推荐",type="view",url="",sub_button=new List<MenuFull_RootButton>()
                                      }
                                }
                            }
                        }
                        }
                    };
                    string access_token = AccessTokenContainer.TryGetToken(appId, secret);
                    var buttonData = CommonApi.GetMenuFromJsonResult(resultFull).menu;
                    var result = CommonApi.CreateMenu(access_token, buttonData);
                    if (result.errcode == 0)
                    {
                        Response.Write("菜单创建成功");
                        return;
                    }
                    else
                    {
                        Response.Write("菜单创建失败:" + result.errcode);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("菜单创建失败:" + ex.ToString());
                    return;

                }
            }
        }
    }
}