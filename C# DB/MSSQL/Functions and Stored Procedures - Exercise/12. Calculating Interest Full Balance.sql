CREATE OR ALTER PROC usp_CalculateFutureValueForAccount (@Id INT,@InterestRate FLOAT)
AS


SELECT *
,dbo.ufn_CalculateFutureValue(R.[Current Balance],@InterestRate, 5) AS [Balance in 5 years]
FROM (SELECT 
	ah.Id AS [Account Id]
		 ,ah.[FirstName]
		 ,ah.[LastName]
	     ,(
				 SELECT 
				 SUM(aSubQ.[Balance]) AS [TotalBalance]
					  FROM [AccountHolders] AS ahSubQ
					  JOIN [Accounts] AS aSubQ ON ahSubQ.Id = aSubQ.AccountHolderId
		 WHERE @Id = aSubQ.[AccountHolderId] -- REMEMBER TO FIX THIS
				  GROUP BY [AccountHolderId]) AS [Current Balance]		
FROM [AccountHolders] AS ah
JOIN [Accounts] AS a ON ah.Id = a.[AccountHolderId]
WHERE ah.Id = @Id
) AS R



								