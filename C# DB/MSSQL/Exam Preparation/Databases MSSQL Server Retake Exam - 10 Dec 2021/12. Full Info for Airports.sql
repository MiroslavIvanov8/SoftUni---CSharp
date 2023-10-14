--Create a stored procedure, named usp_SearchByAirportName, which accepts the following parameters:
--•	airportName(with max length 70)
--Extract information about the airport locations with the given airport name.
--The needed data is the name of the airport,
--full name of the passenger, 
--level of the ticket price (depends on flight destination's ticket price:
--'Low'– lower than 400 (inclusive),
--'Medium' – between 401 and 1500 (inclusive),
--'High' – more than 1501),
--manufacturer and condition of the aircraft,
--and the name of the aircraft type.
--Order the result by Manufacturer, then by passenger's full name.

CREATE PROC usp_SearchByAirportName(@AirportName NVARCHAR(70))
AS
	SELECT 
		a.AirportName
	   ,p.FullName
	   , CASE
				WHEN TicketPrice < 400 THEN 'Low'
				WHEN TicketPrice >= 401 AND TicketPrice <=1500 THEN 'Medium'
				ELSE  'High'
			END AS LevelOfTickerPrice
	   ,ac.Manufacturer
	   ,ac.Condition
	   ,[at].TypeName
			 FROM Passengers AS p 
			 JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
			 JOIN Airports AS a ON a.Id = fd.AirportId
			 JOIN Aircraft AS ac ON ac.Id = fd.AircraftId
			 JOIN AircraftTypes AS [at] ON [at].Id = ac.TypeId
	WHERE a.AirportName = @AirportName
ORDER BY ac.Manufacturer, p.FullName

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'