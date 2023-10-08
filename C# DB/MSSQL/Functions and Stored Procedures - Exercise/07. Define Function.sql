CREATE OR ALTER FUNCTION ufn_IsWordComprised(@SetOfLetters NVARCHAR(20), @Word NVARCHAR(20))
RETURNS BIT
AS 
BEGIN
DECLARE @Index INT = 1;
		
		WHILE(@Index <= LEN(@Word))
		BEGIN
				IF(@SetOfLetters NOT LIKE '%' + SUBSTRING(@Word,@Index,1) + '%')
					RETURN 0

				SET @Index +=1
		END
					RETURN 1
END

