using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity;

namespace Movie.Model.Financial
{
    public class CustomFinancialDetailsModel : EntityBase
    {
        public CustomFinancialDetailsModel()
        {
            TableName = "CustomFinancialDetails";
            IdentityName = "DetailId";
            PrimaryKeys.Add("DetailId");//主键
        }

        public long ID
        {
            get { return getProperty<long>("DetailId"); }
            set { setProperty("DetailId", value); }
        }

        public long CustomId
        {
            get { return getProperty<long>("CustomId"); }
            set { setProperty("CustomId", value); }
        }

        public long ContractId
        {
            get { return getProperty<long>("ContractId"); }
            set { setProperty("ContractId", value); }
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
