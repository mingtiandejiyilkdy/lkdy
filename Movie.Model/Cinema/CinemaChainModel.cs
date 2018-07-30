using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity;

namespace Movie.Model.Cinema
{
    public class CinemaChainModel : EntityBase
    {
        public CinemaChainModel()
        {
            TableName = "Cinema_Chain";
            IdentityName = "CinemaChainId";
            PrimaryKeys.Add("CinemaChainId");//主键
        }

        public long ID
        {
            get { return getProperty<long>("CinemaChainId"); }
            set { setProperty("CinemaChainId", value); }
        }

        public string CinemaChainName
        {
            get { return getProperty<string>("CinemaChainName"); }
            set { setProperty("CinemaChainName", value,50); }
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

