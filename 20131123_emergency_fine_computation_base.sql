﻿use [csdb_prod];
go

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
ALTER TABLE Loans.FineComputationRate ADD
	EmergencyLoanFineComputationBase money NULL
GO
ALTER TABLE Loans.FineComputationRate SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Loans.FineComputationRate', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Loans.FineComputationRate', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Loans.FineComputationRate', 'Object', 'CONTROL') as Contr_Per 
go

update [Loans].[FineComputationRate] set [EmergencyLoanFineComputationBase] = 1100
go


