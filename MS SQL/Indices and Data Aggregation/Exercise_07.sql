  SELECT DepositGroup,
         SUM(DepositAmount) AS TotalSum
    FROM WizzardDeposits
GROUP BY DepositGroup,
	            MagicWandCreator
  HAVING MagicWandCreator = 'Ollivander family' 
	     AND  SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC


