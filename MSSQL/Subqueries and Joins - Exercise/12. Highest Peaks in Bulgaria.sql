SELECT 
	c.CountryCode
	,m.MountainRange
	,p.PeakName
	,p.Elevation
FROM Countries AS c 
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON mc.MountainId = m.Id
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE p.Elevation > 2835 AND c.IsoCode = 'BGR'
ORDER BY p.Elevation DESC