CREATE TABLE [dbo].[HSNCodes](
	[HSNCodeId]			INT			 NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[HSNCode]			VARCHAR(30)	 NOT NULL,
	[HSNDetail]			VARCHAR(MAX) NOT NULL,
	[IsActive]			BIT			 NOT NULL DEFAULT 1,
	[CreatedBy]			INT			 NOT NULL,
	[CreatedDate]		DATETIME	 NOT NULL,
	[UpdatedBy]			INT			 NULL,
	[UpdatedDate]		DATETIME	 NULL,
	[BranchTransferd]	BIT			 NOT NULL DEFAULT 0,
	[Transfered]		BIT			 NOT NULL DEFAULT 0,
	[ChangeTimeStamp]	ROWVERSION	 NOT NULL,
)