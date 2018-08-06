using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Movie.Model;
using PWMIS.DataMap.Entity;
using Movie.ViewModel;
using PWMIS.Core.Extensions;
using Movie.Common.Utils;

namespace Movie.BLL
{
    public class AdminMenuBLL : BLLBase
    {

        #region 基础方法
        /// <summary>
        /// 列表（全部）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonRsp<MenuViewModel> GetAllList()
        {
            JsonRsp<MenuViewModel> rsp = new JsonRsp<MenuViewModel>();
            AdminMenu model = new AdminMenu();
            OQL q = OQL.From(model)
                .Select()
                .OrderBy(model.ID, "asc")
                .END;
            List<AdminMenu> list = q.ToList<AdminMenu>();//使用OQL扩展
            rsp.data = list.ConvertAll<MenuViewModel>(o =>
            {
                return new MenuViewModel()
                {
                    ID = o.ID,
                    MenuKey = o.MenuKey,
                    MenuName = o.MenuName,
                    MenuUrl = o.MenuUrl,
                    MenuType = o.MenuType,
                    IDPath = o.IDPath,
                    Remark = o.Remark,
                    Sort = o.Sort,
                    Status = o.Status,
                    CreateTIme = o.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
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
        public JsonRsp<MenuViewModel> GetPageList(int pageIndex, int pageSize)
        {
            JsonRsp<MenuViewModel> rsp = new JsonRsp<MenuViewModel>();

            AdminMenu m = new AdminMenu();
            OQL q = OQL.From(m)
                .Select()
                .OrderBy(m.ID, "asc")
                .END;
            //分页
            q.Limit(pageSize, pageIndex, true);
            //q.PageWithAllRecordCount = allCount;
            //List<Employee> list= EntityQuery<Employee>.QueryList(q);
            List<AdminMenu> list = q.ToList<AdminMenu>();//使用OQL扩展
            rsp.data = list.ConvertAll<MenuViewModel>(o =>
            {
                return new MenuViewModel()
                {
                    ID = o.ID,
                    MenuKey = o.MenuKey,
                    MenuName = o.MenuName,
                    MenuUrl = o.MenuUrl,
                    MenuType = o.MenuType,
                    IDPath = o.IDPath,
                    Remark = o.Remark,
                    Sort = o.Sort,
                    Status = o.Status,
                    CreateTIme = o.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
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
        public JsonRsp Add(AdminMenu model)
        {
            int returnvalue = EntityQuery<AdminMenu>.Instance.Insert(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        /// <summary>
        /// 删
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Remove(AdminMenu model)
        {
            int returnvalue = EntityQuery<AdminMenu>.Instance.Delete(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Update(AdminMenu model)
        {
            int returnvalue = EntityQuery<AdminMenu>.Instance.Update(model);
            return new JsonRsp { success = returnvalue > 0, code = returnvalue };
        }

        /// <summary>
        /// 查 根据Id获取详情，如果没有则返回空对象
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public AdminMenu GetModelById(long Id)
        {
            AdminMenu model = new AdminMenu() { ID = Id };
            if (EntityQuery<AdminMenu>.Fill(model))
                return model;
            else
                return null;
        }
        /// <summary>
        /// save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp DeleteById(int Id)
        {
            return Remove(GetModelById(Id));
        }


        /// <summary>
        /// save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonRsp Save(AdminMenu model)
        { 
            if (model.ID == 0)
            {
                model.CreateTime = DateTime.Now;
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
        /// <param name="Status"></param>
        /// <returns></returns>
        public JsonRsp SetStatus(int Id, int status)
        {
            AdminMenu model = GetModelById(Id);
            model.Status = status;
            return Update(model);
        }
        #endregion

        #region 递归获取菜单列表

        public JsonRsp<TreeSelect> GetMenuTreeSelect(int roleId)
        {
            AdminRole role = new AdminRoleBLL().GetModelById(roleId);
            string menuIds = "0";
            if (roleId > 0)
            {
                menuIds="," + role.MenuIds + ",";
            }
            //int[] checkedArray = Array.ConvertAll(role.MenuIds.Split(','), int.Parse);

            JsonRsp<TreeSelect> rsp = new JsonRsp<TreeSelect>();
            AdminMenu model = new AdminMenu();
            OQL q = OQL.From(model)
                .Select()
                .OrderBy(model.ID, "asc")
                .END;
            List<AdminMenu> list = q.ToList<AdminMenu>();//使用OQL扩展
            List<TreeSelect> allList = list.ConvertAll<TreeSelect>(o =>
            {
                return new TreeSelect()
                {
                    id=o.ID,
                    value = o.ID,
                    ParentID=o.ParentID, 
                    name = o.MenuName,
                    isChecked = menuIds.IndexOf(","+o.ID+",")>-1,
                };
            }
            );
            rsp.data= getMenuNodes(0, 0, allList); 
            rsp.success = true;
            rsp.code = 0;
            return rsp;
        }

        /// <summary>
        /// 递归获取json tree
        /// </summary>
        /// <param name="parentId">菜单的父id</param>
        /// <param name="rootId">根节点id ,递归入口</param>
        /// <param name="allMenus">所有的菜单集合</param>
        /// <returns></returns>
        public List<TreeSelect> getMenuNodes(long parentId, long rootId, List<TreeSelect> allMenus)
        {
            List<TreeSelect> menus = new List<TreeSelect>();
            foreach (TreeSelect menu in allMenus)
            {
                if (rootId == (menu.ParentID == null ? 0 : menu.ParentID))
                {
                    List<TreeSelect> childrenMenu = getMenuNodes(parentId, menu.value, allMenus);
                    if (childrenMenu.Count() > 0)
                    {
                        menu.children = childrenMenu;
                    }
                    menus.Add(menu);
                }
            }

            return menus;
        }
        #endregion
    }
}
