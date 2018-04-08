CREATE Procedure [dbo].[SP_fin_Departments](
@deptId int =null,
@deptTitle nvarchar (100)=null,
@deptCode varchar (5)=null,
@deptDescription varchar (500)=null,
@Flg int) as Begin 
if @Flg=1
Begin
Declare @lastID int
Set @lastID=IsNull((select max(deptId) from fin_Departments), 0)
Set @deptId=@lastID+1
insert into fin_Departments output inserted.deptId values(@deptId, @deptTitle,@deptCode,@deptDescription) 
End
if @Flg=2
Begin
update fin_Departments set deptTitle=@deptTitle,deptCode=@deptCode,deptDescription=@deptDescription where deptId=@deptId 
End
if @Flg=3
Begin
delete from fin_Departments where deptId=@deptId 
End
if @Flg=4
Begin
select *, IsNull(deptDescription, 'N / A') as deptDesc from fin_Departments 
End
if @Flg=5
Begin
select * from fin_Departments where deptId=@deptId
End

End