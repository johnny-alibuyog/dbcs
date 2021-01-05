/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
USE csdb_prod
GO
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
	IsLatePaymentChargeCalculationCompleted bit NULL
GO
ALTER TABLE Loans.Loans SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Loans.Loans', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Loans.Loans', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Loans.Loans', 'Object', 'CONTROL') as Contr_Per 

use csdb_prod;
go

update Loans.Loans
   set IsLatePaymentChargeCalculationCompleted = 1
 where LoanID = 1020

select * from Loans.Loans where LoanID = 1020