CREATE OR ALTER PROC usp_GetHoldersFullName
AS

SELECT CONCAT_WS(' ', r.[FirstName], r.[LastName]) AS [Full Name] 
FROM (
		SELECT  
			    ac.[FirstName]
			   ,ac.[LastName]
			    ,a.[AccountHolderId]	
			  FROM [AccountHolders] AS ac
			  JOIN [Accounts] AS a ON ac.Id = a.[AccountHolderId]	
		GROUP BY a.[AccountHolderId], ac.[FirstName], ac.[LastName]
	 ) AS r
	