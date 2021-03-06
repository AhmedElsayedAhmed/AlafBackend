/****** Object:  Table [dbo].[FormMasters]    Script Date: 4/3/2019 4:18:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormMasters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_FormMasters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[PageActions]    Script Date: 4/3/2019 4:18:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PageActions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_PageActions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Pages]    Script Date: 4/3/2019 4:18:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Module] [nvarchar](max) NULL,
	[UrlPath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Pages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[RoleDefaultPrivileges]    Script Date: 4/3/2019 4:18:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleDefaultPrivileges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[SysPageId] [int] NOT NULL,
	[PageActionCombination] [nvarchar](max) NULL,
	[SysRoleId] [int] NULL,
 CONSTRAINT [PK_RoleDefaultPrivileges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 4/3/2019 4:18:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenantId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[UserPrivileges]    Script Date: 4/3/2019 4:18:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPrivileges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[SysPageId] [int] NOT NULL,
	[PageActionCombination] [nvarchar](max) NULL,
	[SysUserId] [int] NULL,
 CONSTRAINT [PK_UserPrivileges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 4/3/2019 4:18:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[SysRoleId] [int] NULL,
	[SysUserId] [int] NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/3/2019 4:18:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenantId] [int] NOT NULL,
	[Username] [nvarchar](max) NULL,
	[HashedPassword] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [TenantId], [Username], [HashedPassword], [Email]) VALUES (1, 0, N'The Two', N'123456', N'asd@asd.com')
INSERT [dbo].[Users] ([Id], [TenantId], [Username], [HashedPassword], [Email]) VALUES (2, 0, N'Mohamed Arabi', N'e10adc3949ba59abbe56e057f20f883e', N'marabi@asd.com')
INSERT [dbo].[Users] ([Id], [TenantId], [Username], [HashedPassword], [Email]) VALUES (3, 0, N'MohamedArabiSaleh', N'e10adc3949ba59abbe56e057f20f883e', N'marabis@asd.com')
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Index [IX_RoleDefaultPrivileges_SysPageId]    Script Date: 4/3/2019 4:18:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleDefaultPrivileges_SysPageId] ON [dbo].[RoleDefaultPrivileges]
(
	[SysPageId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Index [IX_RoleDefaultPrivileges_SysRoleId]    Script Date: 4/3/2019 4:18:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleDefaultPrivileges_SysRoleId] ON [dbo].[RoleDefaultPrivileges]
(
	[SysRoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Index [IX_UserPrivileges_SysPageId]    Script Date: 4/3/2019 4:18:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserPrivileges_SysPageId] ON [dbo].[UserPrivileges]
(
	[SysPageId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Index [IX_UserPrivileges_SysUserId]    Script Date: 4/3/2019 4:18:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserPrivileges_SysUserId] ON [dbo].[UserPrivileges]
(
	[SysUserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Index [IX_UserRoles_SysRoleId]    Script Date: 4/3/2019 4:18:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_SysRoleId] ON [dbo].[UserRoles]
(
	[SysRoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Index [IX_UserRoles_SysUserId]    Script Date: 4/3/2019 4:18:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_SysUserId] ON [dbo].[UserRoles]
(
	[SysUserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
ALTER TABLE [dbo].[RoleDefaultPrivileges]  WITH CHECK ADD  CONSTRAINT [FK_RoleDefaultPrivileges_Pages_SysPageId] FOREIGN KEY([SysPageId])
REFERENCES [dbo].[Pages] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleDefaultPrivileges] CHECK CONSTRAINT [FK_RoleDefaultPrivileges_Pages_SysPageId]
GO
ALTER TABLE [dbo].[RoleDefaultPrivileges]  WITH CHECK ADD  CONSTRAINT [FK_RoleDefaultPrivileges_Roles_SysRoleId] FOREIGN KEY([SysRoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[RoleDefaultPrivileges] CHECK CONSTRAINT [FK_RoleDefaultPrivileges_Roles_SysRoleId]
GO
ALTER TABLE [dbo].[UserPrivileges]  WITH CHECK ADD  CONSTRAINT [FK_UserPrivileges_Pages_SysPageId] FOREIGN KEY([SysPageId])
REFERENCES [dbo].[Pages] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserPrivileges] CHECK CONSTRAINT [FK_UserPrivileges_Pages_SysPageId]
GO
ALTER TABLE [dbo].[UserPrivileges]  WITH CHECK ADD  CONSTRAINT [FK_UserPrivileges_Users_SysUserId] FOREIGN KEY([SysUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserPrivileges] CHECK CONSTRAINT [FK_UserPrivileges_Users_SysUserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_SysRoleId] FOREIGN KEY([SysRoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_SysRoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_SysUserId] FOREIGN KEY([SysUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_SysUserId]
GO
