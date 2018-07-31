using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel; 
using PWMIS.DataMap.Entity; 
using PWMIS.Core.Extensions;
using Movie.Common.Utils;
using Movie.ViewModel.Custom;
using Movie.Model.Custom; 

namespace Movie.BLL.Custom
{
    public class CustomBLL : BLLBase
    {
        #region 基础方法
        /// <summary>
        /// 获取管理员列表（全部）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonRsp<CustomViewModel> GetAllList()
        {
            JsonRsp<CustomViewModel> rsp = new JsonRsp<CustomViewModel>();
            CustomModel model = new CustomModel();
            OQL q = OQL.From(model)
                .Select()
                .OrderBy(model.ID, "asc")
                .END;
            List<CustomModel> list = q.ToList<CustomModel>();//使用OQL扩展
            rsp.data = list.ConvertAll<CustomViewModel>(o =>
            {
                return new CustomViewModel()
                {
                    ID = o.ID,
                    CustomName = o.CustomName,
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
        public JsonRsp<CustomViewModel> GetPageList(int pageIndex, int pageSize)
        {
            JsonRsp<CustomViewModel> rsp = new JsonRsp<CustomViewModel>();

            CustomModel m = new CustomModel();
            OQL q = OQL.From(m)
                .Select()
                .OrderBy(m.ID, "asc")
                .END;
            //分页
            q.Limit(pageSize, pageIndex, true);
            //q.PageWithAllRecordCount = allCount;
            //List<Employee> list= EntityQuery<Employee>.QueryList(q);
            List<CustomModel> list = q.ToList<CustomModel>();//使用OQL扩展
            rsp.data = list.ConvertAll<CustomViewModel>(o =>
            {
                return new CustomViewModel()
                {
                    ID = o.ID,
                    CustomTypeId = o.CustomTypeId,
                    CustomName = o.CustomName,
                    LinkPhone = o.LinkPhone,
                    LinkName = o.LinkName,
                    LinkMobile = o.LinkMobile,
                    CustomArea = o.CustomArea,
                    CustomAddress = o.CustomAddress,
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
        public JsonRsp Add(CustomModel model)
        {
            //salt
            string strSalt = Guid.NewGuid().ToString();
            model.CreateBy = "admin";
            model.CreateIP = Util.GetLocalIP();
            model.CreateTime = DateTime.Now; 
            int returnvalue = EntityQuery<CustomModel>.Instance.Insert(model);
            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }
        /// <summary>
        /// 删
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Remove(CustomModel model)
        {
            int returnvalue = EntityQuery<CustomModel>.Instance.Delete(model);
            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Update(CustomModel model)
        {
            int returnvalue = EntityQuery<CustomModel>.Instance.Update(model);
            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }

        /// <summary>
        /// 查 根据Id获取详情，如果没有则返回空对象
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public CustomModel GetModelById(int accountId)
        {
            CustomModel model = new CustomModel() { ID = accountId };
            if (EntityQuery<CustomModel>.Fill(model))
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
            CustomModel user = new CustomModel(); 
             
            OQL deleteQ = OQL.From(user)
                            .Delete()
                            .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                         .END;
            int returnvalue = EntityQuery<CustomModel>.Instance.ExecuteOql(deleteQ);

            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }


        /// <summary>
        /// save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Save(CustomModel model)
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
            CustomModel user = new CustomModel();
            user.Status = status;
            OQL q = OQL.From(user)
               .Update(user.Status)
                          .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                       .END;
            int returnvalue = EntityQuery<CustomModel>.Instance.ExecuteOql(q);
            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        }
        #endregion
    }
}
