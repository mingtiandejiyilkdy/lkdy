using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Movie.Model;
using PWMIS.DataMap.Entity;
using Movie.ViewModel;
using PWMIS.Core.Extensions;
using Movie.Common.Utils;
using System.Security.Cryptography;

namespace Movie.BLL
{
    public class AdminAccountBLL : BLLBase
    {  
        #region 基础方法
        /// <summary>
        /// 获取管理员列表（全部）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonRsp<AccountViewModel> GetAllList()
        {
            JsonRsp<AccountViewModel> rsp=new JsonRsp<AccountViewModel>();
            AdminAccount model = new AdminAccount();
            OQL q = OQL.From(model)
                .Select() 
                .OrderBy(model.ID, "asc")
                .END; 
            List<AdminAccount> list = q.ToList<AdminAccount>();//使用OQL扩展
            rsp.data= list.ConvertAll<AccountViewModel>(o =>
            {
                return new AccountViewModel() {
                    ID = o.ID,
                    AccountName = o.AccountName,
                    TrueName = o.TrueName,
                    AccountStatus = o.AccountStatus,
                    LoginTime = o.LoginTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    LastLoginTime = o.LastLoginTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    LoginCount = o.LoginCount,
                    CreateTIme = o.CreateTIme.ToString("yyyy-MM-dd HH:mm:ss"),
                };
            }
            );
            rsp.success = true;
            rsp.code = 0; 
            return rsp;
        }

        /// <summary>
        /// 获取管理员列表（分页）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonRsp<AccountViewModel> GetPageList(int pageIndex, int pageSize)
        {
            JsonRsp<AccountViewModel> rsp = new JsonRsp<AccountViewModel>();
              
            AdminAccount m = new AdminAccount();
            OQL q = OQL.From(m)
                .Select(m.ID,m.AccountName,m.TrueName,m.AccountStatus,m.LoginTime,m.LoginCount,m.LastLoginTime,m.CreateTIme)
                .OrderBy(m.ID, "asc")
                .END;
            //分页
            q.Limit(pageSize, pageIndex,true);
            //q.PageWithAllRecordCount = allCount;
            //List<Employee> list= EntityQuery<Employee>.QueryList(q);
            List<AdminAccount> list = q.ToList<AdminAccount>();//使用OQL扩展
            rsp.data= list.ConvertAll<AccountViewModel>(o =>
            {
                return new AccountViewModel()
                {
                    ID = o.ID,
                    AccountName = o.AccountName,
                    TrueName = o.TrueName,
                    AccountStatus = o.AccountStatus,
                    LoginTime = o.LoginTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    LastLoginTime = o.LastLoginTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    LoginCount = o.LoginCount,
                    CreateTIme = o.CreateTIme.ToString("yyyy-MM-dd HH:mm:ss"),
                };
            }
            );
            rsp.success = true;
            rsp.code = 0;
            rsp.count = q.PageWithAllRecordCount;
            return rsp;
        }

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Add(AdminAccount model)
        {
            //salt
            string strSalt = Guid.NewGuid().ToString();
            model.Salt = strSalt;
            model.AccountPwd = EncryptHelper.MD5Encoding(model.AccountPwd,strSalt);
            int returnvalue = EntityQuery<AdminAccount>.Instance.Insert(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        /// <summary>
        /// 删
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Remove(AdminAccount model)
        {
            int returnvalue = EntityQuery<AdminAccount>.Instance.Delete(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue }; 
        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Update(AdminAccount model)
        {
            int returnvalue = EntityQuery<AdminAccount>.Instance.Update(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };  
        }
        
        /// <summary>
        /// 查 根据Id获取详情，如果没有则返回空对象
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public AdminAccount GetModelById(int accountId)
        {
            AdminAccount model = new AdminAccount() { ID = accountId };
            if (EntityQuery<AdminAccount>.Fill(model))
                return model;
            else
                return null;
        } 
        /// <summary>
        /// save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp DeleteById(int Id)
        {
            return Remove(GetModelById(Id));
        }
        

        /// <summary>
        /// save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Save(AdminAccount model)
        {
            if (model.ID == 0)
            { 
                return Add(model);
            }
            else {
                return Update(model);
            } 
        }

        /// <summary>
        ///  启用/禁用
        /// </summary>
        /// <param name="accountStatus"></param>
        /// <returns></returns>
        public JsonRsp SetStatus(int accountId, int accountStatus)
        {
            AdminAccount dbAccount = GetModelById(accountId);
            dbAccount.AccountStatus = accountStatus;
            return Update(dbAccount);
        }
        #endregion


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public JsonRsp Login(string accountName,string accountPwd)
        {
            JsonRsp json = new JsonRsp();

            AdminAccount model = new AdminAccount();
            model.AccountName = accountName;
            OQL q = OQL.From(model)
                .Select()
                .Where(model.AccountName) //以用户名和密码来验证登录
            .END;

            model = q.ToEntity<AdminAccount>();//ToEntity，OQL扩展方法 
            if (model == null) {

                json.success = false;
                json.retmsg = "账号或密码不匹配";
            }
            else
            { 
                if (model.AccountPwd == EncryptHelper.MD5Encoding(accountPwd, model.Salt))
                {
                    json.success = true;
                    json.code = 0;
                    json.returnObj = model;
                }
                else {
                    json.success = false;
                    json.retmsg = "账号或密码不匹配";
                } 
            }
            return json;
        } 
    }
}
