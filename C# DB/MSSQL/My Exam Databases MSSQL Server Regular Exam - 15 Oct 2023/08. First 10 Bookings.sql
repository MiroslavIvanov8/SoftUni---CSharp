SELECT TOP(10)
	h.[Name]
	,d.[Name]
	,c.[Name]
		FROM Bookings AS b
		JOIN Hotels AS h ON b.HotelId = h.Id
		JOIN Destinations AS d ON h.DestinationId = d.Id
		JOIN Countries AS c ON d.CountryId = c.Id
	WHERE h.Id % 2 = 1 AND b.ArrivalDate < '2023-12-31'
ORDER BY c.[Name], b.ArrivalDate