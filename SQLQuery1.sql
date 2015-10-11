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
VALUES ('Михаил', 'Веллер')
INSERT INTO Writers (FirstName, LastName) 
VALUES ('Виктор', 'Пелевин')
INSERT INTO Writers (FirstName, LastName) 
VALUES ('Дмитрий', 'Быков')
INSERT INTO Writers (FirstName, LastName) 
VALUES ('Владимир', 'Набоков')
INSERT INTO Writers (FirstName, LastName) 
VALUES ('Михаил', 'Елизаров')

INSERT INTO Publichers (Title) 
VALUES ('Эксмо')
INSERT INTO Publichers (Title) 
VALUES ('АСТ')
INSERT INTO Publichers (Title) 
VALUES ('AdMarginem')

INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('Перпендикуляр', 1, 1)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('S.N.U.F.F.', 2, 2)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('Ногти', 5, 3)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('Приглашение на казнь', 4, 1)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('Камера Обскура', 4, 2)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('Гражданская история безумной войны', 1, 2)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('Всё о жизни', 1, 2)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('Омон Ра', 2, 2)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('Календарь', 3, 1)
INSERT INTO Books (Title, WriterID, PublicherID) 
VALUES ('Generation «П»', 2, 1)

select * from Writers
select * from Publichers
select * from Books