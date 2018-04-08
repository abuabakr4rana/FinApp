CREATE Procedure [dbo].[SP_fin_Income](
@incomeId uniqueidentifier =null,
@amount int =null,
@createdOn datetime =null,
@createdBy int =null,
@vendorId int =null,
@deptId int =null,
@notes varchar (500)=null,
@tax1_Id int =null,
@tax1_Amount int =null,
@tax2_Id int =null,
@tax2_Amount int =null,
@consumerId int =null,
@imageUrl varchar (500)=null,
@incomeDate datetime=null,
@transGroupId	int=null,
@Flg int) as Begin 
if @Flg=1
Begin
--Declare @lastID int
--Set @lastID=IsNull((select max(incomeId) from fin_Income), 0)
--Set @incomeId=@lastID+1

insert into fin_Income output inserted.incomeId values(@incomeId,@amount,@createdOn,@createdBy,@vendorId,@deptId,@notes,@tax1_Id,@tax1_Amount,@tax2_Id,@tax2_Amount,@consumerId,@imageUrl, @incomeDate, @transGroupId) 
End
if @Flg=2
Begin
update fin_Income set amount=@amount,createdOn=@createdOn,createdBy=@createdBy,vendorId=@vendorId,deptId=@deptId,notes=@notes,tax1_Id=@tax1_Id,tax1_Amount=@tax1_Amount,tax2_Id=@tax2_Id,tax2_Amount=@tax2_Amount,consumerId=@consumerId,imageUrl=@imageUrl, incomeDate=@incomeDate, transGroupId=@transGroupId where incomeId=@incomeId 
End
if @Flg=3
Begin
delete from fin_Income where incomeId=@incomeId 
End
if @Flg=4
Begin
select * from fin_Income 
End
if @Flg=5
Begin
select * from fin_Income where incomeId=@incomeId
End

End