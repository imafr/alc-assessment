DECLARE
@ColumnName AS VARCHAR(50) = '[Month]',  -- Column to be pivoted
    @AggColumn AS VARCHAR(50) = '[Amount]',  -- Column to be aggregated
    @ColumnValues AS NVARCHAR(300) = '[Jan],[Feb],[Mar],[Apr],[May],[Jun],[Jul],[Aug],[Sep],[Oct],[Nov],[Dec]',  -- Pivot column values
    @SQL AS NVARCHAR(MAX);  -- Dynamic SQL query

-- Case 1: When there are no extra columns except the three mentioned
SET @SQL = '
SELECT * 
FROM Sales
PIVOT (
    SUM(' + @AggColumn + ') 
    FOR ' + @ColumnName + ' IN (' + @ColumnValues + ')
) AS pvt';

EXEC(@SQL);

-- Case 2: When there are extra columns (e.g., Primary Key, additional attributes)
-- Using a subquery to preserve other columns
SET @SQL = '
SELECT * FROM
(
    SELECT 
        Product, 
        Amount, 
        [Month]
    FROM Sales
) AS src
PIVOT (
    SUM(' + @AggColumn + ') 
    FOR ' + @ColumnName + ' IN (' + @ColumnValues + ')
) AS pvt';

EXEC(@SQL);
