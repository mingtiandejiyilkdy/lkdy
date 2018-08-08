using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity;

namespace Movie.Model.Merchant
{
    public class MerchantTypeModel: EntityBase
    {
        public MerchantTypeModel()
        {
            TableName = "P_MerchantType";
            IdentityName = "MerchantTypeId";
            PrimaryKeys.Add("MerchantTypeId");//主键
        }

        public long ID
        {
            get { return getProperty<long>("MerchantTypeId"); }
            set { setProperty("MerchantTypeId", value); }
        }

        public string MerchantTypeName
        {
            get { return getProperty<string>("MerchantTypeName"); }
            set { setProperty("MerchantTypeName", value,50); }
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
        public long CreateId
        {
            get { return getProperty<long>("CreateId"); }
            set { setProperty("CreateId", value); }
        }
        public string CreateUser
        {
            get { return getProperty<string>("CreateUser"); }
            set { setProperty("CreateUser", value); }
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

        public long UpdateId
        {
            get { return getProperty<long>("UpdateId"); }
            set { setProperty("UpdateId", value); }
        }
        public string UpdateUser
        {
            get { return getProperty<string>("UpdateUser"); }
            set { setProperty("UpdateUser", value); }
        }
        public string UpdateIP
        {
            get { return getProperty<string>("UpdateIP"); }
            set { setProperty("UpdateIP", value, 20); }
        }
        public DateTime? UpdateTime
        {
            get { return getProperty<DateTime>("UpdateTime"); }
            set { setProperty("UpdateTime", value); }
        }

        /// <summary>
        /// 商家Id
        /// </summary>
        public long TenantId
        {
            get { return getProperty<long>("TenantId"); }
            set { setProperty("TenantId", value); }
        }    
    }
}

