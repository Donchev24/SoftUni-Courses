	SELECT EmployeeID,
	       FirstName,
	       CASE 
		       WHEN [Year] < 2005 THEN [ProjectName]
			   ELSE NULL
            END
		AS [ProjectName]
	  FROM 
	       (
		      SELECT e.EmployeeID,
                     FirstName,
		             p.[Name] AS ProjectName,
                     DATEPART(YEAR, EndDate) AS Year
                FROM Employees AS e
                JOIN EmployeesProjects AS ep
               	  ON e.EmployeeID = ep.EmployeeID
           LEFT JOIN Projects AS p
                  ON ep.ProjectID = p.ProjectID
               WHERE e.EmployeeID = 24
		   )
        AS Employee24