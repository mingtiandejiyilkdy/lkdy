using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movie.Common.Utils;
using Movie.Enum;

namespace Movie.ViewModel
{
    public class BaseViewModel
    {
        public int Sort { get; set; }
        public string CreateBy { get; set; }
        public string CreateIP { get; set; }
        public DateTime CreateTime { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateIP { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string CreateTimeStr
        {
            get { return CreateTime.ToString("yyyy-MM-dd HH:mm:ss"); }
        }
        public string UpdateTimeStr
        {
            get { return UpdateTime == null ? "" : Convert.ToDateTime(UpdateTime).ToString("yyyy-MM-dd HH:mm:ss"); }
        }
    }
}
