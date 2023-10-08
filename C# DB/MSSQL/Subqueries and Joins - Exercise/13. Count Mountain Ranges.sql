SELECT 
	  DISTINCT Ranges.CountryCode
	 ,COUNT(Ranges.MountainRange) AS MountainRanges
FROM 
		(SELECT 
			c.CountryCode
			,m.MountainRange
			FROM Countries AS c 
		JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
		JOIN Mountains AS m ON mc.MountainId = m.Id
		) AS Ranges
	WHERE Ranges.CountryCode IN ('RU','BG','US')
GROUP BY CountryCode
