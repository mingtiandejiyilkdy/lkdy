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
using Movie.Model.ChargeCard;
using Movie.Model.Custom;
using Movie.Model.Financial;
using Movie.BLL.Financial;
using Movie.Enum;

namespace Movie.BLL.Ticket
{
    public class CustomChargeCardBLL : BLLBase
    {
        #region 基础方法
        /// <summary>
        /// 获取列表（全部）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<CustomChargeCardsModel> GetAllModelList()
        {
            CustomChargeCardsModel model = new CustomChargeCardsModel();
            OQL q = OQL.From(model)
                .Select()
                .OrderBy(model.Sort, "desc")
                .OrderBy(model.ID, "asc")
                .END;
            return q.ToList<CustomChargeCardsModel>();//使用OQL扩展             
        } 

        /// <summary>
        /// 获取管理员列表（分页）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonRsp<CustomChargeCardViewModel> GetPageList(int pageIndex, int pageSize,bool limit=true)
        {
            JsonRsp<CustomChargeCardViewModel> rsp = new JsonRsp<CustomChargeCardViewModel>();

            CustomChargeCardsModel c = new CustomChargeCardsModel();
            CustomModel custom = new CustomModel();
            TicketTypeModel t = new TicketTypeModel();
            OQL joinQ = OQL.From(c)
               .Join(custom).On(c.CustomId, custom.ID)
                .LeftJoin(t).On(c.TicketTypeID, t.ID) 
                .Select()
                .OrderBy(c.Sort, "desc")
                .END;
            //分页
            if (limit)
            {
                joinQ.Limit(pageSize, pageIndex, true);
            }
             PWMIS.DataProvider.Data.AdoHelper db = PWMIS.DataProvider.Adapter.MyDB.GetDBHelper();
            EntityContainer ec = new EntityContainer(joinQ, db);

            rsp.data = (List<CustomChargeCardViewModel>)ec.MapToList<CustomChargeCardViewModel>(() => new CustomChargeCardViewModel()
            {
                ID = c.ID,
                CustomId=c.CustomId,
                CustomName=custom.CustomName,
                TicketTypeID = c.TicketTypeID,
                TicketTypeName = t.TicketTypeName,
                CurrentCount = c.CurrentCount,
                FaceAmount = c.FaceAmount,
                CurrentAmount = c.CurrentAmount,
                ExpireDate = c.ExpireDate,
                TicketBatchId = c.TicketBatchId,
                TicketStart = c.TicketStart,
                TicketEnd = c.TicketEnd,
                Consumptionlevel = c.Consumptionlevel,
                IsCommonCard = c.IsCommonCard,
                Sort = c.Sort,
                CreateBy = c.CreateBy,
                CreateIP = c.CreateIP,
                CreateTime = c.CreateTime,
                UpdateBy = c.UpdateBy,
                UpdateIP = c.UpdateIP,
                UpdateTime = c.UpdateTime,                
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
        public JsonRsp Add(CustomChargeCardsModel model)
        {
            model.ChargeCardNo = "H" +model.CustomId+ DateTime.Now.ToString("yyyyMMddHHmmss"); ;
            //客户财务信息操作
            //新增客户财务明细信息 
            CustomFinancialModel financialModel = new CustomFinancialBLL().GetCustomFinancialByCustomId(model.CustomId);
            decimal amount = model.CurrentAmount ;
            if (model.MoneyType == (int)BaseEnum.MoneyTypeEnum.应收)
            {
                financialModel.ARBalance -= amount;

                CustomFinancialDetailModel financialDetail = new CustomFinancialDetailModel();
                financialDetail.CreateBy = AdminName;
                financialDetail.CreateIP = Util.GetLocalIP();
                financialDetail.CreateTime = DateTime.Now;
                financialDetail.CustomFinancialId = financialModel.ID;
                financialDetail.FinanciaOpeType = (int)FinanciaOpeTypeEnum.减少; 
                financialDetail.Remark = "客户充卡";
                financialDetail.MoneyType = (int)BaseEnum.MoneyTypeEnum.应收;
                financialDetail.CurrentAmount = amount;
                financialDetail.Balance = financialModel.ARBalance - amount; ;
                Add(financialDetail);
            }
            else if (model.MoneyType == (int)BaseEnum.MoneyTypeEnum.赠送)
            {
                financialModel.LargessBalance -= amount;

                CustomFinancialDetailModel financialDetail = new CustomFinancialDetailModel();
                financialDetail.CreateBy = AdminName;
                financialDetail.CreateIP = Util.GetLocalIP();
                financialDetail.CreateTime = DateTime.Now;
                financialDetail.CustomFinancialId = financialModel.ID;
                financialDetail.FinanciaOpeType = (int)FinanciaOpeTypeEnum.减少;
                financialDetail.Remark = "客户充卡";
                financialDetail.MoneyType = (int)BaseEnum.MoneyTypeEnum.赠送;
                financialDetail.CurrentAmount = amount;
                financialDetail.Balance = financialModel.LargessBalance - amount; ;
                Add(financialDetail);
            }
            else if (model.MoneyType == (int)BaseEnum.MoneyTypeEnum.置换)
            {
                financialModel.ExChangeBalance = amount;

                CustomFinancialDetailModel financialDetail = new CustomFinancialDetailModel();
                financialDetail.CreateBy = AdminName;
                financialDetail.CreateIP = Util.GetLocalIP();
                financialDetail.CreateTime = DateTime.Now;
                financialDetail.CustomFinancialId = financialModel.ID;
                financialDetail.FinanciaOpeType = (int)FinanciaOpeTypeEnum.减少;
                financialDetail.Remark = "客户充卡";
                financialDetail.MoneyType = (int)BaseEnum.MoneyTypeEnum.置换;
                financialDetail.CurrentAmount = amount;
                financialDetail.Balance = financialModel.ExChangeBalance - amount; ;
                Add(financialDetail);
            }
            int returnvalue = EntityQuery<CustomFinancialModel>.Instance.Update(financialModel);

            model.CreateBy = AdminName;
            model.CreateIP = Util.GetLocalIP();
            model.CreateTime = DateTime.Now;
            returnvalue = EntityQuery<CustomChargeCardsModel>.Instance.Insert(model);

            //新增客户应付
            CustomAccReceiptModel customAR = new CustomAccReceiptModel();
            customAR.CustomId = model.CustomId;
            customAR.ChargeCardNo = model.ChargeCardNo;
            customAR.ARAmount = model.CurrentAmount;
            customAR.Status = (int)ARStatusEnum.已确认;
            customAR.CreateBy = AdminName;
            customAR.CreateIP = Util.GetLocalIP();
            customAR.CreateTime = DateTime.Now;
            returnvalue = EntityQuery<CustomAccReceiptModel>.Instance.Insert(customAR);


            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        /// <summary>
        /// 删
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Remove(CustomChargeCardsModel model)
        {
            int returnvalue = EntityQuery<CustomChargeCardsModel>.Instance.Delete(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Update(CustomChargeCardsModel model)
        {
            int returnvalue = EntityQuery<CustomChargeCardsModel>.Instance.Update(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }

        /// <summary>
        /// 查 根据Id获取详情，如果没有则返回空对象
        /// </summary>
        /// <param name="TicketerID"></param>
        /// <returns></returns>
        public CustomChargeCardsModel GetModelById(int accountId)
        {
            CustomChargeCardsModel model = new CustomChargeCardsModel() { ID = accountId };
            if (EntityQuery<CustomChargeCardsModel>.Fill(model))
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
            CustomChargeCardsModel user = new CustomChargeCardsModel(); 
             
            OQL deleteQ = OQL.From(user)
                            .Delete()
                            .Where(cmp => cmp.Comparer(user.ID, "IN", Ids)) //为了安全，不带Where条件是不会全部删除数据的
                         .END;
            int returnvalue = EntityQuery<CustomChargeCardsModel>.Instance.ExecuteOql(deleteQ);

            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }


        /// <summary>
        /// save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Save(CustomChargeCardsModel model)
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
            return new JsonRsp { success = false };
        }
        #endregion 

        #region  获取充值编号SelectTree
        public List<TreeSelect> GetSelectTrees()
        {
            List<TreeSelect> treeSelects = new List<TreeSelect>();
            foreach (var item in GetAllModelList())
            {
                treeSelects.Add(new TreeSelect
                {
                    id = item.ID,
                    name = item.ChargeCardNo,
                    value = item.ID,
                });
            }
            return treeSelects;
        }
        #endregion
         
    }
}
