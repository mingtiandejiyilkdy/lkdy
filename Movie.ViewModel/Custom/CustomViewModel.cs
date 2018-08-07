using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movie.Common.Utils;
using Movie.Enum;

namespace Movie.ViewModel.Custom
{
    public class CustomViewModel:BaseViewModel
    {
        public long ID { get; set; }
        public long CustomTypeId { get; set; }
        public string CustomTypeName { get; set; }
        public string CustomName { get; set; }
        public string LinkName { get; set; }
        public string LinkPhone { get; set; }
        public string LinkMobile { get; set; }
        public string CustomArea { get; set; }
        public string CustomAddress { get; set; }
        public int Status { get; set; }
        public string StatusStr
        {
            get { return Util.getStatus(Status, typeof(CustomStatusEnum)); }
        }

    }
}
