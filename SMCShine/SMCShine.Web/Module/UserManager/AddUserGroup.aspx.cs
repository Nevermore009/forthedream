using System;
using System.Data;
using System.Xml;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;
using SMCShine.Common;
using SMCShine.Logic;
using SMCShine.Data.Entities;

public partial class Module_UserManager_AddUserGroup : BasePage
{
    private CampusManager campusLogic = new CampusManager();
    private UserManager userManager = new UserManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitPermissionTree();
            BindDropCampus();
            treePermission.Attributes.Add("onclick", "CheckEvent(event)");
        }
    }

    protected void BindDropCampus()
    {
        BindHelper.BindDropDownList(ddlCampus, campusLogic.GetCampusByUser(Campus), "Name", "guid");
    }

    protected void InitPermissionTree()
    {
        string filepath = Server.MapPath("~/Common/xmldoc/menu.xml");
        XmlDocument doc = new XmlDocument();
        doc.Load(filepath);
        XmlNode root = doc.DocumentElement;
        Stack<TreeNode> treeStack = new Stack<TreeNode>();
        Stack<XmlNode> xmlStack = new Stack<XmlNode>();
        foreach (XmlNode n in root.ChildNodes)
        {
            xmlStack.Push(n);
            if (n.Attributes["name"] != null)
            {
                TreeNode node = new TreeNode(n.Attributes["name"].Value, n.Name);
                node.SelectAction = TreeNodeSelectAction.SelectExpand;
                treePermission.Nodes.Add(node);
                treeStack.Push(node);
            }
        }
        XmlNode curXmlNode;
        TreeNode curTreeNode;
        while (xmlStack.Count > 0)
        {
            curXmlNode = xmlStack.Pop();
            curTreeNode = treeStack.Pop();
            foreach (XmlNode n in curXmlNode.ChildNodes)
            {
                xmlStack.Push(n);
                if (n.Attributes["name"] != null)
                {
                    TreeNode node = new TreeNode(n.Attributes["name"].Value, n.Name);
                    node.SelectAction = TreeNodeSelectAction.SelectExpand;
                    curTreeNode.ChildNodes.Add(node);
                    treeStack.Push(node);
                }
            }
        }

    }

    protected void btnAddUserGroup_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            UserGroup entity = new UserGroup();
            entity.Name = txtUserGroupName.Text.Trim();
            entity.Memo = txtUserGroupMemo.Text;
            entity.CampusGuid = new Guid(ddlCampus.SelectedValue);
            entity.PermisionXml = GetPermissionXml();
            if (userManager.AddUserGroup(entity))
            {
                MessageBox.Show(this.Page, "添加成功!");
                Response.AddHeader("refresh", "0");
            }
            else
            {
                MessageBox.Show(this.Page, "添加失败!");
            }
        }
    }
    protected string GetPermissionXml()
    {
        XmlDocument doc = new XmlDocument();
        XmlNode root = doc.CreateElement("root");
        doc.AppendChild(root);
        Stack<TreeNode> treeStack = new Stack<TreeNode>();
        Stack<XmlNode> xmlStack = new Stack<XmlNode>();
        foreach (TreeNode n in treePermission.Nodes)
        {
            treeStack.Push(n);
            XmlElement xe = doc.CreateElement(n.Value);
            xe.SetAttribute("name", n.Text);
            if (n.Checked)
            {
                xe.SetAttribute("visible", "1");
            }
            else
            {
                xe.SetAttribute("visible", "0");
            }
            root.AppendChild(xe);
            xmlStack.Push(xe);
        }
        XmlNode curXmlNode;
        TreeNode curTreeNode;
        while (treeStack.Count > 0)
        {
            curXmlNode = xmlStack.Pop();
            curTreeNode = treeStack.Pop();
            foreach (TreeNode n in curTreeNode.ChildNodes)
            {
                treeStack.Push(n);
                XmlElement xe = doc.CreateElement(n.Value);
                xe.SetAttribute("name", n.Text);
                if (n.Checked)
                {
                    xe.SetAttribute("visible", "1");
                }
                else
                {
                    xe.SetAttribute("visible", "0");
                }
                curXmlNode.AppendChild(xe);
                xmlStack.Push(xe);
            }
        }
        return doc.InnerXml;
    }
}