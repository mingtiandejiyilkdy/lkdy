﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movie.Common.Utils;
using Movie.Enum;

namespace Movie.ViewModel.Tenant
{
    public class TenantViewModel
    {
        public long ID { get; set; }
        public string TenantName { get; set; }
        public string TenantDomain { get; set; }
        public int Sort { get; set; }
        public int Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateIP { get; set; }
        public DateTime CreateTime { get; set; }

        public string StatusStr
        {
            get { return Util.getStatus(Status, typeof(BaseEnum.CredentialTypeEnum)); }
        }

        public string CreateTimeStr
        {
            get
            {
                { return CreateTime.ToString("yyyy-MM-dd HH:mm:ss"); }
            }
        }
    }
}
