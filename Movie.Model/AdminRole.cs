using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity; 

namespace Movie.Model
{
    public class AdminRole : EntityBase
    {
        public AdminRole()
        {
            TableName = "Admin_Role";
            IdentityName = "RoleId";
            PrimaryKeys.Add("RoleId");//主键
        } 

        public long ID
        {
            get { return getProperty<long>("RoleId"); }
            set { setProperty("RoleId", value); }
        }

        public string RoleName
        {
            get { return getProperty<string>("RoleName"); }
            set { setProperty("RoleName", value, 20); }
        }

        public string MenuIds
        {
            get { return getProperty<string>("MenuIds"); }
            set { setProperty("MenuIds", value); }
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
         
        public DateTime CreateTIme
        {
            get { return getProperty<DateTime>("CreateTIme"); }
            set { setProperty("CreateTIme", value); }
        } 
    }
}
