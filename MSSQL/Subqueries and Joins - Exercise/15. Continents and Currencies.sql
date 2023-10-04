SELECT ContinentCode, CurrencyCode , CurrencyCount AS [CurrencyUsage]
FROM
	(	SELECT ContinentCode, CurrencyCode, CurrencyCount ,
		DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyCount  DESC) as CurrencyRank
		 FROM 	
			(
				SELECT ContinentCode, CurrencyCode , COUNT(CurrencyCode) AS CurrencyCount 
				FROM Countries
				GROUP BY CurrencyCode, ContinentCode
			) AS CurrencyCountSubQuerry
		 WHERE CurrencyCount > 1
	) AS CurrensyRankSubQuerry
WHERE CurrencyRank = 1
ORDER BY ContinentCode