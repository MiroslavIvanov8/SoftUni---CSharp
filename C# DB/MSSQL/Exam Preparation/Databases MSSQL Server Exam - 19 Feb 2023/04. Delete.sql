DELETE FROM CreatorsBoardgames
WHERE BoardgameId IN (
		SELECT BoardgameId 
		FROM CreatorsBoardgames AS cbg
		JOIN Boardgames AS bg ON cbg.BoardgameId = bg.Id
		JOIN Publishers AS p ON p.Id = bg.PublisherId
		JOIN Addresses AS a ON a.Id = p.AddressId
		WHERE Town LIKE 'L%'
)

DELETE FROM Boardgames
WHERE PublisherId IN (
		SELECT PublisherId 
		FROM Boardgames AS bg 
		JOIN Publishers AS p ON p.Id = bg.PublisherId
		JOIN Addresses AS a ON a.Id = p.AddressId
		WHERE Town LIKE 'L%'
)

DELETE FROM Publishers
WHERE AddressId IN (
		SELECT AddressId 
		FROM Publishers AS p		
		JOIN Addresses AS a ON a.Id = p.AddressId
		WHERE Town LIKE 'L%'
)

DELETE FROM Addresses
WHERE Town LIKE 'L%'