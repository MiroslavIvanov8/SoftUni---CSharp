SELECT 
	 c.Id
	,CONCAT_WS(' ', c.FirstName,c.LastName) AS CreatorName
	,c.Email
FROM Creators AS c
LEFT JOIN CreatorsBoardgames AS cbg ON c.Id = cbg.CreatorId
WHERE cbg.BoardgameId IS NULL