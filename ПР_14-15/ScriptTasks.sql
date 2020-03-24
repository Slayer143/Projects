  alter proc DeleteAllForOne(
  @num as int,
  @logical as int)
  as
  begin tran
  delete 
  from AppointmentHistory
  where Staffid =  @num
  if @logical = 0
  rollback
  else
  commit
  select *
  from AppointmentHistory

  exec DeleteAllForOne 1, 1

  begin transaction
  select *
  from AppointmentHistory
  rollback 

  alter proc AddCandidate(
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
  begin tran
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
	
	if @posId < 0 and @subId < 0
	rollback
	else
	commit
