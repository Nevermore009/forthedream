using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using SMCShine.Data.Entities;

namespace SMCShine.Data
{
    public class GlobalDataContext : BaseDataContext
    {
        public Table<CampusInfo> CampusInfo
        {
            get
            {
                return this.GetTable<CampusInfo>();
            }
        }
        public Table<Campus> Campus
        {
            get
            {
                return this.GetTable<Campus>();
            }
        }
        public Table<School> School
        {
            get
            {
                return this.GetTable<School>();
            }
        }        
        public Table<Grade> Grade
        {
            get
            {
                return this.GetTable<Grade>();
            }
        }
        public Table<ClassType> ClassType
        {
            get
            {
                return this.GetTable<ClassType>();
            }
        }
        public Table<UserGroup> UserGroup
        {
            get
            {
                return this.GetTable<UserGroup>();
            }
        }
        public Table<User> User
        {
            get
            {
                return this.GetTable<User>();
            }
        }
        public Table<Student> Student
        {
            get
            {
                return this.GetTable<Student>();
            }
        }
        public Table<GoodsType> GoodsType
        {
            get
            {
                return this.GetTable<GoodsType>();
            }
        }
        public Table<GoodsItem> GoodsItem
        {
            get
            {
                return this.GetTable<GoodsItem>();
            }
        }
        public Table<ChargeNote> ChargeNote
        {
            get
            {
                return this.GetTable<ChargeNote>();
            }
        }
        public Table<ChargeNoteItem> ChargeNoteItem
        {
            get
            {
                return this.GetTable<ChargeNoteItem>();
            }
        }
        public Table<RechargeNote> RechargeNote
        {
            get
            {
                return this.GetTable<RechargeNote>();
            }
        }
        public Table<ReturnGoods> ReturnGoods
        {
            get
            {
                return this.GetTable<ReturnGoods>();
            }
        }
        public Table<SystemLog> SystemLog
        {
            get
            {
                return this.GetTable<SystemLog>();
            }
        }
        public Table<ChargeInfo> ChargeNoteInfo
        {
            get
            {
                return this.GetTable<ChargeInfo>();
            }
        }
        public Table<VChargeNote> VChargeNote
        {
            get
            {
                return this.GetTable<VChargeNote>();
            }
        }
    }
}
