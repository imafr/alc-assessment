SELECT 
    ProductId, 
    OrderDate, 
    COUNT(*) AS DuplicateCount
FROM Orders
GROUP BY ProductId, OrderDate
HAVING COUNT(*) > 1;