CREATE Procedure [dbo].[SP_fin_Taxes](
@taxId int =null,
@taxTitle varchar (50)=null,
@taxValue money =null,
@taxTypeIsPercent bit =null,
@taxCreatedBy int =null,
@taxCreatedOn datetime =null,
@taxCreatedIP varchar (50)=null,
@taxAccountId int=null,
@taxTransNarration varchar(500)=null,
@Flg int) as Begin 
if @Flg=1
Begin
--Declare @lastID int
--Set @lastID=IsNull((select max(taxId) from fin_Taxes), 0)
--Set @taxId=@lastID+1

insert into fin_Taxes output inserted.taxId values(@taxTitle,@taxValue,@taxTypeIsPercent,@taxCreatedBy,@taxCreatedOn,@taxCreatedIP,@taxAccountId, @taxTransNarration) 
End
if @Flg=2
Begin
update fin_Taxes set taxTitle=@taxTitle,taxValue=@taxValue,taxTypeIsPercent=@taxTypeIsPercent,taxCreatedBy=@taxCreatedBy,taxCreatedOn=@taxCreatedOn,taxCreatedIP=@taxCreatedIP, taxAccountId=@taxAccountId, taxTransNarration=@taxTransNarration where taxId=@taxId 
End
if @Flg=3
Begin
delete from fin_Taxes where taxId=@taxId 
End
if @Flg=4
Begin
select * from fin_Taxes 
End
if @Flg=5
Begin
select * from fin_Taxes where taxId=@taxId
End

End