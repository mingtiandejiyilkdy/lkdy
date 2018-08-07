using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity;
using Movie.Enum;

namespace Movie.Model.ChargeCard
{
    public class CustomChargeCardsModel : EntityBase
    {
        public CustomChargeCardsModel()
        {
            TableName = "P_Custom_ChargeCards";
            IdentityName = "ChargeCardId";
            PrimaryKeys.Add("ChargeCardId");//主键
        }

        public long ID
        {
            get { return getProperty<long>("ChargeCardId"); }
            set { setProperty("ChargeCardId", value); }
        }

        public string ChargeCardNo
        {
            get { return getProperty<string>("ChargeCardNo"); }
            set { setProperty("ChargeCardNo", value,50); }
        }

        public long CustomId
        {
            get { return getProperty<long>("CustomId"); }
            set { setProperty("CustomId", value); }
        }

        public long TicketTypeID
        {
            get { return getProperty<long>("TicketTypeID"); }
            set { setProperty("TicketTypeID", value); }
        }

        public long MoneyType
        {
            get { return getProperty<long>("MoneyType"); }
            set { setProperty("MoneyType", value); }
        }
        public decimal CurrentCount
        {
            get { return getProperty<decimal>("CurrentCount"); }
            set { setProperty("CurrentCount", value); }
        }

        public decimal FaceAmount
        {
            get { return getProperty<decimal>("FaceAmount"); }
            set { setProperty("FaceAmount", value); }
        }

        public decimal CurrentAmount
        {
            get { return getProperty<decimal>("CurrentAmount"); }
            set { setProperty("CurrentAmount", value); }
        }

        public DateTime ExpireDate
        {
            get { return getProperty<DateTime>("ExpireDate"); }
            set { setProperty("ExpireDate", value); }
        }

        public long TicketBatchId
        {
            get { return getProperty<long>("TicketBatchId"); }
            set { setProperty("TicketBatchId", value); }
        }

        public long TicketStart
        {
            get { return getProperty<long>("TicketStart"); }
            set { setProperty("TicketStart", value); }
        }

        public long TicketEnd
        {
            get { return getProperty<long>("TicketEnd"); }
            set { setProperty("TicketEnd", value); }
        }

        public int Consumptionlevel
        {
            get { return getProperty<int>("Consumptionlevel"); }
            set { setProperty("Consumptionlevel", value); }
        }

        public int IsCommonCard
        {
            get { return getProperty<int>("IsCommonCard"); }
            set { setProperty("IsCommonCard", value); }
        }


        public int Sort
        {
            get { return getProperty<int>("Sort"); }
            set { setProperty("Sort", value); }
        }
        public int Status
        {
            get { return getProperty<int>("Status"); }
            set { setProperty("Status", value); }
        }
        public long CreateId
        {
            get { return getProperty<long>("CreateId"); }
            set { setProperty("CreateId", value); }
        }
        public string CreateUser
        {
            get { return getProperty<string>("CreateUser"); }
            set { setProperty("CreateUser", value); }
        }
        public string CreateIP
        {
            get { return getProperty<string>("CreateIP"); }
            set { setProperty("CreateIP", value, 20); }
        }
        public DateTime CreateTime
        {
            get { return getProperty<DateTime>("CreateTime"); }
            set { setProperty("CreateTime", value); }
        }

        public long UpdateId
        {
            get { return getProperty<long>("UpdateId"); }
            set { setProperty("UpdateId", value); }
        }
        public string UpdateUser
        {
            get { return getProperty<string>("UpdateUser"); }
            set { setProperty("UpdateUser", value); }
        }
        public string UpdateIP
        {
            get { return getProperty<string>("UpdateIP"); }
            set { setProperty("UpdateIP", value, 20); }
        }
        public DateTime? UpdateTime
        {
            get { return getProperty<DateTime>("UpdateTime"); }
            set { setProperty("UpdateTime", value); }
        }

        /// <summary>
        /// 商家Id
        /// </summary>
        public long TenantId
        {
            get { return getProperty<long>("TenantId"); }
            set { setProperty("TenantId", value); }
        }    
    }
}
