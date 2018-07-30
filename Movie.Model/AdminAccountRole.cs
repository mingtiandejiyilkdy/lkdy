using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity; 

namespace Movie.Model
{
    public class AdminAccountRole : EntityBase
    {
        public AdminAccountRole()
        {
            TableName = "Admin_Account_Role";
            IdentityName = "AccountRoleId";
            PrimaryKeys.Add("AccountRoleId");//主键
        }

        public long ID
        {
            get { return getProperty<long>("AccountRoleId"); }
            set { setProperty("AccountRoleId", value); }
        }

        public long AccountID
        {
            get { return getProperty<long>("AccountID"); }
            set { setProperty("AccountID", value); }
        } 

        public long RoleID
        {
            get { return getProperty<long>("RoleID"); }
            set { setProperty("RoleID", value); }
        }
    }
}
