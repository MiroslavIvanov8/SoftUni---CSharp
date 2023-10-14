SELECT  *
FROM (
		SELECT 
			CONCAT_WS(' ',c.FirstName,c.LastName) AS FullName
			,a.Country AS Country
			,a.ZIP AS ZIP
			,CONCAT('$',MAX(cig.PriceForSingleCigar)) AS CigarPrice
			  FROM Clients AS c 
				JOIN Addresses AS a ON c.AddressId = a.Id
				JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
				JOIN Cigars AS cig ON cig.Id = cc.CigarId 
		      GROUP BY CONCAT_WS(' ',c.FirstName,c.LastName), a.ZIP ,a.Country
	) AS r
	WHERE ISNUMERIC(r.ZIP) <> 0
