SELECT TOP (5)
	o.[Name]
    ,COUNT(a.OwnerId) AS CountOfAnimals
		FROM Owners AS o
		JOIN Animals AS a ON o.Id = a.OwnerId
	GROUP BY o.[Name]
ORDER BY COUNT(a.OwnerId) DESC, o.[Name]