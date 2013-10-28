using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SMCShine.Data;
using SMCShine.Data.Entities;
using System.Data.SqlClient;
using SMCShine.Logic.Common;


namespace SMCShine.Logic
{
    public class ChargeManager
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

        public List<School> GetSchoolsFromCampus(string campusGuid)
        {
            List<School> schoolList;
            if (campusGuid != null)
            {
                schoolList = (from s in DataContext.School
                              where s.CampusGuid == new Guid(campusGuid)
                              select s).ToList<School>();
            }
            else
            {
                schoolList = (from s in DataContext.School
                              select s).ToList<School>();
            }
            return schoolList;
        }
        public List<School> GetAllSchools()
        {
            List<School> schoolList = (from s in DataContext.School
                                       select s).ToList<School>();
            return schoolList;
        }
        //public Student CheckStudent(Guid schoolGuid, string ID)
        //{
        //    Student student = DataContext.Student.SingleOrDefault<Student>(x => x.SchoolGuid == schoolGuid && x.ID == ID);
        //    return student;
        //}
        public Student CheckStudent(Guid classGuid, string studentName)
        {
            return DataContext.Student.SingleOrDefault(x => x.State == 0 && x.ClassTypeGuid == classGuid && x.Name == studentName);
        }
        public List<GoodsType> GetGoodsTypeByCampus(string campusGuid)
        {
            if (string.IsNullOrEmpty(campusGuid))
            {
                return null;
            }
            List<GoodsType> goodsTypeList;
            if (campusGuid == Guid.Empty.ToString())
            {
                goodsTypeList = (from g in DataContext.GoodsType
                                 select g).ToList<GoodsType>();
            }
            else
            {
                goodsTypeList = (from g in DataContext.GoodsType
                                 where g.CampusGuid == new Guid(campusGuid)
                                 select g).ToList<GoodsType>();
            }
            return goodsTypeList;
        }
        public List<GoodsType> GetGoodsTypeBySchool(Guid schoolGuid)
        {
            return (from g in DataContext.GoodsItem
                    join t in DataContext.GoodsType on g.GoodsTypeGuid equals t.Guid
                    where g.SchoolGuid == schoolGuid
                    select t).Distinct<GoodsType>().ToList();
        }
        public List<GoodsItem> GetGoodsItem(Guid goodsTypeGuid)
        {
            List<GoodsItem> goodsList = (
                            from gi in DataContext.GoodsItem
                            where gi.GoodsTypeGuid == goodsTypeGuid
                            select gi
                        ).ToList<GoodsItem>();
            return goodsList;
        }
        public object GetGoodsItemWithPrice(Guid goodsTypeGuid)
        {
            var goodsList = (
                              from gi in DataContext.GoodsItem
                              where gi.GoodsTypeGuid == goodsTypeGuid
                              select new
                              {
                                  Name = gi.Name + "(" + gi.Price + ")",
                                  Guid = gi.Guid
                              }
                          );
            return goodsList;
        }
        public string GenerateBillNumber(Guid campusGuid)
        {
            //校区编码，时间，四位随机数
            string billNumber = string.Empty;
            Random random = new Random();
            Campus campus = DataContext.Campus.SingleOrDefault<Campus>(x => x.Guid == campusGuid);
            if (campus != null)
            {
                List<ChargeNote> list = (from cn in DataContext.ChargeNote
                                         where cn.CampusGuid == campus.Guid && cn.OperateTime > Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).AddSeconds(-1)
                                         select cn).ToList<ChargeNote>();
                int number = list.Count == 0 ? 1 : list.Count + 1;
                billNumber = campus.CampusCode + DateTime.Now.ToString("yyMMdd") + number.ToString("000");
            }
            return billNumber;
        }
        public Student GetStudentByID(string id)
        {
            Student student = DataContext.Student.SingleOrDefault<Student>(x => x.ID == id);
            return student;
        }
        public Student GetStudentByName(string studentName)
        {
            Student student = DataContext.Student.FirstOrDefault(x => x.State == 0 && x.Name == studentName);
            return student;
        }
        public bool AddChargeNote(ChargeNote chargeNote, ChargeNoteItem chargeNoteItem)
        {
            if (DataContext.Connection.State != ConnectionState.Open)
                DataContext.Connection.Open();
            SqlTransaction tran = (SqlTransaction)DataContext.Connection.BeginTransaction();
            DataContext.Transaction = tran;
            try
            {
                DataContext.ChargeNote.InsertOnSubmit(chargeNote);
                chargeNote.ChargeNoteItems.Add(chargeNoteItem);
                DataContext.SubmitChanges();
                DataContext.Transaction.Commit();
                return true;
            }
            catch
            {
                DataContext.Transaction.Rollback();
                return false;
            }
        }
        public School GetSchoolByGuid(Guid schoolGuid)
        {
            School school = DataContext.School.SingleOrDefault<School>(x => x.Guid == schoolGuid);
            return school;
        }
        public GoodsItem GetGoodsItemByGuid(Guid goodsItemGuid)
        {
            GoodsItem goodsItem = DataContext.GoodsItem.SingleOrDefault<GoodsItem>(x => x.Guid == goodsItemGuid);
            return goodsItem;
        }
        public List<VChargeNote> GetChargeNoteByBillNumber(string billNumber, Guid campusGuid)
        {
            List<VChargeNote> chargeNote = (from cn in DataContext.VChargeNote
                                            where cn.BillNumber == billNumber && cn.CampusGuid == campusGuid
                                            select cn).ToList<VChargeNote>();
            //select new
            //{
            //    BillNumber = cn.BillNumber,
            //    CampusName = cn.CampusName,
            //    SchoolName = cn.SchoolName,
            //    GradeName = cn.GradeName,
            //    ClassName = cn.ClassName,
            //    StudentName = cn.StudentName,
            //    GoodsTypeName = cn.GoodsTypeName,
            //    GoodsItemName = cn.GoodsItemName,
            //    TotalMoney = cn.TotalMoney,
            //    PaidMoney = cn.PaidMoney,
            //    UserName = cn.UserName,
            //    ChargeWay = cn.ChargeWay,
            //    PosNumber = cn.PosNumber,
            //    Price = cn.Price
            //};
            return chargeNote;
        }

        public List<ChargeInfo> GetAllChargeInfoByUser(string campusGuid)
        {
            return DataContext.ChargeNoteInfo.Where(x => x.State == 0 && (campusGuid == Guid.Empty.ToString() || campusGuid == x.CampusGuid.ToString())).OrderByDescending(x => x.OperateTime).ToList<ChargeInfo>();
        }

        public List<ChargeInfo> GetChargeInfoByCondition(ChargeInfoCondition entity)
        {
            var predicate = PredicateBuilder.True<ChargeInfo>();
            predicate.And(x => x.State == 0);
            if (entity.ChargeInfoEntity.CampusGuid != null)
                predicate = predicate.And(x => x.CampusGuid == entity.ChargeInfoEntity.CampusGuid);
            if (entity.ChargeInfoEntity.SchoolGuid != null)
                predicate = predicate.And(x => x.SchoolGuid == entity.ChargeInfoEntity.SchoolGuid);
            if (entity.ChargeInfoEntity.GradeGuid != null)
                predicate = predicate.And(x => x.GradeGuid == entity.ChargeInfoEntity.GradeGuid);
            if (entity.ChargeInfoEntity.ClassGuid != null)
                predicate = predicate.And(x => x.ClassGuid == entity.ChargeInfoEntity.ClassGuid);
            if (!string.IsNullOrEmpty(entity.ChargeInfoEntity.BillNumber))
                predicate = predicate.And(x => x.BillNumber.Contains(entity.ChargeInfoEntity.BillNumber));
            if (!string.IsNullOrEmpty(entity.ChargeInfoEntity.ID))
                predicate = predicate.And(x => x.ID.Contains(entity.ChargeInfoEntity.ID));
            if (!string.IsNullOrEmpty(entity.ChargeInfoEntity.StudentName))
                predicate = predicate.And(x => x.StudentName.Contains(entity.ChargeInfoEntity.StudentName));
            if (!string.IsNullOrEmpty(entity.StartDate))
            {
                DateTime starttime = DateTime.ParseExact(entity.StartDate, "yyyy-MM-dd", null);
                predicate = predicate.And(x => x.CreateTime.Date >= starttime.Date);
            }
            if (!string.IsNullOrEmpty(entity.EndDate))
            {
                DateTime endtime = DateTime.ParseExact(entity.EndDate, "yyyy-MM-dd", null);
                predicate = predicate.And(x => x.CreateTime.Date <= endtime.Date);
            }
            return DataContext.ChargeNoteInfo.Where(predicate).OrderByDescending(x => x.CreateTime).ToList<ChargeInfo>();
        }

        #region 使用举例
        /*
        List<Product> GetProductsByAND(params string[] keywords)
        {
            DBDataContext db = new DBDataContext(Database.ConnectionString);
            IQueryable<Product> query = db.Products;
            foreach (string keyword in keywords)
            {
                string temp = keyword;
                query = query.Where(p => p.Description.Contains(temp));
            }
            //翻译后的sql语句:
            //Select [t0].[ID], [t0].[Name], [t0].[Description]
            //FROM [dbo].[Product] AS [t0]
            //Where ([t0].[Description] LIKE '%手机%') AND ([t0].[Description] LIKE '%6111%')
            return query.ToList();
        }


        List<Product> GetProductsByOR(params string[] keywords)
        {
            DBDataContext db = new DBDataContext(Database.ConnectionString);
            var predicate = PredicateBuilder.False<Product>();
            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate = predicate.Or(p => p.Description.Contains(temp));
            }
            var query = db.Products.Where(predicate);
            //翻译后的sql语句:
            //Select [t0].[ID], [t0].[Name], [t0].[Description]
            //FROM [dbo].[Product] AS [t0]
            //Where ([t0].[Description] LIKE '%6111%') OR ([t0].[Description] LIKE '%2350%')
            return query.ToList();
        }

        void ShowData()
        {
            //var _products = GetProductsByOR("6111", "2350");
            //Repeater1.DataSource = _products;
            //Repeater1.DataBind();

            var predicate = PredicateBuilder.True<Product>();

            string _name = "6111";
            if (!string.IsNullOrEmpty(_name))
            {
                predicate = predicate.And(p => p.Name.Contains(_name));
            }

            string _description = "长虹";
            if (!string.IsNullOrEmpty(_description))
            {
                predicate = predicate.And(p => p.Description.Contains(_description));
            }

            using (DBDataContext db = new DBDataContext(Database.ConnectionString))
            {
                var _Products = db.Products.Where(predicate);
                Repeater1.DataSource = _Products;
                Repeater1.DataBind();
            }
        }
         * */
        #endregion
    }
}
