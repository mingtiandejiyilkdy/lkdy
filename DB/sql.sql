/*
Navicat SQL Server Data Transfer

Source Server         : test
Source Server Version : 100000
Source Host           : .:1433
Source Database       : PDB
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 100000
File Encoding         : 65001

Date: 2018-08-08 02:31:59
*/


-- ----------------------------
-- Table structure for P_Admin_Account
-- ----------------------------
DROP TABLE [dbo].[P_Admin_Account]
GO
CREATE TABLE [dbo].[P_Admin_Account] (
[AccountId] bigint NOT NULL IDENTITY(1,1) ,
[AccountName] nvarchar(20) NULL ,
[AccountPwd] nvarchar(50) NULL ,
[Salt] nvarchar(50) NULL ,
[TrueName] nvarchar(20) NULL ,
[Mobile] nvarchar(11) NULL ,
[Email] nvarchar(50) NULL ,
[AccountStatus] int NULL ,
[LoginTime] datetime NULL ,
[LastLoginTime] datetime NULL ,
[LoginCount] int NULL ,
[CreateTIme] datetime NULL ,
[TenantId] bigint NULL 
)


GO

-- ----------------------------
-- Records of P_Admin_Account
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_Admin_Account] ON
GO
INSERT INTO [dbo].[P_Admin_Account] ([AccountId], [AccountName], [AccountPwd], [Salt], [TrueName], [Mobile], [Email], [AccountStatus], [LoginTime], [LastLoginTime], [LoginCount], [CreateTIme], [TenantId]) VALUES (N'1', N'admin', N'ad8293650d57f265ebb2fce8b5911d15', N'27db0cbc-ebf9-4066-aee0-c0d427bcd612', N'超管', null, null, N'0', N'2018-07-28 00:59:07.000', N'2018-07-28 00:59:07.000', N'0', N'2018-07-28 00:59:07.000', null)
GO
GO
SET IDENTITY_INSERT [dbo].[P_Admin_Account] OFF
GO

-- ----------------------------
-- Table structure for P_Admin_Account_Role
-- ----------------------------
DROP TABLE [dbo].[P_Admin_Account_Role]
GO
CREATE TABLE [dbo].[P_Admin_Account_Role] (
[AccountRoleId] bigint NOT NULL IDENTITY(1,1) ,
[AccountID] bigint NULL ,
[RoleID] bigint NULL ,
[TenantId] bigint NULL 
)


GO

-- ----------------------------
-- Records of P_Admin_Account_Role
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_Admin_Account_Role] ON
GO
INSERT INTO [dbo].[P_Admin_Account_Role] ([AccountRoleId], [AccountID], [RoleID], [TenantId]) VALUES (N'1', N'1', N'1', null)
GO
GO
SET IDENTITY_INSERT [dbo].[P_Admin_Account_Role] OFF
GO

-- ----------------------------
-- Table structure for P_Admin_Menu
-- ----------------------------
DROP TABLE [dbo].[P_Admin_Menu]
GO
CREATE TABLE [dbo].[P_Admin_Menu] (
[MenuId] bigint NOT NULL IDENTITY(1,1) ,
[ParentID] bigint NULL ,
[MenuKey] nvarchar(50) NULL ,
[MenuName] nvarchar(20) NULL ,
[MenuUrl] nvarchar(100) NULL ,
[MenuType] int NULL ,
[IDPath] nvarchar(500) NULL ,
[Remark] nvarchar(200) NULL ,
[Sort] int NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] nvarchar(1) NULL ,
[TenantId] bigint NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[P_Admin_Menu]', RESEED, 11)
GO

