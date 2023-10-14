--Extract information about all the Aircraft and the count of their FlightDestinations.
--Display average ticket price (AvgPrice) of each flight destination by the Aircraft, rounded to the second digit.
--Take only the aircraft with at least 2  FlightDestinations.
--Order the results by count of flight destinations descending, 
--then by the aircraft's id ascending. 


SELECT *
        FROM (
			 SELECT    a.Id AS ID
					  ,a.Manufacturer
					  ,a.FlightHours
					  ,COUNT(fd.Id) AS FlightDestinationsCount
					  ,ROUND(AVG(fd.TicketPrice),2) AvgPrice
					FROM Aircraft AS a
					JOIN FlightDestinations AS fd ON a.Id = fd.AircraftId
				  GROUP BY a.Id ,a.Manufacturer, a.FlightHours
				
) AS r
WHERE FlightDestinationsCount >=2	
ORDER BY FlightDestinationsCount DESC, ID