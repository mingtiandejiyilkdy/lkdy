using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movie.Common.Utils;
using Movie.Enum;

namespace Movie.ViewModel.Contract
{
    public class ContractViewModel
    {
        public long ID { get; set; }

        public long CustomId { get; set; }

        public string CustomName { get; set; }

        public string CustomTypeName { get; set; }
        
        public string ContractNo { get; set; }

        public string ContractAmount { get; set; }

        public string Deductions { get; set; }

        public string Balance { get; set; }

        public string Remark { get; set; }
         
        public int Sort { get; set; }
        public int Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateIP { get; set; }
        public string CreateTime { get; set; }

        public string StatusStr
        {
            get
            {
                return Util.getStatus(Status, typeof(BaseEnum.ProtocolTypeEnum));
            }
        } 
    }
}
