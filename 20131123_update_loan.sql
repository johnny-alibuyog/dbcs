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
ALTER TABLE Loans.Loans ADD
	UnpaidLatePaymentCharge money NULL,
	UnpaidDelinquentCharge money NULL
GO
ALTER TABLE Loans.Loans SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Loans.Loans', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Loans.Loans', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Loans.Loans', 'Object', 'CONTROL') as Contr_Per 


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
ALTER TABLE Loans.LatePaymentFineReceipts
	DROP COLUMN Accumulated
GO
ALTER TABLE Loans.LatePaymentFineReceipts SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Loans.LatePaymentFineReceipts', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Loans.LatePaymentFineReceipts', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Loans.LatePaymentFineReceipts', 'Object', 'CONTROL') as Contr_Per 


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
ALTER TABLE Loans.DelinquentFineReceipts
	DROP COLUMN Accumulated
GO
ALTER TABLE Loans.DelinquentFineReceipts SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Loans.DelinquentFineReceipts', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Loans.DelinquentFineReceipts', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Loans.DelinquentFineReceipts', 'Object', 'CONTROL') as Contr_Per 
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
ALTER TABLE Loans.LatePaymentFineReceipts ADD
	PreviousUnpaid money NULL
GO
ALTER TABLE Loans.LatePaymentFineReceipts SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Loans.LatePaymentFineReceipts', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Loans.LatePaymentFineReceipts', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Loans.LatePaymentFineReceipts', 'Object', 'CONTROL') as Contr_Per 
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
ALTER TABLE Loans.DelinquentFineReceipts ADD
	PreviousUnpaid money NULL
GO
ALTER TABLE Loans.DelinquentFineReceipts SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Loans.DelinquentFineReceipts', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Loans.DelinquentFineReceipts', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Loans.DelinquentFineReceipts', 'Object', 'CONTROL') as Contr_Per 
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
ALTER TABLE Loans.Loans ADD
	UnpaidPayables money NULL
GO
ALTER TABLE Loans.Loans SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Loans.Loans', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Loans.Loans', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Loans.Loans', 'Object', 'CONTROL') as Contr_Per 