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
ALTER TABLE Member.Members
	DROP CONSTRAINT FK_Members_AccountStatuses
GO
ALTER TABLE Lookup.AccountStatuses SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Lookup.AccountStatuses', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Lookup.AccountStatuses', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Lookup.AccountStatuses', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Member.Members
	DROP CONSTRAINT FK_Members_MaritalStatuses
GO
ALTER TABLE Lookup.MaritalStatuses SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Lookup.MaritalStatuses', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Lookup.MaritalStatuses', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Lookup.MaritalStatuses', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Member.Members
	DROP CONSTRAINT FK_Members_SexTypes
GO
ALTER TABLE Lookup.SexTypes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Lookup.SexTypes', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Lookup.SexTypes', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Lookup.SexTypes', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Member.Members
	DROP CONSTRAINT FK_Members_MembershipCategories
GO
ALTER TABLE Lookup.MembershipCategories SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Lookup.MembershipCategories', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Lookup.MembershipCategories', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Lookup.MembershipCategories', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE Member.Tmp_Members
	(
	MemberID bigint NOT NULL IDENTITY (1, 1),
	AccountNumber char(13) NOT NULL,
	AccountStatusID varchar(2) NOT NULL,
	MembershipCategoryID varchar(2) NOT NULL,
	ApplicationDate smalldatetime NOT NULL,
	WithdrawalDate smalldatetime NULL,
	LastName varchar(30) NOT NULL,
	FirstName varchar(30) NOT NULL,
	MiddleName varchar(50) NOT NULL,
	DateOfBirth smalldatetime NOT NULL,
	PlaceOfBirth varchar(80) NULL,
	MaritalStatusID char(1) NOT NULL,
	SexTypeID char(1) NOT NULL,
	Address varchar(80) NULL,
	Province varchar(80) NULL,
	HomePhone varchar(50) NULL,
	MobilePhone varchar(50) NULL,
	MotherMaidenName varchar(90) NULL,
	LanguageDialects varchar(60) NULL,
	HighestEducationalAttainment varchar(60) NULL,
	Occupation nvarchar(50) NULL,
	Employer nvarchar(60) NULL,
	MonthlySalary money NULL,
	OfficeAddress varchar(80) NULL,
	OfficePhone varchar(50) NULL,
	SpouseLastName varchar(50) NULL,
	SpouseFirstName varchar(50) NULL,
	SpouseMiddleName varchar(50) NULL,
	SpouseOccupation varchar(50) NULL,
	SpouseContactNumber varchar(50) NULL,
	SpouseEmployer varchar(50) NULL,
	SpouseOfficeAddress varchar(80) NULL,
	SpouseOfficePhone varchar(50) NULL,
	NearestRelativeLastName varchar(50) NULL,
	NearestRelativeFirstName varchar(50) NULL,
	NearestRelativeMiddleName varchar(50) NULL,
	NearestRelativeContactNumber varchar(50) NULL,
	MotherLastName varchar(50) NULL,
	MotherFirstName varchar(50) NULL,
	MotherMiddleName varchar(50) NULL,
	MotherContactNumber varchar(50) NULL,
	MotherOccupation varchar(50) NULL,
	MotherAddress varchar(80) NULL,
	FatherLastName varchar(50) NULL,
	FatherFirstName varchar(50) NULL,
	FatherMiddleName varchar(50) NULL,
	FatherContactNumber varchar(50) NULL,
	FatherOccupation varchar(50) NULL,
	FatherAddress varchar(80) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE Member.Tmp_Members SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT Member.Tmp_Members ON
GO
IF EXISTS(SELECT * FROM Member.Members)
	 EXEC('INSERT INTO Member.Tmp_Members (MemberID, AccountNumber, AccountStatusID, MembershipCategoryID, ApplicationDate, WithdrawalDate, LastName, FirstName, MiddleName, DateOfBirth, PlaceOfBirth, MaritalStatusID, SexTypeID, Address, Province, HomePhone, MobilePhone, MotherMaidenName, LanguageDialects, HighestEducationalAttainment, Occupation, Employer, MonthlySalary, OfficeAddress, OfficePhone, SpouseLastName, SpouseFirstName, SpouseMiddleName, SpouseOccupation, SpouseContactNumber, SpouseEmployer, SpouseOfficeAddress, SpouseOfficePhone, NearestRelativeLastName, NearestRelativeFirstName, NearestRelativeMiddleName, NearestRelativeContactNumber, MotherLastName, MotherFirstName, MotherMiddleName, MotherContactNumber, MotherOccupation, MotherAddress, FatherLastName, FatherFirstName, FatherMiddleName, FatherContactNumber, FatherOccupation, FatherAddress)
		SELECT MemberID, AccountNumber, AccountStatusID, MembershipCategoryID, ApplicationDate, WithdrawalDate, LastName, FirstName, MiddleName, DateOfBirth, PlaceOfBirth, MaritalStatusID, SexTypeID, Address, Province, HomePhone, MobilePhone, MotherMaidenName, LanguageDialects, HighestEducationalAttainment, Occupation, Employer, MonthlySalary, OfficeAddress, OfficePhone, SpouseLastName, SpouseFirstName, SpouseMiddleName, SpouseOccupation, SpouseContactNumber, SpouseEmployer, SpouseOfficeAddress, SpouseOfficePhone, NearestRelativeLastName, NearestRelativeFirstName, NearestRelativeMiddleName, NearestRelativeContactNumber, MotherLastName, MotherFirstName, MotherMiddleName, MotherContactNumber, MotherOccupation, MotherAddress, FatherLastName, FatherFirstName, FatherMiddleName, FatherContactNumber, FatherOccupation, FatherAddress FROM Member.Members WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT Member.Tmp_Members OFF
GO
ALTER TABLE Savings.TimeDeposits
	DROP CONSTRAINT FK_TimeDeposits_Members
GO
ALTER TABLE Link.Adjustments
	DROP CONSTRAINT FK_Adjustments_Members
GO
ALTER TABLE Savings.DividendComputations
	DROP CONSTRAINT FK_DividendComputations_Members
GO
ALTER TABLE Loans.Loans
	DROP CONSTRAINT FK_Loans_Members
GO
ALTER TABLE Member.EducationalAttainments
	DROP CONSTRAINT FK_EducationalAttainments_Members
GO
ALTER TABLE Plans.PensionPlans
	DROP CONSTRAINT FK_PensionPlans_Members
GO
ALTER TABLE Link.CashReceipts
	DROP CONSTRAINT FK_CashReceipts_Members
GO
ALTER TABLE Link.CashDisbursements
	DROP CONSTRAINT FK_CashDisbursements_Members
GO
ALTER TABLE Savings.QuarterlyInterestComputations
	DROP CONSTRAINT FK_QuarterlyInterestComputations_Members
GO
ALTER TABLE Member.Dependents
	DROP CONSTRAINT FK_Dependents_Members
GO
ALTER TABLE Member.AvailedServices
	DROP CONSTRAINT FK_AvailedServices_Members
GO
ALTER TABLE Savings.PatronageComputations
	DROP CONSTRAINT FK_PatronageComputations_Members
GO
ALTER TABLE Member.Pictures
	DROP CONSTRAINT FK_Pictures_Members
GO
ALTER TABLE SpecialFunds.TulunganFunds
	DROP CONSTRAINT FK_TulunganFunds_Members
GO
ALTER TABLE SpecialFunds.DeathAidFunds
	DROP CONSTRAINT FK_DeathAidFund_Members
GO
ALTER TABLE Savings.SavingsDeposits
	DROP CONSTRAINT FK_SavingsDeposits_Members
GO
ALTER TABLE Savings.CapitalShares
	DROP CONSTRAINT FK_CapitalShares_Members
GO
ALTER TABLE Plans.CollegeInsurancePlans
	DROP CONSTRAINT FK_CollegeInsurancePlans_Members
GO
DROP TABLE Member.Members
GO
EXECUTE sp_rename N'Member.Tmp_Members', N'Members', 'OBJECT' 
GO
ALTER TABLE Member.Members ADD CONSTRAINT
	PK_Members PRIMARY KEY CLUSTERED 
	(
	MemberID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE Member.Members ADD CONSTRAINT
	IX_Members UNIQUE NONCLUSTERED 
	(
	AccountNumber
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE Member.Members ADD CONSTRAINT
	FK_Members_MembershipCategories FOREIGN KEY
	(
	MembershipCategoryID
	) REFERENCES Lookup.MembershipCategories
	(
	MembershipCategoryID
	) ON UPDATE  CASCADE 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Member.Members ADD CONSTRAINT
	FK_Members_SexTypes FOREIGN KEY
	(
	SexTypeID
	) REFERENCES Lookup.SexTypes
	(
	SexTypeID
	) ON UPDATE  CASCADE 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Member.Members ADD CONSTRAINT
	FK_Members_MaritalStatuses FOREIGN KEY
	(
	MaritalStatusID
	) REFERENCES Lookup.MaritalStatuses
	(
	MaritalStatusID
	) ON UPDATE  CASCADE 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Member.Members ADD CONSTRAINT
	FK_Members_AccountStatuses FOREIGN KEY
	(
	AccountStatusID
	) REFERENCES Lookup.AccountStatuses
	(
	AccountStatusID
	) ON UPDATE  CASCADE 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'Member.Members', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Member.Members', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Member.Members', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Plans.CollegeInsurancePlans ADD CONSTRAINT
	FK_CollegeInsurancePlans_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  CASCADE 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Plans.CollegeInsurancePlans SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Plans.CollegeInsurancePlans', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Plans.CollegeInsurancePlans', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Plans.CollegeInsurancePlans', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Savings.CapitalShares ADD CONSTRAINT
	FK_CapitalShares_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  CASCADE 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Savings.CapitalShares SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Savings.CapitalShares', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Savings.CapitalShares', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Savings.CapitalShares', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Savings.SavingsDeposits ADD CONSTRAINT
	FK_SavingsDeposits_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  CASCADE 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Savings.SavingsDeposits SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Savings.SavingsDeposits', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Savings.SavingsDeposits', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Savings.SavingsDeposits', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE SpecialFunds.DeathAidFunds ADD CONSTRAINT
	FK_DeathAidFund_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  CASCADE 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE SpecialFunds.DeathAidFunds SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'SpecialFunds.DeathAidFunds', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'SpecialFunds.DeathAidFunds', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'SpecialFunds.DeathAidFunds', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE SpecialFunds.TulunganFunds ADD CONSTRAINT
	FK_TulunganFunds_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  CASCADE 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE SpecialFunds.TulunganFunds SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'SpecialFunds.TulunganFunds', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'SpecialFunds.TulunganFunds', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'SpecialFunds.TulunganFunds', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Member.Pictures ADD CONSTRAINT
	FK_Pictures_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE Member.Pictures SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Member.Pictures', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Member.Pictures', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Member.Pictures', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Savings.PatronageComputations ADD CONSTRAINT
	FK_PatronageComputations_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  CASCADE 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Savings.PatronageComputations SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Savings.PatronageComputations', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Savings.PatronageComputations', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Savings.PatronageComputations', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Member.AvailedServices ADD CONSTRAINT
	FK_AvailedServices_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE Member.AvailedServices SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Member.AvailedServices', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Member.AvailedServices', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Member.AvailedServices', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Member.Dependents ADD CONSTRAINT
	FK_Dependents_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE Member.Dependents SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Member.Dependents', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Member.Dependents', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Member.Dependents', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Savings.QuarterlyInterestComputations ADD CONSTRAINT
	FK_QuarterlyInterestComputations_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  CASCADE 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Savings.QuarterlyInterestComputations SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Savings.QuarterlyInterestComputations', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Savings.QuarterlyInterestComputations', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Savings.QuarterlyInterestComputations', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Link.CashDisbursements ADD CONSTRAINT
	FK_CashDisbursements_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Link.CashDisbursements SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Link.CashDisbursements', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Link.CashDisbursements', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Link.CashDisbursements', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Link.CashReceipts ADD CONSTRAINT
	FK_CashReceipts_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Link.CashReceipts SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Link.CashReceipts', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Link.CashReceipts', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Link.CashReceipts', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Plans.PensionPlans ADD CONSTRAINT
	FK_PensionPlans_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  CASCADE 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Plans.PensionPlans SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Plans.PensionPlans', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Plans.PensionPlans', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Plans.PensionPlans', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Member.EducationalAttainments ADD CONSTRAINT
	FK_EducationalAttainments_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE Member.EducationalAttainments SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Member.EducationalAttainments', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Member.EducationalAttainments', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Member.EducationalAttainments', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Loans.Loans ADD CONSTRAINT
	FK_Loans_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  CASCADE 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Loans.Loans SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Loans.Loans', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Loans.Loans', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Loans.Loans', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Savings.DividendComputations ADD CONSTRAINT
	FK_DividendComputations_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE Savings.DividendComputations SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Savings.DividendComputations', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Savings.DividendComputations', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Savings.DividendComputations', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Link.Adjustments ADD CONSTRAINT
	FK_Adjustments_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Link.Adjustments SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Link.Adjustments', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Link.Adjustments', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Link.Adjustments', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Savings.TimeDeposits ADD CONSTRAINT
	FK_TimeDeposits_Members FOREIGN KEY
	(
	MemberID
	) REFERENCES Member.Members
	(
	MemberID
	) ON UPDATE  CASCADE 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Savings.TimeDeposits SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Savings.TimeDeposits', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Savings.TimeDeposits', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Savings.TimeDeposits', 'Object', 'CONTROL') as Contr_Per 