using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity;

namespace Movie.Model.Financial
{
    public class CustomAccReceiptModel : EntityBase
    {
        public CustomAccReceiptModel()
        {
            TableName = "P_Custom_Acc_Receipt";
            IdentityName = "CustomAccReceiptId";
            PrimaryKeys.Add("CustomAccReceiptId");//主键
        }

        public long ID
        {
            get { return getProperty<long>("CustomAccReceiptId"); }
            set { setProperty("CustomAccReceiptId", value); }
        }


        public string ChargeCardNo
        {
            get { return getProperty<string>("ChargeCardNo"); }
            set { setProperty("ChargeCardNo", value, 50); }
        }

        public long CustomId
        {
            get { return getProperty<long>("CustomId"); }
            set { setProperty("CustomId", value); }
        }

        /// <summary>
        /// 应收
        /// </summary>
        public decimal ARAmount
        {
            get { return getProperty<decimal>("ARAmount"); }
            set { setProperty("ARAmount", value); }
        } 

        public string Remark
        {
            get { return getProperty<string>("Remark"); }
            set { setProperty("Remark", value); }
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