-- ----------------------------
-- Records of P_Admin_Menu
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_Admin_Menu] ON
GO
INSERT INTO [dbo].[P_Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'1', N'0', N'Menu', N'系统设置', N'#', N'1', N'1', N'系统设置', N'1', N'1', N'1', N'1', null, N'2018-08-08 00:45:27.000', null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[P_Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'2', N'1', N'AdminMenu', N'菜单管理', N'/Admin/Menu/index', N'1', N'1', N'菜单管理', N'1', N'1', N'1', N'1', null, N'2018-08-08 00:45:29.000', null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[P_Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'3', N'1', N'AdminAccount', N'用户管理', N'/Admin/Account/', N'1', null, N'用户管理', N'1', N'1', null, null, null, N'2018-08-08 00:47:23.437', null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[P_Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'4', N'1', N'AdminRole', N'角色管理', N'/Admin/Role/', N'1', null, N'角色管理', N'1', N'1', null, null, null, N'2018-08-08 00:48:00.563', null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[P_Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'5', N'0', N'Custom', N'客户管理', N'#', N'1', null, N'客户管理', N'1', N'1', null, null, null, N'2018-08-08 00:52:51.797', null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[P_Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'6', N'5', N'CustomList', N'客户列表', N'/Admin/Custom/', N'1', null, N'客户列表', N'1', null, null, null, null, N'2018-08-08 00:55:24.313', null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[P_Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'7', N'1', N'CustomType', N'客户类型', N'/Admin/CustomType', N'1', null, N'客户类型', N'1', null, null, null, null, N'2018-08-08 00:55:56.923', null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[P_Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'8', N'0', N'Tenant', N'租户管理', N'#', N'1', null, N'租户管理', N'1', null, null, null, null, N'2018-08-08 02:04:30.770', null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[P_Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'9', N'8', N'TenantList', N'租户列表', N'/Admin/Tenant', N'1', null, N'租户列表', N'1', null, null, null, null, N'2018-08-08 02:04:56.297', null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[P_Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'10', N'0', N'merchant', N'商户管理', N'#', N'1', null, N'商户管理', N'1', null, null, null, null, N'2018-08-08 02:21:38.937', null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[P_Admin_Menu] ([MenuId], [ParentID], [MenuKey], [MenuName], [MenuUrl], [MenuType], [IDPath], [Remark], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'11', N'10', N'merchantList', N'商户列表', N'/Admin/Merchant', N'1', null, N'商户列表', N'1', null, null, null, null, N'2018-08-08 02:22:08.300', null, null, null, null, null)
GO
GO
SET IDENTITY_INSERT [dbo].[P_Admin_Menu] OFF
GO

-- ----------------------------
-- Table structure for P_Admin_Role
-- ----------------------------
DROP TABLE [dbo].[P_Admin_Role]
GO
CREATE TABLE [dbo].[P_Admin_Role] (
[RoleId] bigint NOT NULL IDENTITY(1,1) ,
[RoleName] nvarchar(20) NULL ,
[MenuIds] varchar(MAX) NULL ,
[Sort] int NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] nvarchar(1) NULL ,
[TenantId] bigint NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[P_Admin_Role]', RESEED, 3)
GO

-- ----------------------------
-- Records of P_Admin_Role
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_Admin_Role] ON
GO
INSERT INTO [dbo].[P_Admin_Role] ([RoleId], [RoleName], [MenuIds], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'1', N'超级管理员', N'1,2,3,4', null, null, null, null, null, N'2018-08-08 00:49:33.983', null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[P_Admin_Role] ([RoleId], [RoleName], [MenuIds], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'2', N'中聚福', N'1,2,3,4', null, null, null, null, null, N'2018-08-08 00:49:44.500', null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[P_Admin_Role] ([RoleId], [RoleName], [MenuIds], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'3', N'乐看电影网', N'1,2,3,4', null, null, null, null, null, N'2018-08-08 00:49:55.630', null, null, null, null, null)
GO
GO
SET IDENTITY_INSERT [dbo].[P_Admin_Role] OFF
GO

-- ----------------------------
-- Table structure for P_Bank
-- ----------------------------
DROP TABLE [dbo].[P_Bank]
GO
CREATE TABLE [dbo].[P_Bank] (
[BankId] bigint NOT NULL IDENTITY(1,1) ,
[BankName] nvarchar(50) NULL ,
[BankType] int NULL ,
[Sort] int NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] nvarchar(1) NULL ,
[TenantId] bigint NULL 
)


GO

-- ----------------------------
-- Records of P_Bank
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_Bank] ON
GO
SET IDENTITY_INSERT [dbo].[P_Bank] OFF
GO

-- ----------------------------
-- Table structure for P_BankAccount
-- ----------------------------
DROP TABLE [dbo].[P_BankAccount]
GO
CREATE TABLE [dbo].[P_BankAccount] (
[BankAccountId] bigint NOT NULL IDENTITY(1,1) ,
[BankAccountName] nvarchar(50) NULL ,
[BankId] bigint NULL ,
[BankAccountCode] nvarchar(50) NULL ,
[Sort] int NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] nvarchar(1) NULL ,
[TenantId] bigint NULL 
)


GO

-- ----------------------------
-- Records of P_BankAccount
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_BankAccount] ON
GO
SET IDENTITY_INSERT [dbo].[P_BankAccount] OFF
GO

-- ----------------------------
-- Table structure for P_Cinema
-- ----------------------------
DROP TABLE [dbo].[P_Cinema]
GO
CREATE TABLE [dbo].[P_Cinema] (
[CinemaId] bigint NOT NULL IDENTITY(1,1) ,
[CinemaChainId] bigint NULL ,
[CinemaName] nvarchar(50) NULL ,
[LinkName] nvarchar(50) NULL ,
[LinkPhone] nvarchar(20) NULL ,
[LinkMobile] nvarchar(15) NULL ,
[CinemaArea] nvarchar(15) NULL ,
[CinemaAddress] nvarchar(15) NULL ,
[Sort] int NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] nvarchar(1) NULL ,
[TenantId] bigint NULL 
)


GO

-- ----------------------------
-- Records of P_Cinema
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_Cinema] ON
GO
SET IDENTITY_INSERT [dbo].[P_Cinema] OFF
GO

-- ----------------------------
-- Table structure for P_Cinema_Chain
-- ----------------------------
DROP TABLE [dbo].[P_Cinema_Chain]
GO
CREATE TABLE [dbo].[P_Cinema_Chain] (
[CinemaChainId] bigint NOT NULL IDENTITY(1,1) ,
[CinemaChainName] nvarchar(50) NULL ,
[Sort] int NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] nvarchar(1) NULL ,
[TenantId] bigint NULL 
)


GO

-- ----------------------------
-- Records of P_Cinema_Chain
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_Cinema_Chain] ON
GO
SET IDENTITY_INSERT [dbo].[P_Cinema_Chain] OFF
GO

-- ----------------------------
-- Table structure for P_Contract
-- ----------------------------
DROP TABLE [dbo].[P_Contract]
GO
CREATE TABLE [dbo].[P_Contract] (
[ContractId] bigint NOT NULL IDENTITY(1,1) ,
[CustomId] bigint NULL ,
[ContractNo] varchar(MAX) NULL ,
[AccountReceivable] decimal(30,8) NULL ,
[LargessAmount] decimal(30,8) NULL ,
[ExChangeAmount] decimal(30,8) NULL ,
[ContractAmount] decimal(30,8) NULL ,
[Deductions] decimal(30,8) NULL ,
[Balance] decimal(30,8) NULL ,
[BalanceKey] nvarchar(200) NULL ,
[Attachment] nvarchar(200) NULL ,
[Deadline] datetime NULL ,
[Remark] varchar(MAX) NULL ,
[Sort] int NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] nvarchar(1) NULL ,
[TenantId] bigint NULL 
)


GO

-- ----------------------------
-- Records of P_Contract
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_Contract] ON
GO
SET IDENTITY_INSERT [dbo].[P_Contract] OFF
GO

-- ----------------------------
-- Table structure for P_Custom
-- ----------------------------
DROP TABLE [dbo].[P_Custom]
GO
CREATE TABLE [dbo].[P_Custom] (
[CustomId] bigint NOT NULL IDENTITY(1,1) ,
[CustomTypeId] bigint NULL ,
[CustomName] nvarchar(50) NULL ,
[LinkName] nvarchar(50) NULL ,
[LinkPhone] nvarchar(20) NULL ,
[LinkMobile] nvarchar(15) NULL ,
[CustomArea] nvarchar(15) NULL ,
[CustomAddress] nvarchar(15) NULL ,
[Sort] int NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] datetime NULL ,
[TenantId] bigint NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[P_Custom]', RESEED, 2)
GO

-- ----------------------------
-- Records of P_Custom
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_Custom] ON
GO
INSERT INTO [dbo].[P_Custom] ([CustomId], [CustomTypeId], [CustomName], [LinkName], [LinkPhone], [LinkMobile], [CustomArea], [CustomAddress], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'1', N'1', N'最惠票务', N'白俊锋', N'0371-55555555', N'15838260190', N'河南省郑州市中原区', N'河南省郑州市中原区帝湖花园', N'0', N'1', N'1', N'admin', N'192.168.0.105', N'2018-08-08 01:23:28.423', N'1', N'admin', N'192.168.0.105', N'1900-01-01 00:00:00.000', N'1')
GO
GO
SET IDENTITY_INSERT [dbo].[P_Custom] OFF
GO

