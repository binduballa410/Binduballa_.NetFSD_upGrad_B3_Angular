
Use CustomerDb

CREATE TABLE Stores
(
store_id INT PRIMARY KEY,
store_name VARCHAR(100)
);

INSERT INTO Stores VALUES
(1,'Hyderabad'),
(2,'Chennia'),
(3,'Bangalore');

CREATE TABLE order_items
(
order_id INT,
item_id INT PRIMARY KEY,
product_id INT,
quantity INT,
list_price DECIMAL(10,2),
discount DECIMAL(4,2),
FOREIGN KEY (order_id) REFERENCES orders(order_id)
);
 INSERT INTO order_items VALUES
 (1,1,101,2, 5000, 0.10),
 (1,2,102,1,3000,0.05),
 (2,1,103,3,1500,0.00),
 (2,2,104,4,2000,0.15),
 (3,1,105,5,10000,0.20),
 (3,1,102,6,3000,0.05),
 (4,1,103,7,1500,0.00);

 CREATE TABLE orders
 (
 order_id INT PRIMARY KEY,
 store_id INT,
 order_status INT
 );

 INSERT INTO orders VALUES
 (1,1,4),
 (2,1,4),
 (3,2,2),
 (4,2,4),
 (5,3,4);

SELECT
s.store_name,
SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM stores s 
INNER JOIN Orders o 
ON s.store_id = s.store_id
INNER JOIN order_items oi 
ON o.order_id = oi.order_id 
WHERE o.order_status = 4
GROUP BY s.store_name
ORDER BY total_sales DESC;
