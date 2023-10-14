--•	DestinationId
--•	Start
--•	FullName (passenger)
--•	AirportName
--•	TicketPrice

SELECT TOP 20
		fd.Id
	   ,fd.[Start]
	   ,p.FullName
	   ,a.AirportName
	   ,fd.TicketPrice
		FROM FlightDestinations AS fd
			 JOIN Passengers AS p ON fd.PassengerId = p.Id
			 JOIN Airports AS a ON a.Id = fd.AirportId
	WHERE DATEPART(DAY,fd.[Start]) % 2 = 0
ORDER BY fd.TicketPrice DESC, a.AirportName
