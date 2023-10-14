CREATE FUNCTION udf_FlightDestinationsByEmail(@Email NVARCHAR(50))
RETURNS INT 
AS 
BEGIN
DECLARE @Result INT
		SET @Result =
			(
				SELECT 
					CountOfFlights
					FROM (
							SELECT 
								p.Id as Id
								,COUNT(fD.Id) AS CountOfFlights
								,p.Email AS [E-mail]
									FROM Passengers AS p 
									JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
								GROUP BY p.Id, p.Email
						  ) AS r
				WHERE [E-mail] = @Email
			)

		IF @Result IS NULL
		SET @Result = 0
		RETURN @Result
END

