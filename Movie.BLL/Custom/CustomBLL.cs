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
        public List<CustomModel> GetAllModelList()
        {
            JsonRsp<CustomViewModel> rsp = new JsonRsp<CustomViewModel>();
            CustomModel model = new CustomModel(); 
            OQL q = OQL.From(model)
                .Select() 
                .Where(model.TenantId==TenantId)
                .OrderBy(model.Sort, "desc")
                .END;
            return q.ToList<CustomModel>();  
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


            CustomModel model = new CustomModel();
            CustomTypeModel customType = new CustomTypeModel();

            model.TenantId = TenantId;
            //Select 方法不指定具体要选择的实体类属性，可以推迟到EntityContainer类的MapToList 方法上指定
            OQL joinQ = OQL.From(model)
                .Join(customType).On(model.CustomTypeId, customType.ID) 
                .Select()
                .OrderBy(model.Sort, "desc")
                .END;

            joinQ.Limit(pageSize, pageIndex, true);

            PWMIS.DataProvider.Data.AdoHelper db = PWMIS.DataProvider.Adapter.MyDB.GetDBHelper();
            EntityContainer ec = new EntityContainer(joinQ, db);

            rsp.data = (List<CustomViewModel>)ec.MapToList<CustomViewModel>(() => new CustomViewModel()
            {
                ID = model.ID,
                CustomTypeId = model.CustomTypeId,
                CustomTypeName = customType.CustomTypeName,
                CustomName = model.CustomName,
                LinkPhone = model.LinkPhone,
                LinkName = model.LinkName,
                LinkMobile = model.LinkMobile,
                CustomArea = model.CustomArea,
                CustomAddress = model.CustomAddress,
                CreateBy = model.CreateUser,
                CreateIP = model.CreateIP,
                CreateTime = model.CreateTime,
                Sort = model.Sort,
                Status = model.Status,
                UpdateBy = model.UpdateUser,
                UpdateIP = model.UpdateIP,
                UpdateTime = model.UpdateTime,
            }); 
             
            rsp.success = true;
            rsp.code = 0;
            rsp.count = joinQ.PageWithAllRecordCount;
            return rsp;
        }

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Add(CustomModel model)
        {
            int returnvalue = EntityQuery<CustomModel>.Instance.Insert(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        /// <summary>
        /// 删
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Remove(CustomModel model)
        { 
            int returnvalue = EntityQuery<CustomModel>.Instance.Delete(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Update(CustomModel model)
        {
            int returnvalue = EntityQuery<CustomModel>.Instance.Update(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }

        /// <summary>
        /// 查 根据Id获取详情，如果没有则返回空对象
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public CustomModel GetModelById(int Id)
        {
            CustomModel model = new CustomModel() { TenantId=TenantId , ID = Id };
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

            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }


        /// <summary>
        /// save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Save(CustomModel model)
        {
            model.TenantId = TenantId;
            if (model.ID == 0)
            {
                model.CreateId = AdminId;
                model.CreateUser = AdminName;
                model.CreateIP = Util.GetLocalIP();
                model.CreateTime = DateTime.Now; 
                return Add(model);
            }
            else
            {
                if (model.TenantId != TenantId)
                {
                    return new JsonRsp { success = false, code = -1, retmsg = "数据验证失败" };
                }
                model.UpdateId = AdminId;
                model.UpdateUser = AdminName;
                model.UpdateIP = Util.GetLocalIP();
                model.UpdateTime = DateTime.Now; 
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
            CustomModel model = new CustomModel();
            model.Status = status;
            model.UpdateId = AdminId;
            model.UpdateUser = AdminName;
            model.UpdateIP = Util.GetLocalIP();
            model.UpdateTime = DateTime.Now;
            OQL q = OQL.From(model)
               .Update(model.Status, model.UpdateId, model.UpdateUser, model.UpdateIP, model.UpdateIP)
                          .Where(cmp => cmp.Comparer(model.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                       .END;
            int returnvalue = EntityQuery<CustomModel>.Instance.ExecuteOql(q);
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
        public JsonRsp<CustomViewModel> GetAllList()
        {
            JsonRsp<CustomViewModel> rsp = new JsonRsp<CustomViewModel>();

            rsp.data = GetAllModelList().ConvertAll<CustomViewModel>(o =>
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
                    CreateBy = o.CreateUser,
                    CreateIP = o.CreateIP,
                    CreateTime = o.CreateTime,
                    Sort = o.Sort,
                    Status = o.Status,
                    UpdateBy = o.UpdateUser,
                    UpdateIP = o.UpdateIP,
                    UpdateTime = o.UpdateTime ,
                };
            }
            );
            rsp.success = true;
            rsp.code = 0;
            return rsp;
        }
        #endregion

        #region  获取客户SelectTree
        public List<TreeSelect> GetSelectTrees() {
            List<TreeSelect> treeSelects = new List<TreeSelect>();
            foreach (var item in GetAllModelList()) {
                treeSelects.Add(new TreeSelect { 
                     id=item.ID,
                      name=item.CustomName,
                        value=item.ID,
                });
            }
            return treeSelects;
        }
        #endregion

        #endregion
    }
}
