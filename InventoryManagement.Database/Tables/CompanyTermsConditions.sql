CREATE TABLE [dbo].[CompanyTermsConditions](
	[CompanyID]				INT			 NOT NULL,
	[BranchID]				INT			 NOT NULL,
	[CompanyLogo]			IMAGE		 NULL,
	[SalesHeaderPrintValue] VARCHAR(220) NULL,
	[SalesFooterPrintValue] VARCHAR(220) NULL,
	[OrderHeaderPrintValue] VARCHAR(220) NULL,
	[OrderFooterPrintValue] VARCHAR(220) NULL,
	[TermsCondition]		VARCHAR(MAX) NULL,
	[CreatedBy]				INT			 NOT NULL,
	[CreatedDate]			DATETIME	 NOT NULL,
	[UpdatedBy]				INT			 NULL,
	[UpdatedDate]			DATETIME	 NULL,
	[BranchTransferd]		BIT			 NOT NULL DEFAULT 0,
	[Transfered]			BIT			 NOT NULL DEFAULT 0,
	[ChangeTimeStamp]		ROWVERSION	 NOT NULL,
	CONSTRAINT PK_CompanyTermsConditions PRIMARY KEY CLUSTERED
	(
		CompanyId ASC,
		BranchId ASC
	)
)