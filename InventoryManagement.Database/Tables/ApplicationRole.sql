CREATE TABLE [dbo].[ApplicationRole] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (256) NOT NULL,
    [NormalizedName] NVARCHAR (256) NOT NULL,
	[IsActive] BIT NOT NULL DEFAULT 1,
	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL ,
	[UpdatedBy] INT NULL,
	[UpdatedDate] DATETIME NULL,
	[ChangeTimeStamp] ROWVERSION NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE NONCLUSTERED INDEX [IX_ApplicationRole_NormalizedName]
    ON [dbo].[ApplicationRole]([NormalizedName] ASC);
GO

