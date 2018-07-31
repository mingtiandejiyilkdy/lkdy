using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using Movie.Enum;
using Movie.Common.Utils;

namespace Movie.Model.Ticket
{
    public class TicketViewModel
    {
        public long ID { get; set; }

        public long TicketTypeId { get; set; }

        public string TicketCode { get; set; }

        public BaseEnum.ConsumptionlevelEnum Consumptionlevel { get; set; }

        public BaseEnum.MoneyTypeEnum MoneyTyp { get; set; }

        public long CustomID { get; set; }

        public decimal InitialAmount { get; set; }

        public decimal CostAmount { get; set; }

        public decimal Balance { get; set; }

        public BaseEnum.CredentialEnum Status { get; set; }

        public bool IsExpire { get; set; }

        public bool IsActivated { get; set; }

        public string MakeTime { get; set; }

        public string ExpireDate { get; set; }

        public string TicketBatchNo { get; set; }

        public long GrantBy { get; set; }

        public string GrantTime { get; set; }

        public int Sort { get; set; }

        public string CreateBy { get; set; }
        public string CreateIP { get; set; }
        public string CreateTime { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateIP { get; set; }
        public string UpdateTime { get; set; }

        public string StatusStr
        {
            get
            {
                return Util.getStatus((int)Status, typeof(BaseEnum.CredentialTypeEnum));
            }
        } 
    }
}
