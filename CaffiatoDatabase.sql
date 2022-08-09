drop database CaffiatoDB
go

create database CaffiatoDB
go

use CaffiatoDB;

drop table Deal;
drop table Address;
drop table Transact;
drop table Caffe;
drop table UserCaffe;

drop table Feedback;
drop table Challenge;



drop proc AddUserCaffe;
drop proc UpdateUserCaffe;
drop proc UpdatePointsUserCaffe;
drop proc DeleteUserCaffe;
drop proc GetUserCaffe;
drop proc GetUserCaffeByMail;
drop proc GetUserCaffes;

drop proc AddCaffe;
drop proc UpdateCaffe;
drop proc DeleteCaffe;
drop proc GetCaffe;
drop proc GetCaffes;

drop proc AddAddress;
drop proc UpdateAddress;
drop proc DeleteAddress;
drop proc GetAddress;
drop proc GetAddresses;

drop proc AddDeal;
drop proc UpdateDeal;
drop proc UpdateActivityDeal;
drop proc DeleteDeal;
drop proc GetDeal;
drop proc GetDeals;

drop proc AddTransaction;
drop proc UpdateTransaction;
drop proc DeleteTransaction;
drop proc GetTransaction;
drop proc GetTransactions;

drop proc AddFeedback;
drop proc GetFeedback;
drop proc GetFeedbacks;

drop proc AddChallenge;
drop proc UpdateChallenge;
drop proc DeleteChallenge;
drop proc GetChallenges;
drop proc GetChallenge;




create table UserCaffe(
IDUserCaffe int primary key identity(1,1),
Email nvarchar(50) not null,
Name nvarchar(150) not null,
Username nvarchar(50) not null,
Surname nvarchar(150),
DateOfBirth date,
Oib nvarchar(11),
Points int not null default 0
)

create table Caffe(
IDCafe int primary key identity(1,1),
Name nvarchar(150) not null,
UserCaffeID int foreign key references UserCaffe(IDUserCaffe) not null 
)
go

create table Address(
IDAddress int primary key identity(1,1),
StreetNumber nvarchar(10) not null,
StreetName nvarchar(50) not null,
City nvarchar(50) not null,
PostCode nvarchar(15),
CaffeID int foreign key references Caffe(IDCafe) not null
)
go


create table Deal(
IDDeal int primary key identity(1,1),
Name nvarchar(50) not null,
DateTime DateTime not null,
Points int not null,
Price money not null,
CaffeID int foreign key references Caffe(IDCafe) not null,
Active bit default 0
)
go

create table Transact(
IDTransaction int primary key identity(1,1),
Time Datetime not null,
Amount money not null,
UserCaffeID int foreign key references UserCaffe(IDUserCaffe) not null
)
go

create table Feedback(
IDFeedback int primary key identity(1,1),
FeedbackLog nvarchar(max)
)
go

create table Challenge(
IDChallenge int primary key identity(1,1),
Name nvarchar(50),
Description nvarchar(max)
)
go


/*----------------------------------------------------------------------------------------------*/

create proc AddUserCaffe
@Email nvarchar(50),
@Name nvarchar(150),
@Username nvarchar(50),
@Surname nvarchar(150),
@DateOfBirth date,
@Oib nvarchar(11)
as
begin 
insert into UserCaffe (Email, Name, Username, Surname, DateOfBirth, Oib) values (@Email, @Name,@Username,@Surname,@DateOfBirth,@Oib);
end
go

create proc UpdateUserCaffe
@IDUserCaffe int,
@Email nvarchar(50),
@Name nvarchar(150),
@Username nvarchar(50),
@Surname nvarchar(150),
@DateOfBirth date,
@Oib nvarchar(11)
as
begin 
update UserCaffe set UserCaffe.Email = @Email, Name = @Name, Username = @Username, Surname = @Surname, DateOfBirth = @DateOfBirth, Oib = @Oib where UserCaffe.IDUserCaffe = @IDUserCaffe;
end
go

create proc UpdatePointsUserCaffe
@IDUserCaffe int,
@Points int
as
begin
Update UserCaffe set Points = @Points where UserCaffe.IDUserCaffe = @IDUserCaffe;
end
go

create proc DeleteUserCaffe
@IDUserCaffe int
as
begin 
delete from UserCaffe where UserCaffe.IDUserCaffe = @IDUserCaffe;
end
go

create proc GetUserCaffe
@IDUserCaffe int
as
begin 
select * from UserCaffe where UserCaffe.IDUserCaffe = @IDUserCaffe;
end
go

create proc GetUserCaffeByMail
@Email nvarchar(50)
as
begin
select * from UserCaffe where UserCaffe.Email = @Email;
end
go

create proc GetUserCaffes
as
begin 
select * from UserCaffe;
end
go

/*----------------------------------------------------------------------------------------------*/

create proc AddCaffe
@Name nvarchar(150),
@UserCaffeID int
as
begin
insert into Caffe (Name, UserCaffeID) values (@Name,@UserCaffeID);
end
go

