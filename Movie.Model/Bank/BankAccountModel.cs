using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity;

namespace Movie.Model.Bank  
{
    public class BankAccountModel : EntityBase
    {
        public BankAccountModel()
        {
            TableName = "BankAccount";
            IdentityName = "BankAccountId";
            PrimaryKeys.Add("BankAccountId");//主键
        }

        public long ID
        {
            get { return getProperty<long>("BankAccountId"); }
            set { setProperty("BankAccountId", value); }
        }

        public string BankAccountName
        {
            get { return getProperty<string>("BankAccountName"); }
            set { setProperty("BankAccountName", value, 50); }
        }

        public long BankId
        {
            get { return getProperty<long>("BankId"); }
            set { setProperty("BankId", value); }
        }

        public string BankAccountCode
        {
            get { return getProperty<string>("BankAccountCode"); }
            set { setProperty("BankAccountCode", value,50); }
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

        public string UpdateBy
        {
            get { return getProperty<string>("UpdateBy"); }
            set { setProperty("UpdateBy", value); }
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
    }
}

