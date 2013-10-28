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
    [Table(Name = "dbo.Student")]
    public class Student : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private Guid guid = Guid.Empty;
        private Guid? campusGuid = null;
        private Guid? schoolGuid = null;
        private Guid gradeGuid = Guid.Empty;
        private Guid classTypeGuid = Guid.Empty;
        private string name = null;
        private string studentID = string.Empty;
        private bool gender = false;
        private string iD = string.Empty;
        private string tel = null;
        private string mobile = null;
        private string email = null;
        private string address = null;
        private int state = 0;
        private DateTime createTime = DateTime.Now;

        public Student()
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
        [Column(Storage = "schoolGuid", Name = "SchoolGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public Guid? SchoolGuid
        {
            get
            {
                return this.schoolGuid;
            }
            set
            {
                if (this.schoolGuid != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.schoolGuid = value;
                    this.SendPropertyChanged("SchoolGuid");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "gradeGuid", Name = "GradeGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public Guid GradeGuid
        {
            get
            {
                return this.gradeGuid;
            }
            set
            {
                if (this.gradeGuid != value || value == Guid.Empty)
                {
                    this.SendPropertyChanging();
                    this.gradeGuid = value;
                    this.SendPropertyChanged("GradeGuid");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "classTypeGuid", Name = "ClassTypeGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public Guid ClassTypeGuid
        {
            get
            {
                return this.classTypeGuid;
            }
            set
            {
                if (this.classTypeGuid != value || value == Guid.Empty)
                {
                    this.SendPropertyChanging();
                    this.classTypeGuid = value;
                    this.SendPropertyChanged("ClassTypeGuid");
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
        [Column(Storage = "studentID", Name = "StudentID", DbType = "nvarchar", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public string StudentID
        {
            get
            {
                return this.studentID;
            }
            set
            {
                if (this.studentID != value || value == string.Empty)
                {
                    this.SendPropertyChanging();
                    this.studentID = value;
                    this.SendPropertyChanged("StudentID");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "gender", Name = "Gender", DbType = "bit", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public bool Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if (this.gender != value || value == false)
                {
                    this.SendPropertyChanging();
                    this.gender = value;
                    this.SendPropertyChanged("Gender");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "iD", Name = "ID", DbType = "nvarchar", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public string ID
        {
            get
            {
                return this.iD;
            }
            set
            {
                if (this.iD != value || value == string.Empty)
                {
                    this.SendPropertyChanging();
                    this.iD = value;
                    this.SendPropertyChanged("ID");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "tel", Name = "Tel", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string Tel
        {
            get
            {
                return this.tel;
            }
            set
            {
                if (this.tel != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.tel = value;
                    this.SendPropertyChanged("Tel");
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
        [Column(Storage = "email", Name = "Email", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (this.email != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.email = value;
                    this.SendPropertyChanged("Email");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "address", Name = "Address", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                if (this.address != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.address = value;
                    this.SendPropertyChanged("Address");
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
