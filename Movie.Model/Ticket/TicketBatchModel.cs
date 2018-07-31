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
            TableName = "TicketBatch";
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
    }
}

