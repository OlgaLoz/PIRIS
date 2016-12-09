IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Clients_Disablement]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Clients] DROP CONSTRAINT [FK_Clients_Disablement]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Clients_FamilyStatus]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Clients] DROP CONSTRAINT [FK_Clients_FamilyStatus]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Clients_Nationality]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Clients] DROP CONSTRAINT [FK_Clients_Nationality]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Clients_Town]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Clients] DROP CONSTRAINT [FK_Clients_Town]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Clients]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Clients]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Disablement]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Disablement]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FamilyStatus]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [FamilyStatus]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Nationality]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Nationality]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Town]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Town]
;

CREATE TABLE [Clients]
(
	[id] int NOT NULL IDENTITY (1, 1),
	[lastName] varchar(50) NOT NULL,
	[firstName] varchar(50) NOT NULL,
	[midName] varchar(50) NOT NULL,
	[birthday] datetime NOT NULL,
	[passportNumber] varchar(50) NOT NULL,
	[passportIssuedBy] varchar(50) NOT NULL,
	[passportIssueDate] datetime NOT NULL,
	[passrortIdNumber] varchar(50) NOT NULL,
	[birthPlace] varchar(50) NOT NULL,
	[address] varchar(50) NOT NULL,
	[homePhone] varchar(50),
	[mobilePhone] varchar(50),
	[mail] varchar(50),
	[workPlace] varchar(50),
	[workPosition] varchar(50),
	[registrationAddress] varchar(50) NOT NULL,
	[pensioner] bit NOT NULL,
	[mounthIncome] money,
	[nationalityId] int,
	[disablementId] int,
	[townId] int,
	[statusId] int
)
;

CREATE TABLE [Disablement]
(
	[disablementId] int NOT NULL IDENTITY (1, 1),
	[name] varchar(50) NOT NULL
)
;

CREATE TABLE [FamilyStatus]
(
	[statusId] int NOT NULL IDENTITY (1, 1),
	[name] varchar(50) NOT NULL
)
;

CREATE TABLE [Nationality]
(
	[nationalityId] int NOT NULL IDENTITY (1, 1),
	[name] varchar(50) NOT NULL
)
;

CREATE TABLE [Town]
(
	[townId] int NOT NULL IDENTITY (1, 1),
	[name] varchar(50)
)
;

ALTER TABLE [Clients] 
 ADD CONSTRAINT [PK_Clients]
	PRIMARY KEY CLUSTERED ([id])
;

ALTER TABLE [Disablement] 
 ADD CONSTRAINT [PK_Disablement]
	PRIMARY KEY CLUSTERED ([disablementId])
;

ALTER TABLE [FamilyStatus] 
 ADD CONSTRAINT [PK_FamilyStatus]
	PRIMARY KEY CLUSTERED ([statusId])
;

ALTER TABLE [Nationality] 
 ADD CONSTRAINT [PK_Nationality]
	PRIMARY KEY CLUSTERED ([nationalityId])
;

ALTER TABLE [Town] 
 ADD CONSTRAINT [PK_Town]
	PRIMARY KEY CLUSTERED ([townId])
;

ALTER TABLE [Clients] ADD CONSTRAINT [FK_Clients_Disablement]
	FOREIGN KEY ([disablementId]) REFERENCES [Disablement] ([disablementId]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Clients] ADD CONSTRAINT [FK_Clients_FamilyStatus]
	FOREIGN KEY ([statusId]) REFERENCES [FamilyStatus] ([statusId]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Clients] ADD CONSTRAINT [FK_Clients_Nationality]
	FOREIGN KEY ([nationalityId]) REFERENCES [Nationality] ([nationalityId]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Clients] ADD CONSTRAINT [FK_Clients_Town]
	FOREIGN KEY ([townId]) REFERENCES [Town] ([townId]) ON DELETE No Action ON UPDATE No Action
;
