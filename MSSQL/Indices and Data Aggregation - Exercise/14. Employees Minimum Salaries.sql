SELECT 
	a.DepartmentID 
	,a.Salary
FROM
	(
		SELECT 
			 e.DepartmentID
			,MIN(Salary) as Salary
		  FROM Employees as e 	
		 GROUP BY DepartmentID
	) as a
WHERE DepartmentID IN (2,5,7)
  

