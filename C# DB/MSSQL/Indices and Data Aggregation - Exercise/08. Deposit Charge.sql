SELECT DepositGroup
	  ,MagicWandCreator
	  ,MinDepositCharge
FROM
(
	SELECT 
		 DepositGroup
		,MIN(DepositCharge) AS [MinDepositCharge]
		,MagicWandCreator
	  FROM WizzardDeposits
	GROUP BY DepositGroup,MagicWandCreator	
) AS DepositSumSubQuerry
ORDER BY MagicWandCreator,DepositGroup


