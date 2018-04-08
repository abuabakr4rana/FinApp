CREATE Procedure [dbo].[SP_fin_InvoiceItems](
@invItemId uniqueidentifier =null,
@invUid uniqueidentifier =null,
@invItemAccId int =null,
@transId int =null,
@invItemDescription nvarchar (2000)=null,
@invItemCost money =null,
@invItemQty int =null,
@invItemTax1Id int =null,
@invItemTax1Rate decimal (18 , 2 )=null,
@invItemTax1Amount money =null,
@invItemTax2Id int =null,
@invItemTax2Rate decimal (18 , 2 )=null,
@invItemTax2Amount money =null,
@invItemCreatedOn datetime =null,
@invItemCreatedBy int =null,
@invItemCreationIP varchar (50)=null,
@invItemStatus tinyint =null,
@invItemDeptId int=null,
@Flg int) as Begin 
if @Flg=1
Begin
--Declare @lastID int
--Set @lastID=IsNull((select max(invItemId) from fin_InvoiceItems), 0)
--Set @invItemId=@lastID+1

insert into fin_InvoiceItems output inserted.invItemId values(newid(),  @invUid,@invItemAccId,@transId,@invItemDescription,@invItemCost,@invItemQty,@invItemTax1Id,@invItemTax1Rate,@invItemTax1Amount,@invItemTax2Id,@invItemTax2Rate,@invItemTax2Amount,@invItemCreatedOn,@invItemCreatedBy,@invItemCreationIP,@invItemStatus, @invItemDeptId)
End
if @Flg=2
Begin
update fin_InvoiceItems set invUid=@invUid,invItemAccId=@invItemAccId,transId=@transId,invItemDescription=@invItemDescription,invItemCost=@invItemCost,invItemQty=@invItemQty,invItemTax1Id=@invItemTax1Id,invItemTax1Rate=@invItemTax1Rate,invItemTax1Amount=@invItemTax1Amount,invItemTax2Id=@invItemTax2Id,invItemTax2Rate=@invItemTax2Rate,invItemTax2Amount=@invItemTax2Amount,invItemCreatedOn=@invItemCreatedOn,invItemCreatedBy=@invItemCreatedBy,invItemCreationIP=@invItemCreationIP,invItemStatus=@invItemStatus, invItemDeptId=@invItemDeptId where invItemId=@invItemId 
End
if @Flg=3
Begin
delete from fin_InvoiceItems where invItemId=@invItemId 
End
if @Flg=4
Begin
select * from fin_InvoiceItems 
End
if @Flg=5
Begin
select * from fin_InvoiceItems where invItemId=@invItemId
End
if @Flg=6
Begin
	select * from fin_InvoiceItems where invUid=@invUid
End
End