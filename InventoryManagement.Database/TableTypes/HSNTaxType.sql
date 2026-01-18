CREATE TYPE [dbo].[HSNTaxType] AS TABLE(
	[TaxId]		        INT			NOT NULL,
	[FromDate]          DATETIME	NOT NULL,
	[ToDate]            DATETIME	NOT NULL,
	[FromRate]          FLOAT		NOT NULL,
	[ToRate]            FLOAT		NOT NULL,
	[FromPurcRate]      FLOAT		NOT NULL,
	[ToPurcRate]        FLOAT		NOT NULL
)