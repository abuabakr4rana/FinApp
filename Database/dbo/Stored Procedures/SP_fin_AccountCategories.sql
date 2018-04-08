Create Procedure [dbo].[SP_fin_AccountCategories](
@accCatID int=null,
@accCatTitle nvarchar(50)=null,
@accCatDescription nvarchar(500)=null,
@Flg int) as Begin 
if @Flg=1
Begin
Declare @lastID int
Set @lastID=IsNull((select max(accCatID) from fin_AccountCategories), 0)
Set @accCatID=@lastID+1

insert into fin_AccountCategories output inserted.accCatID values(@accCatID, @accCatTitle,@accCatDescription) 
End
if @Flg=2
Begin
update fin_AccountCategories set accCatTitle=@accCatTitle,accCatDescription=@accCatDescription where accCatID=@accCatID 
End
if @Flg=3
Begin
delete from fin_AccountCategories where accCatID=@accCatID 
End
if @Flg=4
Begin
select * from fin_AccountCategories 
End
if @Flg=5
Begin
select * from fin_AccountCategories where accCatID=@accCatID
End

End