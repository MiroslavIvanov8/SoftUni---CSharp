SELECT *
FROM Users AS u JOIN UsersGames AS ug ON u.Id = ug.CharacterId
JOIN Characters AS c ON ug.CharacterId = c.Id

SELECT 
[Name]
FROM Characters
ORDER BY [Name]