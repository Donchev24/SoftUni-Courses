  SELECT FirstName,
         LastName,
		 HireDate,
		 d.[Name] AS DeptName
    FROM Employees
	  AS e
	JOIN Departments
	  AS d
	  ON e.DepartmentID = d.DepartmentID
   WHERE e.HireDate > '1999-01-01' 
         AND d.[Name] IN ('Sales', 'Finance')
ORDER BY HireDate
