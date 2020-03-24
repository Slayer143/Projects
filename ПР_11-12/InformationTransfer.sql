use NewDb

update СотрудниткиИмпорт
set [LastName] = substring(ФИО, 1, (charindex(' ', ФИО, 0)) - 1),
ФИО = substring(ФИО, (charindex(' ', ФИО, 0)) + 1, len(фио)),
[Name] = substring(ФИО, 1, (charindex(' ', ФИО, 0)) - 1),
ФИО = substring(ФИО, (charindex(' ', ФИО, 0)) + 1, len(фио)),
[SecondName] = ФИО

select номер, [Name], [LastName], [SecondName], пол, датаРождения, образование, телефон, статус
into Staff
from СотрудниткиИмпорт

select distinct кодОтдела, названиеОтдела
into Subdivision
from СотрудниткиИмпорт

select distinct кодДолжности, названиеДолжности
into Position
from СотрудниткиИмпорт

select номер + кодДолжности as OrderNum, номер, датаПриема, датаУвольнения, кодДолжности, кодОтдела
into  AppointmentHistory
from СотрудниткиИмпорт

select кодДолжности, кодОтдела, Count(номер) as Quantity
into StaffCount
from СотрудниткиИмпорт
group by кодДолжности, кодОтдела

delete from StaffCount

update AppointmentHistory
set Orderid = StaffId * OrderId + StaffId

update ШтатИмпорт
set Subdivision = SUBSTRING(S1, 1, CHARINDEX('/', S1, 1) - 1),
S1 = SUBSTRING(S1, CHARINDEX('/', S1, 1) + 1, len(S1) - CHARINDEX('/', S1, 1)),
Quantity = SUBSTRING(S1, CHARINDEX('/', S1, 1) + 1, LEN(S1)),
Position = SUBSTRING(S1, 0, CHARINDEX('/', S1, 1))

update ШтатИмпорт
set SubdivisionId = 
(
	case 
	when Subdivision = 'Административно-управленческий персонал'
	then 1
	when Subdivision = 'Бухгалтерия'
	then 2
	when Subdivision = 'Отдел кадров'
	then 3
	when Subdivision = 'Учебная часть'
	then 4
	when Subdivision = 'Штат преподавателей'
	then 5
	end
)

insert into Position(PositionName)
select Position
from ШтатИмпорт

insert into StaffCount(PositionId, Quantity)
select Position.PositionId, ШтатИмпорт.Quantity
from Position inner join ШтатИмпорт
on Position.PositionName = ШтатИмпорт.Position

insert into StaffCount(PositionId, Quantity)
values (11, 1)

update StaffCount
set SubdivisionId = substring(CAST(PositionId as nvarchar(2)), 1, 1)

create procedure SelectSubdivision
@staffQt int
as
begin
	select Subdivision.SubdivisionName 
	from Subdivision inner join StaffCount
	on Subdivision.SubdivisionId = StaffCount.SubdivisionId
	group by StaffCount.SubdivisionId, Subdivision.SubdivisionName
	having SUM(StaffCount.Quantity) = @staffQt
end

exec SelectSubdivision 8

create procedure SelectStaffByNums
@subdivId int,
@posId int
as
begin
	select [Name], LastName, SecondName
	from Staff inner join AppointmentHistory
	on Staff.StaffId = AppointmentHistory.StaffId
	where [Status] = 'работает' 
	and PositionId = @posId
	and SubdivisionId = @subdivId
end

create procedure SelectStaffByNames
@subdiv nvarchar(30),
@pos nvarchar(30)
as
begin
	select [Name], LastName, SecondName
	from Staff inner join AppointmentHistory
	on Staff.StaffId = AppointmentHistory.StaffId
	inner join Position on Position.PositionId = AppointmentHistory.PositionId
	inner join Subdivision on Subdivision.SubdivisionId = AppointmentHistory.SubdivisionId
	where PositionName = @pos
	and SubdivisionName = @subdiv
	and [Status] = 'работает'
end

exec SelectStaffByNames 'Штат преподавателей', 'Основной препод'
exec SelectStaffByNums 5, 51
