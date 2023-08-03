create database socialNetwork;

use socialNetwork;

create table Users(
userID			int				primary key identity(1,1),
userFirstName	nvarchar(20)	not null,
userLastName	nvarchar(20)	not null,
userUserName	nvarchar(20)	not null,
userPassword	nvarchar(20)	not null,
userEmail		nvarchar(30),
userGender		nvarchar(10),
userPhone		int,
userPhoto		nvarchar(300),
userDOB			nvarchar(20),
userCity		nvarchar(20),
userState		nvarchar(30),
userCountry		nvarchar(20)
);

create table Messages(
messageID		int			primary key	identity(1,1),
fromUserID		int,
toUserID		int,
currentUserMessage	nvarchar(100),
foreign key(fromUserID) references Users(userID),
foreign key(toUserID) references Users(userID)
);

create table Friends(
friendID		int		primary key	identity(1,1),
userID			int,
friendOfID		int,
foreign key(userID) references Users(userID),
foreign key(friendOfID) references Users(userID)
);
insert into Friends(userID, friendOfID) values(1, 2),(1,3),(2,3);
create table Posts(
postID		int		primary key	identity(1,1),
postCaption	nvarchar(100),
postImg		nvarchar(300),
posterID	int,
posterName	nvarchar(30),
foreign key(posterID) references Users(userID)
);

select * from Users;
select*from Friends;
select * from Messages;
select * from Posts;
drop table Messages;
drop table Friends;
drop table Posts;
drop table Users;