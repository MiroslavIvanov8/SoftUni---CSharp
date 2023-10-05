SELECT TOP 2
DepositGroup
FROM 
	(SELECT 
		 DepositGroup
		,AVG(MagicWandSize) AS AverageWandSize	
	 FROM WizzardDeposits
	GROUP BY DepositGroup
	) AS AverageWandSizeSubQuerry
ORDER BY AverageWandSize ASC 
