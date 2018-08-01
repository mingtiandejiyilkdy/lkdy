INSERT INTO [Admin_Menu] VALUES (0, 'RoleManage', '权限管理', '#', 1, '1', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (1, 'AdminAccount', '用户管理', '/Admin/Account/', 1, '1,2', '用户管理', 0, 0, '2018-7-29 03:24:04', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (1, 'AdminRole', '角色管理', '/Admin/Role/', 1, '1,3', '角色管理', 2, 0, '2018-7-29 03:28:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (1, 'AdminMenu', '菜单管理', '/Admin/Menu/index', 1, '1,4', '操作管理', 4, 0, '2018-7-29 03:29:54', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (4, 'PageList', '查看列表(分页)', '/Admin/Menu/PageList', 2, '1,4,5', '菜单管理', 1, 0, '2018-7-29 03:30:21', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (0, 'SystemManage', '系统设置', '#', 1, '6', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (2, 'Add', '新增用户', '/Admin/Account/Add', 2, '1,2,7', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (2, 'Del', '删除用户', '/Admin/Account/Del', 2, '1,2,8', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (2, 'Edit', '修改用户', '/Admin/Account/Edit', 2, '1,2,9', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (2, 'Show', '查看用户', '/Admin/Account/Show', 2, '1,2,10', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (2, 'PageList', '查看列表(分页)', '/Admin/Account/PageList', 2, '1,2,11', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (3, 'Add', '新增角色', '/Admin/Role/Add', 2, '1,3,12', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (3, 'Del', '删除角色', '/Admin/Role/Del', 2, '1,3,13', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (3, 'Edit', '修改角色', '/Admin/Role/Edit', 2, '1,3,14', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (3, 'Show', '查看角色', '/Admin/Role/Show', 2, '1,3,15', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (3, 'PageList', '查看列表(分页)', '/Admin/Role/PageList', 2, '1,3,16', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (4, 'Add', '新增菜单', '/Admin/Menu/Add', 2, '1,4,17', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (4, 'Del', '删除菜单', '/Admin/Menu/Del', 2, '1,4,18', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (4, 'Edit', '修改菜单', '#/Admin/Menu/Edit', 2, '1,4,19', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (4, 'Show', '查看菜单', '/Admin/Menu/Show', 2, '4,1,4', '菜单', 0, 1, '2018-7-29 03:19:28', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (0, 'CinemaChainManage', '影院管理', '#', 1, '21', '院线管理', 1000, 0, '2018-7-30 00:09:22', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (21, 'CinemaChain', '院线管理', '/Admin/CinemaChain', 1, '21,21', '院线管理', 1, 0, '2018-7-30 00:10:12', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (21, 'Cinema', '影院列表', '/Admin/Cinema', 1, '21,21', '影院列表', 10, 0, '2018-7-30 03:04:01', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (0, 'Custom', '客户管理', '#', 1, '0', '客户管理', 1, 0, '2018-7-31 01:20:49', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (24, 'CustomType', '客户类型', '/Admin/CustomType', 1, '24,0', '客户类型管理', 1, 0, '2018-7-31 01:21:58', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (24, 'Custom', '客户列表', '/Admin/Custom/', 1, '24,0', '客户列表', 1, 0, '2018-7-31 01:25:01', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (0, 'Ticket', '凭据管理', '#', 1, NULL, '凭据管理', 1, 0, '2018-7-31 01:59:59', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (27, 'TicketType', '凭据类型', '/Admin/TicketType', 1, NULL, '凭据类型', 1, 0, '2018-7-31 02:00:52', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (27, 'Ticketing', '线下制卡', '/admin/Ticketing', 1, NULL, '线下制卡', 1, 0, '2018-7-31 02:01:56', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (27, 'TicketImport', '凭据导入', '/Admin/TicketImport', 1, NULL, '1', 1, 0, '2018-7-31 02:03:20', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (27, 'TicketBatch', '凭据批次', '/Admin/TicketBatch', 1, NULL, '1', 1, 0, '2018-7-31 02:04:16', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (27, 'Ticket', '凭据列表', '/Admin/TicketInfo/', 1, NULL, '凭据列表', 1, 0, '2018-7-31 02:05:12', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (0, 'Financial', '财务管理', '/Admin/Financial', 1, NULL, '财务管理', 99, 0, '2018-8-1 21:37:43', NULL);
GO
INSERT INTO [Admin_Menu] VALUES (33, 'Contract', '合同协议', '/Admin/Contract', 1, NULL, '合同协议', 1, 0, '2018-8-1 21:39:00', NULL);
GO
