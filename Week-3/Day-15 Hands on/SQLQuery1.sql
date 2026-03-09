
---LEVEL-1 PROBLEM 1: BASIC SETUP AND DATA RETRIEVAL IN ECOMMDB--
CREATE DATABASE EcommDb;
Use EcommDb;

CREATE TABLE categories
(
category_id INT PRIMARY KEY IDENTITY(1,1),
category_name VARCHAR(100) NOT NULL
);

CREATE TABLE brands
(
brand_id INT PRIMARY KEY IDENTITY(1,1),
brand_name VARCHAR(100)
);

CREATE TABLE stores
(
store_id INT PRIMARY KEY IDENTITY(1,1),
store_name VARCHAR(100),
city VARCHAR(50)
);

CREATE TABLE customers
(
customer_id INT PRIMARY KEY IDENTITY(1,1),
first_name VARCHAR(50),
last_name VARCHAR(50),
city VARCHAR(50)
);


CREATE TABLE products
(
product_id INT PRIMARY KEY IDENTITY(1,1),
product_name VARCHAR(255),
brand_id INT,
category_id INT,
model_year INT,
list_price DECIMAL(10,2),
FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

---INSERTING VALUES TO THE TABLES--

INSERT INTO categories (category_name) VALUES
('Sedan'),
('SUV'),
('Electric'),
('Truck'),
('Convertible');

INSERT INTO brands (brand_name) VALUES
('Tesla'),('Toyota'),('Ford'),('BMW'),('Honda');

INSERT INTO stores (store_name, city) VALUES
('Main Auto','New York'),('City Wheels','Austin'),('Elite Cars','Miami'),('Truck Stop','Dallas'),
('Green Drive','Seattle');

INSERT INTO customers (first_name,last_name,city) VALUES
('John','Doe','Austin'),('Jane','Smith','Austin'),('Mike','Ross','New York'),
('Rachel','Zane','Miami'),('Harvey','Specter','New York');

INSERT INTO products(product_name,brand_id,category_id,model_year,list_price)VALUES
('ModelS',1,3,2023,79999),
('Civic',5,1,2022,22000),
('F-150',3,4,2023,45000),
('X5',4,2,2023,65000),
('Camry',2,1,2022,26000);

---QUERIES TO RETRIVE ALL PRODUCTS WITH THEIR BRAND AND CATEGORY NAMES--

SELECT p.product_name,b.brand_name,c.category_name,p.list_price
FROM products p
JOIN brands b ON p.brand_id =
b.brand_id
JOIN categories c ON p.category_id = 
c.category_id;

---RETIRVE ALL CUSTOMERS FROM SPECIFIC CITY---

SELECT first_name,last_name 
FROM customers
WHERE city = 'Austin';

---DISPLAY TOTAL NUMBER OF PRODUCTS IN EACH CATEGORY--

SELECT 
c.category_name,
COUNT(p.product_id) AS total_products
FROM categories c
LEFT JOIN products p ON c.category_id =
p.category_id
GROUP BY c.category_name;


