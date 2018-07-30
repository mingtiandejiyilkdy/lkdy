using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.Core.Extensions;
using Movie.Model;
using Movie.Model.Cinema;
using Movie.Model.Custom;
using Movie.Model.Ticket;

namespace Movie.BLL
{
    public class BLLBase: DbContext
    {
        public BLLBase()
            : base("local")
        {
            //local 是连接字符串名字
        }

        #region 父类抽象方法的实现

        protected override bool CheckAllTableExists()
        {
            //创建用户表
            CheckTableExists<AdminAccount>();
            //创建角色表
            CheckTableExists<AdminRole>();
            //创建菜单表
            CheckTableExists<AdminMenu>();
            //创建用户角色表
            CheckTableExists<AdminAccountRole>();
            //创建院线表
            CheckTableExists<CinemaChainModel>();
            //创建影院表
            CheckTableExists<CinemaModel>();
            //创建客户类型表
            CheckTableExists<CustomTypeModel>();
            //创建客户表
            CheckTableExists<CustomModel>();
            //创建凭据类型表
            CheckTableExists<TicketTypeModel>();
            //创建制卡批次表
            CheckTableExists<TicketBatchModel>();
            
            return true;
        }

        #endregion
    }
}

