using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using SMCShine.Data;
using SMCShine.Data.Entities;
using System.Collections;
using System.Linq.Expressions;

namespace SMCShine.Logic
{
    public class CampusManager
    {
        private GlobalDataContext dataContext = null;
        /// <summary>
        /// 当前DataContext对象
        /// </summary>
        public GlobalDataContext DataContext
        {
            get
            {
                if (dataContext == null)
                {
                    dataContext = new GlobalDataContext();
                }
                return dataContext;
            }
            set
            {
                if (dataContext == null || !dataContext.Equals(value))
                {
                    dataContext = value;
                }
            }
        }

        #region 校区
        public bool AddCampus(Campus campus, out string message)
        {
            bool flag = false;
            Campus existedCampus = DataContext.Campus.SingleOrDefault<Campus>(x => x.Name == campus.Name && x.State == 0);
            if (existedCampus == null)
            {
                flag = true;
                message = "校区添加成功！";
                DataContext.Campus.InsertOnSubmit(campus);
                DataContext.SubmitChanges();
            }
            else
            {
                flag = false;
                message = "该校区名已存在，请重新输入！";
            }
            return flag;
        }

        public List<Campus> GetCampusByUser( string campusGuid)
        {
            List<Campus> campusList = (
                from campus in DataContext.Campus
                where campus.State == 0 && (campusGuid == Guid.Empty.ToString() || campusGuid == campus.Guid.ToString())
                select campus
                ).ToList<Campus>();
            return campusList;
        }

        //public List<Campus> GetAllCampus()
        //{
        //    List<Campus> campusList = (
        //        from campus in DataContext.Campus
        //        where campus.State == 0
        //        select campus
        //        ).ToList<Campus>();
        //    return campusList;
        //}

        public List<CampusInfo> GetCampusInfo( string campusGuid)
        {
            var list = from c in DataContext.CampusInfo
                       where (campusGuid==Guid.Empty.ToString() || campusGuid == c.CampusGuid.ToString())
                       select c; ;
            return list.ToList<CampusInfo>();
        }

        public Campus GetCampusById(Guid? guid)
        {
            return DataContext.Campus.SingleOrDefault(x => x.Guid == guid && x.State == 0);
        }

        public bool UpdateCampus(Campus campus, out string msg)
        {
            msg = "";
            Campus entity = DataContext.Campus.SingleOrDefault(x => x.Guid == campus.Guid && x.State == 0);
            if (entity == null)
            {
                msg = "更新失败";
                return false;
            }
            else
            {
                entity = campus;
                DataContext.SubmitChanges();
                msg = "更新成功";
                return true;
            }
        }

        #endregion

        #region 学校

        public bool AddSchool(School school, out string message)
        {
            bool flag = false;
            School s = DataContext.School.SingleOrDefault(x => x.Name == school.Name && x.State == 0);
            if (s == null)
            {
                flag = true;
                message = "学校添加成功！";
                DataContext.School.InsertOnSubmit(school);
                DataContext.SubmitChanges();
            }
            else
            {
                flag = false;
                message = "该学校名已存在，请重新输入！";
            }
            return flag;
        }

        public List<School> GetAllSchool()
        {
            List<School> schoolList = (
               from s in DataContext.School
               where s.State == 0
               select s
               ).ToList<School>();
            return schoolList;
        }

        public List<School> GetSchoolByCampus(Guid campusGuid)
        {
            List<School> schoolList = (
                          from s in DataContext.School
                          where s.CampusGuid == campusGuid && s.State == 0
                          select s
                          ).ToList<School>();
            return schoolList;
        }

        public object GetSchoolInfo(params Guid[] guids)
        {
            var list = (from c in DataContext.Campus
                        join s in DataContext.School on c.Guid equals s.CampusGuid
                        where s.State == 0 && (guids.Length <= 0 || guids.Contains(c.Guid))
                        select new
                        {
                            CampusName = c.Name,
                            s.Name,
                            s.Memo,
                            s.Guid
                        });
            return list;
        }

        public School GetSchoolById(Guid? guid)
        {
            return DataContext.School.SingleOrDefault(x => x.Guid == guid);
        }

        public bool UpdateSchool(School school, out string msg)
        {
            msg = "";
            School entity = DataContext.School.SingleOrDefault(x => x.Guid == school.Guid && x.State == 0);
            if (entity == null)
            {
                msg = "更新失败";
                return false;
            }
            else
            {
                entity = school;
                DataContext.SubmitChanges();
                msg = "更新成功";
                return true;
            }
        }

        #endregion

