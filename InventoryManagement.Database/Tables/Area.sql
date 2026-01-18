
CREATE TABLE [dbo].[Area](
	[AreaId] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[AreaName] VARCHAR(150) NOT NULL,
	[PinCode] VARCHAR(10) NULL,
	[CityId] INT NULL,
	[RegionCode] VARCHAR(5) NULL,
	[IsActive] BIT NOT NULL DEFAULT 1,
	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL,
	[UpdatedBy] INT NULL,
	[UpdatedDate] DATETIME NULL,
	[BranchTransferd] BIT NOT NULL DEFAULT 0,
	[Transfered] BIT NOT NULL DEFAULT 0,
	[ChangeTimeStamp] ROWVERSION NOT NULL,
)