
	SELECT
	TownID
	,[Name]	
	FROM Towns
	WHERE LEFT([Name],1) = 'M' OR LEFT([Name],1) = 'K' OR LEFT([Name],1) = 'B' OR LEFT([Name],1) = 'E'
	ORDER BY [Name]



