CREATE PROC usp_SearchByCategory(@Category VARCHAR (50))
AS
	SELECT 
		bg.[Name]
	   ,bg.YearPublished
	   ,bg.Rating
	   ,c.[Name]
	   ,p.[Name]
	   ,CONCAT_WS(' ',pr.PlayersMin, 'people') AS MinPlayers 
	   ,CONCAT_WS(' ',pr.PlayersMax, 'people') AS MaxPlayers 
		FROM Boardgames AS bg
			JOIN Categories AS c ON bg.CategoryId = c.Id
			JOIN Publishers AS p ON p.Id = bg.PublisherId
			JOIN PlayersRanges AS pr ON pr.Id = bg.PlayersRangeId
		WHERE c.[Name] = @Category 
	ORDER BY p.Name ASC, bg.YearPublished DESC
