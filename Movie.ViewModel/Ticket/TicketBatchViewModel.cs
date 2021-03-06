﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movie.Common.Utils;
using Movie.Enum;

namespace Movie.ViewModel.Ticket
{
    public class TicketBatchViewModel
    {
        public long ID { get; set; }
        public long TicketTypeId { get; set; }
        public string TicketTypeIdStr { get; set; }
        public string TicketBatchName { get; set; }
        public string TicketBatchNo { get; set; }
        public string TicketPrefix { get; set; }
        public long Amount { get; set; }
        public int Sort { get; set; }
        public int Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateIP { get; set; }
        public string CreateTime { get; set; }

        public string StatusStr
        {
            get
            {
                return Util.getStatus(Status, typeof(BaseEnum.CredentialTypeEnum));
            }
        } 
    }
}
