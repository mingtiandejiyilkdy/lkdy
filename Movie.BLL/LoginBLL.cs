using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movie.Model;
using PWMIS.DataMap.Entity;
using System.ComponentModel;

namespace Movie.BLL
{
    public class LoginBLL
    {
        private BindingList<AdminAccount> AccountList = new BindingList<AdminAccount>();
        public bool Login(string name,string pwd)
        {
            var admin = AccountList.FirstOrDefault(p => p.AccountName == name && p.AccountPwd == pwd);
            return admin == null; 
        }
    }
}
