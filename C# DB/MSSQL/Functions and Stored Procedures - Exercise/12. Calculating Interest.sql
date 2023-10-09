CREATE OR ALTER PROC usp_CalculateFutureValueForAccount (@Id INT,@InterestRate FLOAT)
AS
SELECT 
	ah.Id AS [Account Id]
		 ,ah.[FirstName]
		 ,ah.[LastName]
	     ,a.Balance	
		 ,dbo.ufn_CalculateFutureValue (a.Balance,@InterestRate,5) AS [Balance in 5 years]
FROM [AccountHolders] AS ah
JOIN [Accounts] AS a ON ah.Id = a.[AccountHolderId]
WHERE a.Id = @Id


