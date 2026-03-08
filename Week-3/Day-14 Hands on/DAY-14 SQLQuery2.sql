
--Level-1: Problem 2 – Customer Activity Classification--

--Scenario:The company wants to classify customers based on their total order value and 
--identify customers who have placed orders versus those who have not.--

Use AutoDb

CREATE TABLE customers 
(
customer_id INT PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50)
);

CREATE TABLE orders
(
order_id INT PRIMARY KEY,
customer_id INT,
order_value INT,
FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

INSERT INTO customers VALUES
(1,'Rahul','Sharma'),
(2,'Priya','Varma'),
(3,'Bindu','Balla'),
(4,'Neha','Gupta');

INSERT INTO orders VALUES
(101,1,4000),
(102,1,3000),
(103,2,12000),
(104,3,2000);
SELECT
c.customer_id,
CONCAT(c.first_name,' ',c.last_name)
AS full_name,
t.total_value,
CASE
WHEN t.total_value > 10000 THEN 'Premium'
WHEN t.total_value BETWEEN 5000 AND 10000 THEN 'Regular'
WHEN t.total_value < 5000 THEN 'Basic'
END AS customer_category
FROM customers c
JOIN
(SELECT customer_id, SUM(order_value)
AS total_value
FROM orders
GROUP BY customer_id)
t ON c.customer_id = t.customer_id
UNION
SELECT
c.customer_id,
CONCAT(c.first_name,' ',c.last_name),0,
'No Orders'
FROM customers c
WHERE c.customer_id NOT IN 
(
SELECT customer_id FROM orders
);





