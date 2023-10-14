SELECT 
	 cli.Id 
	,CONCAT_WS(' ', cli.FirstName,cli.LastName)  AS ClientName
	,cli.Email
		 FROM Cigars AS c
		 JOIN ClientsCigars AS cc ON c.Id = cc.CigarId
		 RIGHT JOIN Clients AS cli ON cli.Id = cc.ClientId
	WHERE cc.ClientId IS NULL
ORDER BY ClientName

		