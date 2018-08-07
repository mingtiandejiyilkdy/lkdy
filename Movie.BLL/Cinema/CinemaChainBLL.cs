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
    public class CinemaChainBLL : BLLBase
    {
        #region 基础方法
        /// <summary>
        /// 获取管理员列表（全部）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonRsp<CinemaChainViewModel> GetAllList()
        {
            JsonRsp<CinemaChainViewModel> rsp = new JsonRsp<CinemaChainViewModel>();
            CinemaChainModel model = new CinemaChainModel();
            OQL q = OQL.From(model)
                .Select()
                .OrderBy(model.ID, "asc")
                .END;
            List<CinemaChainModel> list = q.ToList<CinemaChainModel>();//使用OQL扩展
            rsp.data = list.ConvertAll<CinemaChainViewModel>(o =>
            {
                return new CinemaChainViewModel()
                {
                    ID = o.ID,
                    CinemaChainName = o.CinemaChainName,
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

        /// <summary>
        /// 获取管理员列表（分页）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonRsp<CinemaChainViewModel> GetPageList(int pageIndex, int pageSize)
        {
            JsonRsp<CinemaChainViewModel> rsp = new JsonRsp<CinemaChainViewModel>();

            CinemaChainModel m = new CinemaChainModel();
            OQL q = OQL.From(m)
                .Select()
                .OrderBy(m.ID, "asc")
                .END;
            //分页
            q.Limit(pageSize, pageIndex, true);
            //q.PageWithAllRecordCount = allCount;
            //List<Employee> list= EntityQuery<Employee>.QueryList(q);
            List<CinemaChainModel> list = q.ToList<CinemaChainModel>();//使用OQL扩展
            rsp.data = list.ConvertAll<CinemaChainViewModel>(o =>
            {
                return new CinemaChainViewModel()
                {
                    ID = o.ID,
                    CinemaChainName = o.CinemaChainName,
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
        public JsonRsp Add(CinemaChainModel model)
        {
            //salt
            string strSalt = Guid.NewGuid().ToString();
            model.CreateUser = AdminName;
            model.CreateIP = Util.GetLocalIP();
            model.CreateTime = DateTime.Now; 
            int returnvalue = EntityQuery<CinemaChainModel>.Instance.Insert(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        /// <summary>
        /// 删
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Remove(CinemaChainModel model)
        {
            int returnvalue = EntityQuery<CinemaChainModel>.Instance.Delete(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Update(CinemaChainModel model)
        {
            int returnvalue = EntityQuery<CinemaChainModel>.Instance.Update(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }

        /// <summary>
        /// 查 根据Id获取详情，如果没有则返回空对象
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public CinemaChainModel GetModelById(int accountId)
        {
            CinemaChainModel model = new CinemaChainModel() { ID = accountId };
            if (EntityQuery<CinemaChainModel>.Fill(model))
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
            CinemaChainModel user = new CinemaChainModel(); 
             
            OQL deleteQ = OQL.From(user)
                            .Delete()
                            .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                         .END;
            int returnvalue = EntityQuery<CinemaChainModel>.Instance.ExecuteOql(deleteQ);

            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }


        /// <summary>
        /// save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Save(CinemaChainModel model)
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
            CinemaChainModel user = new CinemaChainModel();
            user.Status = status;
            OQL q = OQL.From(user)
               .Update(user.Status)
                          .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                       .END;
            int returnvalue = EntityQuery<CinemaChainModel>.Instance.ExecuteOql(q);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        #endregion
    }
}
