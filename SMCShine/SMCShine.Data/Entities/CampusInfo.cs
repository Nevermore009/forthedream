///<summary>
///Copyright (C) 奥凯软件
///创建标识： 2013-07-15 Created by xxc
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
    [Table(Name = "dbo.V_CampusInfo")]
    public class CampusInfo : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
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

        private Guid campusGuid = Guid.Empty;
        private string campusName = null;
        private string campusCode = null;
        private string campusMemo = null;
        private DateTime? campusCreateTime;
        private Guid? schoolGuid = Guid.Empty;
        private string schoolName = null;
        private string schoolMemo = null;
        private DateTime? schoolCreateTime;
        private Guid? gradeGuid = Guid.Empty;
        private string gradeName = null;
        private string gradeMemo = null;
        private DateTime? gradeCreateTime;
        private Guid? classGuid = Guid.Empty;
        private string classID = null;
        private string className = null;
        private string classMemo = null;
        private DateTime? classCreateTime;

        public CampusInfo()
        {
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "campusGuid", Name = "CampusGuid", DbType = "uniqueidentifier", IsVersion = false, IsPrimaryKey = false, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public Guid CampusGuid
        {
            get
            {
                return this.campusGuid;
            }
            set
            {
                if (this.campusGuid != value || value == Guid.Empty)
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
        [Column(Storage = "campusCode", Name = "CampusCode", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string CampusCode
        {
            get
            {
                return this.campusCode;
            }
            set
            {
                if (this.campusCode != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.campusCode = value;
                    this.SendPropertyChanged("CampusCode");
                }
            }
        }


        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "campusName", Name = "CampusName", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string CampusName
        {
            get
            {
                return this.campusName;
            }
            set
            {
                if (this.campusName != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.campusName = value;
                    this.SendPropertyChanged("CampusName");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "campusMemo", Name = "CampusMemo", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string CampusMemo
        {
            get
            {
                return this.campusMemo;
            }
            set
            {
                if (this.campusMemo != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.campusMemo = value;
                    this.SendPropertyChanged("CampusMemo");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "campusCreateTime", Name = "CampusCreateTime", DbType = "datetime", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? CampusCreateTime
        {
            get
            {
                return this.campusCreateTime;
            }
            set
            {
                if (this.campusCreateTime != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.campusCreateTime = value;
                    this.SendPropertyChanged("CampusCreateTime");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "schoolGuid", Name = "SchoolGuid", DbType = "uniqueidentifier", IsVersion = false, IsPrimaryKey = false, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public Guid? SchoolGuid
        {
            get
            {
                return this.schoolGuid;
            }
            set
            {
                if (this.schoolGuid != value || value == Guid.Empty)
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
        [Column(Storage = "schoolName", Name = "SchoolName", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string SchoolName
        {
            get
            {
                return this.schoolName;
            }
            set
            {
                if (this.schoolName != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.schoolName = value;
                    this.SendPropertyChanged("SchoolName");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "schoolMemo", Name = "SchoolMemo", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string SchoolMemo
        {
            get
            {
                return this.schoolMemo;
            }
            set
            {
                if (this.schoolMemo != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.schoolMemo = value;
                    this.SendPropertyChanged("SchoolMemo");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "schoolCreateTime", Name = "SchoolCreateTime", DbType = "datetime", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? SchoolCreateTime
        {
            get
            {
                return this.schoolCreateTime;
            }
            set
            {
                if (this.schoolCreateTime != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.schoolCreateTime = value;
                    this.SendPropertyChanged("SchoolCreateTime");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "gradeGuid", Name = "GradeGuid", DbType = "uniqueidentifier", IsVersion = false, IsPrimaryKey = false, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public Guid? GradeGuid
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
        [Column(Storage = "gradeName", Name = "GradeName", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string GradeName
        {
            get
            {
                return this.gradeName;
            }
            set
            {
                if (this.gradeName != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.gradeName = value;
                    this.SendPropertyChanged("GradeName");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "gradeMemo", Name = "GradeMemo", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string GradeMemo
        {
            get
            {
                return this.gradeMemo;
            }
            set
            {
                if (this.gradeMemo != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.gradeMemo = value;
                    this.SendPropertyChanged("GradeMemo");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "gradeCreateTime", Name = "GradeCreateTime", DbType = "datetime", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? GradeCreateTime
        {
            get
            {
                return this.gradeCreateTime;
            }
            set
            {
                if (this.gradeCreateTime != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.gradeCreateTime = value;
                    this.SendPropertyChanged("GradeCreateTime");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "classGuid", Name = "ClassGuid", DbType = "uniqueidentifier", IsVersion = false, IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public Guid? ClassGuid
        {
            get
            {
                return this.classGuid;
            }
            set
            {
                if (this.classGuid != value || value == Guid.Empty)
                {
                    this.SendPropertyChanging();
                    this.classGuid = value;
                    this.SendPropertyChanged("ClassGuid");
                }
            }
        }

                ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "classID", Name = "ClassID", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string ClassID
        {
            get
            {
                return this.classID;
            }
            set
            {
                if (this.classID != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.classID = value;
                    this.SendPropertyChanged("ClassID");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "className", Name = "ClassName", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string ClassName
        {
            get
            {
                return this.className;
            }
            set
            {
                if (this.className != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.className = value;
                    this.SendPropertyChanged("ClassName");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "classMemo", Name = "ClassMemo", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string ClassMemo
        {
            get
            {
                return this.classMemo;
            }
            set
            {
                if (this.classMemo != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.classMemo = value;
                    this.SendPropertyChanged("ClassMemo");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "classCreateTime", Name = "ClassCreateTime", DbType = "datetime", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? ClassCreateTime
        {
            get
            {
                return this.classCreateTime;
            }
            set
            {
                if (this.classCreateTime != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.classCreateTime = value;
                    this.SendPropertyChanged("ClassCreateTime");
                }
            }
        }
    }
}
