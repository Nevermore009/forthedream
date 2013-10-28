using System;
using SMCShine.Logic;
using System.Xml;
using System.Text;
using System.Data;

public partial class leftPages_leftMenu : BasePage
{
    private UserManager userManager = new UserManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitMenu();
        }
    }
    protected void InitMenu()
    {
        Guid g = new Guid(UserGroup);
        string xml = userManager.GetPermisionXml(g);
        DataTable dt = XmlHelper.GetPermissionTable(xml);
        string filepath = Server.MapPath("~/Common/xmldoc/menu.xml");
        XmlDocument doc = new XmlDocument();
        doc.Load(filepath);
        CreateMenu(doc, dt);
    }

    private string urlconvertor(string imagesurl1)
    {
        //获取程序根目录
        string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());
        //转换成URL相对路径
        string imagesurl2 = imagesurl1.Replace(tmpRootDir, "");
        imagesurl2 = imagesurl2.Replace(@"/", @"/");
        return imagesurl2;
    }

    protected void CreateMenu(XmlDocument xmlDoc, DataTable permissionTable)
    {
        string menuHtml = GetNodeHtml(xmlDoc.DocumentElement, permissionTable);
        arrowlistmenu.InnerHtml = menuHtml;
    }
    protected string GetNodeHtml(XmlNode node, DataTable permissionTable)
    {
        StringBuilder menuHtml = new StringBuilder();
        if (node == node.OwnerDocument.DocumentElement)
        {
            foreach (XmlNode n in node.ChildNodes)
            {
                menuHtml.Append(GetNodeHtml(n, permissionTable));
            }
            return menuHtml.ToString();
        }
        if (node.Attributes["name"] == null)
            return "";
        string name = node.Attributes["name"].Value.ToString();
        string url = node.Attributes["url"] == null ? "" : node.Attributes["url"].Value.ToString();
        if (UserGroupName=="管理员"||(permissionTable.Rows.Contains(name) && permissionTable.Rows.Find(name)["visible"].ToString() == "1"))
        {
            if (node.ParentNode == node.OwnerDocument.DocumentElement)
            {
                menuHtml.Append("<div class=\"menuheader expandable\">");
                string cssClass = node.Attributes["cssclass"] == null ? "normal_icon1" : node.Attributes["cssclass"].Value.ToString();
                menuHtml.Append(string.Format("<span class=\"{0}\"></span>", cssClass));
                menuHtml.Append(name);
                menuHtml.Append("</div>");
                menuHtml.Append("<ul class=\"categoryitems\">");
                foreach (XmlNode n in node.ChildNodes)
                {
                    menuHtml.Append(GetNodeHtml(n, permissionTable));
                }
                menuHtml.Append("</ul>");
            }
            else
            {
                if (node.HasChildNodes)
                {
                    menuHtml.Append(string.Format("<li><a href=\"#\"><span class=\"text_slice\">{0}</span></a>", name));
                    menuHtml.Append("<ul>");
                    foreach (XmlNode n in node.ChildNodes)
                    {
                        menuHtml.Append(GetNodeHtml(n, permissionTable));
                    }
                    menuHtml.Append("</ul>");
                    menuHtml.Append("</li>");
                }
                else
                {
                    string target = node.Attributes["target"] == null ? "_blank" : node.Attributes["target"].Value.ToString(); ;
                    menuHtml.Append(string.Format("<li><a href=\"{0}\" target=\"{1}\"><span class=\"text_slice\">{2}</span></a></li>", url, target, name));
                }
            }
            return menuHtml.ToString();
        }
        else
            return "";
    }
}