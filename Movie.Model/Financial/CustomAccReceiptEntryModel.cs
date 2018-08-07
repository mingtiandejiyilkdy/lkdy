using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity;

namespace Movie.Model.Financial
{
    public class CustomAccReceiptEntryModel : EntityBase
    {
        public CustomAccReceiptEntryModel()
        {
            TableName = "P_Custom_Acc_ReceiptEntry";
            IdentityName = "CustomAccReceiptEntryId";
            PrimaryKeys.Add("CustomAccReceiptEntryId");//主键
        }
        
        public long ID
        {
            get { return getProperty<long>("CustomAccReceiptEntryId"); }
            set { setProperty("CustomAccReceiptEntryId", value); }
        }

        public long CustomAccReceiptId
        {
            get { return getProperty<long>("CustomAccReceiptId"); }
            set { setProperty("CustomAccReceiptId", value); }
        }    

        /// <summary>
        ///收款账号
        /// </summary>
        public long BankAccountId
        {
            get { return getProperty<long>("BankAccountId"); }
            set { setProperty("BankAccountId", value); }
        } 

        /// <summary>
        /// 本次收款
        /// </summary>
        public decimal CurrentAmount
        {
            get { return getProperty<decimal>("CurrentAmount"); }
            set { setProperty("CurrentAmount", value); }
        }

        /// <summary>
        /// 银行流水号
        /// </summary>
        public string BankSerialNumber
        {
            get { return getProperty<string>("BankSerialNumber"); }
            set { setProperty("BankSerialNumber", value); }
        } 

        public DateTime DateOfEntry
        {
            get { return getProperty<DateTime>("DateOfEntry"); }
            set { setProperty("DateOfEntry", value); }
        }

        public string Remark
        {
            get { return getProperty<string>("Remark"); }
            set { setProperty("Remark", value); }
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
