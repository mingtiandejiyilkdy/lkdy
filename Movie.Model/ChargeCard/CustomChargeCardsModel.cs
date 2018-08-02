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
            TableName = "Custom_ChargeCards";
            IdentityName = "ChargeCardId";
            PrimaryKeys.Add("ChargeCardId");//主键
        }

        public long ID
        {
            get { return getProperty<long>("ChargeCardId"); }
            set { setProperty("ChargeCardId", value); }
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

        public string CreateBy
        {
            get { return getProperty<string>("CreateBy"); }
            set { setProperty("CreateBy", value); }
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
        public string UpdateBy
        {
            get { return getProperty<string>("UpdateBy"); }
            set { setProperty("UpdateBy", value); }
        }
        public string UpdateIP
        {
            get { return getProperty<string>("UpdateIP"); }
            set { setProperty("UpdateIP", value, 20); }
        }
        public DateTime UpdateTime
        {
            get { return getProperty<DateTime>("UpdateTime"); }
            set { setProperty("UpdateTime", value); }
        } 
    }
}
