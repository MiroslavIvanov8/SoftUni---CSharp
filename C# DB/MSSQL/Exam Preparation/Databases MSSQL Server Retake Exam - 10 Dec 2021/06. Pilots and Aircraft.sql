--Select pilots and aircraft that they operate.
--Extract the pilot's First, Last names, aircraft's Manufacturer, Model, and FlightHours. 
--Skip all plains with NULLs and up to 304 FlightHours.
--Order the result by the FlightHours in descending order,
--then by the pilot's FirstName alphabetically. 
--Required columns:
--•	FirstName
--•	LastName
--•	Manufacturer
--•	Model
--•	FlightHours

SELECT p.FirstName
	  ,p.LastName
	  ,a.Manufacturer
	  ,a.Model
	  ,a.FlightHours
			FROM Pilots AS P
 JOIN PilotsAircraft AS pa ON p.Id = pa.PilotId
 JOIN Aircraft AS a ON a.Id = pa.AircraftId
 WHERE a.FlightHours <= 304 OR a.FlightHours <> NULL 
 ORDER BY a.FlightHours DESC,p.FirstName
