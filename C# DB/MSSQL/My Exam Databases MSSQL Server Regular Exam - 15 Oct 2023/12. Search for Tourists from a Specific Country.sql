CREATE PROC usp_SearchByCountry(@Country VARCHAR(50))
AS 

SELECT *
	,COUNT(q.[Name])
 FROM	(	SELECT 
			t.[Name]
			,t.PhoneNumber
			,t.Email
				FROM Tourists AS t
				JOIN Bookings AS b ON t.Id = b.TouristId
				JOIN Countries AS c ON t.CountryId = c.Id
		WHERE c.[Name] = @Country
		) AS q
GROUP BY q.[Name],q.PhoneNumber, q.Email
