using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity; 

namespace Movie.Model
{
    public class AdminMenu : EntityBase
    {
        public AdminMenu()
        {
            TableName = "Admin_Menu";
            IdentityName = "MenuId";
            PrimaryKeys.Add("MenuId");//主键
        } 

        public long ID
        {
            get { return getProperty<long>("MenuId"); }
            set { setProperty("MenuId", value); }
        }
        public long ParentID
        {
            get { return getProperty<long>("ParentID"); }
            set { setProperty("ParentID", value); }
        }
        public string MenuKey
        {
            get { return getProperty<string>("MenuKey"); }
            set { setProperty("MenuKey", value, 20); }
        }
        public string MenuName
        {
            get { return getProperty<string>("MenuName"); }
            set { setProperty("MenuName", value, 20); }
        }
        public string MenuUrl
        {
            get { return getProperty<string>("MenuUrl"); }
            set { setProperty("MenuUrl", value, 100); }
        }
        public int MenuType
        {
            get { return getProperty<int>("MenuType"); }
            set { setProperty("MenuType", value); }
        }
        public string IDPath
        {
            get { return getProperty<string>("IDPath"); }
            set { setProperty("IDPath", value,500); }
        }
        public string Remark
        {
            get { return getProperty<string>("Remark"); }
            set { setProperty("Remark", value, 200); }
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
        public DateTime CreateTime
        {
            get { return getProperty<DateTime>("CreateTime"); }
            set { setProperty("CreateTime", value); }
        }
        public DateTime UpdateTime
        {
            get { return getProperty<DateTime>("UpdateTime"); }
            set { setProperty("UpdateTime", value); }
        } 
    }
}
