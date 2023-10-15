DELETE FROM Bookings
WHERE TouristId IN (
		SELECT Id FROM Tourists
			WHERE [Name] LIKE '%Smith%'
)

DELETE FROM Tourists
	WHERE [Name] LIKE '%Smith%'