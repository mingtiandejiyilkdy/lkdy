using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity;

namespace Movie.Model.Cinema
{
    public class CinemaModel : EntityBase
    {
        public CinemaModel()
        {
            TableName = "Cinema";
            IdentityName = "CinemaId";
            PrimaryKeys.Add("CinemaId");//主键
        }

        public long ID
        {
            get { return getProperty<long>("CinemaId"); }
            set { setProperty("CinemaId", value); }
        }

        public long CinemaChainId
        {
            get { return getProperty<long>("CinemaChainId"); }
            set { setProperty("CinemaChainId", value); }
        }

        public string CinemaName
        {
            get { return getProperty<string>("CinemaName"); }
            set { setProperty("CinemaName", value, 50); }
        }

        public string LinkName
        {
            get { return getProperty<string>("LinkName"); }
            set { setProperty("LinkName", value, 50); }
        }
        public string LinkPhone
        {
            get { return getProperty<string>("LinkPhone"); }
            set { setProperty("LinkPhone", value, 20); }
        }
        public string LinkMobile
        {
            get { return getProperty<string>("LinkMobile"); }
            set { setProperty("LinkMobile", value, 15); }
        }
        public string CinemaArea
        {
            get { return getProperty<string>("CinemaArea"); }
            set { setProperty("CinemaArea", value, 15); }
        }
        public string CinemaAddress
        {
            get { return getProperty<string>("CinemaAddress"); }
            set { setProperty("CinemaAddress", value, 15); }
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
