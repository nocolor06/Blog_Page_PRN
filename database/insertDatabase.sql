/****** Script for SelectTopNRows command from SSMS  ******/
use PRN211_BlogSystem
select * from [User]
select * from [Blog]

-- User table
go
insert into [User](username,[password],displayName,email,dob,phoneNumber,registerAt,lastLogin)
values ('admin','123',N'Đoán xem ai','admin@gmail.com','2003-06-18','0123456789',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime))

insert into [User](username,[password],displayName,email,dob,phoneNumber,registerAt,lastLogin)
values ('giangpt','123',N'Phạm Trường Giang','nocolor06@gmail.com','2003-06-18','0123456789',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime))

insert into [User](username,[password],displayName,email,dob,phoneNumber,registerAt,lastLogin)
values ('duckm','123',N'Khiếu Minh Đức','khieuminhduc2012@gmail.com','2003-07-25','0123456789',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime))

insert into [User](username,[password],displayName,email,dob,phoneNumber,registerAt,lastLogin)
values ('huyenntk','123',N'Nguyễn Thị Khánh Huyền','hn8319542@gmail.com','2003-05-12','0123456789',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime))

insert into [User](username,[password],displayName,email,dob,phoneNumber,registerAt,lastLogin)
values ('phuonghm','123',N'Hoàng Mai Phương','maiphuonghoangmpk@gmail.com','2003-05-12','0123456789',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime))

insert into [User](username,[password],displayName,email,dob,phoneNumber,registerAt,lastLogin)
values ('antt','123',N'Triệu Thạch Ân','anlalahello@gmail.com','2003-05-12','0123456789',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime))
go
-- Role
go
insert into [Role]([name]) values ('Admin')
insert into [Role]([name]) values ('Customer')
go
-- User_Role
go
insert into [User_Role](roleId,username) values (1,'admin')
insert into [User_Role](roleId,username) values (1,'giangpt')
insert into [User_Role](roleId,username) values (2,'duckm')
insert into [User_Role](roleId,username) values (2,'phuonghm')
insert into [User_Role](roleId,username) values (2,'huyenntk')
insert into [User_Role](roleId,username) values (2,'antt')
go
-- Feature
go
go

