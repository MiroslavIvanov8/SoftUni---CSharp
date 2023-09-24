SELECT 
	ROW_NUMBER() OVER(ORDER BY Salary DESC) AS Id
	,FirstName
	,LastName
	,DENSE_RANK() OVER(ORDER BY Salary DESC) AS [DenseRank]
	,Rank() OVER (ORDER BY Salary DESC) AS [Rank]
	,NTILE(5) OVER (ORDER BY FirstName) AS Pentile
 	FROM Employees
	WHERE DepartmentID = 5

	
	SELECT
	[Name]	
	FROM Towns
	WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
	ORDER BY [Name]



