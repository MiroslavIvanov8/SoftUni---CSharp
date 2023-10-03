SELECT TOP(5)
	 e.EmployeeID
	,e.JobTitle
	,a.AddressID
	,a.AddressText
  FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	 JOIN Addresses AS a ON a.AddressID = e.AddressID
 ORDER BY a.AddressID