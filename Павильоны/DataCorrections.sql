
update Sh1
set Статус = 'Строительство'
where Статус = 'Строительсто'

update Sh1
set a1 = Статус

update Sh1
set a1 = 
(
	select ShoppingCentersStatuses.StatusId
	from ShoppingCentersStatuses
	where Sh1.a1 = ShoppingCentersStatuses.[Status]
)

update Sh1
set Статус = a1

update Sh1
set Город = 
(
	select Cities.CityId
	from Cities
	where Sh1.Город = Cities.[Name] 
)

insert into ShoppingCenters
select [Код ТЦ], Название, Статус, [Кол# Повильонов], Город, Стоимость, [Кооф# Добавочной Стоимости], Этажность, Изображение
from Sh1

insert into EmployeesRoles
values(1, 'Администратор'),
(2, 'Менеджер А'),
(3, 'Менеджер С'),
(4, 'Удален')

insert into PavilionsStatuses
values(1, 'Свободен'),
(2, 'Забронировано'),
(3, 'Удален'),
(4, 'Арендован')

insert into RentStatuses
values(1, 'Открыт'),
(2, 'Ожидание'),
(3, 'Закрыт')

update Sh1
set a1 = ФИО

update Sh1
set a1 = SUBSTRING(a1, 1, CHARINDEX('*', a1, 1) - 1)

update Sh1
set a2 = ФИО

update Sh1
set a2 = SUBSTRING(a2, CHARINDEX('*', a2, 1) + 1, len(a2) - CHARINDEX('*', a2, 1))

update Sh1
set a3 = a2

update Sh1
set a2 = SUBSTRING(a2, 1, CHARINDEX('*', a2, 1) - 1)

update Sh1
set a3 = ФИО

update Sh1
set a3 = SUBSTRING(a3, CHARINDEX('*', a3, 1) + 1, len(a3) - CHARINDEX('*', a3, 1))

update Sh1
set Роль = 
(
	select EmployeesRoles.RoleId
	from EmployeesRoles
	where Sh1.Роль = EmployeesRoles.Role
)

insert into Employees
select ID, Пол, [Номер телефона], Пароль, Логин, a1, a2, a3, Фото, Роль
from Sh1

update Sh2
set [Название ТЦ] = 
(
	select ShoppingCenters.CenterId
	from ShoppingCenters
	where Sh2.[Название ТЦ] = ShoppingCenters.[Name]
)

update Sh2
set Статус = 
(
	select PavilionsStatuses.StatusId
	from PavilionsStatuses
	where Sh2.Статус = PavilionsStatuses.[Status]
)

insert into Pavilions
select Код, [Название ТЦ], [№ Павильона], Этаж, Статус, Площадь, [Стоимость за кв#м], [Кооф# Добавочной стоимости]
from Sh2

insert into Tenants
select [ID Арендатора], [Название ], Номер, Адрес
from Sh3
where [ID Арендатора] is not null

update Sh4
set Статус = 
(
	select RentStatuses.StatusId
	from RentStatuses
	where Sh4.Статус = RentStatuses.[Status]
)

update Sh4
set [№ Павильона] = 
(
	select Pavilions.PavilionId
	from Pavilions
	where Sh4.[№ Павильона] = PavilionNumber
	and Sh4.[№ Павильона] is not null
)

update Sh4
set [Название ТЦ] = 
(
	select ShoppingCenters.CenterId
	from ShoppingCenters
	where Sh4.[Название ТЦ] = ShoppingCenters.[Name]
)

insert into Rent
select [ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], Статус, [Начало Аренды], [Окончание Аренды]
from Sh4
where [ID Аренды] is not null