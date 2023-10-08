CREATE OR ALTER PROC usp_GetEmployeesFromTown(@TownName VARCHAR(20))
AS
 SELECT [FirstName]
       ,[LastName]
   FROM [Employees] AS e
  LEFT JOIN [Addresses] AS a ON e.AddressID = a.AddressID
  LEFT JOIN [Towns] AS t ON a.TownID = t.TownID
WHERE t.[Name] = @TownName


EXEC usp_GetEmployeesFromTown 'Sofia'