-- User_Feature
-- Blog
go
insert into [Blog](authorName,[image],title,metaTitle,summary,content,createAt,updatedAt,noView)
values ('giangpt','1.jpg','Things I learned in 2022','Let gooo',
'I just did by myself create a very simple app "HelloWorld" of JSF 2.2 with a concrete implementation Myfaces
that we can use it later on for our further JSF trying out. I attached the source code link at the end',
'I learned that it''s important to take breaks and practice self-care to avoid burnout. It''s also important to 
communicate with colleagues and managers about workload and prioritize tasks accordingly. Finally, getting 
hands-on experience with different aspects of the business can be valuable for personal and professional growth.
One responsibility as an engineering lead is to support pre-sales by providing quick, rough estimations.
Additionally, I need to understand how the product operates in the production environment. Therefore, I sometimes
support product operation teams with configuration management. This takes time and requires practice. When I am 
doing many things in various contexts, I can easily become stressed.',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime),0)

insert into [Blog](authorName,[image],title,metaTitle,summary,content,createAt,updatedAt,noView)
values ('giangpt','2.jpg','Things I learned in 2022','Let gooo',
'I just did by myself create a very simple app "HelloWorld" of JSF 2.2 with a concrete implementation Myfaces
that we can use it later on for our further JSF trying out. I attached the source code link at the end',
'I learned that it''s important to take breaks and practice self-care to avoid burnout. It''s also important to 
communicate with colleagues and managers about workload and prioritize tasks accordingly. Finally, getting 
hands-on experience with different aspects of the business can be valuable for personal and professional growth.
One responsibility as an engineering lead is to support pre-sales by providing quick, rough estimations.
Additionally, I need to understand how the product operates in the production environment. Therefore, I sometimes
support product operation teams with configuration management. This takes time and requires practice. When I am 
doing many things in various contexts, I can easily become stressed.',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime),0)

insert into [Blog](authorName,[image],title,metaTitle,summary,content,createAt,updatedAt,noView)
values ('duckm','3.jpg','Things I learned in 2022','Let gooo',
'I just did by myself create a very simple app "HelloWorld" of JSF 2.2 with a concrete implementation Myfaces
that we can use it later on for our further JSF trying out. I attached the source code link at the end',
'I learned that it''s important to take breaks and practice self-care to avoid burnout. It''s also important to 
communicate with colleagues and managers about workload and prioritize tasks accordingly. Finally, getting 
hands-on experience with different aspects of the business can be valuable for personal and professional growth.
One responsibility as an engineering lead is to support pre-sales by providing quick, rough estimations.
Additionally, I need to understand how the product operates in the production environment. Therefore, I sometimes
support product operation teams with configuration management. This takes time and requires practice. When I am 
doing many things in various contexts, I can easily become stressed.',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime),0)

insert into [Blog](authorName,[image],title,metaTitle,summary,content,createAt,updatedAt,noView)
values ('duckm','4.jpg','Things I learned in 2022','Let gooo',
'I just did by myself create a very simple app "HelloWorld" of JSF 2.2 with a concrete implementation Myfaces
that we can use it later on for our further JSF trying out. I attached the source code link at the end',
'I learned that it''s important to take breaks and practice self-care to avoid burnout. It''s also important to 
communicate with colleagues and managers about workload and prioritize tasks accordingly. Finally, getting 
hands-on experience with different aspects of the business can be valuable for personal and professional growth.
One responsibility as an engineering lead is to support pre-sales by providing quick, rough estimations.
Additionally, I need to understand how the product operates in the production environment. Therefore, I sometimes
support product operation teams with configuration management. This takes time and requires practice. When I am 
doing many things in various contexts, I can easily become stressed.',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime),0)

insert into [Blog](authorName,[image],title,metaTitle,summary,content,createAt,updatedAt,noView)
values ('huyenntk','5.jpg','Things I learned in 2022','Let gooo',
'I just did by myself create a very simple app "HelloWorld" of JSF 2.2 with a concrete implementation Myfaces
that we can use it later on for our further JSF trying out. I attached the source code link at the end',
'I learned that it''s important to take breaks and practice self-care to avoid burnout. It''s also important to 
communicate with colleagues and managers about workload and prioritize tasks accordingly. Finally, getting 
hands-on experience with different aspects of the business can be valuable for personal and professional growth.
One responsibility as an engineering lead is to support pre-sales by providing quick, rough estimations.
Additionally, I need to understand how the product operates in the production environment. Therefore, I sometimes
support product operation teams with configuration management. This takes time and requires practice. When I am 
doing many things in various contexts, I can easily become stressed.',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime),0)

insert into [Blog](authorName,[image],title,metaTitle,summary,content,createAt,updatedAt,noView)
values ('huyenntk','6.jpg','Things I learned in 2022','Let gooo',
'I just did by myself create a very simple app "HelloWorld" of JSF 2.2 with a concrete implementation Myfaces
that we can use it later on for our further JSF trying out. I attached the source code link at the end',
'I learned that it''s important to take breaks and practice self-care to avoid burnout. It''s also important to 
communicate with colleagues and managers about workload and prioritize tasks accordingly. Finally, getting 
hands-on experience with different aspects of the business can be valuable for personal and professional growth.
One responsibility as an engineering lead is to support pre-sales by providing quick, rough estimations.
Additionally, I need to understand how the product operates in the production environment. Therefore, I sometimes
support product operation teams with configuration management. This takes time and requires practice. When I am 
doing many things in various contexts, I can easily become stressed.',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime),0)

insert into [Blog](authorName,[image],title,metaTitle,summary,content,createAt,updatedAt,noView)
values ('phuonghm','7.jpg','Things I learned in 2022','Let gooo',
'I just did by myself create a very simple app "HelloWorld" of JSF 2.2 with a concrete implementation Myfaces
that we can use it later on for our further JSF trying out. I attached the source code link at the end',
'I learned that it''s important to take breaks and practice self-care to avoid burnout. It''s also important to 
communicate with colleagues and managers about workload and prioritize tasks accordingly. Finally, getting 
hands-on experience with different aspects of the business can be valuable for personal and professional growth.
One responsibility as an engineering lead is to support pre-sales by providing quick, rough estimations.
Additionally, I need to understand how the product operates in the production environment. Therefore, I sometimes
support product operation teams with configuration management. This takes time and requires practice. When I am 
doing many things in various contexts, I can easily become stressed.',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime),0)

insert into [Blog](authorName,[image],title,metaTitle,summary,content,createAt,updatedAt,noView)
values ('phuonghm','8.jpg','Things I learned in 2022','Let gooo',
'I just did by myself create a very simple app "HelloWorld" of JSF 2.2 with a concrete implementation Myfaces
that we can use it later on for our further JSF trying out. I attached the source code link at the end',
'I learned that it''s important to take breaks and practice self-care to avoid burnout. It''s also important to 
communicate with colleagues and managers about workload and prioritize tasks accordingly. Finally, getting 
hands-on experience with different aspects of the business can be valuable for personal and professional growth.
One responsibility as an engineering lead is to support pre-sales by providing quick, rough estimations.
Additionally, I need to understand how the product operates in the production environment. Therefore, I sometimes
support product operation teams with configuration management. This takes time and requires practice. When I am 
doing many things in various contexts, I can easily become stressed.',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime),0)

insert into [Blog](authorName,[image],title,metaTitle,summary,content,createAt,updatedAt,noView)
values ('antt','9.jpg','Things I learned in 2022','Let gooo',
'I just did by myself create a very simple app "HelloWorld" of JSF 2.2 with a concrete implementation Myfaces
that we can use it later on for our further JSF trying out. I attached the source code link at the end',
'I learned that it''s important to take breaks and practice self-care to avoid burnout. It''s also important to 
communicate with colleagues and managers about workload and prioritize tasks accordingly. Finally, getting 
hands-on experience with different aspects of the business can be valuable for personal and professional growth.
One responsibility as an engineering lead is to support pre-sales by providing quick, rough estimations.
Additionally, I need to understand how the product operates in the production environment. Therefore, I sometimes
support product operation teams with configuration management. This takes time and requires practice. When I am 
doing many things in various contexts, I can easily become stressed.',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime),0)

insert into [Blog](authorName,[image],title,metaTitle,summary,content,createAt,updatedAt,noView)
values ('antt','10.jpg','Things I learned in 2022','Let gooo',
'I just did by myself create a very simple app "HelloWorld" of JSF 2.2 with a concrete implementation Myfaces
that we can use it later on for our further JSF trying out. I attached the source code link at the end',
'I learned that it''s important to take breaks and practice self-care to avoid burnout. It''s also important to 
communicate with colleagues and managers about workload and prioritize tasks accordingly. Finally, getting 
hands-on experience with different aspects of the business can be valuable for personal and professional growth.
One responsibility as an engineering lead is to support pre-sales by providing quick, rough estimations.
Additionally, I need to understand how the product operates in the production environment. Therefore, I sometimes
support product operation teams with configuration management. This takes time and requires practice. When I am 
doing many things in various contexts, I can easily become stressed.',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime),0)

insert into [Blog](authorName,[image],title,metaTitle,summary,content,createAt,updatedAt,noView)
values ('admin','11.jpg','Things I learned in 2022','Let gooo',
'I just did by myself create a very simple app "HelloWorld" of JSF 2.2 with a concrete implementation Myfaces
that we can use it later on for our further JSF trying out. I attached the source code link at the end',
'I learned that it''s important to take breaks and practice self-care to avoid burnout. It''s also important to 
communicate with colleagues and managers about workload and prioritize tasks accordingly. Finally, getting 
hands-on experience with different aspects of the business can be valuable for personal and professional growth.
One responsibility as an engineering lead is to support pre-sales by providing quick, rough estimations.
Additionally, I need to understand how the product operates in the production environment. Therefore, I sometimes
support product operation teams with configuration management. This takes time and requires practice. When I am 
doing many things in various contexts, I can easily become stressed.',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime),0)

insert into [Blog](authorName,[image],title,metaTitle,summary,content,createAt,updatedAt,noView)
values ('admin','12.jpg','Things I learned in 2022','Let gooo',
'I just did by myself create a very simple app "HelloWorld" of JSF 2.2 with a concrete implementation Myfaces
that we can use it later on for our further JSF trying out. I attached the source code link at the end',
'I learned that it''s important to take breaks and practice self-care to avoid burnout. It''s also important to 
communicate with colleagues and managers about workload and prioritize tasks accordingly. Finally, getting 
hands-on experience with different aspects of the business can be valuable for personal and professional growth.
One responsibility as an engineering lead is to support pre-sales by providing quick, rough estimations.
Additionally, I need to understand how the product operates in the production environment. Therefore, I sometimes
support product operation teams with configuration management. This takes time and requires practice. When I am 
doing many things in various contexts, I can easily become stressed.',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime),0)

insert into [Blog](authorName,[image],title,metaTitle,summary,content,createAt,updatedAt,noView)
values ('giangpt','13.jpg','Things I learned in 2022','Let gooo',
'I just did by myself create a very simple app "HelloWorld" of JSF 2.2 with a concrete implementation Myfaces
that we can use it later on for our further JSF trying out. I attached the source code link at the end',
'I learned that it''s important to take breaks and practice self-care to avoid burnout. It''s also important to 
communicate with colleagues and managers about workload and prioritize tasks accordingly. Finally, getting 
hands-on experience with different aspects of the business can be valuable for personal and professional growth.
One responsibility as an engineering lead is to support pre-sales by providing quick, rough estimations.
Additionally, I need to understand how the product operates in the production environment. Therefore, I sometimes
support product operation teams with configuration management. This takes time and requires practice. When I am 
doing many things in various contexts, I can easily become stressed.',
CAST(N'2022-07-12 13:00:09.000' AS DateTime),CAST(N'2022-07-12 13:00:09.000' AS DateTime),0)
go

-- Category
go
insert into [Category](title) values ('LifeStyle')
insert into [Category](title) values ('Fashion')
insert into [Category](title) values ('Nature')
insert into [Category](title) values ('Healthy')
insert into [Category](title) values ('Soft Skills')
insert into [Category](title) values ('Clean Code')
go

-- Book_Category
go
insert into [Blog_Category](blogId,categoryId) values (1,1)
insert into [Blog_Category](blogId,categoryId) values (1,2)
insert into [Blog_Category](blogId,categoryId) values (2,2)
insert into [Blog_Category](blogId,categoryId) values (2,3)
insert into [Blog_Category](blogId,categoryId) values (3,3)
insert into [Blog_Category](blogId,categoryId) values (4,4)
insert into [Blog_Category](blogId,categoryId) values (5,5)
insert into [Blog_Category](blogId,categoryId) values (6,6)
insert into [Blog_Category](blogId,categoryId) values (7,1)
insert into [Blog_Category](blogId,categoryId) values (8,2)
insert into [Blog_Category](blogId,categoryId) values (9,3)
insert into [Blog_Category](blogId,categoryId) values (10,4)
insert into [Blog_Category](blogId,categoryId) values (11,5)
insert into [Blog_Category](blogId,categoryId) values (12,6)
insert into [Blog_Category](blogId,categoryId) values (13,1)
go

-- Tags
go
insert into [Tag](title) values ('How to live')
insert into [Tag](title) values ('Life')
insert into [Tag](title) values ('Love')
insert into [Tag](title) values ('Spend goods')
insert into [Tag](title) values ('Coop')
insert into [Tag](title) values ('Live a good life')
insert into [Tag](title) values ('Happy')
go

-- Book_Tag
go
insert into [Blog_Tag](blogId,tagId) values (1,1)
insert into [Blog_Tag](blogId,tagId) values (1,2)
insert into [Blog_Tag](blogId,tagId) values (2,2)
insert into [Blog_Tag](blogId,tagId) values (2,3)
insert into [Blog_Tag](blogId,tagId) values (3,3)
insert into [Blog_Tag](blogId,tagId) values (4,4)
insert into [Blog_Tag](blogId,tagId) values (5,5)
insert into [Blog_Tag](blogId,tagId) values (6,6)
insert into [Blog_Tag](blogId,tagId) values (7,7)
insert into [Blog_Tag](blogId,tagId) values (8,1)
insert into [Blog_Tag](blogId,tagId) values (9,2)
insert into [Blog_Tag](blogId,tagId) values (10,3)
insert into [Blog_Tag](blogId,tagId) values (11,4)
insert into [Blog_Tag](blogId,tagId) values (12,5)
insert into [Blog_Tag](blogId,tagId) values (13,6)
go
