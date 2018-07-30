using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel; 
using PWMIS.DataMap.Entity; 
using PWMIS.Core.Extensions;
using Movie.Common.Utils;
using Movie.ViewModel.Cinema;
using Movie.Model.Cinema;
using PWMIS.Core.Extensions;

namespace Movie.BLL.Cinema
{
    public class CinemaBLL : BLLBase
    {
        #region 基础方法
        /// <summary>
        /// 获取管理员列表（全部）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonRsp<CinemaViewModel> GetAllList()
        {
            JsonRsp<CinemaViewModel> rsp = new JsonRsp<CinemaViewModel>();
            CinemaModel model = new CinemaModel();
            OQL q = OQL.From(model)
                .Select()
                .OrderBy(model.ID, "asc")
                .END;
            List<CinemaModel> list = q.ToList<CinemaModel>();//使用OQL扩展
            rsp.data = list.ConvertAll<CinemaViewModel>(o =>
            {
                return new CinemaViewModel()
                {
                    ID = o.ID,
                    CinemaName = o.CinemaName,
                    CreateBy = o.CreateBy,
                    CreateIP = o.CreateIP,
                    CreateTime = o.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Sort = o.Sort,
                    Status = o.Status,
                    UpdateBy = o.UpdateBy,
                    UpdateIP = o.UpdateIP,
                    UpdateTime = o.UpdateTime == null ? "" : Convert.ToDateTime(o.UpdateTime).ToString("yyyy-MM-dd HH:mm:ss"), 
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
        public JsonRsp<CinemaViewModel> GetPageList(int pageIndex, int pageSize)
        {
            JsonRsp<CinemaViewModel> rsp = new JsonRsp<CinemaViewModel>();

            CinemaModel m = new CinemaModel();
            OQL q = OQL.From(m)
                .Select()
                .OrderBy(m.ID, "asc")
                .END;
            //分页
            q.Limit(pageSize, pageIndex, true);
            //q.PageWithAllRecordCount = allCount;
            //List<Employee> list= EntityQuery<Employee>.QueryList(q);
            List<CinemaModel> list = q.ToList<CinemaModel>();//使用OQL扩展
            rsp.data = list.ConvertAll<CinemaViewModel>(o =>
            {
                return new CinemaViewModel()
                {
                    ID = o.ID,
                    CinemaChainId = o.CinemaChainId,
                    CinemaName = o.CinemaName,
                    LinkPhone = o.LinkPhone,
                    LinkName = o.LinkName,
                    LinkMobile = o.LinkMobile,
                    CinemaArea = o.CinemaArea,
                    CinemaAddress = o.CinemaAddress,
                    CreateBy = o.CreateBy,
                    CreateIP = o.CreateIP,
                    CreateTime = o.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Sort = o.Sort,
                    Status = o.Status,
                    UpdateBy = o.UpdateBy,
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
        public JsonRsp Add(CinemaModel model)
        {
            //salt
            string strSalt = Guid.NewGuid().ToString();
            model.CreateBy = "admin";
            model.CreateIP = Util.GetLocalIP();
            model.CreateTime = DateTime.Now; 
            int returnvalue = EntityQuery<CinemaModel>.Instance.Insert(model);
            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }
        /// <summary>
        /// 删
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Remove(CinemaModel model)
        {
            int returnvalue = EntityQuery<CinemaModel>.Instance.Delete(model);
            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Update(CinemaModel model)
        {
            int returnvalue = EntityQuery<CinemaModel>.Instance.Update(model);
            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }

        /// <summary>
        /// 查 根据Id获取详情，如果没有则返回空对象
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public CinemaModel GetModelById(int accountId)
        {
            CinemaModel model = new CinemaModel() { ID = accountId };
            if (EntityQuery<CinemaModel>.Fill(model))
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
            CinemaModel user = new CinemaModel(); 
             
            OQL deleteQ = OQL.From(user)
                            .Delete()
                            .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                         .END;
            int returnvalue = EntityQuery<CinemaModel>.Instance.ExecuteOql(deleteQ);

            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }


        /// <summary>
        /// save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Save(CinemaModel model)
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
            CinemaModel user = new CinemaModel();
            user.Status = status;
            OQL q = OQL.From(user)
               .Update(user.Status)
                          .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                       .END;
            int returnvalue = EntityQuery<CinemaModel>.Instance.ExecuteOql(q);
            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }
        #endregion
    }
}
