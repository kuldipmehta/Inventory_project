CREATE TABLE [dbo].[BusinessTypes](
	[BusinessTypeId]	INT			 NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[BusinessTypeName]  VARCHAR(50)  NOT NULL,
	[IsActive]			BIT			 NOT NULL DEFAULT 1,
)