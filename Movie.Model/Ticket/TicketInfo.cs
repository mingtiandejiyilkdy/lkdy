using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity;
using Movie.Enum;

namespace Movie.Model.Ticket
{
    public class TicketInfo: EntityBase
    {
        public TicketInfo()
        {
            TableName = "Ticket_Info";
            IdentityName = "TicketId";
            PrimaryKeys.Add("TicketId");//主键
        }

        public long ID
        {
            get { return getProperty<long>("TicketId"); }
            set { setProperty("TicketId", value); }
        }

        public long TicketTypeId
        {
            get { return getProperty<long>("TicketTypeId"); }
            set { setProperty("TicketTypeId", value); }
        }

        public string TicketCode
        {
            get { return getProperty<string>("TicketCode"); }
            set { setProperty("TicketCode", value, 50); }
        }

        public string TicketPwd
        {
            get { return getProperty<string>("TicketPwd"); }
            set { setProperty("TicketPwd", value, 50); }
        }

        public string TicketMD5Pwd
        {
            get { return getProperty<string>("TicketMD5Pwd"); }
            set { setProperty("TicketMD5Pwd", value, 50); }
        }

        public string Salt
        {
            get { return getProperty<string>("Salt"); }
            set { setProperty("Salt", value, 50); }
        }

        public BaseEnum.ConsumptionlevelEnum Consumptionlevel
        {
            get { return getProperty<BaseEnum.ConsumptionlevelEnum>("Consumptionlevel"); }
            set { setProperty("Consumptionlevel", value); }
        }

        public BaseEnum.MoneyTypeEnum MoneyTyp {
            get { return getProperty<BaseEnum.MoneyTypeEnum>("MoneyTyp"); }
            set { setProperty("MoneyTyp", value); }
        }

        public long CustomID
        {
            get { return getProperty<long>("CustomID"); }
            set { setProperty("CustomID", value); }
        }

        public decimal InitialAmount
        {
            get { return getProperty<decimal>("InitialAmount"); }
            set { setProperty("InitialAmount", value); }
        }

        public decimal CostAmount
        {
            get { return getProperty<decimal>("CostAmount"); }
            set { setProperty("CostAmount", value); }
        }

        public decimal Balance
        {
            get { return getProperty<decimal>("Balance"); }
            set { setProperty("Balance", value); }
        }

        public int Status
        {
            get { return getProperty<int>("Status"); }
            set { setProperty("Status", value); }
        }

        public bool IsExpire
        {
            get { return getProperty<bool>("IsExpire"); }
            set { setProperty("IsExpire", value); }
        }

        public bool IsActivated
        {
            get { return getProperty<bool>("IsActivated"); }
            set { setProperty("IsActivated", value); }
        }

        public DateTime MakeTime
        {
            get { return getProperty<DateTime>("MakeTime"); }
            set { setProperty("MakeTime", value); }
        }

        public DateTime ExpireDate
        {
            get { return getProperty<DateTime>("ExpireDate"); }
            set { setProperty("ExpireDate", value); }
        }

        public string TicketBatchNo
        {
            get { return getProperty<string>("TicketBatchNo"); }
            set { setProperty("TicketBatchNo", value,50); }
        }

        public long GrantBy
        {
            get { return getProperty<long>("GrantBy"); }
            set { setProperty("GrantBy", value); }
        } 

        public DateTime GrantTime
        {
            get { return getProperty<DateTime>("GrantTime"); }
            set { setProperty("GrantTime", value); }
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
