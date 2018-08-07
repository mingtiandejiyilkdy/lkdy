using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity;

namespace Movie.Model.Contract
{
    public class ContractModel : EntityBase
    {
        public ContractModel()
        {
            TableName = "P_Contract";
            IdentityName = "ContractId";
            PrimaryKeys.Add("ContractId");//主键
        }

        public long ID
        {
            get { return getProperty<long>("ContractId"); }
            set { setProperty("ContractId", value); }
        }

        public long CustomId
        {
            get { return getProperty<long>("CustomId"); }
            set { setProperty("CustomId", value); }
        }

        public string ContractNo
        {
            get { return getProperty<string>("ContractNo"); }
            set { setProperty("ContractNo", value); }
        }
        public Decimal AccountReceivable
        {
            get { return getProperty<Decimal>("AccountReceivable"); }
            set { setProperty("AccountReceivable", value); }
        }
        public Decimal LargessAmount
        {
            get { return getProperty<Decimal>("LargessAmount"); }
            set { setProperty("LargessAmount", value); }
        }
        public Decimal ExChangeAmount
        {
            get { return getProperty<Decimal>("ExChangeAmount"); }
            set { setProperty("ExChangeAmount", value); }
        }
        /// <summary>
        /// 合同金额
        /// </summary>
        public Decimal ContractAmount
        {
            get { return getProperty<Decimal>("ContractAmount"); }
            set { setProperty("ContractAmount", value); }
        }
        /// <summary>
        /// 已使用金额
        /// </summary>
        public decimal Deductions
        {
            get { return getProperty<decimal>("Deductions"); }
            set { setProperty("Deductions", value); }
        }

        /// <summary>
        /// 可用余额
        /// </summary>
        public decimal Balance
        {
            get { return getProperty<decimal>("Balance"); }
            set { setProperty("Balance", value); }
        }

        public string BalanceKey
        {
            get { return getProperty<string>("BalanceKey"); }
            set { setProperty("BalanceKey", value, 200); }
        }

        public string Attachment
        {
            get { return getProperty<string>("Attachment"); }
            set { setProperty("Attachment", value, 200); }
        }

        public DateTime Deadline
        {
            get { return getProperty<DateTime>("Deadline"); }
            set { setProperty("Deadline", value); }
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
