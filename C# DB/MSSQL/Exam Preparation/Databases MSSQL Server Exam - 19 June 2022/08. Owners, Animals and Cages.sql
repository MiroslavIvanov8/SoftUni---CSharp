SELECT	
	CONCAT_WS('-', o.[Name],a.[Name]) AS OwnersAnimals
	 ,o.PhoneNumber
	,ac.CageId
		FROM Owners AS o 
		JOIN Animals AS a ON a.OwnerId = o.Id
		JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
		JOIN AnimalTypes AS ant ON ant.Id = a.AnimalTypeId
	WHERE ant.AnimalType = 'Mammals' 
ORDER BY o.[Name], a.[Name] DESC
