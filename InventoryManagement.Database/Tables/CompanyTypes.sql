CREATE TABLE [dbo].[CompanyTypes](
	[CompanyTypeId]	  INT		  NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[CompanyTypeName] VARCHAR(40) NOT NULL,
	[IsActive]		  BIT		  NOT NULL DEFAULT 1,
)