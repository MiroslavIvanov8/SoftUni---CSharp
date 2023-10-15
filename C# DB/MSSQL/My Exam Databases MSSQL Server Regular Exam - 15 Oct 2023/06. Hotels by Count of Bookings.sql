SELECT 
q.HotelId
,q.HotelName
	FROM (
			SELECT 
				h.[Name] AS HotelName 
				,b.Id AS BookingId
				,h.Id AS HotelId
			FROM Hotels AS h
				JOIN HotelsRooms AS hr ON h.Id = hr.HotelId
				JOIN Rooms AS r ON hr.RoomId = r.Id
				JOIN Bookings AS b ON h.Id = b.HotelId
		WHERE r.[Type] = 'VIP Apartment'
		) AS q
GROUP BY q.HotelId ,Q.HotelName
ORDER BY COUNT(q.BookingId) DESC