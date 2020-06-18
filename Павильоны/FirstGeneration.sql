use master

drop database if exists PavilionsDb
go
create database PavilionsDb
go

use PavilionsDb

create table Cities
(
	CityId int not null,
	[Name] nvarchar(20) not null,
	constraint Cities_PK primary key clustered (CityId)
)

create table Tenants
(
	TenantId int not null,
	[Name] nvarchar(40) not null,
	Phone nvarchar(16) not null,
	CityId int not null,
	Street nvarchar(20) not null,
	House nvarchar(5) not null,
	constraint Tenants_PK primary key clustered (TenantID),
	constraint Tenants_Cities_FK foreign key (CityId)
	references Cities(CityId)
)

create table EmployeesRoles
(
	RoleId int not null,
	[Role] nvarchar(20),
	constraint EmployeesRoles_PK primary key clustered (RoleId)
)

create table Employees
(
	EmployeeId int not null,
	Gender char not null,
	Phone nvarchar(16) not null,
	[Password] nvarchar(10) not null,
	[Login] nvarchar(20) not null,
	LastName nvarchar(15) not null,
	[Name] nvarchar(15) not null,
	SecondName nvarchar(15) not null,
	Photo varbinary(MAX) null,
	RoleId int not null,
	constraint Employees_PK primary key clustered (EmployeeId),
	constraint Employees_EmployeesRoles_FK foreign key (RoleId)
	references EmployeesRoles(RoleId) 
)

create table RentStatuses
(
	StatusId int not null,
	[Status] nvarchar(20) not null,
	constraint RentStatuses_PK primary key clustered (StatusId)
)

create table PavilionsStatuses
(
	StatusId int not null,
	[Status] nvarchar(20) not null,
	constraint PavilionsStatuses_PK primary key clustered (StatusId)
)

create table ShoppingCentersStatuses
(
	StatusId int not null,
	[Status] nvarchar(20) not null,
	constraint ShoppingCentersStatuses_PK primary key clustered (StatusId)
)

create table ShoppingCenters
(
	CenterId int not null,
	[Name] nvarchar(30) not null,
	StatusId int not null,
	PavilionsQuantity int not null,
	CityId int not null,
	Cost money not null,
	ValueFactor decimal not null,
	FloorsQuantity int not null,
	[Image] varbinary(MAX) null,
	constraint ShoppingCenters_PK primary key clustered (CenterId),
	constraint ShoppingCenters_ShoppingCentersStatuses_FK foreign key (StatusId)
	references ShoppingCentersStatuses(StatusId),
	constraint SHoppingCenters_Cities_FK foreign key (CityId)
	references Cities(CityId)
)

create table Pavilions
(
	PavilionId int not null,
	CenterId int not null,
	PavilionNumber nvarchar(3) not null,
	[Floor] int not null,
	StatusId int not null,
	[Square] decimal not null,
	CostPerSquare decimal not null,
	ValueFactor decimal not null,
	constraint Pavilions_PK primary key clustered (PavilionId),
	constraint Pavilions_ShoppingCenters_FK foreign key (CenterId)
	references ShoppingCenters(CenterId),
	constraint Pavilions_PavilionsStatuses_FK foreign key (StatusId)
	references PavilionsStatuses(StatusId)
)

create table Rent
(
	RentId int not null,
	TenantId int not null,
	CenterId int not null,
	EmployeeId int not null,
	PavilionId int not null,
	StatusId int not null,
	RentalStart datetimeoffset(7) not null,
	RentalEnd datetimeoffset(7) not null,
	constraint Rent_PK primary key clustered (RentId),
	constraint Rent_Tenants_FK foreign key (TenantId)
	references Tenants(TenantId),
	constraint Rent_ShoppingCenters_FK foreign key (CenterId)
	references ShoppingCenters(CenterId),
	constraint Rent_Employees_FK foreign key (EmployeeId)
	references Employees(EmployeeId),
	constraint Rent_Pavilions_FK foreign key (PavilionId)
	references Pavilions(PavilionId),
	constraint Rent_RentStatuses_FK foreign key (StatusId)
	references RentStatuses(StatusId)
)