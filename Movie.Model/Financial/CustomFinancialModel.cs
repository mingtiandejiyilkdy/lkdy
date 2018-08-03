using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity;
using Movie.Enum;

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
            get { return getProperty<long>("CustomFinancialId"); }
            set { setProperty("CustomFinancialId", value); }
        }

        public long CustomId
        {
            get { return getProperty<long>("CustomId"); }
            set { setProperty("CustomId", value); }
        } 

        /// <summary>
        /// 应收累计
        /// </summary>
        public decimal  ARAmount
        {
            get { return getProperty<decimal>("ARAmount"); }
            set { setProperty("ARAmount", value); }
        }

        public decimal ARBalance
        {
            get { return getProperty<decimal>("ARBalance"); }
            set { setProperty("ARBalance", value); }
        }
        /// <summary>
        /// 赠送累计
        /// </summary>
        public decimal LargessAmount
        {
            get { return getProperty<decimal>("LargessAmount"); }
            set { setProperty("LargessAmount", value); }
        }

        public decimal LargessBalance
        {
            get { return getProperty<decimal>("LargessBalance"); }
            set { setProperty("LargessBalance", value); }
        }
        /// <summary>
        /// 置换累计
        /// </summary>
        public decimal ExChangeAmount
        {
            get { return getProperty<decimal>("ExChangeAmount"); }
            set { setProperty("ExChangeAmount", value); }
        }

        public decimal ExChangeBalance
        {
            get { return getProperty<decimal>("ExChangeBalance"); }
            set { setProperty("ExChangeBalance", value); }
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
