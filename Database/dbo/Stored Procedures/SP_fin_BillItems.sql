CREATE Procedure [dbo].[SP_fin_BillItems](
@billItemId uniqueidentifier =null,
@billUid uniqueidentifier =null,
@billItemAccId int =null,
@transId int =null,
@billItemDescription nvarchar (2000)=null,
@billItemCost money =null,
@billItemQty int =null,
@billItemTax1Id int =null,
@billItemTax1Rate decimal (18 , 2 )=null,
@billItemTax1Amount money =null,
@billItemTax2Id int =null,
@billItemTax2Rate decimal (18 , 2 )=null,
@billItemTax2Amount money =null,
@billItemCreatedOn datetime =null,
@billItemCreatedBy int =null,
@billItemCreationIP varchar (50)=null,
@billItemStatus tinyint =null,
@billItemDeptId int =null,
@Flg int) as Begin 
if @Flg=1
Begin
--Declare @lastID int
--Set @lastID=IsNull((select max(billItemId) from fin_BillItems), 0)
--Set @billItemId=@lastID+1

insert into fin_BillItems output inserted.billItemId values(newid(), @billUid,@billItemAccId,@transId,@billItemDescription,@billItemCost,@billItemQty,@billItemTax1Id,@billItemTax1Rate,@billItemTax1Amount,@billItemTax2Id,@billItemTax2Rate,@billItemTax2Amount,@billItemCreatedOn,@billItemCreatedBy,@billItemCreationIP,@billItemStatus,@billItemDeptId)
End
if @Flg=2
Begin
update fin_BillItems set billUid=@billUid,billItemAccId=@billItemAccId,transId=@transId,billItemDescription=@billItemDescription,billItemCost=@billItemCost,billItemQty=@billItemQty,billItemTax1Id=@billItemTax1Id,billItemTax1Rate=@billItemTax1Rate,billItemTax1Amount=@billItemTax1Amount,billItemTax2Id=@billItemTax2Id,billItemTax2Rate=@billItemTax2Rate,billItemTax2Amount=@billItemTax2Amount,billItemCreatedOn=@billItemCreatedOn,billItemCreatedBy=@billItemCreatedBy,billItemCreationIP=@billItemCreationIP,billItemStatus=@billItemStatus,billItemDeptId=@billItemDeptId where billItemId=@billItemId 
End
if @Flg=3
Begin
delete from fin_BillItems where billItemId=@billItemId 
End
if @Flg=4
Begin
select * from fin_BillItems 
End
if @Flg=5
Begin
select * from fin_BillItems where billItemId=@billItemId
End
if @Flg=6
Begin
select * from fin_BillItems where billUid=@billUid
End
End