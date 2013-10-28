use EnergyConservation

if exists (select * from sysobjects where id = OBJECT_ID('[Electricity]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Electricity]

CREATE TABLE [Electricity] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[EquipmentID] [int]  NOT NULL,
[Electricity] [float]  NOT NULL,
[StartTime] [datetime]  NULL,
[CreateTime] [datetime]  NULL DEFAULT (getdate()))

ALTER TABLE [Electricity] WITH NOCHECK ADD  CONSTRAINT [PK_Electricity] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [Electricity] ON


SET IDENTITY_INSERT [Electricity] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[Floors]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Floors]

CREATE TABLE [Floors] (
[FloorID] [int]  IDENTITY (1, 1)  NOT NULL,
[FloorName] [nvarchar]  (200) NULL)

SET IDENTITY_INSERT [Floors] ON


SET IDENTITY_INSERT [Floors] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[GroupInfo]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [GroupInfo]

CREATE TABLE [GroupInfo] (
[ID] [bigint]  IDENTITY (1, 1)  NOT NULL,
[GroupID] [int]  NOT NULL,
[InfoID] [int]  NULL)

ALTER TABLE [GroupInfo] WITH NOCHECK ADD  CONSTRAINT [PK_GroupInfo] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [GroupInfo] ON


SET IDENTITY_INSERT [GroupInfo] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[Groups]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Groups]

CREATE TABLE [Groups] (
[GroupID] [int]  IDENTITY (1, 1)  NOT NULL,
[GroupName] [nvarchar]  (100) NULL,
[GroupState] [int]  NULL DEFAULT (1))

ALTER TABLE [Groups] WITH NOCHECK ADD  CONSTRAINT [PK_Groups] PRIMARY KEY  NONCLUSTERED ( [GroupID] )
SET IDENTITY_INSERT [Groups] ON


SET IDENTITY_INSERT [Groups] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[HelpText]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [HelpText]

CREATE TABLE [HelpText] (
[ID] [bigint]  IDENTITY (1, 1)  NOT NULL,
[Title] [nvarchar]  (300) NULL,
[Content] [nvarchar]  (MAX) NULL)

ALTER TABLE [HelpText] WITH NOCHECK ADD  CONSTRAINT [PK_HelpText] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [HelpText] ON

INSERT [HelpText] ([ID],[Title],[Content]) VALUES ( 1,N'��ο���ĳ���乩�磿',N'1.����������ർ����ѡ��Ҫ����ķ��䣬Ȼ�������硣2.��ק��Ӧ���䵽���簴ť֮�ϡ�3.����������ർ�������Ҽ����Ҫ����ķ��䣬����ֹ���˵���ѡ���缴�ɡ�')
INSERT [HelpText] ([ID],[Title],[Content]) VALUES ( 2,N'��ο�������¥�㹩�磿',N'����������ർ����ѡ��Ҫ����¥�㣬Ȼ�������硣')
INSERT [HelpText] ([ID],[Title],[Content]) VALUES ( 3,N'��θ���¥��򷿼�����ƣ�',N'����������ർ�����Ҽ�Ҫ��������¥��򷿼䣬����ʵ����������')
INSERT [HelpText] ([ID],[Title],[Content]) VALUES ( 4,N'������¥��򷿼䣿',N'����������ർ����[���з���]����Ҽ��������¥�㣬��¥���ϵ���Ҽ�������ӷ��䵽��¥�㡣')
INSERT [HelpText] ([ID],[Title],[Content]) VALUES ( 5,N'������Ⱥ�飿',N'����������ർ����[Ⱥ��]����Ҽ����ɴ����µ�Ⱥ�顣')
INSERT [HelpText] ([ID],[Title],[Content]) VALUES ( 6,N'��θ���Ⱥ���Ա��',N'����������ർ����ĳȺ���ϵ���Ҽ������˵���ѡ��༭���ɸ���Ⱥ���Ա��')

SET IDENTITY_INSERT [HelpText] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[Rooms]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Rooms]

CREATE TABLE [Rooms] (
[RoomID] [int]  IDENTITY (1, 1)  NOT NULL,
[RoomName] [nvarchar]  (200) NULL,
[FloorID] [int]  NOT NULL,
[RoomState] [int]  NOT NULL DEFAULT (1))

