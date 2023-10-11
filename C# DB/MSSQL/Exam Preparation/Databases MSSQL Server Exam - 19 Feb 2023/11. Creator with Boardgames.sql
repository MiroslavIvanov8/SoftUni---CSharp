CREATE FUNCTION udf_CreatorWithBoardgames(@Name NVARCHAR(30))
RETURNS INT
AS 
BEGIN

		RETURN
		( SELECT COUNT(1) 
			FROM Creators AS c
			JOIN CreatorsBoardgames AS cbg ON c.Id = cbg.CreatorId
			WHERE c.FirstName = @Name
		)

END
