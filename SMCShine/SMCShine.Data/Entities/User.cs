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
    [Table(Name = "dbo.User")]
    public class User : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private Guid guid = Guid.Empty;
        private Guid userGroupGuid = Guid.Empty;
        private Guid? campusGuid = null;
        private string userAccount = null;
        private string userPassword = null;
        private string name = null;
        private string mobile = null;
        private int state = 0;
        private string memo = null;
        private DateTime createTime = DateTime.Now;
        private EntityRef<UserGroup> userGroup;

        public User()
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
        [Column(Storage = "userGroupGuid", Name = "UserGroupGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public Guid UserGroupGuid
        {
            get
            {
                return this.userGroupGuid;
            }
            set
            {
                if (this.userGroupGuid != value || value == Guid.Empty)
                {
                    this.SendPropertyChanging();
                    this.userGroupGuid = value;
                    this.SendPropertyChanged("UserGroupGuid");
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
        [Column(Storage = "userAccount", Name = "UserAccount", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string UserAccount
        {
            get
            {
                return this.userAccount;
            }
            set
            {
                if (this.userAccount != value || value == null)
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
        [Column(Storage = "userPassword", Name = "UserPassword", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string UserPassword
        {
            get
            {
                return this.userPassword;
            }
            set
            {
                if (this.userPassword != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.userPassword = value;
                    this.SendPropertyChanged("UserPassword");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "name", Name = "Name", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.name = value;
                    this.SendPropertyChanged("Name");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "mobile", Name = "Mobile", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string Mobile
        {
            get
            {
                return this.mobile;
            }
            set
            {
                if (this.mobile != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.mobile = value;
                    this.SendPropertyChanged("Mobile");
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
        [Column(Storage = "createTime", Name = "CreateTime", DbType = "datetime", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
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
        [Association(Storage = "userGroup", Name = "UserGroup_User", ThisKey = "UserGroupGuid", OtherKey = "Guid", IsForeignKey = true)]
        public UserGroup UserGroup
        {
            get
            {
                return this.userGroup.Entity;
            }
            set
            {
                UserGroup previousValue = this.userGroup.Entity;
                if (((previousValue != value)
                            || (this.userGroup.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this.userGroup.Entity = null;
                        previousValue.Users.Remove(this);
                    }
                    this.userGroup.Entity = value;
                    if ((value != null))
                    {
                        value.Users.Add(this);
                        this.userGroupGuid = value.Guid;
                    }
                    else
                    {
                        this.userGroupGuid = Guid.Empty;
                    }
                    this.SendPropertyChanged("UserGroup");
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
