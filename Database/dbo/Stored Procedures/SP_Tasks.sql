CREATE Procedure [dbo].[SP_Tasks](
@taskId uniqueidentifier =null,
@userId int =null,
@taskTitle varchar(MAX)=null,
@taskDescription varchar(MAX)=null,
@taskCreatedBy int =null,
@taskCreatedOn datetime =null,
@taskCreatedIP varchar (50)=null,
@taskType tinyint =null,
@taskStatus tinyint =null,
@taskLastUpdatedOn datetime =null,
@taskLastUpdatedBy int =null,
@taskLastUpdatedIP varchar (50)=null,
@Flg int) as Begin 
if @Flg=1
Begin
--Declare @lastID int
--Set @lastID=IsNull((select max(taskId) from fin_Tasks), 0)
--Set @taskId=@lastID+1

insert into fin_Tasks output inserted.taskId values(@taskId,@userId,@taskTitle,@taskDescription,@taskCreatedBy,@taskCreatedOn,@taskCreatedIP,@taskType,@taskStatus,@taskLastUpdatedOn,@taskLastUpdatedBy,@taskLastUpdatedIP) 
End
if @Flg=2
Begin
update fin_Tasks set userId=@userId,taskTitle=@taskTitle,taskDescription=@taskDescription,taskCreatedBy=@taskCreatedBy,taskCreatedOn=@taskCreatedOn,taskCreatedIP=@taskCreatedIP,taskType=@taskType,taskStatus=@taskStatus,taskLastUpdatedOn=@taskLastUpdatedOn,taskLastUpdatedBy=@taskLastUpdatedBy,taskLastUpdatedIP=@taskLastUpdatedIP where taskId=@taskId 
End
if @Flg=3
Begin
delete from fin_Tasks where taskId=@taskId 
End
if @Flg=4
Begin
select * from fin_Tasks 
End
if @Flg=5
Begin
select * from fin_Tasks where taskId=@taskId
End

End