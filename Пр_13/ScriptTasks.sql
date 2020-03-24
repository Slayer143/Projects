
  select SubdivisionId, PositionId, Count(Staff.StaffId) as 'Занято'
  from AppointmentHistory inner join Staff
  on AppointmentHistory.StaffId = Staff.StaffId
  where Status = 'работает'
  group by PositionId, SubdivisionId

  create proc GetSubdivisionId(
  @subName as nvarchar(40))
  as
  begin
	select SubdivisionId
	from Subdivision
	where SubdivisionName = @subName
  end

  create proc GetPositionId(
  @posName as nvarchar(40))
  as
  begin
	select PositionId
	from Position
	where PositionName = @posName
  end

  create proc AddCandidate(
  @staffId as int,
  @name as nvarchar(40),
  @lName as nvarchar(40),
  @sName as nvarchar(40),
  @gender as nvarchar(1),
  @dateOfBirth as date,
  @edLevel as nvarchar(60),
  @phoneNum as nvarchar(13),
  @subId as int,
  @posId as int)
  as
  begin
  insert into Staff
  values(
	@staffId,
	@name,
	@lName,
	@sName,
	@gender,
	@dateOfBirth,
	@edLevel,
	@phoneNum,
	'рассматривается')

  insert into AppointmentHistory(OrderId, StaffId, PositionId, SubdivisionId)
  values(
	(select MAX(OrderId) + 64
	from AppointmentHistory),
	@staffId,
	@posId,
	@subId)
  end

  alter proc FindVacancies
  as
  begin
  select Subdivision.SubdivisionName, Position.PositionName, StaffCount.Quantity - Count(AppointmentHistory.StaffId) as 'Free'
  from AppointmentHistory inner join Staff
  on AppointmentHistory.StaffId = Staff.StaffId
  right join StaffCount
  on StaffCount.PositionId = AppointmentHistory.PositionId
  inner join Position
  on Position.PositionId = StaffCount.PositionId
   inner join Subdivision
  on Subdivision.SubdivisionId = StaffCount.SubdivisionId
  group by StaffCount.PositionId, StaffCount.SubdivisionId, StaffCount.Quantity, Subdivision.SubdivisionName, Position.PositionName
  having StaffCount.Quantity - Count(AppointmentHistory.StaffId) > 0
  end

