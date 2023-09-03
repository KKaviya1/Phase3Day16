Create database PlayersDb
use PlayersDb

Create Table Team
(TeamId int primary key,
TeamName nvarchar(50) not null unique)

Create table Player
(PlayerId int primary key,
PlayerName nvarchar(50) not null,
PlayerType nvarchar(50) not null,
PlayerTeam int foreign key references Team(TeamId))

Insert into Team Values (1,'CSk'),(2,'RCB'),(3,'KKR'),(4,'DC')

Insert Into Player Values
(1,'MSD','WicketKeeper/Bat',1),
(2,'Virat Kohli','Bat',2),
(3,'M.Siraj','Ball',2)