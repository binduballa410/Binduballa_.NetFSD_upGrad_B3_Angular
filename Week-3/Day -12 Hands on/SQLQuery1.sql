

CREATE DATABASE EventDb

USE EventDb

CREATE TABLE UserInfo
(
EmailId VARCHAR(100) PRIMARY KEY,
UserName VARCHAR(50) Not Null,
Role varchar check(Role IN('Admin','Participant')),
Password VARCHAR(20) NOT NULL CHECK(LEN(PASSWORD)BETWEEN 6 AND 20)
);