        #region 年级
        public bool AddGrade(Grade grade, out string message)
        {
            bool flag = false;
            if (grade.SchoolGuid != null)
            {
                Grade existedGrade = DataContext.Grade.SingleOrDefault<Grade>(x => x.Name == grade.Name && x.SchoolGuid == grade.SchoolGuid && x.State == 0);
                if (existedGrade == null)
                {
                    flag = true;
                    message = "添加年级成功！";
                    DataContext.Grade.InsertOnSubmit(grade);
                    DataContext.SubmitChanges();
                }
                else
                {
                    message = "该年级已经存在，请重新输入！";
                    flag = false;
                }

            }
            else
            {
                message = "请选择校区！";
                flag = false;
            }
            return flag;
        }

        public List<Grade> GetAllGrades()
        {
            List<Grade> gradeList = (
                from grade in DataContext.Grade
                where grade.State == 0
                select grade
                ).ToList<Grade>();
            return gradeList;
        }

        public List<Grade> GetGradeBySchool(Guid schoolGuid)
        {
            return (from s in DataContext.Grade where s.SchoolGuid == schoolGuid && s.State == 0 select s).ToList<Grade>();
        }

        public object GetGradesInfo(params Guid[] guids)
        {
            var list = (from c in DataContext.Campus
                        join s in DataContext.School on c.Guid equals s.CampusGuid
                        join g in DataContext.Grade on s.Guid equals g.SchoolGuid
                        where g.State == 0 && (guids.Length <= 0 || guids.Contains(s.Guid))
                        select new
                        {
                            CampusName = c.Name,
                            SchoolName = s.Name,
                            g.Name,
                            g.Memo,
                            g.Guid
                        });
            return list;
        }

        public Grade GetGradeById(Guid? guid)
        {
            return DataContext.Grade.SingleOrDefault(x => x.Guid == guid && x.State == 0);
        }

        public bool UpdateGrade(Grade grade, out string msg)
        {
            msg = "";
            Grade entity = DataContext.Grade.SingleOrDefault(x => x.Guid == grade.Guid && x.State == 0);
            if (entity == null)
            {
                msg = "更新失败";
                return false;
            }
            else
            {
                entity = grade;
                DataContext.SubmitChanges();
                msg = "更新成功";
                return true;
            }
        }

        #endregion

        #region 班级
        public bool AddClass(ClassType classType, out string message)
        {
            bool flag = false;
            ClassType existedClassType = DataContext.ClassType.SingleOrDefault<ClassType>(x => x.GradeGuid == classType.GradeGuid && x.Name == classType.Name && x.State == 0);
            if (existedClassType == null)
            {
                message = "添加班别成功！";
                flag = true;
                DataContext.ClassType.InsertOnSubmit(classType);
                DataContext.SubmitChanges();
            }
            else
            {
                flag = false;
                message = "该班别已存在，请重新输入！";
            }
            return flag;
        }

        public List<ClassType> GetAllClass()
        {
            return DataContext.ClassType.ToList<ClassType>();
        }

        public List<ClassType> GetClassByGrade(string ClassGuid)
        {
            Guid guid = new Guid(ClassGuid);
            List<ClassType> classlist = (from s in DataContext.ClassType where s.GradeGuid == guid && s.State == 0 select s).ToList<ClassType>();
            return classlist;
        }

        public object GetClassInfo(params Guid[] guids)
        {
            var list = (from c in DataContext.Campus
                        join s in DataContext.School on c.Guid equals s.CampusGuid
                        join g in DataContext.Grade on s.Guid equals g.SchoolGuid
                        join cl in DataContext.ClassType on g.Guid equals cl.GradeGuid
                        where cl.State == 0 && (guids.Length <= 0 || guids.Contains(g.Guid))
                        select new
                        {
                            CampusName = c.Name,
                            SchoolName = s.Name,
                            GradeName = g.Name,
                            cl.Name,
                            cl.Memo,
                            cl.Classification,
                            cl.Guid
                        });
            return list;
        }

        public ClassType GetClassById(Guid? guid)
        {
            return DataContext.ClassType.SingleOrDefault(x => x.Guid == guid && x.State == 0);
        }

        public bool UpdateClass(ClassType classType, out string msg)
        {
            msg = "";
            ClassType entity = DataContext.ClassType.SingleOrDefault(x => x.Guid == classType.Guid && x.State == 0);
            if (entity == null)
            {
                msg = "更新失败";
                return false;
            }
            else
            {
                entity = classType;
                DataContext.SubmitChanges();
                msg = "更新成功";
                return true;
            }
        }

        #endregion


        public string GetUserGroupNameByUserAccount(string userAccount, string campusGuid)
        {
            string userGroupName = string.Empty;
            userGroupName = (
                from user in DataContext.User
                join ug in DataContext.UserGroup on user.UserGroupGuid equals ug.Guid
                where user.UserAccount == userAccount && user.CampusGuid == new Guid(campusGuid) && user.State == 0
                select new { ug.Name }
                ).ToString();
            return userGroupName;
        }

    }
}
