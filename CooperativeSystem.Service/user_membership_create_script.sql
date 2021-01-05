USE [csdb_prod]
GO

/****** Object:  Table [User].[Roles]    Script Date: 09/21/2013 10:39:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [User].[Roles](
	[RoleID] [varchar](2) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [csdb_prod]
GO

/****** Object:  Table [User].[UsersRoles]    Script Date: 09/21/2013 10:39:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [User].[UsersRoles](
	[UserID] [varchar](20) NOT NULL,
	[RoleID] [varchar](2) NOT NULL,
 CONSTRAINT [PK_UsersRoles] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [User].[UsersRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersRoles_Roles] FOREIGN KEY([RoleID])
REFERENCES [User].[Roles] ([RoleID])
GO

ALTER TABLE [User].[UsersRoles] CHECK CONSTRAINT [FK_UsersRoles_Roles]
GO

ALTER TABLE [User].[UsersRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersRoles_Users] FOREIGN KEY([UserID])
REFERENCES [User].[Users] ([UserID])
GO

ALTER TABLE [User].[UsersRoles] CHECK CONSTRAINT [FK_UsersRoles_Users]
GO



/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE Member.Pictures ADD
	Signature varbinary(MAX) NULL
GO
ALTER TABLE Member.Pictures SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Member.Pictures', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Member.Pictures', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Member.Pictures', 'Object', 'CONTROL') as Contr_Per 

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE Loans.LatePaymentFineReceipts ADD
	Accumulated bit NULL
GO
ALTER TABLE Loans.LatePaymentFineReceipts SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Loans.LatePaymentFineReceipts', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Loans.LatePaymentFineReceipts', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Loans.LatePaymentFineReceipts', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Loans.DelinquentFineReceipts ADD
	Accumulated bit NULL
GO
ALTER TABLE Loans.DelinquentFineReceipts SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Loans.DelinquentFineReceipts', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Loans.DelinquentFineReceipts', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Loans.DelinquentFineReceipts', 'Object', 'CONTROL') as Contr_Per 