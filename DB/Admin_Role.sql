/*
Navicat SQL Server Data Transfer

Source Server         : test
Source Server Version : 100000
Source Host           : .:1433
Source Database       : LocalDB
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 100000
File Encoding         : 65001

Date: 2018-08-05 14:48:57
*/


-- ----------------------------
-- Table structure for Admin_Role
-- ----------------------------
DROP TABLE [dbo].[Admin_Role]
GO
CREATE TABLE [dbo].[Admin_Role] (
[RoleId] bigint NOT NULL IDENTITY(1,1) ,
[RoleName] nvarchar(20) NULL ,
[Sort] int NULL DEFAULT ((0)) ,
[Status] int NULL ,
[CreateTIme] datetime NULL ,
[MenuIds] text NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Admin_Role]', RESEED, 5)
GO

-- ----------------------------
-- Records of Admin_Role
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Admin_Role] ON
GO
INSERT INTO [dbo].[Admin_Role] ([RoleId], [RoleName], [Sort], [Status], [CreateTIme], [MenuIds]) VALUES (N'1', N'超级管理员', N'0', N'1', N'2018-07-29 02:29:15.000', N'1,2,7,8,9,10,11,3,12,13,14,15,16,4,5,17,18,19,20,6,33,21,22,23,24,25,26,27,28,29,30,31,32')
GO
GO
INSERT INTO [dbo].[Admin_Role] ([RoleId], [RoleName], [Sort], [Status], [CreateTIme], [MenuIds]) VALUES (N'2', N'财务人员', N'0', N'0', N'2018-07-29 02:29:24.000', N'1,2,7,8,9,10,11,3,12,13,14,15,16,4,5,17,18,19,20')
GO
GO
INSERT INTO [dbo].[Admin_Role] ([RoleId], [RoleName], [Sort], [Status], [CreateTIme], [MenuIds]) VALUES (N'3', N'业务人员', N'0', N'1', N'2018-07-29 02:29:26.000', N'1,2,7,8,9,10,11,3,12,13,14,15,16,4,5,17,18,19,20')
GO
GO
INSERT INTO [dbo].[Admin_Role] ([RoleId], [RoleName], [Sort], [Status], [CreateTIme], [MenuIds]) VALUES (N'4', N'院线角色', N'0', N'0', N'2018-07-29 02:29:28.000', N'1,2,7,8,9,10,11,3,12,13,14,15,16,4,5,17,18,19,20')
GO
GO
INSERT INTO [dbo].[Admin_Role] ([RoleId], [RoleName], [Sort], [Status], [CreateTIme], [MenuIds]) VALUES (N'5', N'猫眼', N'0', N'0', N'2018-07-29 02:30:43.000', N'1,2,7,8')
GO
GO
SET IDENTITY_INSERT [dbo].[Admin_Role] OFF
GO

-- ----------------------------
-- Indexes structure for table Admin_Role
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Admin_Role
-- ----------------------------
ALTER TABLE [dbo].[Admin_Role] ADD PRIMARY KEY ([RoleId])
GO
