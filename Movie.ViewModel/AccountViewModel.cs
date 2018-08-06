using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie.ViewModel
{
    public class AccountViewModel
    { 
        public long ID { get; set; }
        public long TenantId { get; set; }
        public string AccountName { get; set; }
        public string TrueName { get; set; }
        public int AccountStatus { get; set; }
        public string LoginTime { get; set; }
        public string LastLoginTime { get; set; }
        public int LoginCount { get; set; }
        public string CreateTIme { get; set; }
    }
}
