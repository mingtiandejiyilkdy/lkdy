using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel; 
using PWMIS.DataMap.Entity; 
using PWMIS.Core.Extensions;
using Movie.Common.Utils; 
using Movie.Model.Financial;
using Movie.ViewModel.Financial;

namespace Movie.BLL.Financial
{
    public class CustomAccReceiptEntryBLL : BLLBase
    {
        #region 基础方法
        /// <summary>
        /// 获取管理员列表（全部）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<CustomAccReceiptEntryModel> GetAllModelList()
        {
            JsonRsp<CustomAccReceiptEntryViewModel> rsp = new JsonRsp<CustomAccReceiptEntryViewModel>();
            CustomAccReceiptEntryModel model = new CustomAccReceiptEntryModel();
            OQL q = OQL.From(model)
                .Select()
                .OrderBy(model.ID, "desc")
                .END;
            return q.ToList<CustomAccReceiptEntryModel>();  
        }

        /// <summary>
        /// 获取管理员列表（分页）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonRsp<CustomAccReceiptEntryViewModel> GetPageList(int pageIndex, int pageSize)
        {
            JsonRsp<CustomAccReceiptEntryViewModel> rsp = new JsonRsp<CustomAccReceiptEntryViewModel>();

            CustomAccReceiptEntryModel m = new CustomAccReceiptEntryModel();
            OQL q = OQL.From(m)
                .Select()
                .OrderBy(m.ID, "asc")
                .END;
            //分页
            q.Limit(pageSize, pageIndex, true);
            //q.PageWithAllRecordCount = allCount;
            //List<Employee> list= EntityQuery<Employee>.QueryList(q);
            List<CustomAccReceiptEntryModel> list = q.ToList<CustomAccReceiptEntryModel>();//使用OQL扩展
            rsp.data = list.ConvertAll<CustomAccReceiptEntryViewModel>(o =>
            {
                return new CustomAccReceiptEntryViewModel()
                {
                    ID = o.ID,
                    CustomAccReceiptId = o.CustomAccReceiptId, 
                    BankAccountId = o.BankAccountId,
                    CurrentAmount = o.CurrentAmount,
                    BankSerialNumber = o.BankSerialNumber,
                    DateOfEntry = o.DateOfEntry, 
                    CreateBy = o.CreateUser,
                    CreateIP = o.CreateIP,
                    CreateTime = o.CreateTime, 
                    Status = o.Status, 
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
        public JsonRsp Add(CustomAccReceiptEntryModel model)
        {
            //salt
            string strSalt = Guid.NewGuid().ToString();
            model.CreateUser = AdminName;
            model.CreateIP = Util.GetLocalIP();
            model.CreateTime = DateTime.Now; 
            int returnvalue = EntityQuery<CustomAccReceiptEntryModel>.Instance.Insert(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        /// <summary>
        /// 删
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Remove(CustomAccReceiptEntryModel model)
        {
            int returnvalue = EntityQuery<CustomAccReceiptEntryModel>.Instance.Delete(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Update(CustomAccReceiptEntryModel model)
        {
            int returnvalue = EntityQuery<CustomAccReceiptEntryModel>.Instance.Update(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }

        /// <summary>
        /// 查 根据Id获取详情，如果没有则返回空对象
        /// </summary>
        /// <param name="CustomAccReceiptEntryerID"></param>
        /// <returns></returns>
        public CustomAccReceiptEntryModel GetModelById(int accountId)
        {
            CustomAccReceiptEntryModel model = new CustomAccReceiptEntryModel() { ID = accountId };
            if (EntityQuery<CustomAccReceiptEntryModel>.Fill(model))
                return model;
            else
                return null;
        }
        /// <summary>
        /// save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp DeleteById(long[] Ids)
        {
            //删除 测试数据-----------------------------------------------------
            CustomAccReceiptEntryModel user = new CustomAccReceiptEntryModel(); 
             
            OQL deleteQ = OQL.From(user)
                            .Delete()
                            .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                         .END;
            int returnvalue = EntityQuery<CustomAccReceiptEntryModel>.Instance.ExecuteOql(deleteQ);

            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }


        /// <summary>
        /// save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Save(CustomAccReceiptEntryModel model)
        {
            if (model.ID == 0)
            {
                return Add(model);
            }
            else
            {
                return Update(model);
            }
        }

        /// <summary>
        ///  启用/禁用
        /// </summary>
        /// <param name="accountStatus"></param>
        /// <returns></returns>
        public JsonRsp SetStatus(long[] Ids, int status)
        {
            if (Ids == null)
            {
                return new JsonRsp { success = false, retmsg="请选择要操作的数据" };
            }
            CustomAccReceiptEntryModel user = new CustomAccReceiptEntryModel();
            user.Status = status;
            OQL q = OQL.From(user)
               .Update(user.Status)
                          .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                       .END;
            int returnvalue = EntityQuery<CustomAccReceiptEntryModel>.Instance.ExecuteOql(q);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        #endregion

        
        #region ViewModel

        #region 获取列表（全部）
        /// <summary>
        /// 获取管理员列表（全部）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonRsp<CustomAccReceiptEntryViewModel> GetAllList()
        {
            JsonRsp<CustomAccReceiptEntryViewModel> rsp = new JsonRsp<CustomAccReceiptEntryViewModel>();

            rsp.data = GetAllModelList().ConvertAll<CustomAccReceiptEntryViewModel>(o =>
            {
                return new CustomAccReceiptEntryViewModel()
                {
                    ID = o.ID,
                    CustomAccReceiptId = o.CustomAccReceiptId, 
                    BankAccountId = o.BankAccountId,
                    CurrentAmount = o.CurrentAmount,
                    BankSerialNumber = o.BankSerialNumber,
                    DateOfEntry = o.DateOfEntry,
                    CreateBy = o.CreateUser,
                    CreateIP = o.CreateIP,
                    CreateTime = o.CreateTime,
                    Status = o.Status,
                };
            }
            );
            rsp.success = true;
            rsp.code = 0;
            return rsp;
        }
        #endregion
         

        #endregion
    }
}
