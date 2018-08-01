using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity;

namespace Movie.Model.Financial
{
    public class CustomFinancialModel : EntityBase
    {
        public CustomFinancialModel()
        {
            TableName = "CustomFinancial";
            IdentityName = "CustomFinancialId";
            PrimaryKeys.Add("CustomFinancialId");//主键
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

        public decimal AccumulativeAmount
        {
            get { return getProperty<decimal>("AccumulativeAmount"); }
            set { setProperty("AccumulativeAmount", value); }
        }

        public decimal Deductions
        {
            get { return getProperty<decimal>("Deductions"); }
            set { setProperty("Deductions", value); }
        }

        public decimal Balance
        {
            get { return getProperty<decimal>("Balance"); }
            set { setProperty("Balance", value); }
        }

        public string CheckSign
        {
            get { return getProperty<string>("CheckSign"); }
            set { setProperty("CheckSign", value, 50); }
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
