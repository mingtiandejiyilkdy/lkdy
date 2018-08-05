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
            TableName = "Custom_Acc_Receipt";
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
