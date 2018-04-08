CREATE Procedure [dbo].[SP_fin_Invoices](
@invUid uniqueidentifier =null,
@invUserGroupId int =null,
@invUserGroupInvId int =null,
@invCreatedBy int =null,
@invCreatedOn datetime =null,
@invCreatedIP varchar (50)=null,
@invPoUid uniqueidentifier =null,
@invToEntityId int =null,
@invDate date =null,
@invPaymentTerms nvarchar (max)=null,
@invNotes nvarchar (max)=null,
@invDiscountId int =null,
@invDiscountAmount money =null,
@invStatus tinyint =null,
@invDescription nvarchar (2000)=null,
@invRefId varchar(50)=null,
@invDueDate date=null,
@Flg int) as Begin 
if @Flg=1
Begin
--Declare @lastID int
--Set @lastID=IsNull((select max(invUid) from fin_Invoices), 0)
--Set @invUid=@lastID+1
Declare @newInvId int
Set @newInvId = (select IsNull(max(invUserGroupInvId), 0) from fin_Invoices where invUserGroupId=@invUserGroupId)
Set @newInvId = @newInvId + 1
insert into fin_Invoices output inserted.invUid values(newid(),@invUserGroupId,@newInvId,@invCreatedBy,@invCreatedOn,@invCreatedIP,@invPoUid,@invToEntityId,@invDate,@invPaymentTerms,@invNotes,@invDiscountId,@invDiscountAmount,@invStatus,@invDescription,@invRefId, @invDueDate)
End
if @Flg=2
Begin
update fin_Invoices set invUserGroupId=@invUserGroupId,invUserGroupInvId=@invUserGroupInvId,invCreatedBy=@invCreatedBy,invCreatedOn=@invCreatedOn,invCreatedIP=@invCreatedIP,invPoUid=@invPoUid,invToEntityId=@invToEntityId,invDate=@invDate,invPaymentTerms=@invPaymentTerms,invNotes=@invNotes,invDiscountId=@invDiscountId,invDiscountAmount=@invDiscountAmount,invStatus=@invStatus,invDescription=@invDescription,invRefId=@invRefId, invDueDate=@invDueDate where invUid=@invUid 
End
if @Flg=3
Begin
delete from fin_Invoices where invUid=@invUid 
End
if @Flg=4
Begin
select * from fin_Invoices 
End
if @Flg=5
Begin
select * from fin_Invoices where invUid=@invUid
End

End