-- ----------------------------
-- Table structure for P_Custom_Acc_Receipt
-- ----------------------------
DROP TABLE [dbo].[P_Custom_Acc_Receipt]
GO
CREATE TABLE [dbo].[P_Custom_Acc_Receipt] (
[CustomAccReceiptId] bigint NOT NULL IDENTITY(1,1) ,
[ChargeCardNo] nvarchar(50) NULL ,
[CustomId] bigint NULL ,
[ARAmount] decimal(30,8) NULL ,
[Remark] varchar(MAX) NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] nvarchar(1) NULL ,
[TenantId] bigint NULL 
)


GO

-- ----------------------------
-- Records of P_Custom_Acc_Receipt
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_Custom_Acc_Receipt] ON
GO
SET IDENTITY_INSERT [dbo].[P_Custom_Acc_Receipt] OFF
GO

-- ----------------------------
-- Table structure for P_Custom_Acc_ReceiptEntry
-- ----------------------------
DROP TABLE [dbo].[P_Custom_Acc_ReceiptEntry]
GO
CREATE TABLE [dbo].[P_Custom_Acc_ReceiptEntry] (
[CustomAccReceiptEntryId] bigint NOT NULL IDENTITY(1,1) ,
[CustomAccReceiptId] bigint NULL ,
[BankAccountId] bigint NULL ,
[CurrentAmount] decimal(30,8) NULL ,
[BankSerialNumber] varchar(MAX) NULL ,
[DateOfEntry] datetime NULL ,
[Remark] varchar(MAX) NULL ,
[Sort] int NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] nvarchar(1) NULL ,
[TenantId] bigint NULL 
)


