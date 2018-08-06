using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.Core.Extensions;
using Movie.Model;
using Movie.Model.Cinema;
using Movie.Model.Custom;
using Movie.Model.Ticket;
using Movie.Model.Contract;
using Movie.Model.Financial;
using Movie.Model.ChargeCard;
using Movie.Model.Bank;
using System.Web;
using System.Web.Security;
using Movie.ViewModel;
using System.Web.Script.Serialization;
using Movie.Model.Tenant;

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
            //创建租户表
            CheckTableExists<TenantModel>(); 
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
            //创建凭据表
            CheckTableExists<TicketInfo>();
            //创建合同协议表
            CheckTableExists<ContractModel>();
            //创建客户财务表
            CheckTableExists<CustomFinancialModel>();
            //创建财务明细表
            CheckTableExists<CustomFinancialDetailModel>();
            //创建充卡记录表
            CheckTableExists<CustomChargeCardsModel>();
            //创建应收款记录表
            CheckTableExists<CustomAccReceiptModel>();
            //创建实收款记录表
            CheckTableExists<CustomAccReceiptEntryModel>();
            //创建银行表
            CheckTableExists<BankModel>();
            //创建银行账号表
            CheckTableExists<BankAccountModel>();

            
            
            return true;
        }

        #endregion 

        #region cookies方法 
        public static AccountViewModel AdminUser
        {
            get
            {
                //1.登录状态获取用户信息（自定义保存的用户）
                var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                //2.使用 FormsAuthentication 解密用户凭据
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                AccountViewModel model = new AccountViewModel();

                //3. 直接解析到用户模型里去，有没有很神奇
                model = new JavaScriptSerializer().Deserialize<AccountViewModel>(ticket.UserData);

                return model;
            }
        }
        //登录用户Id
        public static long AdminId
        {
            get
            {
                return AdminUser.ID;
            }
        }
        //登录用户名称
        public static string AdminName
        {
            get
            {
                return AdminUser.AccountName;
            }
        }
        #endregion
    }
}

