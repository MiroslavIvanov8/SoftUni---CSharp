CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT 
AS 
BEGIN
		
	  RETURN
			(	SELECT COUNT(s.Id) AS [COUNT]
					FROM SitesTourists AS st 
					JOIN Sites AS s ON st.SiteId = s.Id
				WHERE s.[Name] = @Site
				GROUP BY SiteId		
			)
END


