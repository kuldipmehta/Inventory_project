CREATE TABLE [dbo].[ApplicationUser] (
    Id                   INT            IDENTITY (1, 1) NOT NULL,
    UserName             NVARCHAR (256) NOT NULL,
    NormalizedUserName   NVARCHAR (256) NOT NULL,
    Email                NVARCHAR (256) NULL,
    NormalizedEmail      NVARCHAR (256) NULL,
    EmailConfirmed       BIT            NOT NULL,
    PasswordHash         NVARCHAR (MAX) NULL,
    PhoneNumber          NVARCHAR (50)  NULL,
    PhoneNumberConfirmed BIT            NOT NULL,
    TwoFactorEnabled     BIT            NOT NULL,
	RoleId 			     INT			NOT NULL,
	Address				 VARCHAR(220)   NULL,
	AdharCardNo			 VARCHAR(30)    NULL,
	AllowedCompanyID	 VARCHAR(120)   NULL,
	AllowedBranchID		 VARCHAR(120)   NOT NULL,
	LoginCompanyID		 INT			NULL,
	LoginBranchID		 INT			NOT NULL,
	DefaultLastFinancialYearID BIT		NULL,
	AllowedListingDays	 INT			NULL,
	AllowedDiscountLimitPrc FLOAT		NULL,
	PreviousDateEntryDays INT			NULL,
	PurchaseRateShow	 BIT			NULL,
	AllUserDataShow		 BIT			NULL,
	AllowedDayBookID	 VARCHAR(MAX)	NULL,
	UserImage			 IMAGE			NULL,
	IsActive			 BIT			NOT NULL DEFAULT 1,
	CreatedBy			 INT			NOT NULL,
	CreatedDate			 DATETIME		NOT NULL,
	UpdatedBy			 INT			NULL,
	UpdatedDate			 DATETIME		NULL,
	BranchTransferd		 BIT			NOT NULL DEFAULT 0,
	Transfered			 BIT			NOT NULL DEFAULT 0,
	ChangeTimeStamp      ROWVERSION		NOT NULL,
    PRIMARY KEY CLUSTERED (Id ASC)
);
GO

CREATE NONCLUSTERED INDEX [IX_ApplicationUser_NormalizedEmail]
    ON [dbo].[ApplicationUser]([NormalizedEmail] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_ApplicationUser_NormalizedUserName]
    ON [dbo].[ApplicationUser]([NormalizedUserName] ASC);
GO

