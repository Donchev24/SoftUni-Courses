  SELECT 
     TOP 5
         EmployeeID,
         FirstName,
	     Salary,
	     d.[Name]
    FROM Employees
      AS e
    JOIN Departments
      AS d
	  ON e.DepartmentID = d.DepartmentID
   WHERE Salary > 15000
ORDER BY e.DepartmentID