SELECT TOP(10)
	   e.[FirstName]
	  ,e.[LastName]
	  ,e.[DepartmentID]	  
	FROM [Employees] AS e
 WHERE e.[Salary] > 
				(
				   SELECT AVG(Salary) AS [AverageSalary]
					 FROM [Employees] AS esub
				  WHERE e.[DepartmentID] = esub.[DepartmentID]
		    GROUP BY esub.[DepartmentID]
				 )	   

