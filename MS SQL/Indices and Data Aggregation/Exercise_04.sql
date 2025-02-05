  SELECT DepositGroup
    FROM (
	      SELECT
             TOP 2 
                 DepositGroup,
	             AVG(MagicWandSize) AS AvgWandSize
                 FROM WizzardDeposits
                 GROUP BY DepositGroup
				 ORDER BY  AVG(MagicWandSize)
	     )
	  AS SmallestDepositGroup