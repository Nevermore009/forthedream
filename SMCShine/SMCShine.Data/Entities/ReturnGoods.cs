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
    [Table(Name = "dbo.ReturnGoods")]
    public class ReturnGoods : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private Guid guid = Guid.Empty;
        private Guid? campusGuid = null;
        private Guid studentGuid = Guid.Empty;
        private decimal returnMeney = 0;
        private string reson = null;
        private string approver = null;
        private Guid userGuid = Guid.Empty;
        private string memo = null;
        private int state = 0;
        private DateTime operateTime = DateTime.Now;

        public ReturnGoods()
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
        [Column(Storage = "studentGuid", Name = "StudentGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public Guid StudentGuid
        {
            get
            {
                return this.studentGuid;
            }
            set
            {
                if (this.studentGuid != value || value == Guid.Empty)
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
        [Column(Storage = "returnMeney", Name = "ReturnMeney", DbType = "decimal", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public decimal ReturnMeney
        {
            get
            {
                return this.returnMeney;
            }
            set
            {
                if (this.returnMeney != value || value == 0)
                {
                    this.SendPropertyChanging();
                    this.returnMeney = value;
                    this.SendPropertyChanged("ReturnMeney");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "reson", Name = "Reson", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string Reson
        {
            get
            {
                return this.reson;
            }
            set
            {
                if (this.reson != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.reson = value;
                    this.SendPropertyChanged("Reson");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "approver", Name = "Approver", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string Approver
        {
            get
            {
                return this.approver;
            }
            set
            {
                if (this.approver != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.approver = value;
                    this.SendPropertyChanged("Approver");
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
