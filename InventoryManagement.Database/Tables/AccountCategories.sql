CREATE TABLE [dbo].[AccountCategories](
	[AccountCategoryId]	INT			 NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[CategoryName]		VARCHAR(60)  NOT NULL,
	[ShortCode]			VARCHAR(10)  NOT NULL,
	[IsActive]			BIT			 NOT NULL DEFAULT 1,
	[CreatedBy]			INT			 NOT NULL,
	[CreatedDate]		DATETIME	 NOT NULL,
	[UpdatedBy]			INT			 NULL,
	[UpdatedDate]		DATETIME	 NULL,
	[BranchTransferd]	BIT			 NOT NULL DEFAULT 0,
	[Transfered]		BIT			 NOT NULL DEFAULT 0,
	[ChangeTimeStamp]	ROWVERSION	 NOT NULL,
)