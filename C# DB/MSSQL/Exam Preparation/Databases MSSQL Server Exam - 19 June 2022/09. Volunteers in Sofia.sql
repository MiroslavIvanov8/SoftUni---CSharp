--Extract information about the volunteers, involved in 'Education program assistant' department,
--who live in Sofia.
--Select their name, phone number and their address in Sofia (skip city's name). 
--Order the result by the name of the volunteers (ascending).

SELECT 
	v.[Name]
   ,v.PhoneNumber
   ,SUBSTRING(v.[Address] ,CHARINDEX(',',v.[Address]) +1, LEN(v.[Address])) AS [Address]
		FROM Volunteers AS v 
		JOIN VolunteersDepartments AS vd ON v.DepartmentId = vd.Id
	WHERE vd.DepartmentName = 'Education program assistant' AND v.[Address] LIKE '%Sofia%'
ORDER BY v.[Name]