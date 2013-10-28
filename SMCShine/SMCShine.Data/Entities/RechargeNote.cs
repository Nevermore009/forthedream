///<summary>
///Copyright (C) 奥凯软件
///创建标识： 2013-08-05 Created by xxc
///功能说明：实体类
///</summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Reflection;
using SMCShine.Common.Validation;

namespace SMCShine.Data.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract, Serializable]
    [Table(Name = "dbo.RechargeNote")]
    public class RechargeNote : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private Guid guid = Guid.Empty;
        private Guid? campusGuid = null;
        private Guid chargeNoteItemGuid = Guid.Empty;
        private decimal owedMoney = 0;
        private decimal paidMoney = 0;
        private decimal reduceMoney = 0;
        private Guid userGuid = Guid.Empty;
        private bool isUndo = false;
        private string memo = null;
        private int state = 0;
        private DateTime operateTime = DateTime.Now;

        public RechargeNote()
        {
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "guid", Name = "Guid", IsDbGenerated = true, DbType = "uniqueidentifier", IsVersion = false, IsPrimaryKey = true)]
        public Guid Guid
        {
            get
            {
                return this.guid;
            }
            set
            {
                if (this.guid != value || value == Guid.Empty)
                {
                    this.SendPropertyChanging();
                    this.guid = value;
                    this.SendPropertyChanged("Guid");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "campusGuid", Name = "CampusGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public Guid? CampusGuid
        {
            get
            {
                return this.campusGuid;
            }
            set
            {
                if (this.campusGuid != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.campusGuid = value;
                    this.SendPropertyChanged("CampusGuid");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "chargeNoteItemGuid", Name = "ChargeNoteItemGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public Guid ChargeNoteItemGuid
        {
            get
            {
                return this.chargeNoteItemGuid;
            }
            set
            {
                if (this.chargeNoteItemGuid != value || value == Guid.Empty)
                {
                    this.SendPropertyChanging();
                    this.chargeNoteItemGuid = value;
                    this.SendPropertyChanged("ChargeNoteItemGuid");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "owedMoney", Name = "OwedMoney", DbType = "decimal", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public decimal OwedMoney
        {
            get
            {
                return this.owedMoney;
            }
            set
            {
                if (this.owedMoney != value || value == 0)
                {
                    this.SendPropertyChanging();
                    this.owedMoney = value;
                    this.SendPropertyChanged("OwedMoney");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "paidMoney", Name = "PaidMoney", DbType = "decimal", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public decimal PaidMoney
        {
            get
            {
                return this.paidMoney;
            }
            set
            {
                if (this.paidMoney != value || value == 0)
                {
                    this.SendPropertyChanging();
                    this.paidMoney = value;
                    this.SendPropertyChanged("PaidMoney");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "reduceMoney", Name = "ReduceMoney", DbType = "decimal", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public decimal ReduceMoney
        {
            get
            {
                return this.reduceMoney;
            }
            set
            {
                if (this.reduceMoney != value || value == 0)
                {
                    this.SendPropertyChanging();
                    this.reduceMoney = value;
                    this.SendPropertyChanged("ReduceMoney");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "userGuid", Name = "UserGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public Guid UserGuid
        {
            get
            {
                return this.userGuid;
            }
            set
            {
                if (this.userGuid != value || value == Guid.Empty)
                {
                    this.SendPropertyChanging();
                    this.userGuid = value;
                    this.SendPropertyChanged("UserGuid");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "isUndo", Name = "IsUndo", DbType = "bit", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public bool IsUndo
        {
            get
            {
                return this.isUndo;
            }
            set
            {
                if (this.isUndo != value || value == false)
                {
                    this.SendPropertyChanging();
                    this.isUndo = value;
                    this.SendPropertyChanged("IsUndo");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "memo", Name = "Memo", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string Memo
        {
            get
            {
                return this.memo;
            }
            set
            {
                if (this.memo != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.memo = value;
                    this.SendPropertyChanged("Memo");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "state", Name = "State", DbType = "int", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public int State
        {
            get
            {
                return this.state;
            }
            set
            {
                if (this.state != value || value == 0)
                {
                    this.SendPropertyChanging();
                    this.state = value;
                    this.SendPropertyChanged("State");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "operateTime", Name = "OperateTime", DbType = "datetime", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public DateTime OperateTime
        {
            get
            {
                return this.operateTime;
            }
            set
            {
                if (this.operateTime != value || value == DateTime.Now)
                {
                    this.SendPropertyChanging();
                    this.operateTime = value;
                    this.SendPropertyChanged("OperateTime");
                }
            }
        }



        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            PropertyInfo pi = this.GetType().GetProperty(propertyName);
            foreach (object validator in pi.GetCustomAttributes(typeof(IValidator), true))
            {
                ((IValidator)validator).Validate(pi.GetValue(this, null));
            }
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
