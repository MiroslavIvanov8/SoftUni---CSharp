
  SELECT * 
     FROM
		 (	SELECT EmployeeID ,FirstName ,LastName, Salary
					,DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeId) AS [Rank]
				 FROM Employees
				WHERE Salary BETWEEN 10000 AND 50000
		 )
	  AS RankingTable
   WHERE [Rank] = 2
ORDER BY Salary DESC
	
	
	

	