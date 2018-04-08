CREATE Procedure [dbo].[SP_fin_Bills](
@billUid uniqueidentifier =null,
@billUserGroupId int =null,
@billUserGroupbillId int =null,
@billCreatedBy int =null,
@billCreatedOn datetime =null,
@billCreatedIP varchar (50)=null,
@billPoUid uniqueidentifier =null,
@billToEntityId int =null,
@billDate date =null,
@billPaymentTerms nvarchar (max)=null,
@billNotes nvarchar (max)=null,
@billDiscountId int =null,
@billDiscountAmount money =null,
@billStatus tinyint =null,
@billDescription nvarchar (2000)=null,
@billRefId varchar (50)=null,
@billDueDate date=null,
@Flg int) as Begin 
if @Flg=1
Begin
--Declare @lastID int
--Set @lastID=IsNull((select max(billUid) from fin_Bills), 0)
--Set @billUid=@lastID+1
Declare @newBillId int
Set @newBillId = (select IsNull(max(billUserGroupbillId), 0) from fin_Bills where billUserGroupId=@billUserGroupId)
Set @newBillId = @newBillId + 1

insert into fin_Bills output inserted.billUid values(newid(), @billUserGroupId,@newBillId,@billCreatedBy,@billCreatedOn,@billCreatedIP,@billPoUid,@billToEntityId,@billDate,@billPaymentTerms,@billNotes,@billDiscountId,@billDiscountAmount,@billStatus,@billDescription,@billRefId, @billDueDate)
End
if @Flg=2
Begin
update fin_Bills set billUserGroupId=@billUserGroupId,billUserGroupbillId=@billUserGroupbillId,billCreatedBy=@billCreatedBy,billCreatedOn=@billCreatedOn,billCreatedIP=@billCreatedIP,billPoUid=@billPoUid,billToEntityId=@billToEntityId,billDate=@billDate,billPaymentTerms=@billPaymentTerms,billNotes=@billNotes,billDiscountId=@billDiscountId,billDiscountAmount=@billDiscountAmount,billStatus=@billStatus,billDescription=@billDescription,billRefId=@billRefId, billDueDate=@billDueDate where billUid=@billUid 
End
if @Flg=3
Begin
delete from fin_Bills where billUid=@billUid 
End
if @Flg=4
Begin
select * from fin_Bills 
End
if @Flg=5
Begin
select * from fin_Bills where billUid=@billUid
End

End