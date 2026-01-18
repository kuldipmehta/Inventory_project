CREATE TABLE [dbo].[Colors](
	[ColorId]		  INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[ColorName]		  VARCHAR(100) NOT NULL,
	[SrNo]			  INT NOT NULL,
	[IsActive]		  BIT NOT NULL DEFAULT 1,
	[CreatedBy]		  INT NOT NULL,
	[CreatedDate]	  DATETIME NOT NULL,
	[UpdatedBy]		  INT NULL,
	[UpdatedDate]	  DATETIME NULL,
	[BranchTransferd] BIT NOT NULL DEFAULT 0,
	[Transfered]	  BIT NOT NULL DEFAULT 0,
	[ChangeTimeStamp] ROWVERSION NOT NULL,
)