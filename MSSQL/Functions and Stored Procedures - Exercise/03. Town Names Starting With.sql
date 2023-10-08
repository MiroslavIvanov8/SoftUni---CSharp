CREATE OR ALTER PROC usp_GetTownsStartingWith(@String VARCHAR(10))
AS
SELECT [Name]
  FROM [Towns]
WHERE [Name] LIKE @String + '%'

