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
using Movie.Model.Contract;
using Movie.ViewModel.Contract;
using Movie.Model.Custom;
using Movie.Model.Financial;
using PWMIS.DataProvider.Data;
using PWMIS.DataProvider.Adapter;

namespace Movie.BLL.Contract
{
    public class ContractBLL : BLLBase
    {
        #region 基础方法
        /// <summary>
        /// 获取列表（全部）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<ContractModel> GetAllModelList()
        { 
            ContractModel model = new ContractModel();
            OQL q = OQL.From(model)
                .Select()
                .OrderBy(model.ID, "asc")
                .END;
            return q.ToList<ContractModel>(); 
        }

        /// <summary>
        /// 获取管理员列表（分页）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonRsp<ContractViewModel> GetPageList(int pageIndex, int pageSize)
        {
            JsonRsp<ContractViewModel> rsp = new JsonRsp<ContractViewModel>();


            ContractModel contract = new ContractModel();
            CustomModel custom = new CustomModel();
            CustomTypeModel customType = new CustomTypeModel();

            //Select 方法不指定具体要选择的实体类属性，可以推迟到EntityContainer类的MapToList 方法上指定
            OQL joinQ = OQL.From(contract)
                .Join(custom).On(contract.CustomId, custom.ID)
                .Join(customType).On(custom.CustomTypeId, customType.ID)
                .Select()
                .OrderBy(contract.Sort, "desc")
                .END;

            joinQ.Limit(pageSize, pageIndex, true);

            PWMIS.DataProvider.Data.AdoHelper db = PWMIS.DataProvider.Adapter.MyDB.GetDBHelper();
            EntityContainer ec = new EntityContainer(joinQ, db);

            rsp.data = (List<ContractViewModel>)ec.MapToList<ContractViewModel>(() => new ContractViewModel()
            {
                ID = contract.ID,
                CustomId = contract.CustomId,
                CustomName=custom.CustomName,
                CustomTypeName=customType.CustomTypeName,
                ContractNo = contract.ContractNo,
                ContractAmount = contract.ContractAmount.ToString("N2"),
                Deductions = contract.Deductions.ToString("N2"),
                Balance = contract.Balance.ToString("N2"),
                Remark = contract.Remark,
                Sort = contract.Sort,
                Status = contract.Status,
                CreateBy = contract.CreateUser,
                CreateIP = contract.CreateIP,
                CreateTime = contract.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
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
        public JsonRsp Add(ContractModel model)
        { 
            int returnvalue = EntityQuery<ContractModel>.Instance.Insert(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        /// <summary>
        /// 删
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Remove(ContractModel model)
        {
            int returnvalue = EntityQuery<ContractModel>.Instance.Delete(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Update(ContractModel model)
        {
            int returnvalue = EntityQuery<ContractModel>.Instance.Update(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }

        /// <summary>
        /// 查 根据Id获取详情，如果没有则返回空对象
        /// </summary>
        /// <param name="TicketerID"></param>
        /// <returns></returns>
        public ContractModel GetModelById(long id)
        {
            ContractModel model = new ContractModel() { ID = id };
            if (EntityQuery<ContractModel>.Fill(model))
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
            ContractModel user = new ContractModel();

            OQL deleteQ = OQL.From(user)
                            .Delete()
                            .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                         .END;
            int returnvalue = EntityQuery<ContractModel>.Instance.ExecuteOql(deleteQ);

            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }


        /// <summary>
        /// save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Save(ContractModel model)
        {
            model.TenantId = TenantId;
            if (model.ID == 0)
            {
                //合同信息
                string salt = model.CreateTime.ToString("yyyyMMddHHmmss");
                string signStr = model.ContractAmount.ToString() + model.Deductions.ToString() + model.Balance + salt;
                model.BalanceKey = EncryptHelper.MD5Encoding(signStr, salt);

                model.ContractNo = "H" + DateTime.Now.ToString("yyyyMMddHHmmss");
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
                return new JsonRsp { success = false, retmsg = "请选择要操作的数据" };
            }
            ContractModel user = new ContractModel();
            user.Status = status;
            OQL q = OQL.From(user)
               .Update(user.Status)
                          .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                       .END;
            int returnvalue = EntityQuery<ContractModel>.Instance.ExecuteOql(q);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        #endregion

         /// <summary>
        /// 审核
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Audit(long[] Ids, int status)
        {
            if (Ids == null)
            {
                return new JsonRsp { success = false, retmsg = "请选择要操作的数据" };
            }
 

            //更新状态
            ContractModel model = new ContractModel();
            model.Status = status;
            OQL q = OQL.From(model)
               .Update(model.Status)
                          .Where(cmp => cmp.Comparer(model.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                       .END;
            //初始化客户财务信息 

            OQL qList = OQL.From(model)
                .Select()
                .OrderBy(model.Sort, "asc")
                .END;
            List<ContractModel> items= qList.ToList<ContractModel>();
            int  returnvalue = 0;
            foreach (ContractModel item in items)
            {
                if (item.Status != 0) {
                    return new JsonRsp { success = false, retmsg = "只能审核待审核合同，该合同当前状态为：" + Util.getStatus(item.Status, typeof(BaseEnum.ProtocolTypeEnum)) };
                }
                //客户财务信息初始化
                CustomFinancialModel financialModel = new CustomFinancialModel();
                financialModel.CreateUser = AdminName;
                financialModel.CreateIP = Util.GetLocalIP();
                financialModel.CreateTime = DateTime.Now; 
                financialModel.CustomId = item.CustomId;
                financialModel.ARAmount = item.AccountReceivable;
                financialModel.ARBalance = item.AccountReceivable;
                financialModel.LargessAmount = item.LargessAmount;
                financialModel.LargessBalance = item.LargessAmount;
                financialModel.ExChangeAmount = item.ExChangeAmount;
                financialModel.ExChangeBalance = item.ExChangeAmount; 
                financialModel.Remark = "合同/协议号：" + item.ContractNo;
                returnvalue = Add<CustomFinancialModel>(financialModel);

                //新增客户财务信息日志
                List<CustomFinancialDetailModel> details = new List<CustomFinancialDetailModel>();

                CustomFinancialDetailModel financialDetail = new CustomFinancialDetailModel();
                financialDetail.CreateUser = AdminName;
                financialDetail.CreateIP = Util.GetLocalIP();
                financialDetail.CreateTime = DateTime.Now;
                financialDetail.CustomFinancialId = financialModel.ID;
                financialDetail.FinanciaOpeType = (int)FinanciaOpeTypeEnum.增加;
                financialDetail.CurrentAmount = item.AccountReceivable;
                financialDetail.Balance = financialDetail.CurrentAmount;
                financialDetail.Remark = "合同/协议号：" + item.ContractNo; 
                financialDetail.MoneyType = (int)BaseEnum.MoneyTypeEnum.应收;
                returnvalue = Add<CustomFinancialDetailModel>(financialDetail);

                financialDetail.CreateUser = AdminName;
                financialDetail.CreateIP = Util.GetLocalIP();
                financialDetail.CreateTime = DateTime.Now;
                financialDetail.CustomFinancialId = financialModel.ID;
                financialDetail.FinanciaOpeType = (int)FinanciaOpeTypeEnum.增加;
                financialDetail.CurrentAmount = item.LargessAmount;
                financialDetail.Balance = financialDetail.CurrentAmount;
                financialDetail.Remark = "合同/协议号：" + item.ContractNo; 
                financialDetail.MoneyType = (int)BaseEnum.MoneyTypeEnum.赠送;
                returnvalue = Add<CustomFinancialDetailModel>(financialDetail);

                financialDetail.CreateUser = AdminName;
                financialDetail.CreateIP = Util.GetLocalIP();
                financialDetail.CreateTime = DateTime.Now;
                financialDetail.CustomFinancialId = financialModel.ID;
                financialDetail.FinanciaOpeType = (int)FinanciaOpeTypeEnum.增加;
                financialDetail.CurrentAmount = item.ExChangeAmount;
                financialDetail.Balance = financialDetail.CurrentAmount;
                financialDetail.Remark = "合同/协议号：" + item.ContractNo; 
                financialDetail.MoneyType = (int)BaseEnum.MoneyTypeEnum.置换;
                returnvalue = Add <CustomFinancialDetailModel>(financialDetail);
            }
             returnvalue = EntityQuery<TicketInfo>.Instance.ExecuteOql(q);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }

        /// <summary>
        /// 查 根据Id获取详情，如果没有则返回空对象
        /// </summary>
        /// <param name="TicketerID"></param>
        /// <returns></returns>
        public ContractViewModel GetViewModelById(long contractId)
        {
            ContractModel contract = GetModelById(contractId);
            if (contract!=null)
            {                
                CustomModel customModel = new CustomModel() { ID = contract.CustomId };
                if (EntityQuery<CustomModel>.Fill(customModel))
                {     
                   return new ContractViewModel()
                        {
                            ID = contract.ID,
                            CustomId = contract.CustomId,
                            CustomName = customModel.CustomName, 
                            ContractNo = contract.ContractNo,
                            ContractAmount = contract.ContractAmount.ToString("N2"),
                            Deductions = contract.Deductions.ToString("N2"),
                            Balance = contract.Balance.ToString("N2"),
                            Remark = contract.Remark,
                            Sort = contract.Sort,
                            Status = contract.Status,
                            CreateBy = contract.CreateUser,
                            CreateIP = contract.CreateIP,
                            CreateTime = contract.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        };
                }
                else
                {
                return null;
                }
            }
            else
                return null; 
        }


        #region  获取合同SelectTree
        public JsonRsp<TreeSelect> GetSelectTrees(long? customId)
        {
            JsonRsp<TreeSelect> rsp = new JsonRsp<TreeSelect>();
            List<ContractModel> contractList = GetAllModelList().FindAll(o=>o.Balance>0);
            if(customId>0){
                contractList = contractList.FindAll(o=>o.CustomId==customId);
            };
            foreach (var item in GetAllModelList())
            {
                rsp.data.Add(new TreeSelect
                {
                    id = item.ID,
                    name = item.ContractNo,
                    value = item.ID,
                });
            }
            rsp.success=true;
            return rsp;
        }
        #endregion

    }
}
