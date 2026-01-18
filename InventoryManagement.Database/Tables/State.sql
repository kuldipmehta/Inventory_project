CREATE TABLE [dbo].[State](
	[StateId] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[StateName] VARCHAR(100) NULL,
	[StateCode] VARCHAR(50) NULL,
	[CountryId] INT NULL,
	[IsActive] BIT NOT NULL DEFAULT 1,
	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL ,
	[UpdatedBy] INT NULL,
	[UpdatedDate] DATETIME NULL,
	[BranchTransferd] BIT NOT NULL DEFAULT 0,
	[Transfered] BIT NOT NULL DEFAULT 0,
	[ChangeTimeStamp] ROWVERSION NOT NULL,
)