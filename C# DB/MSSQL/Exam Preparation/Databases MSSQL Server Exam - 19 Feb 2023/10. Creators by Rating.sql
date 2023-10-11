SELECT c.LastName
	,CEILING(AVG(bG.Rating)) AS AverageRating
	,p.[Name]
	FROM Creators AS c
	JOIN CreatorsBoardgames AS cbg ON c.Id = cbg.CreatorId
	JOIN Boardgames AS bg ON bg.Id = cbg.BoardgameId
	JOIN Publishers AS p ON p.Id = bg.PublisherId
WHERE p.[Name] =  'Stonemaier Games'
GROUP BY c.LastName,p.[Name]
ORDER BY AVG(bG.Rating) DESC