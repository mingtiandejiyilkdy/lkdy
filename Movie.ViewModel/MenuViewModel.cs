using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie.ViewModel
{
    public class MenuViewModel
    {
        public long ID { get; set; }
        public long ParentID { get; set; }
        public string MenuKey { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public int MenuType { get; set; }
        public string IDPath { get; set; }
        public string Remark { get; set; }
        public int Sort { get; set; }
        public int Status { get; set; } 
        public string CreateTIme { get; set; }
    }

    
}
