CREATE OR ALTER FUNCTION ufn_CalculateFutureValue 
(@Sum DECIMAL(18,4), @YearlyInterestRate FLOAT, @Year INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
-- FV=I×((1+R)^T)	
--I  Initial sum
--R  Yearly interest rate
--T  Number of years
DECLARE @cnt INT = 0;

		WHILE @cnt < @Year
		BEGIN
		   
		   SET @Sum *= (1 + @YearlyInterestRate)
		   SET @cnt += 1
		END

		RETURN @Sum
END


