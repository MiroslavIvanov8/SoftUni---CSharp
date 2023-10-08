SELECT DISTINCT
SUBSTRING(FirstName, 1, 1) as FirstLetter
FROM
	(
		SELECT 
		FirstName
		,DepositGroup
		FROM WizzardDeposits
		GROUP BY FirstName, DepositGroup
	) AS a
WHERE DepositGroup = 'Troll Chest'