GO

-- ----------------------------
-- Records of P_Custom_Acc_ReceiptEntry
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_Custom_Acc_ReceiptEntry] ON
GO
SET IDENTITY_INSERT [dbo].[P_Custom_Acc_ReceiptEntry] OFF
GO

-- ----------------------------
-- Table structure for P_Custom_ChargeCards
-- ----------------------------
DROP TABLE [dbo].[P_Custom_ChargeCards]
GO
CREATE TABLE [dbo].[P_Custom_ChargeCards] (
[ChargeCardId] bigint NOT NULL IDENTITY(1,1) ,
[ChargeCardNo] nvarchar(50) NULL ,
[CustomId] bigint NULL ,
[TicketTypeID] bigint NULL ,
[MoneyType] bigint NULL ,
[CurrentCount] decimal(30,8) NULL ,
[FaceAmount] decimal(30,8) NULL ,
[CurrentAmount] decimal(30,8) NULL ,
[ExpireDate] datetime NULL ,
[TicketBatchId] bigint NULL ,
[TicketStart] bigint NULL ,
[TicketEnd] bigint NULL ,
[Consumptionlevel] int NULL ,
[IsCommonCard] int NULL ,
[Sort] int NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] nvarchar(1) NULL ,
[TenantId] bigint NULL 
)


GO

-- ----------------------------
-- Records of P_Custom_ChargeCards
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_Custom_ChargeCards] ON
GO
SET IDENTITY_INSERT [dbo].[P_Custom_ChargeCards] OFF
GO

-- ----------------------------
-- Table structure for P_Custom_FinancialDetail
-- ----------------------------
DROP TABLE [dbo].[P_Custom_FinancialDetail]
GO
CREATE TABLE [dbo].[P_Custom_FinancialDetail] (
[FinancialDetailId] bigint NOT NULL IDENTITY(1,1) ,
[FinancialId] bigint NULL ,
[MoneyType] int NULL ,
[FinanciaOpeType] int NULL ,
[Amount] decimal(30,8) NULL ,
[Balance] decimal(30,8) NULL ,
[Remark] varchar(MAX) NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[TenantId] bigint NULL 
)


