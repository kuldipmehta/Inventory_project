CREATE TABLE [dbo].[ProfitSharingRatios](
	[CompanyId]			INT			NOT NULL,
	[AccountId]			INT			NOT NULL,
	[ProfitPrc]			FLOAT		NOT NULL,
	[CreatedBy]			INT			NOT NULL,
	[CreatedDate]		DATETIME	NOT NULL,
	[UpdatedBy]			INT			NULL,
	[UpdatedDate]		DATETIME	NULL,
	[Transfered]		BIT			NOT NULL DEFAULT 0,
	[ChangeTimeStamp]	ROWVERSION	NOT NULL
	CONSTRAINT PK_ProfitSharingRatio PRIMARY KEY CLUSTERED
	(
		CompanyId ASC,
		AccountId ASC
	)
)