using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml;

/// <summary>
///XmlHelper 的摘要说明
/// </summary>
public class XmlHelper
{
    public XmlHelper()
    {

    }

    public static DataTable GetPermissionTable(string xmlText)
    {
        DataTable permissionDt = new DataTable();
        permissionDt.Columns.Add("name");
        permissionDt.Columns.Add("visible");
        permissionDt.PrimaryKey = new DataColumn[]{permissionDt.Columns["name"]};
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlText);
        XmlNode root = doc.DocumentElement;
        Stack<XmlNode> stack = new Stack<XmlNode>();
        foreach (XmlNode n in root.ChildNodes)
        {
            stack.Push(n);
        }
        XmlNode curNode;
        while (stack.Count > 0)
        {
            curNode = stack.Pop();
            foreach (XmlNode n in curNode.ChildNodes)
            {
                stack.Push(n);
            }
            if (curNode.Attributes["name"] == null)
                continue;
            string name = curNode.Attributes["name"].Value;
            string visible = curNode.Attributes["visible"] == null ? "0" :curNode.Attributes["visible"].Value.ToString();
            DataRow row = permissionDt.NewRow();
            row["name"] = name;
            row["visible"] = visible;
            try
            {
                permissionDt.Rows.Add(row);
            }
            catch
            {
                continue;
            }
        }
        return permissionDt;
    }
}