
update Sh1
set ������ = '�������������'
where ������ = '������������'

update Sh1
set a1 = ������

update Sh1
set a1 = 
(
	select ShoppingCentersStatuses.StatusId
	from ShoppingCentersStatuses
	where Sh1.a1 = ShoppingCentersStatuses.[Status]
)

update Sh1
set ������ = a1

update Sh1
set ����� = 
(
	select Cities.CityId
	from Cities
	where Sh1.����� = Cities.[Name] 
)

insert into ShoppingCenters
select [��� ��], ��������, ������, [���# ����������], �����, ���������, [����# ���������� ���������], ���������, �����������
from Sh1

insert into EmployeesRoles
values(1, '�������������'),
(2, '�������� �'),
(3, '�������� �'),
(4, '������')

insert into PavilionsStatuses
values(1, '��������'),
(2, '�������������'),
(3, '������'),
(4, '���������')

insert into RentStatuses
values(1, '������'),
(2, '��������'),
(3, '������')

update Sh1
set a1 = ���

update Sh1
set a1 = SUBSTRING(a1, 1, CHARINDEX('*', a1, 1) - 1)

update Sh1
set a2 = ���

update Sh1
set a2 = SUBSTRING(a2, CHARINDEX('*', a2, 1) + 1, len(a2) - CHARINDEX('*', a2, 1))

update Sh1
set a3 = a2

update Sh1
set a2 = SUBSTRING(a2, 1, CHARINDEX('*', a2, 1) - 1)

update Sh1
set a3 = ���

update Sh1
set a3 = SUBSTRING(a3, CHARINDEX('*', a3, 1) + 1, len(a3) - CHARINDEX('*', a3, 1))

update Sh1
set ���� = 
(
	select EmployeesRoles.RoleId
	from EmployeesRoles
	where Sh1.���� = EmployeesRoles.Role
)

insert into Employees
select ID, ���, [����� ��������], ������, �����, a1, a2, a3, ����, ����
from Sh1

update Sh2
set [�������� ��] = 
(
	select ShoppingCenters.CenterId
	from ShoppingCenters
	where Sh2.[�������� ��] = ShoppingCenters.[Name]
)

update Sh2
set ������ = 
(
	select PavilionsStatuses.StatusId
	from PavilionsStatuses
	where Sh2.������ = PavilionsStatuses.[Status]
)

insert into Pavilions
select ���, [�������� ��], [� ���������], ����, ������, �������, [��������� �� ��#�], [����# ���������� ���������]
from Sh2

insert into Tenants
select [ID ����������], [�������� ], �����, �����
from Sh3
where [ID ����������] is not null

update Sh4
set ������ = 
(
	select RentStatuses.StatusId
	from RentStatuses
	where Sh4.������ = RentStatuses.[Status]
)

update Sh4
set [� ���������] = 
(
	select Pavilions.PavilionId
	from Pavilions
	where Sh4.[� ���������] = PavilionNumber
	and Sh4.[� ���������] is not null
)

update Sh4
set [�������� ��] = 
(
	select ShoppingCenters.CenterId
	from ShoppingCenters
	where Sh4.[�������� ��] = ShoppingCenters.[Name]
)

insert into Rent
select [ID ������], [ID ����������], [�������� ��], [ID ���������], [� ���������], ������, [������ ������], [��������� ������]
from Sh4
where [ID ������] is not null