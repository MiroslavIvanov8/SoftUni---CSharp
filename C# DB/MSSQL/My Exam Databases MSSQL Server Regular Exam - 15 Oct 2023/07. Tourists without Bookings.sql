SELECT 
	t.Id
	,t.[Name]
	,t.PhoneNumber
		FROM Tourists AS t
		LEFT JOIN Bookings AS b ON t.Id = b.TouristId
	WHERE b.ArrivalDate IS NULL
ORDER BY t.[Name]