CREATE FUNCTION udf_RoomsWithTourists(@Name VARCHAR(40))
RETURNS INT 
AS 
BEGIN
	RETURN		
		(	
			SELECT 
				sum(B.AdultsCount) + sum(b.ChildrenCount) as Guests						
				FROM Bookings AS b
					JOIN Rooms AS r ON b.RoomId = r.Id
				WHERE r.[Type] = @Name							
		)
END