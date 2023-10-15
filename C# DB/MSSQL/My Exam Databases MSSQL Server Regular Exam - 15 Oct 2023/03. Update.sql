UPDATE Bookings
	SET DepartureDate = DATEADD(DAY,1,DepartureDate)
	WHERE DATEPART(MONTH,ArrivalDate) = 12 AND DATEPART(YEAR, ArrivalDate) = 2023


UPDATE Tourists
	SET Email = NULL
	WHERE [Name] LIKE '%MA%'