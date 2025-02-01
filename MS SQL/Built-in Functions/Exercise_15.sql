  SELECT * 
    FROM (
         SELECT [Username],
  	     RIGHT([Email], LEN([Email]) - CHARINDEX('@', [Email])) AS [Email]
         FROM [Users]
	     )
      AS Result
ORDER BY [Email],
         [Username]
          
