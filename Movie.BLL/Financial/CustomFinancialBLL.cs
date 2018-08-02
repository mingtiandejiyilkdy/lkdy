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

namespace Movie.BLL.Financial
{
    public class CustomFinancialBLL : BLLBase
    {
        #region 基础方法
        /// <summary>
        /// 获取列表（全部）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<ContractModel> GetAllList()
        {
            JsonRsp<ContractViewModel> rsp = new JsonRsp<ContractViewModel>();
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
                //ContractAmount = contract.ContractAmount.ToString("N2"),
                //Deductions = contract.Deductions.ToString("N2"),
                //Balance = contract.Balance.ToString("N2"),
                Remark = contract.Remark,
                Sort = contract.Sort,
                Status = contract.Status,
                CreateBy = contract.CreateBy,
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
        public JsonRsp Add(CustomFinancialModel model)
        {  
            model.Balance = model.Balance - model.Deductions; 
            string salt = model.CreateTime.ToString("yyyyMMddHHmmss");
            string signStr = model.AccumulativeAmount.ToString()+model.Deductions.ToString()+model.Balance+salt ;
            model.CheckSign = EncryptHelper.MD5Encoding(signStr, salt);

            model.CreateBy = "admin";
            model.CreateIP = Util.GetLocalIP();
            model.CreateTime = DateTime.Now;
            int returnvalue = EntityQuery<CustomFinancialModel>.Instance.Insert(model); 
            return new JsonRsp { success = returnvalue > 0, code = 0, returnvalue = returnvalue };
        } 
        /// <summary>
        /// 查 根据Id获取详情，如果没有则返回空对象
        /// </summary>
        /// <param name="TicketerID"></param>
        /// <returns></returns>
        public CustomFinancialModel GetModelById(int customFinancialId)
        {
            CustomFinancialModel model = new CustomFinancialModel() { ID = customFinancialId };
            if (EntityQuery<CustomFinancialModel>.Fill(model))
                return model;
            else
                return null;
        } 


        /// <summary>
        /// save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Save(CustomFinancialModel model)
        { 
            return Add(model); 
        }
         
        #endregion
    }
}
