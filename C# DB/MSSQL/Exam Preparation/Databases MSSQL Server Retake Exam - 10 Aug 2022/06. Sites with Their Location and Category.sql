SELECT 
s.[Name]
	,l.[Name]
	,s.Establishment
	,c.[Name]
	FROM Sites AS s
		JOIN Locations AS L ON s.LocationId =l.Id
		JOIN Categories AS c ON c.Id = S.CategoryId
ORDER BY c.[Name] DESC , l.[Name], s.[Name]
