CREATE PROCEDURE ReportByPeriod
    @startDate DATE, 
    @endDate DATE
AS
BEGIN
    SELECT 
        o.OrderDate,
        o.TotalAmount,
        o.Status,
        c.CustomerName,
        STUFF((SELECT ';' + p.ProductName
               FROM Order_Products op
               JOIN Products p ON op.ProductID = p.ProductID
               WHERE op.OrderID = o.OrderID
               FOR XML PATH('')), 1, 1, '') AS Products,
        ROW_NUMBER() OVER (PARTITION BY o.CustomerID ORDER BY o.OrderDate) AS CustomerOrderNumber
    FROM Orders o
    JOIN Customers c ON o.CustomerID = c.CustomerID
    WHERE o.OrderDate BETWEEN @startDate AND @endDate
    GROUP BY o.OrderID, o.OrderDate, o.TotalAmount, o.Status, c.CustomerName, o.CustomerID
    ORDER BY o.OrderDate DESC;
END