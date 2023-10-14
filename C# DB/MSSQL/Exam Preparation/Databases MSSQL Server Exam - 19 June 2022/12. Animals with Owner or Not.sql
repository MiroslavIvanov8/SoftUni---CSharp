CREATE OR ALTER PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR (30))
AS 
BEGIN
IF(SELECT OwnerId FROM Animals WHERE [Name] = @AnimalName) IS NULL
	BEGIN
		SELECT [Name], 'For adoption'
		FROM Animals
		WHERE [Name] = @AnimalName
	END
ELSE
	BEGIN
		SELECT a.[Name], o.[Name]
			FROM Animals AS a
			JOIN Owners AS o ON o.Id = a.OwnerId
			WHERE a.[Name] = @AnimalName
	END
END
	EXEC usp_AnimalsWithOwnersOrNot 'Hippo'
	EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'
