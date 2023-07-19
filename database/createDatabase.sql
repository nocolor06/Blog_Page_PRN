 -- create database PRN211_BlogSystem

use PRN211_BlogSystem
create table [User](
	username varchar(100) not null,
	[password] varchar(100) not null,
	displayName nvarchar(255) not null,
	email nvarchar(100) not null,
	dob date not null,
	phoneNumber nvarchar(100) not null,
	registerAt datetime not null,
	lastLogin datetime not null,
	constraint PK_User primary key(username)
)

create table [Role](
	id int identity(1,1) not null,
	[name] varchar(100) not null,
	constraint PK_Role primary key (id)
)

create table User_Role(
	username varchar(100) foreign key references [User](username) not null,
	roleId int foreign key references [Role](id) not null,
	constraint PK_User_Role primary key(username,roleId)
)

create table Feature(
	id int identity(1,1) not null,
	[name] varchar(100) not null,
	constraint PK_Feature primary key (id)
)

create table Role_Feature(
	roleId int foreign key references [Role](id),
	featureId int foreign key references [Feature](id) ,
	constraint PK_Role_Feature primary key(roleId,featureId)
)
create table Category(
	id int identity(1,1) not null,
	title nvarchar(255) not null,
	constraint PK_Category primary key (id) 
)

create table [Blog](
	id int identity(1,1) not null,
	authorName varchar(100) foreign key references [User](username) not null,
	[image] varchar(255),
	title nvarchar(255) not null,
	metaTitle nvarchar(255) ,
	summary nvarchar(255) not null,
	content text not null,
	createAt datetime not null,
	updatedAt datetime not null,
	noView int ,
	categoryId int not null foreign key references [Category](id),
	constraint PK_Blog primary key(id)

)



create table Comment(
	id int identity(1,1) not null,
	blogId int foreign key references Blog(id) not null,
	authorName varchar(100) foreign key references [User](username) not null,
	content text not null,
	createAt datetime not null,
	constraint PK_Comment primary key(id)
)

