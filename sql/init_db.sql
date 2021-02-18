use Library;
go

create table Library.dbo.Author(
ID INT IDENTITY(1,1) PRIMARY KEY,
FirstName nvarchar(100),
LastName nvarchar(100) not null,
)

create table Library.dbo.Book (
ISBN nvarchar(13) PRIMARY KEY not null,
AuthorID INT not null,
Title nvarchar(100) not null,
PublishYear nvarchar(4) not null,
InStock bit default 1 not null,
FOREIGN KEY (AuthorID) REFERENCES Author(ID),
)

create table Library.dbo.Reader (
ID INT IDENTITY(1,1) PRIMARY KEY,
FirstName nvarchar(100) not null,
LastName nvarchar(100) not null,
Pesel nvarchar(11) not null,
Active bit default 1 not null, 
constraint UN_Pesel unique (Pesel)
)

create table Library.dbo.LendHistory (
ID INT IDENTITY(1,1) PRIMARY KEY,
ReaderID INT not null,
BookID nvarchar(13) not null,
LendingDate DATETIME not null,
ReturnDate DATETIME,
FOREIGN KEY (ReaderID) REFERENCES Reader(ID),
FOREIGN KEY (BookID) REFERENCES Book(ISBN),
CONSTRAINT UN_BookId_LendingDate unique (BookID, LendingDate),
CONSTRAINT UN_BookId_ReturnDate unique (BookID, ReturnDate)
);
