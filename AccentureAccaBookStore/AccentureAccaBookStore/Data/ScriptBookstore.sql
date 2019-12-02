CREATE DATABASE AccentureAcademyBookstore;
GO

USE  AccentureAcademyBookstore;
GO

CREATE TABLE Author
(
	Id int primary key identity(1,1),
	AuthorName varchar(150) unique not null
)

CREATE TABLE Publisher
(
	Id int primary key identity(1,1),
	[Name] varchar(150) unique not null
)


CREATE TABLE Genre
(
	Id int primary key identity(1,1),
	Genero varchar(150) unique not null,
	Descripcion varchar(2000)
)

CREATE TABLE Book
(
	Id int primary key identity(1,1),
	Title varchar(200) not null,
	Descripcion varchar(2000),
	Publisher_Id int not null,
	Genre_Id int not null,
	CONSTRAINT FK_PUBLISHER FOREIGN KEY (Publisher_Id) REFERENCES Publisher(Id) ON DELETE CASCADE,
	CONSTRAINT FK_GENRE FOREIGN KEY (Genre_Id) REFERENCES Genre(Id) ON DELETE CASCADE
)

CREATE TABLE WrittenBy
(
	Book_Id int not null,
	Author_Id int not null,
	CONSTRAINT FK_AUTHOR FOREIGN KEY (Author_Id) REFERENCES Author(Id) ON DELETE CASCADE,
	CONSTRAINT FK_BOOK FOREIGN KEY (Book_Id) REFERENCES Book(Id) ON DELETE CASCADE,
	CONSTRAINT PK_AUTHOR_BOOK PRIMARY KEY (Book_Id,Author_Id)
)

INSERT INTO Genre
	(Genero, Descripcion)
VALUES
	('Fantasia', 'El término literatura fantástica alude a un género narrativo basado sobre todo en los elementos de fantasía'),
	('Drama', 'Lo que sucede en la obra no está descrito ni narrado, ni comentado directamente, sino visto por el espectador'),
	('Novela policial', 'La novela policíaca, policial, detectivesca o, con más amplitud y precisión, la novela criminal, es una clase de textos o género literario dentro de la novela, que es a su vez un subgénero de la narrativa'),
	('Cienca Ficcion','Es un género especulativo que relata acontecimientos posibles desarrollados en un marco imaginario'),
	('Thriller','El thriller es un género literario estrechamente emparentado con el de misterio, pero con más acción, donde predomina el suspenso, y el temor de ser víctima de un asesinato por parte del protagonista'),
	('Autoayuda', 'aquella que tiene como objetivo plantear posibles soluciones, guías o ayudas a problemas sentimentales, emocionales y sociales de los individuos.')

	SELECT
		*
	FROM
		Author

INSERT INTO	Author
	(AuthorName)
VALUES
	('Edgar Alan Poe'),
	('GRR Martin'),
	('Maria Elena Walsh'),
	('Jorge Luis Borges'),
	('JRR Tolkien'),
	('Haruki Murakami'),
	('Guillermo Martínez'),
	('Gabriel Garcia Marquez'),
	('George Orwell'),
	('Ray Bradbury'),
	('Stephen King'),
	('Ernest Hemingway')