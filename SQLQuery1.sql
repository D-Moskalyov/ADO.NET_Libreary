CREATE DATABASE Library
--DROP DATABASE Library
USE Library
--USE northwind

CREATE TABLE Books
(
	BookID int IDENTITY(1,1) PRIMARY KEY,
	Title varchar(255),
	WriterID int,
	PublicherID int
)
CREATE TABLE Writers
(
	WriterID int IDENTITY(1,1) PRIMARY KEY,
	FirstName varchar(255),
	LastName varchar(255),
)
CREATE TABLE Publichers
(
	PublicherID int IDENTITY(1,1) PRIMARY KEY,
	Title varchar(255)
)

INSERT INTO Writers (FirstName, LastName) 
VALUES ('������', '������')
INSERT INTO Writers (FirstName, LastName) 
VALUES ('������', '�������')
INSERT INTO Writers (FirstName, LastName) 
VALUES ('�������', '�����')
INSERT INTO Writers (FirstName, LastName) 
VALUES ('��������', '�������')
INSERT INTO Writers (FirstName, LastName) 
VALUES ('������', '��������')

INSERT INTO Publichers (Title) 
VALUES ('�����')
INSERT INTO Publichers (Title) 
VALUES ('���')
INSERT INTO Publichers (Title) 
VALUES ('AdMarginem')

INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('�������������', 1, 1)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('S.N.U.F.F.', 2, 2)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('�����', 5, 3)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('����������� �� �����', 4, 1)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('������ �������', 4, 2)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('����������� ������� �������� �����', 1, 2)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('�� � �����', 1, 2)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('���� ��', 2, 2)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('���������', 3, 1)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('Generation �ϻ', 2, 1)

select * from Writers
select * from Publichers
select * from Books