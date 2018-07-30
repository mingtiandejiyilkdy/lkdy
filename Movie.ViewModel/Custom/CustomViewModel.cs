using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie.ViewModel.Custom
{
    public class CustomViewModel
    {
        public long ID { get; set; }
        public long CustomTypeId { get; set; }
        public string CustomName { get; set; }
        public string LinkName { get; set; }
        public string LinkPhone { get; set; }
        public string LinkMobile { get; set; }
        public string CustomArea { get; set; }
        public string CustomAddress { get; set; }
        public int Sort { get; set; }
        public int Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateIP { get; set; }
        public string CreateTime { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateIP { get; set; }
        public string UpdateTime { get; set; }
    }
}
