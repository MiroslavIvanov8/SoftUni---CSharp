CREATE OR ALTER FUNCTION udf_ClientWithCigars(@Name NVARCHAR(30))
RETURNS INT 
AS 
BEGIN
	DECLARE @Result INT

		SET @Result =
					(SELECT 
						COUNT(cc.CigarId) AS CNT
							FROM Clients AS c 
							JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
						WHERE c.FirstName = @Name
						GROUP BY ClientId
					)
	IF @Result IS NULL
	SET @Result = 0

	RETURN @Result
END

