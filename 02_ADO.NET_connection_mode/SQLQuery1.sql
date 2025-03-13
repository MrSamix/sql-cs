create database Library

use Library

create table Books
(
	Id int primary key identity(1,1),
	Title nvarchar(100) not null check(Title <> '')
)

create table Authors
(
	Id int primary key identity(1,1),
	FullName nvarchar(100) not null check(FullName <> '')
)

create table Clients
(
	Id int primary key identity(1,1),
	FullName nvarchar(100) not null check(FullName <> ''),
	IsDebtor bit default(0) not null
)


create table BooksAuthors
(
	BookId int references Books(Id),
	AuthorId int references Authors(Id)
)

create table ClientsBooks
(
	BookId int references Books(Id),
	ClientId int references Clients(Id)
)


select *
from Clients
where IsDebtor = 1;


select a.FullName
from Books as b join BooksAuthors as ba on ba.BookId = b.Id
				join Authors as a on ba.AuthorId = a.Id
where b.Title = 'Harry Potter';


select Title
from Books
where Id NOT IN (select BookId from ClientsBooks)


select Title
from Books
where Id IN (select BookId from ClientsBooks join Clients on ClientsBooks.ClientId = Clients.Id where Clients.FullName = @Name)


delete from ClientsBooks;
update Clients set IsDebtor = 0 where IsDebtor = 1


select * from Books
select * from BooksAuthors
select * from Authors
select * from Clients
select * from ClientsBooks

insert into Clients(FullName)
values
	('Stepan Oksenchuk'),
	('Sasha Panchuk'),
	('Maksym Bobrovskyi'),
	('Sveta Tymoshenko')

insert into ClientsBooks(BookId, ClientId)
values
	(1,3),
	(2,2),
	(3,4)

update Clients set IsDebtor = 1