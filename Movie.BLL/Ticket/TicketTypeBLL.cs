﻿using System;
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
    public class TicketTypeBLL : BLLBase
    {
        #region 基础方法
        /// <summary>
        /// 获取管理员列表（全部）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<TicketTypeModel> GetAllModelList()
        {
            TicketTypeModel model = new TicketTypeModel();
            OQL q = OQL.From(model)
                .Select()
                .OrderBy(model.Sort, "desc")
                .OrderBy(model.ID, "asc")
                .END;
            return q.ToList<TicketTypeModel>();//使用OQL扩展             
        } 

        /// <summary>
        /// 获取管理员列表（分页）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonRsp<TicketTypeViewModel> GetPageList(int pageIndex, int pageSize)
        {
            JsonRsp<TicketTypeViewModel> rsp = new JsonRsp<TicketTypeViewModel>();

            TicketTypeModel m = new TicketTypeModel();
            OQL q = OQL.From(m)
                .Select()
                .OrderBy(m.Sort, "desc") 
                .END;
            //分页
            q.Limit(pageSize, pageIndex, true);
            //q.PageWithAllRecordCount = allCount;
            //List<Employee> list= EntityQuery<Employee>.QueryList(q);
            List<TicketTypeModel> list = q.ToList<TicketTypeModel>();//使用OQL扩展
            rsp.data = list.ConvertAll<TicketTypeViewModel>(o =>
            {
                return new TicketTypeViewModel()
                {
                    ID = o.ID,
                    TicketTypeName = o.TicketTypeName,
                    CreateBy = o.CreateUser,
                    CreateIP = o.CreateIP,
                    CreateTime = o.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Sort = o.Sort,
                    Status = o.Status,
                    UpdateBy = o.UpdateUser,
                    UpdateIP = o.UpdateIP,
                    UpdateTime = o.UpdateTime == null ? "" : Convert.ToDateTime(o.UpdateTime).ToString("yyyy-MM-dd HH:mm:ss"), 
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
        public JsonRsp Add(TicketTypeModel model)
        {
            //salt
            string strSalt = Guid.NewGuid().ToString();
            model.CreateUser = AdminName;
            model.CreateIP = Util.GetLocalIP();
            model.CreateTime = DateTime.Now; 
            int returnvalue = EntityQuery<TicketTypeModel>.Instance.Insert(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        /// <summary>
        /// 删
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Remove(TicketTypeModel model)
        {
            int returnvalue = EntityQuery<TicketTypeModel>.Instance.Delete(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Update(TicketTypeModel model)
        {
            int returnvalue = EntityQuery<TicketTypeModel>.Instance.Update(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }

        /// <summary>
        /// 查 根据Id获取详情，如果没有则返回空对象
        /// </summary>
        /// <param name="TicketerID"></param>
        /// <returns></returns>
        public TicketTypeModel GetModelById(int accountId)
        {
            TicketTypeModel model = new TicketTypeModel() { ID = accountId };
            if (EntityQuery<TicketTypeModel>.Fill(model))
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
            TicketTypeModel user = new TicketTypeModel(); 
             
            OQL deleteQ = OQL.From(user)
                            .Delete()
                            .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                         .END;
            int returnvalue = EntityQuery<TicketTypeModel>.Instance.ExecuteOql(deleteQ);

            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }


        /// <summary>
        /// save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Save(TicketTypeModel model)
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
            TicketTypeModel user = new TicketTypeModel();
            user.Status = status;
            OQL q = OQL.From(user)
               .Update(user.Status)
                          .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                       .END;
            int returnvalue = EntityQuery<TicketTypeModel>.Instance.ExecuteOql(q);
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
        public JsonRsp<TicketTypeViewModel> GetAllList()
        {
            JsonRsp<TicketTypeViewModel> rsp = new JsonRsp<TicketTypeViewModel>();

            rsp.data = GetAllModelList().ConvertAll<TicketTypeViewModel>(o =>
            {
                return new TicketTypeViewModel()
                {
                    ID = o.ID,
                    TicketTypeName = o.TicketTypeName,
                    CreateBy = o.CreateUser,
                    CreateIP = o.CreateIP,
                    CreateTime = o.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Sort = o.Sort,
                    Status = o.Status,
                    UpdateBy = o.UpdateUser,
                    UpdateIP = o.UpdateIP,
                    UpdateTime = o.UpdateTime == null ? "" : Convert.ToDateTime(o.UpdateTime).ToString("yyyy-MM-dd HH:mm:ss"),
                };
            }
            );
            rsp.success = true;
            rsp.code = 0;
            return rsp;
        }
        #endregion

        #region  获取凭据类型SelectTree
        public List<TreeSelect> GetSelectTrees() {
            List<TreeSelect> treeSelects = new List<TreeSelect>();
            foreach (var item in GetAllModelList()) {
                treeSelects.Add(new TreeSelect { 
                     id=item.ID,
                      name=item.TicketTypeName,
                        value=item.ID,
                });
            }
            return treeSelects;
        }
        #endregion

        #endregion
    }
}
