using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movie.Common.Utils;
using Movie.Enum;

namespace Movie.ViewModel.Bank
{
    public class BankViewModel
    {
        public long ID { get; set; }
        public string BankName { get; set; }
        public int BankType { get; set; } 
        public int Sort { get; set; }
        public int Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateIP { get; set; }
        public string CreateTime { get; set; }

        public string BankTypeStr
        {
            get { return Util.getStatus(BankType, typeof(BankTypeEnum)); }
        }
        public string StatusStr
        {
            get { return Util.getStatus(Status, typeof(BaseEnum.CredentialTypeEnum)); }
        }
    }
}
