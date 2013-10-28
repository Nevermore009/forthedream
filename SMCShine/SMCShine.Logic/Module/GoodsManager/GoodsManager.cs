using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMCShine.Data.Entities;
using SMCShine.Data;

namespace SMCShine.Logic.Module.GoodsManager
{
    public class GoodsManager
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
        /// 获取所有缴费类型
        /// </summary>
        /// <returns></returns>
        public List<GoodsType> GetGoodsTypesByUser(string campusGuid)
        {
            return DataContext.GoodsType.Where(x => x.State == 0 && (campusGuid == Guid.Empty.ToString() || campusGuid == x.CampusGuid.ToString())).ToList<GoodsType>();
        }

        public List<GoodsType> GetGoodsTypeByCampus(Guid campusGuid)
        {
            return (from s in DataContext.GoodsType where s.CampusGuid == campusGuid && s.State == 0 select s).ToList<GoodsType>();
        }

        /// <summary>
        /// 获取所有缴费项目
        /// </summary>
        /// <returns></returns>
        public List<GoodsItem> GetGoodsItemsByUser(string campusGuid)
        {
            return DataContext.GoodsItem.Where(x => campusGuid == Guid.Empty.ToString() || x.CampusGuid.ToString() == campusGuid).ToList<GoodsItem>();
        }


        public List<GoodsItem> GetGoodsItemsByType(Guid goodsTypeGuid)
        {
            return (from s in DataContext.GoodsItem where s.GoodsTypeGuid == goodsTypeGuid && s.State == 0 select s).ToList<GoodsItem>();
        }

        public object GetGoodsTypeInfoByUser( string campusGuid)
        {
            var list = (from t in DataContext.GoodsType
                        join c in DataContext.Campus on t.CampusGuid equals c.Guid
                        where t.State == 0 && (campusGuid==Guid.Empty.ToString() || campusGuid == c.Guid.ToString())
                        select new
                        {
                            campusName = c.Name,
                            t.Name,
                            t.Memo,
                            t.Guid
                        });
            return list;
        }

        public object GetGoodsItemInfoByUser( string campusGuid)
        {
            var list = (from t in DataContext.GoodsType
                        join c in DataContext.Campus on t.CampusGuid equals c.Guid
                        join i in DataContext.GoodsItem on t.Guid equals i.GoodsTypeGuid
                        join s in DataContext.School on i.SchoolGuid equals s.Guid
                        join g in DataContext.Grade on i.GradeGuid equals g.Guid
                        join p in DataContext.ClassType on i.ClassGuid equals p.Guid
                        where i.State == 0 && (campusGuid==Guid.Empty.ToString() || campusGuid == c.Guid.ToString())
                        select new
                        {
                            goodsTypeName = t.Name,
                            campusName = c.Name,
                            schoolName = s.Name,
                            gradeName = g.Name,
                            className = p.Name,
                            i.Price,
                            i.Name,
                            i.Memo,
                            i.Guid
                        });
            return list;
        }

        public bool AddGoodsType(GoodsType entity)
        {
            if (DataContext.GoodsType.SingleOrDefault(x => x.Name == entity.Name && x.CampusGuid == entity.CampusGuid && x.State == 0) == null)
            {
                DataContext.GoodsType.InsertOnSubmit(entity);
                DataContext.SubmitChanges();
                return true;
            }
            else
                return false;
        }

        public bool AddGoodsItem(GoodsItem entity)
        {
            if (DataContext.GoodsItem.SingleOrDefault(x => x.Name == entity.Name && x.GoodsTypeGuid == entity.GoodsTypeGuid && x.State == 0) == null)
            {
                DataContext.GoodsItem.InsertOnSubmit(entity);
                DataContext.SubmitChanges();
                return true;
            }
            else
                return false;
        }
    }
}
