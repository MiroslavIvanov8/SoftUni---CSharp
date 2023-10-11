SELECT 
	CONCAT_WS(' ',c.FirstName,c.LastName) AS FullName
	,c.Email
	,MAX(bg.Rating)
FROM Creators AS c
JOIN CreatorsBoardgames AS cbg ON cbg.CreatorId = c.Id
JOIN Boardgames AS bg ON bg.Id = cbg.BoardgameId
WHERE c.Email LIKE '%.com'
GROUP BY CONCAT_WS(' ',c.FirstName,c.LastName),c.Email
