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
using Movie.Enum;

namespace Movie.BLL.Ticket
{
    public class TicketBLL : BLLBase
    {
        #region 基础方法
        /// <summary>
        /// 获取管理员列表（全部）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonRsp<TicketViewModel> GetAllList()
        {
            JsonRsp<TicketViewModel> rsp = new JsonRsp<TicketViewModel>();
            TicketInfo model = new TicketInfo();
            OQL q = OQL.From(model)
                .Select()
                .OrderBy(model.ID, "asc")
                .END;
            List<TicketInfo> list = q.ToList<TicketInfo>();//使用OQL扩展
            rsp.data = list.ConvertAll<TicketViewModel>(ticket =>
            {
                return new TicketViewModel()
                {
                    ID = ticket.ID,
                    TicketCode = ticket.TicketCode,
                    TicketTypeId = ticket.TicketTypeId,
                    Consumptionlevel = BaseEnum.ConsumptionlevelEnum.初始化,
                    MoneyTyp = BaseEnum.MoneyTypeEnum.初始化,
                    CustomID = 0,
                    InitialAmount = 0,
                    CostAmount = 0,
                    Balance = 0,
                    Status = BaseEnum.CredentialEnum.未交付,
                    IsExpire = false,
                    IsActivated = false,
                    //MakeTime=null,
                    //ExpireDate=null,
                    TicketBatchNo = model.TicketBatchNo,
                    GrantBy = 0,
                    //GrantTime=null, 
                    CreateBy = "admin",
                    CreateIP = Util.GetLocalIP(),
                    CreateTime = ticket.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Sort = ticket.Sort, 
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
        public JsonRsp<TicketViewModel> GetPageList(int pageIndex, int pageSize)
        {
            JsonRsp<TicketViewModel> rsp = new JsonRsp<TicketViewModel>();


            TicketInfo ticket = new TicketInfo();
            TicketTypeModel ticketType = new TicketTypeModel();

            //Select 方法不指定具体要选择的实体类属性，可以推迟到EntityContainer类的MapToList 方法上指定
            OQL joinQ = OQL.From(ticket)
                .Join(ticketType).On(ticket.TicketTypeId, ticketType.ID)
                .Select()
                .OrderBy(ticket.Sort, "desc")
                .END;

            joinQ.Limit(pageSize, pageIndex, true);

            PWMIS.DataProvider.Data.AdoHelper db = PWMIS.DataProvider.Adapter.MyDB.GetDBHelper();
            EntityContainer ec = new EntityContainer(joinQ, db);

            rsp.data = (List<TicketViewModel>)ec.MapToList<TicketViewModel>(() => new TicketViewModel()
            {
                ID = ticket.ID,
                TicketCode = ticket.TicketCode,
                TicketTypeId = ticket.TicketTypeId,
                Consumptionlevel = BaseEnum.ConsumptionlevelEnum.初始化,
                MoneyTyp = BaseEnum.MoneyTypeEnum.初始化,
                CustomID = 0,
                InitialAmount = 0,
                CostAmount = 0,
                Balance = 0,
                Status = BaseEnum.CredentialEnum.未交付,
                IsExpire = false,
                IsActivated = false,
                //MakeTime=null,
                //ExpireDate=null,
                TicketBatchNo = ticket.TicketBatchNo,
                GrantBy = 0,
                //GrantTime=null, 
                CreateBy = "admin",
                CreateIP = Util.GetLocalIP(),
                CreateTime = ticket.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                Sort = ticket.Sort, 
            });
            rsp.success = true;
            rsp.code = 0;
            rsp.count = joinQ.PageWithAllRecordCount;
            return rsp;
        }
        BLLBase context = new BLLBase();//自动创建表
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Add(TicketInfo model)
        {
            return new JsonRsp();
        }
        /// <summary>
        /// 删
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Remove(TicketInfo model)
        {
            int returnvalue = EntityQuery<TicketInfo>.Instance.Delete(model);
            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Update(TicketInfo model)
        {
            int returnvalue = EntityQuery<TicketInfo>.Instance.Update(model);
            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }

        /// <summary>
        /// 查 根据Id获取详情，如果没有则返回空对象
        /// </summary>
        /// <param name="TicketerID"></param>
        /// <returns></returns>
        public TicketInfo GetModelById(int accountId)
        {
            TicketInfo model = new TicketInfo() { ID = accountId };
            if (EntityQuery<TicketInfo>.Fill(model))
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
            TicketInfo user = new TicketInfo();

            OQL deleteQ = OQL.From(user)
                            .Delete()
                            .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                         .END;
            int returnvalue = EntityQuery<TicketInfo>.Instance.ExecuteOql(deleteQ);

            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }


        /// <summary>
        /// save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Save(TicketInfo model)
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
            TicketInfo user = new TicketInfo();
            user.Status = status;
            OQL q = OQL.From(user)
               .Update(user.Status)
                          .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                       .END;
            int returnvalue = EntityQuery<TicketInfo>.Instance.ExecuteOql(q);
            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }
        #endregion
    }
}
