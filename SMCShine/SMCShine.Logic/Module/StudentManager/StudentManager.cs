using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMCShine.Data.Entities;
using SMCShine.Data;

namespace SMCShine.Logic
{
    public class StudentManager
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

        /// <summary>
        /// 获取所有学员信息
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudentsByUser(string campusGuid)
        {
            List<Student> studentList = (from s in DataContext.Student
                                         where s.State == 0 && (campusGuid == Guid.Empty.ToString() || campusGuid == s.CampusGuid.ToString())
                                         select s).ToList<Student>();
            return studentList;
        }

        public Student GetStudentById(Guid guid)
        {
            return DataContext.Student.SingleOrDefault(x => x.Guid == guid && x.State == 0);
        }

        public bool Add(Student student)
        {
            var campusCode = (from c in DataContext.Campus
                              where c.Guid == student.CampusGuid
                              select new
                              {
                                  c.CampusCode
                              }).ToArray();
            var ClassID = (from c in DataContext.ClassType
                           where c.Guid == student.ClassTypeGuid
                           select new
                           {
                               c.ClassID
                           }).ToArray();
            if (campusCode.Length <= 0 && ClassID.Length <= 0)
                return false;
            int studentNum = DataContext.Student.Count(x => x.ClassTypeGuid == student.ClassTypeGuid);
            string code = campusCode[0].CampusCode;
            string ID = ClassID[0].ClassID;
            student.StudentID = code + ID.PadLeft(3, '0') + (studentNum + 1).ToString("000");
            dataContext.Student.InsertOnSubmit(student);
            dataContext.SubmitChanges();
            return true;
        }

        public bool Update(Student entity)
        {
            Student student = DataContext.Student.SingleOrDefault(x => x.Guid == entity.Guid && x.State == 0);
            if (student == null)
                return false;
            else
            {
                student = entity;
                DataContext.SubmitChanges();
                return true;
            }
        }
    }
}
