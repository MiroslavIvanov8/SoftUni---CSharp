--Extract all locations which are in Sofia province.
--Find the count of sites in every location.

SELECT 
	 l.Province
	,l.Municipality
	,l.[Name]
	,COUNT(s.Id) AS CountOfSites
		FROM Sites AS s
			JOIN Locations AS l ON s.LocationId = l.Id
		WHERE l.Province = 'Sofia'
	GROUP BY l.Municipality, l.Province,  l.[Name]
ORDER BY COUNT(s.Id) DESC, l.[Name] ASC