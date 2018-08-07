using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity;

namespace Movie.Model.Ticket
{
    public class TicketBatchModel : EntityBase
    {
        public TicketBatchModel()
        {
            TableName = "P_TicketBatch";
            IdentityName = "TicketBatchId";
            PrimaryKeys.Add("TicketBatchId");//主键
        }

        public long ID
        {
            get { return getProperty<long>("TicketBatchId"); }
            set { setProperty("TicketBatchId", value); }
        }

        public long TicketTypeId
        {
            get { return getProperty<long>("TicketTypeId"); }
            set { setProperty("TicketTypeId", value); }
        }
        public string TicketBatchName
        {
            get { return getProperty<string>("TicketBatchName"); }
            set { setProperty("TicketBatchName", value, 50); }
        }
        public string TicketBatchNo
        {
            get { return getProperty<string>("TicketBatchNo"); }
            set { setProperty("TicketBatchNo", value, 50); }
        }

        public string TicketPrefix
        {
            get { return getProperty<string>("TicketPrefix"); }
            set { setProperty("TicketPrefix", value, 50); }
        }
        public long Amount
        {
            get { return getProperty<long>("Amount"); }
            set { setProperty("Amount", value); }
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

