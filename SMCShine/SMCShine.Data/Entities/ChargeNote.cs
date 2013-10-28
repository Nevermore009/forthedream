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
    [Table(Name = "dbo.ChargeNote")]
    public class ChargeNote : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private Guid guid = Guid.Empty;
        private Guid? campusGuid = null;
        private Guid? studentGuid = null;
        private string billNumber = string.Empty;
        private string userAccount = string.Empty;
        private string memo = null;
        private string posNumber = null;
        private int chargeWay = 0;
        private int state = 0;
        private DateTime operateTime = DateTime.Now;
        private EntitySet<ChargeNoteItem> chargeNoteItems;

        public ChargeNote()
        {
            this.chargeNoteItems = new EntitySet<ChargeNoteItem>(new Action<ChargeNoteItem>(this.attach_ChargeNoteItem), new Action<ChargeNoteItem>(this.detach_ChargeNoteItem));
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
        [Column(Storage = "studentGuid", Name = "StudentGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public Guid? StudentGuid
        {
            get
            {
                return this.studentGuid;
            }
            set
            {
                if (this.studentGuid != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.studentGuid = value;
                    this.SendPropertyChanged("StudentGuid");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "billNumber", Name = "BillNumber", DbType = "nvarchar", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public string BillNumber
        {
            get
            {
                return this.billNumber;
            }
            set
            {
                if (this.billNumber != value || value == string.Empty)
                {
                    this.SendPropertyChanging();
                    this.billNumber = value;
                    this.SendPropertyChanged("BillNumber");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "userAccount", Name = "UserAccount", DbType = "nvarchar", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public string UserAccount
        {
            get
            {
                return this.userAccount;
            }
            set
            {
                if (this.userAccount != value || value == string.Empty)
                {
                    this.SendPropertyChanging();
                    this.userAccount = value;
                    this.SendPropertyChanged("UserAccount");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "posNumber", Name = "PosNumber", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string PosNumber
        {
            get
            {
                return this.posNumber;
            }
            set
            {
                if (this.posNumber != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.posNumber = value;
                    this.SendPropertyChanged("PosNumber");
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
        [Column(Storage = "chargeWay", Name = "ChargeWay", DbType = "int", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public int ChargeWay
        {
            get
            {
                return this.chargeWay;
            }
            set
            {
                if (this.chargeWay != value || value == 0)
                {
                    this.SendPropertyChanging();
                    this.chargeWay = value;
                    this.SendPropertyChanged("ChargeWay");
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


        ///<summary>
        ///所有
        ///</summary>
        [Association(Storage = "chargeNoteItems", Name = "ChargeNote_ChargeNoteItem", ThisKey = "Guid", OtherKey = "ChargeNoteGuid")]
        public EntitySet<ChargeNoteItem> ChargeNoteItems
        {
            get
            {
                return this.chargeNoteItems;
            }
            set
            {
                this.chargeNoteItems.Assign(value);
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

        private void attach_ChargeNoteItem(ChargeNoteItem entity)
        {
            this.SendPropertyChanging();
            entity.ChargeNote = this;
        }

        private void detach_ChargeNoteItem(ChargeNoteItem entity)
        {
            this.SendPropertyChanging();
            entity.ChargeNote = null;
        }
    }
}