GO

-- ----------------------------
-- Records of P_Custom_FinancialDetail
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_Custom_FinancialDetail] ON
GO
SET IDENTITY_INSERT [dbo].[P_Custom_FinancialDetail] OFF
GO

-- ----------------------------
-- Table structure for P_CustomFinancial
-- ----------------------------
DROP TABLE [dbo].[P_CustomFinancial]
GO
CREATE TABLE [dbo].[P_CustomFinancial] (
[CustomFinancialId] bigint NOT NULL IDENTITY(1,1) ,
[CustomId] bigint NULL ,
[ARAmount] decimal(30,8) NULL ,
[ARBalance] decimal(30,8) NULL ,
[LargessAmount] decimal(30,8) NULL ,
[LargessBalance] decimal(30,8) NULL ,
[ExChangeAmount] decimal(30,8) NULL ,
[ExChangeBalance] decimal(30,8) NULL ,
[Remark] varchar(MAX) NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] nvarchar(1) NULL ,
[TenantId] bigint NULL 
)


GO

-- ----------------------------
-- Records of P_CustomFinancial
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_CustomFinancial] ON
GO
SET IDENTITY_INSERT [dbo].[P_CustomFinancial] OFF
GO

-- ----------------------------
-- Table structure for P_CustomType
-- ----------------------------
DROP TABLE [dbo].[P_CustomType]
GO
CREATE TABLE [dbo].[P_CustomType] (
[CustomTypeId] bigint NOT NULL IDENTITY(1,1) ,
[CustomTypeName] nvarchar(50) NULL ,
[Sort] int NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] datetime NULL ,
[TenantId] bigint NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[P_CustomType]', RESEED, 4)
GO

-- ----------------------------
-- Records of P_CustomType
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_CustomType] ON
GO
INSERT INTO [dbo].[P_CustomType] ([CustomTypeId], [CustomTypeName], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'1', N'企业', N'0', N'1', N'1', N'admin', N'192.168.0.105', N'2018-08-08 00:56:37.000', null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[P_CustomType] ([CustomTypeId], [CustomTypeName], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'2', N'单位', N'0', N'1', N'1', N'admin', N'192.168.0.105', N'2018-08-08 00:56:45.203', null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[P_CustomType] ([CustomTypeId], [CustomTypeName], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'3', N'个人', N'0', N'1', N'1', N'admin', N'192.168.0.105', N'2018-08-08 00:56:49.203', null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[P_CustomType] ([CustomTypeId], [CustomTypeName], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime], [TenantId]) VALUES (N'4', N'代理人', N'0', N'1', N'1', N'admin', N'192.168.0.105', N'2018-08-08 00:56:57.577', N'1', N'admin', N'192.168.0.105', N'2018-08-08 01:16:21.170', null)
GO
GO
SET IDENTITY_INSERT [dbo].[P_CustomType] OFF
GO

-- ----------------------------
-- Table structure for P_Tenant
-- ----------------------------
DROP TABLE [dbo].[P_Tenant]
GO
CREATE TABLE [dbo].[P_Tenant] (
[TenantId] bigint NOT NULL IDENTITY(1,1) ,
[TenantName] nvarchar(50) NULL ,
[TenantDomain] nvarchar(50) NULL ,
[Sort] int NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] nvarchar(1) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[P_Tenant]', RESEED, 2)
GO

-- ----------------------------
-- Records of P_Tenant
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_Tenant] ON
GO
INSERT INTO [dbo].[P_Tenant] ([TenantId], [TenantName], [TenantDomain], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime]) VALUES (N'1', N'中聚福福利网', N'localhost', N'0', null, null, N'admin', N'192.168.0.105', N'2018-08-08 02:05:26.687', null, null, null, null)
GO
GO
INSERT INTO [dbo].[P_Tenant] ([TenantId], [TenantName], [TenantDomain], [Sort], [Status], [CreateId], [CreateUser], [CreateIP], [CreateTime], [UpdateId], [UpdateUser], [UpdateIP], [UpdateTime]) VALUES (N'2', N'乐看电影网', N'www.lekan.com', N'0', null, null, N'admin', N'192.168.0.105', N'2018-08-08 02:05:43.140', null, null, null, null)
GO
GO
SET IDENTITY_INSERT [dbo].[P_Tenant] OFF
GO

