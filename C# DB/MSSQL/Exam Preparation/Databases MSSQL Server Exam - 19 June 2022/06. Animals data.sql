SELECT 
	a.[Name]
   ,ant.AnimalType
   ,FORMAT(a.BirthDate, 'dd.MM.yyyy') AS BirthDate
		FROM Animals AS a 
		JOIN AnimalTypes AS ant ON a.AnimalTypeId = ant.Id
ORDER BY a.[Name]