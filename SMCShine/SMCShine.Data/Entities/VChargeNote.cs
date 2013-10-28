///<summary>
///Copyright (C) 奥凯软件
///创建标识： 2013-08-11 Created by xxc
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
    [Table(Name = "dbo.V_ChargeNoteInfo")]
    public class VChargeNote : INotifyPropertyChanging, INotifyPropertyChanged
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

        private Guid chargeNoteItemGuid = Guid.Empty;
        private Guid? campusGuid = Guid.Empty;
        private Guid chargeNoteGuid = Guid.Empty;
        private Guid goodsItemGuid = Guid.Empty;
        private decimal number = 0;
        private decimal totalMoney = 0;
        private decimal paidMoney = 0;
        private decimal reducedMoney = 0;
        private decimal owedMoney = 0;
        private bool isUndo = false;
        private string chargeNoteItemMemo = string.Empty;
        private int state = 0;
        private DateTime createTime;
        private string billNumber = string.Empty;
        private int chargeWay = 0;
        private string posNumber = string.Empty;
        private DateTime operateTime;
        private string chargeNoteMemo = string.Empty;
        private string userName = string.Empty;
        private string userAccount = string.Empty;
        private string goodsTypeName = string.Empty;
        private string goodsItemName = string.Empty;
        private decimal price = 0;
        private string className = string.Empty;
        private string gradeName = string.Empty;
        private string schoolName = string.Empty;
        private string campusName = string.Empty;
        private string studentName = string.Empty;
        private string studentID = string.Empty;
        private string iD = string.Empty;
        private Guid? studentGuid = Guid.Empty;
        private string memo = string.Empty;
        

        public VChargeNote()
        {
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "chargeNoteItemGuid", Name = "ChargeNoteItemGuid", DbType = "uniqueidentifier", IsVersion = false, IsPrimaryKey = false, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public Guid ChargeNoteItemGuid
        {
            get
            {
                return this.chargeNoteItemGuid;
            }
            set
            {
                if (this.campusGuid != value || value == Guid.Empty)
                {
                    this.SendPropertyChanging();
                    this.campusGuid = value;
                    this.SendPropertyChanged("ChargeNoteItemGuid");
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
        [Column(Storage = "chargeNoteGuid", Name = "ChargeNoteGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
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
        [Column(Storage = "goodsItemGuid", Name = "GoodsItemGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public Guid CampusMemo
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

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "number", Name = "Number", DbType = "decimal", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public decimal Number
        {
            get
            {
                return this.number;
            }
            set
            {
                if (this.number != value || value == 0)
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
        [Column(Storage = "totalMoney", Name = "TotalMoney", DbType = "decimal", IsVersion = false, IsPrimaryKey = false, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
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
        [Column(Storage = "paidMoney", Name = "PaidMoney", DbType = "decimal", IsVersion = false, UpdateCheck = UpdateCheck.Never)]
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
        [Column(Storage = "reducedMoney", Name = "ReducedMoney", DbType = "decimal", IsVersion = false, UpdateCheck = UpdateCheck.Never)]
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
        [Column(Storage = "owedMoney", Name = "OwedMoney", DbType = "decimal", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public decimal OwedMoney
        {
            get
            {
                return this.owedMoney;
            }
            set
            {
                if (this.owedMoney != value || value == null)
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
        [Column(Storage = "isUndo", Name = "IsUndo", DbType = "bit", IsVersion = false, IsPrimaryKey = false, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
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
        [Column(Storage = "chargeNoteItemMemo", Name = "ChargeNoteItemMemo", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string ChargeNoteItemMemo
        {
            get
            {
                return this.chargeNoteItemMemo;
            }
            set
            {
                if (this.chargeNoteItemMemo != value || value == string.Empty)
                {
                    this.SendPropertyChanging();
                    this.chargeNoteItemMemo = value;
                    this.SendPropertyChanged("ChargeNoteItemMemo");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "state", Name = "State", DbType = "int", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public int GradeMemo
        {
            get
            {
                return this.state;
            }
            set
            {
                if (this.state != value || value == null)
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
        [Column(Storage = "createTime", Name = "CreateTime", DbType = "datetime", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime CreateTime
        {
            get
            {
                return this.createTime;
            }
            set
            {
                if (this.createTime != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.createTime = value;
                    this.SendPropertyChanged("CreateTime");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "billNumber", Name = "BillNumber", DbType = "nvarchar", IsVersion = false, IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
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
        [Column(Storage = "chargeWay", Name = "ChargeWay", DbType = "int", IsVersion = false, UpdateCheck = UpdateCheck.Never)]
        public int ChargeWay
        {
            get
            {
                return this.chargeWay;
            }
            set
            {
                if (this.chargeWay != value || value == null)
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
        [Column(Storage = "operateTime", Name = "OperateTime", DbType = "datetime", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime OperateTime
        {
            get
            {
                return this.operateTime;
            }
            set
            {
                if (this.operateTime != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.operateTime = value;
                    this.SendPropertyChanged("OperateTime");
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "chargeNoteMemo", Name = "ChargeNoteMemo", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string ChargeNoteMemo
        {
            get
            {
                return this.chargeNoteMemo;
            }
            set
            {
                if (this.chargeNoteMemo != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.chargeNoteMemo = value;
                    this.SendPropertyChanged("ChargeNoteMemo");
                }
            }
        }
        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "userName", Name = "UserName", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                if (this.userName != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.userName = value;
                    this.SendPropertyChanged("UserName");
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
        [Column(Storage = "goodsTypeName", Name = "GoodsTypeName", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string GoodsTypeName
        {
            get
            {
                return this.goodsTypeName;
            }
            set
            {
                if (this.goodsTypeName != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.goodsTypeName = value;
                    this.SendPropertyChanged("GoodsTypeName");
                }
            }
        }
        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "goodsItemName", Name = "GoodsItemName", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string GoodsItemName
        {
            get
            {
                return this.goodsItemName;
            }
            set
            {
                if (this.goodsItemName != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.goodsItemName = value;
                    this.SendPropertyChanged("GoodsItemName");
                }
            }
        }
        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "price", Name = "Price", DbType = "decimal", IsVersion = false, UpdateCheck = UpdateCheck.Never)]
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
        [Column(Storage = "studentName", Name = "StudentName", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string StudentName
        {
            get
            {
                return this.studentName;
            }
            set
            {
                if (this.studentName != value || value == null)
                {
                    this.SendPropertyChanging();
                    this.studentName = value;
                    this.SendPropertyChanged("StudentName");
                }
            }
        }
        ///<summary>
        ///
        ///</summary>
        [DataMember]
        [Column(Storage = "studentID", Name = "StudentID", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string StudentID
        {
            get
            {
                return this.studentID;
            }
            set
            {
                if (this.studentID != value || value == null)
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
        [Column(Storage = "iD", Name = "ID", DbType = "nvarchar", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string ID
        {
            get
            {
                return this.iD;
            }
            set
            {
                if (this.iD != value || value == null)
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
        [Column(Storage = "studentGuid", Name = "StudentGuid", DbType = "uniqueidentifier", IsVersion = false, CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public Guid? StudentGuid
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
    }
}
