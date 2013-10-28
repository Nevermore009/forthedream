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
    [Table(Name = "dbo.GoodsItem")]
    public class GoodsItem : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private Guid guid = Guid.Empty;
        private Guid? campusGuid = null;
        private Guid? schoolGuid = null;
        private Guid? gradeGuid = null;
        private Guid? classGuid = null;
        private Guid goodsTypeGuid = Guid.Empty;
        private string name = string.Empty;
        private decimal price = 0;
        private string memo = null;
        private int state = 0;
        private DateTime createTime = DateTime.Now;
        private EntityRef<GoodsType> goodsType;

        public GoodsItem()
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
        [Column(Storage = "gradeGuid", Name = "GradeGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public Guid? GradeGuid
        {
            get
            {
                return this.gradeGuid;
            }
            set
            {
                if (this.gradeGuid != value || value == null)
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
        [Column(Storage = "classGuid", Name = "ClassGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public Guid? ClassGuid
        {
            get
            {
                return this.classGuid;
            }
            set
            {
                if (this.classGuid != value || value == null)
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
        [Column(Storage = "goodsTypeGuid", Name = "GoodsTypeGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public Guid GoodsTypeGuid
        {
            get
            {
                return this.goodsTypeGuid;
            }
            set
            {
                if (this.goodsTypeGuid != value || value == Guid.Empty)
                {
                    this.SendPropertyChanging();
                    this.goodsTypeGuid = value;
                    this.SendPropertyChanged("GoodsTypeGuid");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "name", Name = "Name", DbType = "nvarchar", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value || value == string.Empty)
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
        [Column(Storage = "price", Name = "Price", DbType = "decimal", IsVersion = false, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (this.price != value || value == 0)
                {
                    this.SendPropertyChanging();
                    this.price = value;
                    this.SendPropertyChanged("Price");
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
        [Association(Storage = "goodsType", Name = "GoodsType_GoodsItem", ThisKey = "GoodsTypeGuid", OtherKey = "Guid", IsForeignKey = true)]
        public GoodsType GoodsType
        {
            get
            {
                return this.goodsType.Entity;
            }
            set
            {
                GoodsType previousValue = this.goodsType.Entity;
                if (((previousValue != value)
                            || (this.goodsType.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this.goodsType.Entity = null;
                        previousValue.GoodsItems.Remove(this);
                    }
                    this.goodsType.Entity = value;
                    if ((value != null))
                    {
                        value.GoodsItems.Add(this);
                        this.goodsTypeGuid = value.Guid;
                    }
                    else
                    {
                        this.goodsTypeGuid = Guid.Empty;
                    }
                    this.SendPropertyChanged("GoodsType");
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
