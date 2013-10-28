using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMCShine.Logic;
using System.Data;
using SMCShine.Data.Entities;
using System.Collections;

public partial class Module_CampusManager_CampusTreeManage : BasePage
{
    private CampusManager campusLogic = new CampusManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitTree();
    }
    protected void InitTree()
    {
        List<CampusInfo> list = campusLogic.GetCampusInfo(Campus);
        List<CampusInfo> campusList = list.Distinct(new CampusComparer()).ToList<CampusInfo>();
        List<CampusInfo> schoolList;
        List<CampusInfo> gradeList;
        List<CampusInfo> classList;
        foreach (CampusInfo c in campusList)
        {
            if (c.CampusGuid != null)
            {
                TreeNode campusNode = new TreeNode(c.CampusName, c.CampusGuid.ToString(), "", "AddCampus.aspx?guid="+c.CampusGuid, "framedetail");
                schoolList = list.Where(x => x.CampusGuid == c.CampusGuid).Distinct(new SchoolComparer()).ToList<CampusInfo>();
                foreach (CampusInfo s in schoolList)
                {
                    if (s.SchoolGuid != null)
                    {
                        TreeNode schoolNode = new TreeNode(s.SchoolName, s.SchoolGuid.ToString(), "", "AddSchool.aspx?guid="+s.SchoolGuid.ToString(), "framedetail");
                        gradeList = list.Where(x => x.SchoolGuid == s.SchoolGuid).Distinct(new GradeComparer()).ToList<CampusInfo>();
                        foreach (CampusInfo g in gradeList)
                        {
                            if (g.GradeGuid != null)
                            {
                                TreeNode gradeNode = new TreeNode(g.GradeName, g.GradeGuid.ToString(), "", "AddGrade.aspx?guid=" + g.GradeGuid.ToString(), "framedetail");
                                classList = list.Where(x => x.GradeGuid == g.GradeGuid).Distinct(new ClassComparer()).ToList<CampusInfo>();
                                foreach (CampusInfo p in classList)
                                {
                                    if (p.GradeGuid != null)
                                    {
                                        TreeNode classNode = new TreeNode(p.ClassName, p.ClassGuid.ToString(), "", "AddProfession.aspx?guid="+p.ClassGuid.ToString(), "framedetail");
                                        gradeNode.ChildNodes.Add(classNode);
                                    }
                                }
                                gradeNode.SelectAction = TreeNodeSelectAction.SelectExpand;
                                schoolNode.ChildNodes.Add(gradeNode);
                            }
                        }
                        schoolNode.SelectAction = TreeNodeSelectAction.SelectExpand;                  
                        campusNode.ChildNodes.Add(schoolNode);
                    }
                }
                campusNode.SelectAction = TreeNodeSelectAction.SelectExpand;
                treeCampus.Nodes.Add(campusNode);
            }
        }
    }

   
    class CampusComparer : IEqualityComparer<CampusInfo>
    {
        public bool Equals(CampusInfo c1, CampusInfo c2)
        {
            return (c1.CampusGuid == c2.CampusGuid);
        }
        public int GetHashCode(CampusInfo t)
        {
            return t.ToString().GetHashCode();
        }
    }
    class SchoolComparer : IEqualityComparer<CampusInfo>
    {
        public bool Equals(CampusInfo c1, CampusInfo c2)
        {
            return (c1.SchoolGuid == c2.SchoolGuid);
        }
        public int GetHashCode(CampusInfo t)
        {
            return t.ToString().GetHashCode();
        }
    }
    class GradeComparer : IEqualityComparer<CampusInfo>
    {
        public bool Equals(CampusInfo c1, CampusInfo c2)
        {
            return (c1.GradeGuid == c2.GradeGuid);
        }
        public int GetHashCode(CampusInfo t)
        {
            return t.ToString().GetHashCode();
        }
    }
    class ClassComparer : IEqualityComparer<CampusInfo>
    {
        public bool Equals(CampusInfo c1, CampusInfo c2)
        {
            return (c1.ClassGuid == c2.ClassGuid);
        }
        public int GetHashCode(CampusInfo t)
        {
            return t.ToString().GetHashCode();
        }
    }

}