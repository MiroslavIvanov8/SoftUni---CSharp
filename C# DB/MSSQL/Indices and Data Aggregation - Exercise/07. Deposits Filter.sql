SELECT DepositGroup
	  ,TotalSum
FROM
(
	SELECT 
		 DepositGroup
		,SUM(DepositAmount) AS [TotalSum]
		,MagicWandCreator
	  FROM WizzardDeposits
	GROUP BY DepositGroup,MagicWandCreator
	HAVING SUM(DepositAmount) < 150000
) AS DepositSumSubQuerry
WHERE MagicWandCreator = 'Ollivander family'
ORDER BY TotalSum DESC
