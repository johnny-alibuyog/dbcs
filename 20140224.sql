
USE [csdb_prod]
GO

/****** Object:  Table [Loans].[AgingLoans]    Script Date: 02/24/2014 15:17:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Loans].[AgingLoans](
	[AgingLoanID] [bigint] IDENTITY(1,1) NOT NULL,
	[Period] [datetime] NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_AgingLoans] PRIMARY KEY CLUSTERED 
(
	[AgingLoanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Loans].[AgingLoanItems](
	[AgingLoanItemID] [bigint] IDENTITY(1,1) NOT NULL,
	[AgingLoanID] [bigint] NULL,
	[Name] [nvarchar](150) NULL,
	[AgeInDays] [int] NULL,
	[AgeInMonths] [int] NULL,
	[AgeGroupInDays] [nvarchar](50) NULL,
	[LoanType] [nvarchar](50) NULL,
	[LoanHasAged] [bit] NULL,
	[CurrentPayables] [decimal](18, 4) NULL,
	[OutstandingBalance] [decimal](18, 4) NULL,
	[AgedPayables] [decimal](18, 4) NULL,
	[GoodPayables] [decimal](18, 4) NULL,
	[LatePaymentFine] [decimal](18, 4) NULL,
	[DelinquentCharge] [decimal](18, 4) NULL,
	[LoanDate] [datetime] NULL,
	[LastPaymentDate] [datetime] NULL,
	[DueDate] [datetime] NULL,
 CONSTRAINT [PK_AgingLoanItems] PRIMARY KEY CLUSTERED 
(
	[AgingLoanItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Loans].[AgingLoanItems]  WITH CHECK ADD  CONSTRAINT [FK_AgingLoanItems_AgingLoans] FOREIGN KEY([AgingLoanID])
REFERENCES [Loans].[AgingLoans] ([AgingLoanID])
GO

ALTER TABLE [Loans].[AgingLoanItems] CHECK CONSTRAINT [FK_AgingLoanItems_AgingLoans]
GO

CREATE TABLE [Loans].[DelinquentLoans](
	[DelinquentLoanID] [bigint] IDENTITY(1,1) NOT NULL,
	[Period] [datetime] NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_DelinquentLoans] PRIMARY KEY CLUSTERED 
(
	[DelinquentLoanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Loans].[DelinquentLoanItems](
	[DelinquentLoanItemID] [bigint] IDENTITY(1,1) NOT NULL,
	[DelinquentLoanID] [bigint] NULL,
	[Name] [nvarchar](150) NULL,
	[LoanType] [nvarchar](50) NULL,
	[OutstandingBalance] [decimal](18, 4) NULL,
	[DelinquentCharge] [decimal](18, 4) NULL,
	[LatePaymentFine] [decimal](18, 4) NULL,
	[CapitalShare] [decimal](18, 4) NULL,
	[SavingsDeposit] [decimal](18, 4) NULL,
	[TimeDeposit] [decimal](18, 4) NULL,
	[NetExposure] [decimal](18, 4) NULL,
	[LoanDate] [datetime] NULL,
	[LastPayment] [datetime] NULL,
	[DueDate] [datetime] NULL,
 CONSTRAINT [PK_DelinquentLoanItems] PRIMARY KEY CLUSTERED 
(
	[DelinquentLoanItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Loans].[DelinquentLoanItems]  WITH CHECK ADD  CONSTRAINT [FK_DelinquentLoanItems_DelinquentLoans] FOREIGN KEY([DelinquentLoanID])
REFERENCES [Loans].[DelinquentLoans] ([DelinquentLoanID])
GO

ALTER TABLE [Loans].[DelinquentLoanItems] CHECK CONSTRAINT [FK_DelinquentLoanItems_DelinquentLoans]
GO

