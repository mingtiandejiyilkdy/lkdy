using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movie.Common.Utils;
using Movie.Enum;

namespace Movie.ViewModel.Ticket
{
    public class CustomChargeCardViewModel
    {
        public long ID { get; set; }
        public long CustomId { get; set; }
        public string CustomName { get; set; }
        public long TicketTypeID { get; set; }
        public string TicketTypeName { get; set; }
        public int MoneyType { get; set; }
        public decimal CurrentCount { get; set; }
        public decimal FaceAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime ExpireDate { get; set; }
        public long TicketBatchId { get; set; }
        public long TicketStart { get; set; }
        public long TicketEnd { get; set; }
        public int Consumptionlevel { get; set; }
        public int IsCommonCard { get; set; }         
        public int Sort { get; set; } 
        public string CreateBy { get; set; }
        public string CreateIP { get; set; }
        public DateTime CreateTime { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateIP { get; set; }
        public DateTime? UpdateTime { get; set; }
        
        public string ExpireDateStr { 
            get { return ExpireDate.ToString(""); } 
        } 

        public string MoneyTypeypeStr
        {
            get { return Util.getStatus(IsCommonCard, typeof(BaseEnum.MoneyTypeEnum)); }
        }

        public string IsCommonCardStr
        {
            get { return Util.getStatus(IsCommonCard, typeof(BaseEnum.WhetherEnum)); }
        }

        public string CreateTimeStr
        {
            get { return CreateTime.ToString("yyyy-MM-dd HH:mm:ss"); }
        }
    }
}
