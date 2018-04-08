CREATE Procedure [dbo].[SP_fin_Payments](
@paymentUid uniqueidentifier =null,
@itemUid uniqueidentifier =null,
@paymentPayDate datetime =null,
@paymentCreatedBy int =null,
@paymentCreatedOn datetime =null,
@paymentIP varchar (50)=null,
@paymentAmount money =null,
@paymentTransGroupId int =null,
@paymentTransAccountId int =null,
@paymentNotes varchar (500)=null,
@paymentNotes2 varchar (500)=null,
@paymentType tinyint =null,
@paymentStatus tinyint =null,
@paymentVendorId int =null,
@paymentDeptId int =null,
@paymentTax1 int =null,
@paymentTax1Amount money =null,
@paymentTax2 int =null,
@paymentTax2Amount money =null,
@paymentImageURL varchar (500)=null,
@paymentDebitAccId int=null,
@paymentCreditAccId int=null,
@Flg int) as Begin 
if @Flg=1
Begin
--Declare @lastID int
--Set @lastID=IsNull((select max(paymentUid) from fin_Payments), 0)
--Set @paymentUid=@lastID+1

insert into fin_Payments output inserted.paymentUid values(newid(), @itemUid,@paymentPayDate,@paymentCreatedBy,@paymentCreatedOn,@paymentIP,
@paymentAmount,@paymentTransGroupId,@paymentTransAccountId,@paymentNotes,@paymentNotes2,@paymentType,@paymentStatus,@paymentVendorId,
@paymentDeptId,@paymentTax1,@paymentTax1Amount,@paymentTax2,@paymentTax2Amount,@paymentImageURL,@paymentDebitAccId,@paymentCreditAccId)
End
if @Flg=2
Begin
update fin_Payments set itemUid=@itemUid,paymentPayDate=@paymentPayDate,paymentCreatedBy=@paymentCreatedBy,paymentCreatedOn=@paymentCreatedOn,
paymentIP=@paymentIP,paymentAmount=@paymentAmount,paymentTransGroupId=@paymentTransGroupId,paymentTransAccountId=@paymentTransAccountId,
paymentNotes=@paymentNotes,paymentNotes2=@paymentNotes2,paymentType=@paymentType,paymentStatus=@paymentStatus,paymentVendorId=@paymentVendorId,
paymentDeptId=@paymentDeptId,paymentTax1=@paymentTax1,paymentTax1Amount=@paymentTax1Amount,paymentTax2=@paymentTax2,paymentTax2Amount=@paymentTax2Amount,
paymentImageURL=@paymentImageURL, paymentDebitAccId=@paymentDebitAccId, paymentCreditAccId=@paymentCreditAccId where paymentUid=@paymentUid 
End
if @Flg=3
Begin
delete from fin_Payments where paymentUid=@paymentUid 
End
if @Flg=4
Begin
select * from fin_Payments 
End
if @Flg=5
Begin
select * from fin_Payments where paymentUid=@paymentUid
End
if @Flg=6
Begin
select * from fin_Payments where itemUid=@itemUid
End
End