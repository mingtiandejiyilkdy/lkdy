using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie.ViewModel
{
    public class RoleViewModel
    {
        public long ID { get; set; }
        public string RoleName { get; set; }
        public int Status { get; set; } 
        public string CreateTIme { get; set; }
    }
}
