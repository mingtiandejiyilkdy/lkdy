using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movie.Common.Utils;
using Movie.Enum;

namespace Movie.ViewModel.Merchant
{
    public class MerchantViewModel:BaseViewModel
    {
        public long ID { get; set; }
        public long MerchantTypeId { get; set; }
        public string MerchantTypeName { get; set; }
        public string MerchantName { get; set; }
        public string LinkName { get; set; }
        public string LinkPhone { get; set; }
        public string LinkMobile { get; set; }
        public string MerchantArea { get; set; }
        public string MerchantAddress { get; set; }
        public int Status { get; set; }
        public string StatusStr
        {
            get { return Util.getStatus(Status, typeof(MerchantStatusEnum)); }
        }

    }
}
