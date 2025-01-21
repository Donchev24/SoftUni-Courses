UPDATE [Employees]
   SET [Salary] += (0.12 * [Salary])
 WHERE [DepartmentID] IN (
                           SELECT [DepartmentID]
						     FROM [Departments]
							WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
						 )
SELECT [Salary]
  FROM [Employees]