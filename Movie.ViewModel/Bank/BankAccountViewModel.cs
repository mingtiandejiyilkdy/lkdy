﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movie.Common.Utils;
using Movie.Enum;

namespace Movie.ViewModel.Bank
{
    public class BankAccountViewModel
    {
        public long ID { get; set; }
        public string BankAccountName { get; set; }
        public long BankId { get; set; }
        public string BankName { get; set; }
        public string BankAccountCode { get; set; } 
        public int Sort { get; set; }
        public int Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateIP { get; set; }
        public string CreateTime { get; set; }
         
        public string StatusStr
        {
            get { return Util.getStatus(Status, typeof(BaseEnum.CredentialTypeEnum)); }
        }
    }
}
