  SELECT [p].PeakName,
         [r].RiverName,
		 LOWER(CONCAT(SUBSTRING([p].[PeakName], 1, LEN([p].[PeakName])-1), [r].[RiverName] ))
      AS [Mix]
    FROM [Rivers]
	  AS [r]
	JOIN [Peaks]
	  AS [p]
	  ON RIGHT([p].[PeakName], 1) = LEFT([r].[RiverName], 1)
ORDER BY [Mix]

