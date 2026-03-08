
-- Level-1: Problem 1 – Product Analysis Using Nested Queries--
CREATE DATABASE AutoDb
Use AutoDb

--creating tables--
CREATE TABLE categories 
(
category_id INT PRIMARY KEY,
category_name VARCHAR(100)
);

CREATE TABLE brands
(
brand_id INT PRIMARY KEY,
brand_name VARCHAR(100)
);

CREATE TABLE products
( 
product_id INT PRIMARY KEY,
product_name VARCHAR(50),
brand_id INT,
category_id INT,
model_year INT,
list_price DECIMAL(10,2),
FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
FOREIGN KEY (category_id) REFERENCES categories(category_id)
);


--Inserting values into tables

INSERT INTO categories VALUES
(1,'Mountain Bikes'),
(2,'Road Bikes'),
(3,'Electric Bikes'),
(4,'Kids Bikes');

INSERT INTO brands VALUES
(1,'Trek'),
(2,'Giant'),
(3,'Specialized'),
(4,'Cannandale');

INSERT INTO products VALUES
(1,'Trail Blazer',1,1,2018,1200),
(2,'Mountain King',2,1,2019,1500),
(3,'Rock Rider',3,1,2017,900),

(4,'Speedster',1,2,2018,1100),
(5,'Road Master',2,2,2019,1300),
(6,'Rapid Ride',3,2,2017,950),

(7,'E-Bike Pro',4,3,2019,2500),
(8,'Volt Rider',2,3,2018,2200),
(9,'Power Glide',1,3,2017,2000);

SELECT
CONCAT(product_name ,'(',model_year,')') AS ProductName,
list_price,

(SELECT AVG(list_price)
FROM products p2
WHERE p2.category_id = 
p1.category_id) AS Category_Average,

list_price -
(SELECT AVG(list_price)
FROM PRODUCTS P2
WHERE p2.category_id =
p1.category_id) AS Price_Difference

FROM products p1
WHERE list_price >
(SELECT AVG(list_price)
FROM products p2
WHERE p2.category_id = 
p1.category_id);

