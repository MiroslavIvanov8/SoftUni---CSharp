CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS 
 SELECT	
			t.[Name]
			,CASE 
				WHEN COUNT(st.SiteId) >= 100 THEN 'Gold badge'
				WHEN COUNT(st.SiteId) >= 50 THEN 'Silver badge'
				WHEN COUNT(st.SiteId) >= 50 THEN 'Bronze badge'
				ELSE NULL
			END
		FROM Tourists AS t 
		JOIN SitesTourists AS st ON t.Id = st.TouristId
	WHERE t.[Name] = @TouristName
	GROUP BY t.[Name]	