-- ----------------------------
-- Table structure for P_Ticket_Info
-- ----------------------------
DROP TABLE [dbo].[P_Ticket_Info]
GO
CREATE TABLE [dbo].[P_Ticket_Info] (
[TicketId] bigint NOT NULL IDENTITY(1,1) ,
[TicketTypeId] bigint NULL ,
[TicketCode] nvarchar(50) NULL ,
[TicketPwd] nvarchar(50) NULL ,
[TicketMD5Pwd] nvarchar(50) NULL ,
[Salt] nvarchar(50) NULL ,
[Consumptionlevel] int NULL ,
[MoneyTyp] int NULL ,
[CustomID] bigint NULL ,
[InitialAmount] decimal(30,8) NULL ,
[Deductions] decimal(30,8) NULL ,
[Balance] decimal(30,8) NULL ,
[IsExpire] bit NULL ,
[IsActivated] bit NULL ,
[MakeTime] datetime NULL ,
[ExpireDate] datetime NULL ,
[TicketBatchNo] nvarchar(50) NULL ,
[GrantBy] bigint NULL ,
[GrantTime] datetime NULL ,
[Sort] int NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] nvarchar(1) NULL ,
[TenantId] bigint NULL 
)


GO

-- ----------------------------
-- Records of P_Ticket_Info
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_Ticket_Info] ON
GO
SET IDENTITY_INSERT [dbo].[P_Ticket_Info] OFF
GO

-- ----------------------------
-- Table structure for P_TicketBatch
-- ----------------------------
DROP TABLE [dbo].[P_TicketBatch]
GO
CREATE TABLE [dbo].[P_TicketBatch] (
[TicketBatchId] bigint NOT NULL IDENTITY(1,1) ,
[TicketTypeId] bigint NULL ,
[TicketBatchName] nvarchar(50) NULL ,
[TicketBatchNo] nvarchar(50) NULL ,
[TicketPrefix] nvarchar(50) NULL ,
[Amount] bigint NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] nvarchar(1) NULL ,
[TenantId] bigint NULL 
)


GO

-- ----------------------------
-- Records of P_TicketBatch
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_TicketBatch] ON
GO
SET IDENTITY_INSERT [dbo].[P_TicketBatch] OFF
GO

-- ----------------------------
-- Table structure for P_TicketType
-- ----------------------------
DROP TABLE [dbo].[P_TicketType]
GO
CREATE TABLE [dbo].[P_TicketType] (
[TicketTypeId] bigint NOT NULL IDENTITY(1,1) ,
[TicketTypeName] nvarchar(50) NULL ,
[Sort] int NULL ,
[Status] int NULL ,
[CreateId] bigint NULL ,
[CreateUser] varchar(MAX) NULL ,
[CreateIP] nvarchar(20) NULL ,
[CreateTime] datetime NULL ,
[UpdateId] bigint NULL ,
[UpdateUser] varchar(MAX) NULL ,
[UpdateIP] nvarchar(20) NULL ,
[UpdateTime] nvarchar(1) NULL ,
[TenantId] bigint NULL 
)


GO

-- ----------------------------
-- Records of P_TicketType
-- ----------------------------
SET IDENTITY_INSERT [dbo].[P_TicketType] ON
GO
SET IDENTITY_INSERT [dbo].[P_TicketType] OFF
GO

-- ----------------------------
-- Indexes structure for table P_Admin_Account
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_Admin_Account
-- ----------------------------
ALTER TABLE [dbo].[P_Admin_Account] ADD PRIMARY KEY ([AccountId])
GO

-- ----------------------------
-- Indexes structure for table P_Admin_Account_Role
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_Admin_Account_Role
-- ----------------------------
ALTER TABLE [dbo].[P_Admin_Account_Role] ADD PRIMARY KEY ([AccountRoleId])
GO

-- ----------------------------
-- Indexes structure for table P_Admin_Menu
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_Admin_Menu
-- ----------------------------
ALTER TABLE [dbo].[P_Admin_Menu] ADD PRIMARY KEY ([MenuId])
GO

