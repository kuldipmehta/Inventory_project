CREATE TABLE [dbo].[FinancialYears](
	[FinancialYearId]	INT			 NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[YearCode]			VARCHAR(10)  NOT NULL UNIQUE,
	[OpeningDate]		DATETIME	 NOT NULL,
	[ClosingDate]		DATETIME	 NOT NULL,
	[IsActive]			BIT			 NOT NULL DEFAULT 1,
	[CreatedBy]			INT			 NOT NULL,
	[CreatedDate]		DATETIME	 NOT NULL,
	[UpdatedBy]			INT			 NULL,
	[UpdatedDate]		DATETIME	 NULL,
	[Transfered]		BIT			 NOT NULL DEFAULT 0,
	[ChangeTimeStamp]	ROWVERSION	 NOT NULL,
)