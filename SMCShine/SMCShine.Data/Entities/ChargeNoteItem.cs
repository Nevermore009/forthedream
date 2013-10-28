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
    [Table(Name = "dbo.ChargeNoteItem")]
    public class ChargeNoteItem : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private Guid guid = Guid.Empty;
        private Guid? campusGuid = null;
        private Guid chargeNoteGuid = Guid.Empty;
        private Guid goodsItemGuid = Guid.Empty;
        //private Guid studentGuid = Guid.Empty;
        private decimal number = 1;
        private decimal totalMoney = 0;
        private decimal paidMoney = 0;
        private decimal reducedMoney = 0;
        private decimal owedMoney = 0;
        private bool isUndo = false;
        private string memo = null;
        private int state = 0;
        private DateTime createTime = DateTime.Now;
        private EntityRef<ChargeNote> chargeNote;

        public ChargeNoteItem()
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
        [Column(Storage = "chargeNoteGuid", Name = "ChargeNoteGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public Guid ChargeNoteGuid
        {
            get
            {
                return this.chargeNoteGuid;
            }
            set
            {
                if (this.chargeNoteGuid != value || value == Guid.Empty)
                {
                    this.SendPropertyChanging();
                    this.chargeNoteGuid = value;
                    this.SendPropertyChanged("ChargeNoteGuid");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "goodsItemGuid", Name = "GoodsItemGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public Guid GoodsItemGuid
        {
            get
            {
                return this.goodsItemGuid;
            }
            set
            {
                if (this.goodsItemGuid != value || value == Guid.Empty)
                {
                    this.SendPropertyChanging();
                    this.goodsItemGuid = value;
                    this.SendPropertyChanged("GoodsItemGuid");
                }
            }
        }

        /////<summary>
        /////
        /////</summary>
        //[DataMember]
        //[Column(Storage = "studentGuid", Name = "StudentGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        //public Guid StudentGuid
        //{
        //    get
        //    {
        //        return this.studentGuid;
        //    }
        //    set
        //    {
        //        if (this.studentGuid != value || value == Guid.Empty)
        //        {
        //            this.SendPropertyChanging();
        //            this.studentGuid = value;
        //            this.SendPropertyChanged("StudentGuid");
        //        }
        //    }
        //}

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "number", Name = "Number", DbType = "decimal", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public decimal Number
        {
            get
            {
                return this.number;
            }
            set
            {
                if (this.number != value || value == 1)
                {
                    this.SendPropertyChanging();
                    this.number = value;
                    this.SendPropertyChanged("Number");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "totalMoney", Name = "TotalMoney", DbType = "decimal", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public decimal TotalMoney
        {
            get
            {
                return this.totalMoney;
            }
            set
            {
                if (this.totalMoney != value || value == 0)
                {
                    this.SendPropertyChanging();
                    this.totalMoney = value;
                    this.SendPropertyChanged("TotalMoney");
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
        [Column(Storage = "reducedMoney", Name = "ReducedMoney", DbType = "decimal", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public decimal ReducedMoney
        {
            get
            {
                return this.reducedMoney;
            }
            set
            {
                if (this.reducedMoney != value || value == 0)
                {
                    this.SendPropertyChanging();
                    this.reducedMoney = value;
                    this.SendPropertyChanged("ReducedMoney");
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
        [Column(Storage = "createTime", Name = "CreateTime", DbType = "datetime", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public DateTime CreateTime
        {
            get
            {
                return this.createTime;
            }
            set
            {
                if (this.createTime != value || value == DateTime.Now)
                {
                    this.SendPropertyChanging();
                    this.createTime = value;
                    this.SendPropertyChanged("CreateTime");
                }
            }
        }



        ///<summary>
        ///所属
        ///</summary>
        [Association(Storage = "chargeNote", Name = "ChargeNote_ChargeNoteItem", ThisKey = "ChargeNoteGuid", OtherKey = "Guid", IsForeignKey = true)]
        public ChargeNote ChargeNote
        {
            get
            {
                return this.chargeNote.Entity;
            }
            set
            {
                ChargeNote previousValue = this.chargeNote.Entity;
                if (((previousValue != value)
                            || (this.chargeNote.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this.chargeNote.Entity = null;
                        previousValue.ChargeNoteItems.Remove(this);
                    }
                    this.chargeNote.Entity = value;
                    if ((value != null))
                    {
                        value.ChargeNoteItems.Add(this);
                        this.chargeNoteGuid = value.Guid;
                    }
                    else
                    {
                        this.chargeNoteGuid = Guid.Empty;
                    }
                    this.SendPropertyChanged("ChargeNote");
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
