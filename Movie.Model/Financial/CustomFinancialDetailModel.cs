using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity;
using Movie.Enum;

namespace Movie.Model.Financial
{
    public class CustomFinancialDetailModel : EntityBase
    {
        public CustomFinancialDetailModel()
        {
            TableName = "P_Custom_FinancialDetail";
            IdentityName = "FinancialDetailId";
            PrimaryKeys.Add("FinancialDetailId");//主键
        }

        public long ID
        {
            get { return getProperty<long>("FinancialDetailId"); }
            set { setProperty("FinancialDetailId", value); }
        }

        public long CustomFinancialId
        {
            get { return getProperty<long>("FinancialId"); }
            set { setProperty("FinancialId", value); }
        }

        /// <summary>
        /// 金额类型
        /// </summary>
        public int MoneyType
        {
            get { return getProperty<int>("MoneyType"); }
            set { setProperty("MoneyType", value); }
        }

        /// <summary>
        /// 财务操作类型
        /// </summary>
        public int FinanciaOpeType
        {
            get { return getProperty<int>("FinanciaOpeType"); }
            set { setProperty("FinanciaOpeType", value); }
        }

        /// <summary>
        /// 当前操作金额
        /// </summary>
        public decimal CurrentAmount
        {
            get { return getProperty<decimal>("Amount"); }
            set { setProperty("Amount", value); }
        }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal Balance
        {
            get { return getProperty<decimal>("Balance"); }
            set { setProperty("Balance", value); }
        }

        public string Remark
        {
            get { return getProperty<string>("Remark"); }
            set { setProperty("Remark", value); }
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