create proc UpdateCaffe
@IDCaffe int,
@Name nvarchar(150),
@UserCaffeID int
as
begin
update Caffe set Name = @Name, UserCaffeID = @UserCaffeID where IDCafe = @IDCaffe;
end
go

create proc DeleteCaffe
@IDCaffe int
as
begin
delete from Caffe where IDCafe = @IDCaffe;
end
go

create proc GetCaffe
@IDCaffe int
as
begin
select * from Caffe where Caffe.IDCafe = @IDCaffe
end
go

create proc GetCaffes
as
begin
select * from Caffe;
end
go

/*----------------------------------------------------------------------------------------------*/

create proc AddAddress
@StreetNumber nvarchar(10),
@StreetName nvarchar(50),
@City nvarchar(50),
@PostCode nvarchar(15),
@CaffeID int
as
begin
insert into Address (StreetNumber, StreetName, City, PostCode, CaffeID) values (@StreetNumber, @StreetName, @City, @PostCode, @CaffeID);
end
go

create proc UpdateAddress
@IDAddress int,
@StreetNumber nvarchar(10),
@StreetName nvarchar(50),
@City nvarchar(50),
@PostCode nvarchar(15),
@CaffeID int
as
begin
update Address set StreetName = @StreetName, StreetNumber = @StreetNumber, City = @City, PostCode = @PostCode, CaffeID = @CaffeID where IDAddress = @IDAddress;
end
go

create proc DeleteAddress
@IDAddress int
as
begin
delete from Address where IDAddress = @IDAddress;
end
go

create proc GetAddress
@IDAddress int
as
begin
select * from Address where IDAddress = @IDAddress;
end
go

create proc GetAddresses
as
begin
select * from Address;
end
go

/*----------------------------------------------------------------------------------------------*/

create proc AddDeal
@Name nvarchar(50),
@DateTime DateTime,
@Points int,
@Price money,
@CaffeID int
as
begin
insert into Deal (Name, DateTime, Points, Price, CaffeID) values (@Name, @DateTime, @Points, @Price, @CaffeID);
end
go

create proc UpdateDeal
@IDDeal int,
@Name nvarchar(50),
@DateTime DateTime,
@Points int,
@Price money,
@CaffeID int,
@Active bit
as
begin
update Deal set Name = @Name, DateTime = @DateTime, Points = @Points, Price = @Price, CaffeID = @CaffeID, Active = @Active where IDDeal = @IDDeal;
end
go

create proc UpdateActivityDeal
@IDDeal int,
@Active bit
as
begin
update Deal set Active = @Active where IDDeal =  @IDDeal;
end
go

create proc DeleteDeal
@IDDeal int
as
begin
delete from Deal where IDDeal = @IDDeal;
end
go

create proc GetDeal
@IDDeal int
as
begin
select * from Deal where IDDeal = @IDDeal;
end
go

create proc GetDeals
as
begin
select * from Deal;
end
go

/*----------------------------------------------------------------------------------------------*/

create proc AddTransaction
@Time Datetime,
@Amount money,
@UserCaffeID int
as
begin
insert into Transact (Time, Amount, UserCaffeID) values (@Time, @Amount, @UserCaffeID);
end
go

create proc UpdateTransaction
@IDTransaction int,
@Time Datetime,
@Amount money,
@UserCaffeID int
as
begin
update Transact set Time = @Time, Amount = @Amount, UserCaffeID = @UserCaffeID where IDTransaction = @IDTransaction
end
go

create proc DeleteTransaction
@IDTransaction int
as
begin
delete from Transact where IDTransaction = @IDTransaction;
end
go

create proc GetTransaction
@IDTransaction int
as
begin
select * from Transact where IDTransaction = @IDTransaction;
end
go

create proc GetTransactions
as
begin
select * from Transact;
end
go

/*----------------------------------------------------------------------------------------------*/

create proc AddFeedback
@FeedbackLog nvarchar(max)
as
begin
insert into Feedback (FeedbackLog) values (@FeedbackLog);
end
go

create proc GetFeedback
@IDFeedback int
as
begin
select * from Feedback where Feedback.IDFeedback = @IDFeedback
end
go

create proc GetFeedbacks
as
begin
select * from Feedback;
end
go


/*----------------------------------------------------------------------------------------------*/

create proc AddChallenge
@Name nvarchar(50),
@Description nvarchar(max)
as
begin
insert into Challenge (Name, Description) values (@Name, @Description);
end
go

create proc UpdateChallenge
@IDChallenge int,
@Name nvarchar(50),
@Description nvarchar(max)
as
begin
update Challenge set Name = @Name, Description = @Description where IDChallenge = @IDChallenge;
end
go

create proc DeleteChallenge
@IDChallenge int
as 
begin
delete from Challenge where IDChallenge = @IDChallenge;
end
go

create proc GetChallenges
as
begin
select * from Challenge;
end
go

create proc GetChallenge
@IDChallenge int
as
begin
select * from Challenge where IDChallenge = @IDChallenge;
end
go

/*-------------------------------------------------------------*/