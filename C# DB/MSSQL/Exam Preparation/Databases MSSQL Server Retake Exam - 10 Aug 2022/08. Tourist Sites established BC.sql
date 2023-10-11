SELECT 
	 s.[Name]
    ,l.[Name]
	,l.Municipality
	,l.Province
	,s.Establishment
		FROM Sites AS s
			JOIN Locations AS l ON s.LocationId = l.Id
		WHERE l.[Name] NOT LIKE 'B%'
		  AND l.[Name] NOT LIKE 'M%'
		  AND l.[Name] NOT LIKE 'D%'
		  AND s.Establishment LIKE '%BC%'
ORDER BY s.[Name]