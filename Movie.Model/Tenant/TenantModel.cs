using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity;

namespace Movie.Model.Tenant
{ 
    public class TenantModel : EntityBase
    {
        public TenantModel()
        {
            TableName = "Tenant";
            IdentityName = "TenantId";
            PrimaryKeys.Add("TenantId");//主键
        }

        public long ID
        {
            get { return getProperty<long>("TenantId"); }
            set { setProperty("TenantId", value); }
        }

        public string TenantName
        {
            get { return getProperty<string>("TenantName"); }
            set { setProperty("TenantName", value, 50); }
        }

        public string TenantDomain
        {
            get { return getProperty<string>("TenantDomain"); }
            set { setProperty("TenantDomain", value, 50); }
        }
        public int Sort
        {
            get { return getProperty<int>("Sort"); }
            set { setProperty("Sort", value); }
        }
        public int Status
        {
            get { return getProperty<int>("Status"); }
            set { setProperty("Status", value); }
        }
        public string CreateBy
        {
            get { return getProperty<string>("CreateBy"); }
            set { setProperty("CreateBy", value); }
        }
        public string CreateIP
        {
            get { return getProperty<string>("CreateIP"); }
            set { setProperty("CreateIP", value, 20); }
        }
        public DateTime CreateTime
        {
            get { return getProperty<DateTime>("CreateTime"); }
            set { setProperty("CreateTime", value); }
        } 
    }
}
