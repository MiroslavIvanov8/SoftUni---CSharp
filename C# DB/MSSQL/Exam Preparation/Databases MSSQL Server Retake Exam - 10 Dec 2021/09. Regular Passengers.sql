--Extract all passengers, who have flown in more than one aircraft 
--and have an 'a' as the second letter of their full name.
--Select the full name, the count of aircraft that he/she traveled,
--and the total sum which was paid.
--Order the result by passenger's FullName.
--Required columns:
--•	FullName
--•	CountOfAircraft
--•	TotalPayed

SELECT *
FROM (	
		SELECT   
			  p.FullName AS FullName
			  ,COUNT(fd.AircraftId) AS CountOfAircraft
			  ,SUM(fd.TicketPrice) AS TotalPayed
			FROM Passengers AS p 
			JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId	 
		GROUP BY p.FullName
	) AS r
WHERE CountOfAircraft > 1 AND SUBSTRING(FullName,2,1) = 'a'
ORDER BY FullName