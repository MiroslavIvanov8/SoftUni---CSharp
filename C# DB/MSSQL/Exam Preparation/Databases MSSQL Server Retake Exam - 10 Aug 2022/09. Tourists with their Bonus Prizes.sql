--Extract information about the tourists, along with their bonus prizes.
--If there is no data for the bonus prize put '(no bonus prize)'.
--Select tourist's name, age, phone number, nationality and bonus prize. 
--Order the result by the name of the tourist (ascending).

SELECT 
	t.[Name]
	,t.Age
	,t.PhoneNumber
	,t.Nationality
	,CASE
		WHEN bp.[Name] IS NULL THEN '(no bonus prize)'
		ELSE bP.[Name]
	END
		FROM Tourists AS t
			LEFT JOIN TouristsBonusPrizes AS tbp ON t.Id = tbp.TouristId
			LEFT JOIN BonusPrizes AS bp ON bp.Id = tbp.BonusPrizeId
		WHERE t.[Name] IS NOT NULL 
		ORDER BY t.[Name] ASC

