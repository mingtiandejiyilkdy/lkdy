INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (1, 0, 'RoleManage', '权限管理', '#', 1, '1', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (2, 1, 'AdminAccount', '用户管理', '/Admin/Account/', 1, '1,2', '用户管理', 0, 0, '2018-7-29 03:24:04', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (3, 1, 'AdminRole', '角色管理', '/Admin/Role/', 1, '1,3', '角色管理', 2, 0, '2018-7-29 03:28:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (4, 1, 'AdminMenu', '菜单管理', '/Admin/Menu/index', 1, '1,4', '操作管理', 4, 0, '2018-7-29 03:29:54', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (5, 4, 'PageList', '查看列表(分页)', '/Admin/Menu/PageList', 2, '1,4,5', '菜单管理', 1, 0, '2018-7-29 03:30:21', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (6, 0, 'SystemManage', '系统设置', '#', 2, '6', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (7, 2, 'Add', '新增用户', '/Admin/Account/Add', 2, '1,2,7', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (8, 2, 'Del', '删除用户', '/Admin/Account/Del', 2, '1,2,8', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (9, 2, 'Edit', '修改用户', '/Admin/Account/Edit', 2, '1,2,9', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (10, 2, 'Show', '查看用户', '/Admin/Account/Show', 2, '1,2,10', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (11, 2, 'PageList', '查看列表(分页)', '/Admin/Account/PageList', 2, '1,2,11', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (12, 3, 'Add', '新增角色', '/Admin/Role/Add', 2, '1,3,12', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (13, 3, 'Del', '删除角色', '/Admin/Role/Del', 2, '1,3,13', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (14, 3, 'Edit', '修改角色', '/Admin/Role/Edit', 2, '1,3,14', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (15, 3, 'Show', '查看角色', '/Admin/Role/Show', 2, '1,3,15', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (16, 3, 'PageList', '查看列表(分页)', '/Admin/Role/PageList', 2, '1,3,16', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (17, 4, 'Add', '新增菜单', '/Admin/Menu/Add', 2, '1,4,17', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (18, 4, 'Del', '删除菜单', '/Admin/Menu/Del', 2, '1,4,18', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (19, 4, 'Edit', '修改菜单', '#/Admin/Menu/Edit', 2, '1,4,19', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (20, 4, 'Show', '查看菜单', '/Admin/Menu/Show', 2, '1,4,20', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (21, 0, 'CinemaChainManage', '影院管理', '#', 1, '21', '院线管理', 1000, 0, '2018-7-30 00:09:22', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (22, 21, 'CinemaChain', '院线管理', '/Admin/CinemaChain', 1, '21,22', '院线管理', 1, 0, '2018-7-30 00:10:12', NULL);
GO
INSERT INTO [Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateTime], [UpdateTime]) VALUES (23, 21, 'Cinema', '影院列表', '/Admin/Cinema', 1, '21,23', '影院列表', 1, 0, '2018-7-30 03:04:01', NULL);
GO
