

CREATE DATABASE procedureDb;

Use procedureDb;

CREATE TABLE stores
(
store_id INT PRIMARY KEY,
store_name VARCHAR(50),
city VARCHAR(50)
);

CREATE TABLE orders
(
order_id INT PRIMARY KEY,
customer_id INT,
order_date DATE,
store_id INT,
FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE products
(
product_id INT PRIMARY KEY,
product_name VARCHAR(50),
list_price DECIMAL(10,2)
);

CREATE TABLE order_items
(
order_item_id INT PRIMARY KEY,
order_id INT,
product_id INT,
quantity INT,
list_price DECIMAL(10,2),
discount DECIMAL(4,2),
FOREIGN KEY (order_id) REFERENCES orders(order_id),
FOREIGN KEY (product_id) REFERENCES products(product_id)
);

-------INSERTING VALUES TO THE TABLES------------

INSERT INTO stores VALUES
(1,'Hyderabad Store','Hyderabad'),
(2,'Chennai Store','Chennai'),
(3,'Bangalore Store','Bangalore');

INSERT INTO orders VALUES
(101,1,'2023-01-10',1),
(102,2,'2023-02-15',2),
(103,3,'2023-03-20',1),
(104,4,'2023-04-05',3),
(105,5,'2023-05-01',2);

INSERT INTO products VALUES
(1,'Laptop',50000),
(2,'Mobile',20000),
(3,'Tablet',15000),
(4,'Headphones',2000),
(5,'Smart watch',5000);

INSERT INTO order_items VALUES
(1,101,1,1,50000,0.10),
(2,101,4,2,2000,0.05),
(3,102,2,1,20000,0.15),
(4,103,3,1,15000,0.10),
(5,104,5,2,5000,0.05),
(6,105,2,1,20000,0.10);

----CREATING A STORED PROCEDURE TO GENERATE TOTAL SALES AMOUNT PER STORE-----

CREATE PROCEDURE usp_TotalSalesPerStore
AS
BEGIN
SELECT
s.store_name,
SUM(oi.quantity * oi.list_price * (1 - oi.discount))
AS total_sales
FROM orders o
JOIN order_items oi
ON o.order_id = oi.order_id
JOIN stores s
ON o.store_id = s.store_id
GROUP BY s.store_name
END;

EXEC usp_TotalSalesPerStore;

----CREATE A STORED PROCEDURE TO RETRIEVE ORDERS BY DATE RANGE.------

CREATE PROCEDURE usp_GetOrderByDateRange
@StarTDate DATE,
@EndDate DATE
AS 
BEGIN
SELECT
order_id,
customer_id,
order_date,
store_id
FROM orders
WHERE order_date BETWEEN @StartDate AND @EndDate
END;

EXEC usp_GetOrderByDateRange
'2023-01-01','2023-12-31';

-----CREATE A SCALAR FUNCTION TO CALCULATE TOTAL PRICE AFTER DISCOUNT---

CREATE FUNCTION fn_TotalPriceAfterDiscount
(
@price DECIMAL(10,2),
@quantity INT,
@DISCOUNT DECIMAL(4,2)
)
RETURNS DECIMAL(10,2)
AS 
BEGIN
DECLARE @total DECIMAL(10,2)
SET @total = @price * @quantity * (1 - ISNULL(@discount,0))
RETURN @total
END;

SELECT
order_id,
product_id,
dbo.fn_TotalPriceAfterDiscount(list_price,quantity,discount) AS final_price
FROM order_items;


------ CREATE A TABLE-VALUED FUNCTION TO RETURN TOP 5 SELLING PRODUCTS.-----

CREATE FUNCTION fn_TopSellingProducts() 
RETURNS TABLE
AS
RETURN
(
SELECT TOP 5
p.product_name,
SUM(oi.quantity) AS total_quantity
FROM order_items oi
JOIN products p
ON oi.product_id = p.product_id
GROUP BY p.product_name
ORDER BY total_quantity DESC
);

SELECT * FROM 
dbo.fn_TopSellingProducts();


