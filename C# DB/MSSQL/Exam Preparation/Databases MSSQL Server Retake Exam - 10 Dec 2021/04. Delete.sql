DELETE FROM [FlightDestinations]
WHERE [PassengerId] in
	(
			SELECT [PassengerId]
				FROM [Passengers]
			WHERE LEN([FullName]) <=10
	)

DELETE FROM [Passengers]
WHERE LEN([FullName]) <=10

SELECT * FROM Passengers