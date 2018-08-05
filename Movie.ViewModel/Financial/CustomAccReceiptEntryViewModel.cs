using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movie.Common.Utils;
using Movie.Enum;

namespace Movie.ViewModel.Financial
{
    public class CustomAccReceiptEntryViewModel
    {
        public long ID { get; set; }

        public long CustomAccReceiptId { get; set; } 
        /// <summary>
        ///收款账号
        /// </summary>
        public long BankAccountId { get; set; }
        /// <summary>
        /// 本次收款
        /// </summary>
        public decimal CurrentAmount { get; set; }
        /// <summary>
        /// 银行流水号
        /// </summary>
        public string BankSerialNumber { get; set; } 
        public DateTime DateOfEntry { get; set; } 
        public int Sort { get; set; }
        public int Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateIP { get; set; }
        public DateTime CreateTime { get; set; }

        public string StatusStr
        {
            get { return Util.getStatus(Status, typeof(BaseEnum.ProtocolTypeEnum)); }
        }

        public string DateOfEntryStr
        {
            get
            {
                return DateOfEntry.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public string CreateTimeStr
        {
            get
            {
                return CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
        } 


    }
}
