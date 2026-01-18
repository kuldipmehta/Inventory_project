CREATE TABLE [dbo].[AccountGroupTypes](
	[AccountGroupTypeId] INT		 NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[GroupTypeName]		VARCHAR(60)  NOT NULL,
	[AccountGroupCrDrType] char(1)	 NULL,
	[IsActive]			BIT			 NOT NULL DEFAULT 1,
	[CreatedBy]			INT			 NOT NULL,
	[CreatedDate]		DATETIME	 NOT NULL,
	[UpdatedBy]			INT			 NULL,
	[UpdatedDate]		DATETIME	 NULL,
	[ChangeTimeStamp]	ROWVERSION	 NOT NULL,
)