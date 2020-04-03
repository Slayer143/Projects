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

  alter proc AppointCandidate(
  @staffId as int)
  as
  begin tran
  if not exists(select StaffId from Staff where StaffId = @staffId)
	rollback
  else
	update AppointmentHistory
	set датаПриема = GETDATE()
	where StaffId = @staffId
	commit

  create proc GetCandidates
  as
  begin
  select Staff.StaffId, LastName, [Name], SecondName, Gender, DateOfBirth, EducationLevel, PhoneNumber, SubdivisionName, PositionName
  from Staff inner join AppointmentHistory
  on Staff.StaffId = AppointmentHistory.StaffId
  inner join Subdivision
  on AppointmentHistory.SubdivisionId = Subdivision.SubdivisionId
  inner join Position
  on AppointmentHistory.PositionId = Position.PositionId
  where AppointmentHistory.датаПриема is null
  end



