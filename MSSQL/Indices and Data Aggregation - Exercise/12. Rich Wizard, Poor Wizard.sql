
SELECT SUM([Difference]) AS SumDifference
FROM
(	SELECT 
		 [FirstName] AS [Host Wizard]
		,[DepositAmount] as [Host Wizard Deposit]
		,LEAD([FirstName]) OVER(ORDER BY [Id]) AS [Guest Wizard]
		,LEAD([DepositAmount]) OVER (ORDER BY [Id]) AS [Guest Wizard Deposit]
		,[DepositAmount] - LEAD([DepositAmount]) OVER (ORDER BY [Id]) AS [Difference]
		FROM WizzardDeposits
) AS D