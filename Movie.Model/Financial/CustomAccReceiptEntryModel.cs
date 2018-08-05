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
            TableName = "Custom_Acc_ReceiptEntry";
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
