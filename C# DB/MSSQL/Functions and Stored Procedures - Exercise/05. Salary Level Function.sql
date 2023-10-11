CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN
DECLARE @Result NVARCHAR(10)

IF(@Salary < 30000)
SET @Result = 'Low'

ELSE IF (@Salary BETWEEN 30000 AND 50000)
SET @Result = 'Average'

ELSE 
SET @Result = 'High'

RETURN @Result
END