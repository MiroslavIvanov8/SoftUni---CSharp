CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan (@SuppliedNumber DECIMAL(18,4))
AS
SELECT 
	 ah.[FirstName]
	,ah.[LastName]
   FROM [AccountHolders] AS ah   
WHERE @SuppliedNumber < (
						      SELECT 
					       SUM(aSubQ.[Balance]) AS [TotalBalance]
								FROM [AccountHolders] AS ahSubQ
								JOIN [Accounts] AS aSubQ ON ahSubQ.Id = aSubQ.AccountHolderId
						    WHERE ah.[Id] = aSubQ.[AccountHolderId]
							GROUP BY [AccountHolderId]
					    )
ORDER BY ah.FirstName, ah.LastName

EXEC usp_GetHoldersWithBalanceHigherThan 10000