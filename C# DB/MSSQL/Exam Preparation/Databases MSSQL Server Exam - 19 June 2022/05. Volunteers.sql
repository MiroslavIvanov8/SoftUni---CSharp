--Extract information about all the Volunteers 
--– name, phone number, address, id of the animal,they are responsible to 
SELECT 
	v.[Name]
   ,v.PhoneNumber
   ,v.[Address]
   ,v.AnimalId
   ,v.DepartmentId
		FROM Volunteers AS v
		JOIN VolunteersDepartments AS vd ON vd.Id = v.DepartmentId
		JOIN Animals AS a ON a.Id = v.AnimalId
	ORDER BY v.[Name], a.Id, vd.Id