ALTER TABLE [Rooms] WITH NOCHECK ADD  CONSTRAINT [PK_Rooms] PRIMARY KEY  NONCLUSTERED ( [RoomID] )
SET IDENTITY_INSERT [Rooms] ON


SET IDENTITY_INSERT [Rooms] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[RoomsInfo]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [RoomsInfo]

CREATE TABLE [RoomsInfo] (
[InfoID] [int]  IDENTITY (1, 1)  NOT NULL,
[RoomID] [int]  NOT NULL,
[EquipmentName] [varchar]  (50) NULL DEFAULT (0),
[EquipmentState] [int]  NULL DEFAULT (0),
[IPAddress] [varchar]  (50) NULL DEFAULT ('172.16.200.164'),
[NetMask] [varchar]  (50) NULL DEFAULT ('255.255.255.128'),
[TimersState] [int]  NULL DEFAULT (0),
[GateWay] [varchar]  (50) NULL DEFAULT ('172.16.202.190'),
[LastMeterValue] [float]  NOT NULL DEFAULT (0),
[LastMeterReadTime] [datetime]  NULL DEFAULT (getdate()),
[CreateTime] [datetime]  NULL DEFAULT (getdate()),
[MinTemperature] [float]  NULL DEFAULT (18),
[MaxTemperature] [float]  NULL DEFAULT (35),
[MacAddress] [varchar]  (50) NULL DEFAULT ('00.01.FF.B8.BC.5F'),
[Port] [int]  NULL DEFAULT (51888))

ALTER TABLE [RoomsInfo] WITH NOCHECK ADD  CONSTRAINT [PK_RoomsInfo] PRIMARY KEY  NONCLUSTERED ( [InfoID] )
SET IDENTITY_INSERT [RoomsInfo] ON


SET IDENTITY_INSERT [RoomsInfo] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[ServerIP]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [ServerIP]

CREATE TABLE [ServerIP] (
[ServerID] [int]  IDENTITY (1, 1)  NOT NULL,
[IPAddress] [varchar]  (50) NULL,
[SubnetMask] [varchar]  (50) NULL,
[Gateway] [varchar]  (50) NULL,
[Port] [int]  NULL)

ALTER TABLE [ServerIP] WITH NOCHECK ADD  CONSTRAINT [PK_ServerIP] PRIMARY KEY  NONCLUSTERED ( [ServerID] )
SET IDENTITY_INSERT [ServerIP] ON


SET IDENTITY_INSERT [ServerIP] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[Timers]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Timers]

CREATE TABLE [Timers] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[Starttime] [time]  NULL DEFAULT (getdate()),
[Stoptime] [time]  NULL,
[CreateTime] [datetime]  NULL DEFAULT (getdate()),
[InfoID] [int]  NULL,
[TimerState] [int]  NULL,
[RepeatTimes] [varchar]  (50) NULL)

ALTER TABLE [Timers] WITH NOCHECK ADD  CONSTRAINT [PK_Timers] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [Timers] ON


SET IDENTITY_INSERT [Timers] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[UserInfo]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [UserInfo]

CREATE TABLE [UserInfo] (
[UserName] [nvarchar]  (100) NOT NULL,
[RealName] [nvarchar]  (200) NULL,
[Gender] [nvarchar]  (50) NULL,
[PhoneNumber] [varchar]  (50) NULL)

ALTER TABLE [UserInfo] WITH NOCHECK ADD  CONSTRAINT [PK_UserInfo] PRIMARY KEY  NONCLUSTERED ( [UserName] )
INSERT [UserInfo] ([UserName],[RealName],[Gender],[PhoneNumber]) VALUES ( N'admin',N'Admin',N'��',N'11111111111')
if exists (select * from sysobjects where id = OBJECT_ID('[Users]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Users]

CREATE TABLE [Users] (
[UserName] [varchar]  (100) NOT NULL,
[Passport] [varchar]  (100) NOT NULL,
[UserState] [int]  NULL DEFAULT (0),
[CreateTime] [datetime]  NULL DEFAULT (getdate()))

ALTER TABLE [Users] WITH NOCHECK ADD  CONSTRAINT [PK_Users] PRIMARY KEY  NONCLUSTERED ( [UserName] )
INSERT [Users] ([UserName],[Passport],[UserState],[CreateTime]) VALUES ( N'admin',N'3ed346684b095f14c677e94e06bba868',0,N'2013/04/09 20:48:37')
