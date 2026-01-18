-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 30/03/2019
-- Description : Returns the Tax Type details
-- ========================================================
CREATE PROCEDURE [dbo].[GetTaxTypeDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    TT.TaxTypeId
	,TT.TaxTypeName
  FROM
    dbo.TaxTypes TT
  WHERE
    TT.IsActive = COALESCE(@IsActive,TT.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

