using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie.ViewModel.Cinema
{
    public class CustomTypeViewModel
    {
        public long ID { get; set; } 
        public string CustomTypeName { get; set; }
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
