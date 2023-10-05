SELECT DepositGroup
	  ,TotalSum
FROM
(
	SELECT 
		 DepositGroup
		,SUM(DepositAmount) AS [TotalSum]
		, MagicWandCreator
	  FROM WizzardDeposits
	GROUP BY DepositGroup,MagicWandCreator
) AS DepositSumSubQuerry
WHERE MagicWandCreator = 'Ollivander family'
