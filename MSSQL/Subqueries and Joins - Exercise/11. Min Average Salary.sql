SELECT Min(a.[Average Salary]) AS MinAverageSalary
FROM
		(
			SELECT
				e.DepartmentID
				, AVG(e.Salary) AS [Average Salary] 
			FROM Employees AS e					
			GROUP BY e.DepartmentID 
		)
		AS a
