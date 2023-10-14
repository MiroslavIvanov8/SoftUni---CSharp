SELECT 
	ap.AirportName
   ,[Start]
   ,fd.TicketPrice
   ,p.FullName
   ,a.Manufacturer
   ,a.Model
		FROM Aircraft AS a
		JOIN FlightDestinations AS fd ON a.Id = fd.AircraftId
		JOIN Airports AS ap ON ap.Id = fD.AirportId
		JOIN Passengers AS p ON p.Id = fd.PassengerId
	WHERE  DATEPART(HOUR,[Start]) BETWEEN 6 AND 20 AND fd.TicketPrice > 2500
ORDER BY a.Model
