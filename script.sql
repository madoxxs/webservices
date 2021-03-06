USE [DiplomnaRabota]
GO
/****** Object:  User [user]    Script Date: 13.5.2017 г. 10:44:24 ч. ******/
CREATE USER [user] FOR LOGIN [user] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [user]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [user]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [user]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [user]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [user]
GO
ALTER ROLE [db_datareader] ADD MEMBER [user]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [user]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [user]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [user]
GO
/****** Object:  Table [dbo].[Auto]    Script Date: 13.5.2017 г. 10:44:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auto](
	[Id] [uniqueidentifier] NOT NULL,
	[OwnerFullName] [nvarchar](50) NOT NULL,
	[OwnerAddress] [nvarchar](50) NOT NULL,
	[OwnerPhone] [nvarchar](20) NOT NULL,
	[MPSModel] [nvarchar](50) NOT NULL,
	[MPSNumber] [nvarchar](50) NOT NULL,
	[TrailerNumber] [nvarchar](50) NULL,
	[InsurerCompany] [nvarchar](50) NOT NULL,
	[InsurerPolicyNumber] [nvarchar](50) NOT NULL,
	[InsurerGreenCardNumber] [nvarchar](50) NOT NULL,
	[ValidFrom] [date] NOT NULL,
	[ValidTo] [date] NOT NULL,
	[InsurerAgency] [nvarchar](20) NOT NULL,
	[InsurerAddress] [nvarchar](50) NOT NULL,
	[InsurerPhone] [nvarchar](50) NOT NULL,
	[LeaderFullName] [nvarchar](50) NOT NULL,
	[LeaderBornDate] [date] NOT NULL,
	[LeaderAddress] [nvarchar](50) NOT NULL,
	[LeaderPhone] [nvarchar](50) NOT NULL,
	[LeaderCertificate] [int] NOT NULL,
	[LeaderCategory] [nvarchar](10) NOT NULL,
	[LeaderCertificateValidTo] [date] NOT NULL,
	[PolicyNumber] [int] NOT NULL,
	[VisibleDamage] [nvarchar](200) NOT NULL,
	[AttachFile] [nvarchar](50) NOT NULL,
	[Circumstances] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[IsGuilty] [bit] NOT NULL,
 CONSTRAINT [PK_Auto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Circumstances]    Script Date: 13.5.2017 г. 10:44:25 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Circumstances](
	[Id] [int] NOT NULL,
	[Text] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Circumstances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estate]    Script Date: 13.5.2017 г. 10:44:25 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estate](
	[Id] [uniqueidentifier] NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[EGN] [nvarchar](20) NOT NULL,
	[MobilePhone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[ModifiedAt] [datetime] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[AttachFile] [nvarchar](50) NOT NULL,
	[Company] [nvarchar](20) NOT NULL,
	[Area] [int] NOT NULL,
	[InsuranceAmount] [float] NOT NULL,
	[Kind] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Estate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Health]    Script Date: 13.5.2017 г. 10:44:25 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Health](
	[Id] [uniqueidentifier] NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[EGN] [nvarchar](20) NOT NULL,
	[MobilePhone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[DocumentNumber] [int] NOT NULL,
	[IBAN] [nvarchar](50) NOT NULL,
	[ModifiedAt] [datetime] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[AttachFile] [nvarchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[Company] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Health_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 13.5.2017 г. 10:44:25 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[SessionId] [uniqueidentifier] NOT NULL,
	[StartTime] [smalldatetime] NULL,
	[ExpirationTime] [smalldatetime] NOT NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[SessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 13.5.2017 г. 10:44:25 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Users_Id]  DEFAULT (CONVERT([uniqueidentifier],CONVERT([varbinary](40),'0',(0)),(0))),
	[IsEnabled] [bit] NOT NULL CONSTRAINT [DF_Users_IsEnabled]  DEFAULT ((1)),
	[CanChgPass] [bit] NULL CONSTRAINT [DF_Users_CanChgPass]  DEFAULT ((1)),
	[Name] [varchar](50) NOT NULL CONSTRAINT [DF_Users_Name]  DEFAULT (NULL),
	[FullName] [nvarchar](124) NOT NULL CONSTRAINT [DF_Users_FullName]  DEFAULT (NULL),
	[Address] [nvarchar](256) NULL CONSTRAINT [DF_Users_Description]  DEFAULT (NULL),
	[PassHash] [nvarchar](128) NULL CONSTRAINT [DF_Users_PassHash]  DEFAULT (NULL),
	[PassDateChng] [datetime] NOT NULL CONSTRAINT [DF_Users_PassDateChng]  DEFAULT (NULL),
	[UserLastLogin] [datetime] NOT NULL CONSTRAINT [DF_Users_UserLastLogin]  DEFAULT (NULL),
	[ModifiedAt] [datetime] NOT NULL CONSTRAINT [DF_Users_ModifiedAt]  DEFAULT (getdate()),
	[CreatedAt] [datetime] NOT NULL CONSTRAINT [DF_Users_CreatedAt]  DEFAULT (getdate()),
	[UserId] [int] NOT NULL CONSTRAINT [DF_Users_UserId]  DEFAULT (NULL),
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (1, N'паркирано/ в спряло състояние')
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (2, N'при тръгване/ при отваряне на врата')
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (3, N'при паркиране')
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (4, N'при излизане от паркинг, частен терен, частен път')
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (5, N'при влизане от паркинг, частен терен, частен път')
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (6, N'при влизане в кръгово движение')
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (7, N'в кръстовище с кръгово движение')
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (8, N'удар в задната част на друго превозно средство при движение в една посока и в същата лента')
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (9, N'движение в една посока и различни ленти')
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (10, N'при смяна на лентите')
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (11, N'при изпреварване')
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (12, N'при завиване надясно')
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (13, N'при завиване наляво')
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (14, N'при обратен завой')
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (15, N'навлизане в лентата за насрещно движение')
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (16, N'идвайки от дясно(на кръщовище)')
INSERT [dbo].[Circumstances] ([Id], [Text]) VALUES (17, N'неспазване на знак за предимство или червена светлина')
INSERT [dbo].[Users] ([Id], [IsEnabled], [CanChgPass], [Name], [FullName], [Address], [PassHash], [PassDateChng], [UserLastLogin], [ModifiedAt], [CreatedAt], [UserId], [Email]) VALUES (N'92d21770-a2ef-4882-96c4-4e25f2565825', 1, 0, N'adminEuroins', N'admin euroins', N'град София,бул.Христофор Колумб 43', N'48719b629a6e244b8da9b2fd195dbcf3a0b5ff451c479a1be55287053d8cb11f037706cb10d2d82cd72aaf736ccec29160bae557b7da81b3063648c08b0a18b8', CAST(N'2016-05-31 10:22:03.300' AS DateTime), CAST(N'2016-05-31 10:22:03.300' AS DateTime), CAST(N'2016-05-31 10:22:03.300' AS DateTime), CAST(N'2016-05-31 10:22:03.287' AS DateTime), 4, N'simeon.prisadov93@gmail.com')
INSERT [dbo].[Users] ([Id], [IsEnabled], [CanChgPass], [Name], [FullName], [Address], [PassHash], [PassDateChng], [UserLastLogin], [ModifiedAt], [CreatedAt], [UserId], [Email]) VALUES (N'f12af4e3-0729-4dee-a55b-559da52fe1fc', 1, 0, N'adminLevins', N'admin levins', N'град София,ул.Раковска', N'22b6555386a1e2d088b378622047354d5b86912a74e73da2807fc0eb4889b2b01942af7f486a1d60cfb6fcc074662787e8c991282fc4bb2071f40321f24afd02', CAST(N'2016-05-31 10:19:37.990' AS DateTime), CAST(N'2016-05-31 10:19:37.990' AS DateTime), CAST(N'2016-05-31 10:19:37.990' AS DateTime), CAST(N'2016-05-31 10:19:37.963' AS DateTime), 2, N'simeon.prisadov93@gmail.com')
INSERT [dbo].[Users] ([Id], [IsEnabled], [CanChgPass], [Name], [FullName], [Address], [PassHash], [PassDateChng], [UserLastLogin], [ModifiedAt], [CreatedAt], [UserId], [Email]) VALUES (N'17046fe9-47bc-410a-be2e-b898e5277f6d', 1, 0, N'adminBulins', N'admin bulins', N'град София,кв.Овча купел', N'69e3c29b2490bd5b8ce89da1bb9bede328c4b516718a107b220904782a83a46a9a8e4c123372a773f5f234c0b1629e7d2be1f9f65ea5778dc06a4c01628434e1', CAST(N'2016-05-31 10:20:46.273' AS DateTime), CAST(N'2016-05-31 10:20:46.273' AS DateTime), CAST(N'2016-05-31 10:20:46.273' AS DateTime), CAST(N'2016-05-31 10:20:46.273' AS DateTime), 3, N'simeon.prisadov93@gmail.com')
INSERT [dbo].[Users] ([Id], [IsEnabled], [CanChgPass], [Name], [FullName], [Address], [PassHash], [PassDateChng], [UserLastLogin], [ModifiedAt], [CreatedAt], [UserId], [Email]) VALUES (N'47b796c6-b143-4490-93a4-bb34f68e4aa9', 1, 0, N'user', N'simply user', N'град Девин', N'b14361404c078ffd549c03db443c3fede2f3e534d73f78f77301ed97d4a436a9fd9db05ee8b325c0ad36438b43fec8510c204fc1c1edb21d0941c00e9e2c1ce2', CAST(N'2016-05-31 10:25:32.100' AS DateTime), CAST(N'2016-05-31 10:25:32.100' AS DateTime), CAST(N'2017-05-10 11:19:04.217' AS DateTime), CAST(N'2016-05-31 10:25:32.100' AS DateTime), 5, N'simeon.prisadov93@gmail.com')
INSERT [dbo].[Users] ([Id], [IsEnabled], [CanChgPass], [Name], [FullName], [Address], [PassHash], [PassDateChng], [UserLastLogin], [ModifiedAt], [CreatedAt], [UserId], [Email]) VALUES (N'351d7e9d-e095-402a-b730-d085d8b68cf8', 1, 1, N'simeon', N'simeon prisadov', N'град София,Младост 1 ', N'6d0eb42a4c3a020ba804fc9b487dafca7e37ee787eff942586d957af58fb304a53863edb87f2ae54d8ced47fe00f852df6c80742827bd970e592bb9b2d081022', CAST(N'2016-05-17 14:45:05.307' AS DateTime), CAST(N'2016-05-17 14:45:05.307' AS DateTime), CAST(N'2017-05-10 10:46:39.180' AS DateTime), CAST(N'2016-05-17 14:45:05.307' AS DateTime), 1, N'simeon.prisadov93@gmail.com')
ALTER TABLE [dbo].[Estate] ADD  CONSTRAINT [DF_Estate_ModifiedAt]  DEFAULT (getdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[Estate] ADD  CONSTRAINT [DF_Estate_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Health] ADD  CONSTRAINT [DF_Health_ModifiedAt]  DEFAULT (getdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[Health] ADD  CONSTRAINT [DF_Health_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Sessions] ADD  CONSTRAINT [DF_Sessions_ExpirationTime]  DEFAULT (dateadd(minute,(20),getdate())) FOR [ExpirationTime]
GO
