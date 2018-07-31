using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using PWMIS.DataMap.Entity;
using PWMIS.Core.Extensions;
using Movie.Common.Utils;
using Movie.ViewModel.Cinema;
using Movie.Model.Ticket;
using Movie.ViewModel.Ticket;

namespace Movie.BLL.Ticket
{
    public class TicketBatchBLL : BLLBase
    {
        #region 基础方法
        /// <summary>
        /// 获取管理员列表（全部）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonRsp<TicketBatchViewModel> GetAllList()
        {
            JsonRsp<TicketBatchViewModel> rsp = new JsonRsp<TicketBatchViewModel>();
            TicketBatchModel model = new TicketBatchModel();
            OQL q = OQL.From(model)
                .Select()
                .OrderBy(model.ID, "asc")
                .END;
            List<TicketBatchModel> list = q.ToList<TicketBatchModel>();//使用OQL扩展
            rsp.data = list.ConvertAll<TicketBatchViewModel>(o =>
            {
                return new TicketBatchViewModel()
                {
                    ID = o.ID,
                    TicketTypeId = o.TicketTypeId,
                    TicketBatchNo = o.TicketBatchNo,
                    TicketPrefix = o.TicketPrefix,
                    Amount = o.Amount,
                    TicketBatchName = o.TicketBatchName,
                    CreateBy = o.CreateBy,
                    CreateIP = o.CreateIP,
                    CreateTime = o.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Sort = o.Sort,
                    Status = o.Status,
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
        public JsonRsp<TicketBatchViewModel> GetPageList(int pageIndex, int pageSize)
        {
            JsonRsp<TicketBatchViewModel> rsp = new JsonRsp<TicketBatchViewModel>();

            TicketBatchModel m = new TicketBatchModel();
            OQL q = OQL.From(m)
                .Select()
                .OrderBy(m.ID, "asc")
                .END;
            //分页
            q.Limit(pageSize, pageIndex, true);
            //q.PageWithAllRecordCount = allCount;
            //List<Employee> list= EntityQuery<Employee>.QueryList(q);
            List<TicketBatchModel> list = q.ToList<TicketBatchModel>();//使用OQL扩展
            rsp.data = list.ConvertAll<TicketBatchViewModel>(o =>
            {
                return new TicketBatchViewModel()
                {
                    ID = o.ID,
                    TicketTypeId = o.TicketTypeId,
                    TicketBatchNo = o.TicketBatchNo,
                    TicketPrefix = o.TicketPrefix,
                    Amount = o.Amount,
                    TicketBatchName = o.TicketBatchName,
                    CreateBy = o.CreateBy,
                    CreateIP = o.CreateIP,
                    CreateTime = o.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Sort = o.Sort,
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
        public JsonRsp Add(TicketBatchModel model)
        {
            //salt
            string strSalt = Guid.NewGuid().ToString();
            model.CreateBy = "admin";
            model.CreateIP = Util.GetLocalIP();
            model.CreateTime = DateTime.Now;
            int returnvalue = EntityQuery<TicketBatchModel>.Instance.Insert(model);
            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }
        /// <summary>
        /// 删
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Remove(TicketBatchModel model)
        {
            int returnvalue = EntityQuery<TicketBatchModel>.Instance.Delete(model);
            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Update(TicketBatchModel model)
        {
            int returnvalue = EntityQuery<TicketBatchModel>.Instance.Update(model);
            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }

        /// <summary>
        /// 查 根据Id获取详情，如果没有则返回空对象
        /// </summary>
        /// <param name="TicketerID"></param>
        /// <returns></returns>
        public TicketBatchModel GetModelById(int accountId)
        {
            TicketBatchModel model = new TicketBatchModel() { ID = accountId };
            if (EntityQuery<TicketBatchModel>.Fill(model))
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
            TicketBatchModel user = new TicketBatchModel();

            OQL deleteQ = OQL.From(user)
                            .Delete()
                            .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                         .END;
            int returnvalue = EntityQuery<TicketBatchModel>.Instance.ExecuteOql(deleteQ);

            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }


        /// <summary>
        /// save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Save(TicketBatchModel model)
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
                return new JsonRsp { success = false, retmsg = "请选择要操作的数据" };
            }
            TicketBatchModel user = new TicketBatchModel();
            user.Status = status;
            OQL q = OQL.From(user)
               .Update(user.Status)
                          .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                       .END;
            int returnvalue = EntityQuery<TicketBatchModel>.Instance.ExecuteOql(q);
            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }
        #endregion
    }
}
