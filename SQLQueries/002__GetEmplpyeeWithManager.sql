-- This query will return all employees with theirs managers
-- 1. SELF JOIN
SELECT
    e.EmployeeId,
    e.Name AS EmployeeName,
    m.ManagerId,
    m.Name AS ManagerName
FROM Employees e
JOIN Employees m
ON e.ManagerId = m.EmployeeId;

-- This query will return all employees with and without managers
-- 2. LEFT JOIN
SELECT 
    e.EmployeeId, 
    e.Name AS EmployeeName,
    m.ManagerId,
    m.Name AS ManagerName
FROM Employees e
LEFT JOIN Employees m 
ON e.ManagerId = m.EmployeeId;