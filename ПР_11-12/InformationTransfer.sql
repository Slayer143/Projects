use NewDb

update �����������������
set [LastName] = substring(���, 1, (charindex(' ', ���, 0)) - 1),
��� = substring(���, (charindex(' ', ���, 0)) + 1, len(���)),
[Name] = substring(���, 1, (charindex(' ', ���, 0)) - 1),
��� = substring(���, (charindex(' ', ���, 0)) + 1, len(���)),
[SecondName] = ���

select �����, [Name], [LastName], [SecondName], ���, ������������, �����������, �������, ������
into Staff
from �����������������

select distinct ���������, ��������������
into Subdivision
from �����������������

select distinct ������������, �����������������
into Position
from �����������������

select ����� + ������������ as OrderNum, �����, ����������, ��������������, ������������, ���������
into  AppointmentHistory
from �����������������

select ������������, ���������, Count(�����) as Quantity
into StaffCount
from �����������������
group by ������������, ���������

delete from StaffCount

update AppointmentHistory
set Orderid = StaffId * OrderId + StaffId

update ����������
set Subdivision = SUBSTRING(S1, 1, CHARINDEX('/', S1, 1) - 1),
S1 = SUBSTRING(S1, CHARINDEX('/', S1, 1) + 1, len(S1) - CHARINDEX('/', S1, 1)),
Quantity = SUBSTRING(S1, CHARINDEX('/', S1, 1) + 1, LEN(S1)),
Position = SUBSTRING(S1, 0, CHARINDEX('/', S1, 1))

update ����������
set SubdivisionId = 
(
	case 
	when Subdivision = '���������������-�������������� ��������'
	then 1
	when Subdivision = '�����������'
	then 2
	when Subdivision = '����� ������'
	then 3
	when Subdivision = '������� �����'
	then 4
	when Subdivision = '���� ��������������'
	then 5
	end
)

insert into Position(PositionName)
select Position
from ����������

insert into StaffCount(PositionId, Quantity)
select Position.PositionId, ����������.Quantity
from Position inner join ����������
on Position.PositionName = ����������.Position

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
	where [Status] = '��������' 
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
	and [Status] = '��������'
end

exec SelectStaffByNames '���� ��������������', '�������� ������'
exec SelectStaffByNums 5, 51
