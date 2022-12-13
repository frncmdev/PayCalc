

-- drop database if exists paycalc_db
-- go

-- create database paycalc_db
-- go
use paycalc_db
go 

create table [day] (
    [DayID] int PRIMARY KEY IDENTITY(1,1),
    [DayName] NVARCHAR(9) not null 
)
create table [awardType] (
    [AwardTypeID] int PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50) not null,
    [Description] NVARCHAR(250) not null
)
create table [user]
(
    userID int PRIMARY KEY IDENTITY(1,1),
    username NVARCHAR(50) not null,
    password NVARCHAR(MAX) not null , -- we are hashing the [Expletive Redacted] out of this, liberals
    salt NVARCHAR(32) not null,
    email NVARCHAR(100) not null,
    dateOfBirth DATE not null,
    fullname NVARCHAR(100) not null ,
    baseRate float not null 
)
create table [award]
(
    awardID int PRIMARY KEY IDENTITY(25001,1),
    Multiplier FLOAT not null,
    awardTypeID int,
    userID int,
    CONSTRAINT FK_AwardType_Award
        FOREIGN KEY (awardTypeID) REFERENCES awardType,
    CONSTRAINT FK_User_Award
        FOREIGN KEY (UserID) REFERENCES [user]
)
create table [Week]
(
    weekID int PRIMARY KEY IDENTITY(50001,1),
    totalPay float, 
    userID int,
    CONSTRAINT FK_User_Week
        foreign key (userID) REFERENCES [user]

)
create table [workDay]
(
    wordDayID int PRIMARY KEY IDENTITY(75001,1),
    BaseHours float,
    AwardHours float,
    weekID int not null,
    AwardID int not null,
    CONSTRAINT FK_Week_WorkDay
        FOREIGN KEY (weekID) REFERENCES Week,
    Constraint FK_Award_WorkDay
        FOREIGN KEY (awardID) references award

)
insert into [day] (DayName) Values 
('Monday'),
('Tuesday'),
('Wednesday'),
('Thursday'),
('Friday'),
('Saturday'),
('Sunday');
insert into awardType ([name], [description]) values 
('Saturday Rate', 'The extra hourly pay you get from working a Saturday'),
('Sunday Rate', 'The extra hourly pay you get from working a Sunday'),
('Casual Loading','The pay you get while working as casual'),
('Public Holiday','The pay you get from working on a public holiday'),
('Other','Other forms of awards that up your pay');
