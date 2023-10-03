SELECT 
	 e.EmployeeID
	,e.FirstName ,	
	CASE 
	  WHEN p.StartDate >= '2005' THEN NULL 
	  WHEN P.StartDate < '2005' THEN p.Name 
	  END AS ProjectName

FROM Employees AS e
		JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
		JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24 
ORDER BY e.EmployeeID
