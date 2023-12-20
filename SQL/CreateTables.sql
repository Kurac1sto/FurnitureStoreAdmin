-- Создание таблицы заказов
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    OrderDate DATE,
    TotalAmount DECIMAL,
    Status VARCHAR(50),
    CustomerID INT
);

-- Создание таблицы товаров
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100)
);

-- Создание таблицы заказчиков
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100)
);

-- Создание таблицы связей заказов и товаров
CREATE TABLE Order_Products (
    OrderID INT,
    ProductID INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Вставка произвольных данных в таблицы
INSERT INTO Products
VALUES 
(1, 'Мебель'),
(2, 'Авто'),
(3, 'Кухонные приборы'),
(4, 'Очки'),
(5, 'Клавиатура'),
(6, 'Микрофон'),
(7, 'Монитор');

INSERT INTO Customers
VALUES
(1, 'Иван'),
(2, 'Антон'),
(3, 'Сергей'),
(4, 'Олег'),
(5, 'Игорь');

INSERT INTO Orders
VALUES
(1, '2023-12-04', 15000, 'Оплачено', 1),
(2, '2023-04-14', 5000, 'Отмена',  1),
(3, '2023-07-14', 15000, 'Оплачено',  1),
(4, '2023-03-14', 13000, 'В обработке',  2),
(5, '2021-05-14', 25000, 'В обработке',  2),
(6, '2023-10-14', 100000, 'Оплачено',  3),
(7, '2022-12-14', 400, 'В обработке',  4),
(8, '2020-12-14', 45000, 'Оплачено',  4),
(9, '2023-11-14', 3000, 'Отмена',  4),
(10, '2020-09-14', 1000, 'Оплачено',  4),
(11, '2021-02-14', 200, 'В обработке',  5),
(12, '2021-01-14', 300, 'Оплачено',  5);

INSERT INTO Order_Products
VALUES
(1, 1),
(2, 3),
(3, 2),
(4, 4),
(5, 1),
(6, 7),
(7, 6),
(8, 2),
(9, 5),
(10, 6),
(11, 7),
(12, 3);