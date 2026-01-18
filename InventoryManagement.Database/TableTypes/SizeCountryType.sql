CREATE TYPE [dbo].[SizeCountryType] AS TABLE(
    [SizeDepartmentId]	 INT		 NOT NULL,
	[USSizeShortName]	 VARCHAR(25) NULL,
	[EuropSizeShortName] VARCHAR(25) NULL,
	[LengthCM]			 FLOAT		 NULL,
	[LengthInch]		 FLOAT		 NULL
)