-- ----------------------------
-- Indexes structure for table P_Admin_Role
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_Admin_Role
-- ----------------------------
ALTER TABLE [dbo].[P_Admin_Role] ADD PRIMARY KEY ([RoleId])
GO

-- ----------------------------
-- Indexes structure for table P_Bank
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_Bank
-- ----------------------------
ALTER TABLE [dbo].[P_Bank] ADD PRIMARY KEY ([BankId])
GO

-- ----------------------------
-- Indexes structure for table P_BankAccount
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_BankAccount
-- ----------------------------
ALTER TABLE [dbo].[P_BankAccount] ADD PRIMARY KEY ([BankAccountId])
GO

-- ----------------------------
-- Indexes structure for table P_Cinema
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_Cinema
-- ----------------------------
ALTER TABLE [dbo].[P_Cinema] ADD PRIMARY KEY ([CinemaId])
GO

-- ----------------------------
-- Indexes structure for table P_Cinema_Chain
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_Cinema_Chain
-- ----------------------------
ALTER TABLE [dbo].[P_Cinema_Chain] ADD PRIMARY KEY ([CinemaChainId])
GO

-- ----------------------------
-- Indexes structure for table P_Contract
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_Contract
-- ----------------------------
ALTER TABLE [dbo].[P_Contract] ADD PRIMARY KEY ([ContractId])
GO

-- ----------------------------
-- Indexes structure for table P_Custom
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_Custom
-- ----------------------------
ALTER TABLE [dbo].[P_Custom] ADD PRIMARY KEY ([CustomId])
GO

-- ----------------------------
-- Indexes structure for table P_Custom_Acc_Receipt
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_Custom_Acc_Receipt
-- ----------------------------
ALTER TABLE [dbo].[P_Custom_Acc_Receipt] ADD PRIMARY KEY ([CustomAccReceiptId])
GO

-- ----------------------------
-- Indexes structure for table P_Custom_Acc_ReceiptEntry
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_Custom_Acc_ReceiptEntry
-- ----------------------------
ALTER TABLE [dbo].[P_Custom_Acc_ReceiptEntry] ADD PRIMARY KEY ([CustomAccReceiptEntryId])
GO

-- ----------------------------
-- Indexes structure for table P_Custom_ChargeCards
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_Custom_ChargeCards
-- ----------------------------
ALTER TABLE [dbo].[P_Custom_ChargeCards] ADD PRIMARY KEY ([ChargeCardId])
GO

-- ----------------------------
-- Indexes structure for table P_Custom_FinancialDetail
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_Custom_FinancialDetail
-- ----------------------------
ALTER TABLE [dbo].[P_Custom_FinancialDetail] ADD PRIMARY KEY ([FinancialDetailId])
GO

-- ----------------------------
-- Indexes structure for table P_CustomFinancial
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_CustomFinancial
-- ----------------------------
ALTER TABLE [dbo].[P_CustomFinancial] ADD PRIMARY KEY ([CustomFinancialId])
GO

-- ----------------------------
-- Indexes structure for table P_CustomType
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_CustomType
-- ----------------------------
ALTER TABLE [dbo].[P_CustomType] ADD PRIMARY KEY ([CustomTypeId])
GO

-- ----------------------------
-- Indexes structure for table P_Tenant
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_Tenant
-- ----------------------------
ALTER TABLE [dbo].[P_Tenant] ADD PRIMARY KEY ([TenantId])
GO

-- ----------------------------
-- Indexes structure for table P_Ticket_Info
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_Ticket_Info
-- ----------------------------
ALTER TABLE [dbo].[P_Ticket_Info] ADD PRIMARY KEY ([TicketId])
GO

-- ----------------------------
-- Indexes structure for table P_TicketBatch
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_TicketBatch
-- ----------------------------
ALTER TABLE [dbo].[P_TicketBatch] ADD PRIMARY KEY ([TicketBatchId])
GO

-- ----------------------------
-- Indexes structure for table P_TicketType
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table P_TicketType
-- ----------------------------
ALTER TABLE [dbo].[P_TicketType] ADD PRIMARY KEY ([TicketTypeId])
GO
