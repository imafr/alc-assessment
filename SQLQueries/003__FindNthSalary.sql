-- Note: We can select the Nth salary only.
-- For more descriptive control, I have used other columns in the select list.

DECLARE @N INT = 3; 
        
SELECT
    EmployeeId,
    Name, 
    Salary
FROM
    Employees
ORDER BY
    Salary DESC
OFFSET (@N-1) ROWS
FETCH NEXT 1 ROWS ONLY;

-- Alternative solution
-- Select all employee who have the Nth highest salary
WITH RankedSalaries AS (
    SELECT
        EmployeeId,
        Name,
        Salary,
        DENSE_RANK() OVER (ORDER BY Salary DESC) AS rnk
    FROM Employees
)
SELECT EmployeeId, Name, Salary
FROM RankedSalaries
WHERE rnk = @N;

-- Alternative solution
SELECT 
    TOP(1)
    EmployeeId,
    Name,
    Salary
FROM
    (SELECT 
        TOP(@N)
        EmployeeId,
        Name,
        Salary
    FROM
        Employees
    ORDER BY  
        Salary DESC) AS Temp
ORDER BY 
    Salary ASC ;

-- Alternative solution
SELECT
    TOP(1)
    EmployeeId,
    Name,
    Salary
FROM
    Employees
WHERE  
    Salary NOT IN (
        SELECT
            TOP(@N-1)
            Salary
        FROM
            Employees
        ORDER BY
            Salary DESC
    );

-- Alternative solution
SELECT
    EmployeeId,
    Name,
    Salary
FROM
    Employees
WHERE
    Salary IN (
        SELECT
            TOP(@N)
            Salary
        FROM
            Employees
        ORDER BY
            Salary DESC
    )
ORDER BY 
    Salary ASC;