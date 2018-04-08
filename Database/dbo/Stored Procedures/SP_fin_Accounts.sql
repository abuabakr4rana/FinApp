CREATE Procedure [dbo].[SP_fin_Accounts](
@accountID int=null,
@accountPrefix varchar(20)=null,
@accountNo varchar(20)=null,
@accountLevel int=null,
@accountParent int=null,
@accountType tinyint=null,
@associateID int=null,
@accountTitle nvarchar(150)=null,
@accountDescription nvarchar(500)=null,
@accountCreatedOn datetime=null,
@accountCreatedBy int=null,
@accountLastUpdated datetime=null,
@accountLastUpdatedBy int=null,
@accountLedger decimal(18, 2)=null,
@accountActual decimal(18, 2)=null,
@accountDefaultVersaAccount int=null,
@accountIsBudgetDependent bit=null,
@accountIsActive bit=null,
@accountIsVisible bit=null,
@accountIsTransactable tinyint=null,
@accountSystemIndex tinyint=null,
@Flg int) as Begin 
if @Flg=1
Begin
Declare @lastID  int
Set @lastID = IsNull((Select max(accountID) from fin_Accounts), 0)
Set @accountID = @lastID + 1
insert into fin_Accounts output inserted.accountID values(@accountID, @accountPrefix, @accountNo, @accountLevel, @accountParent, @accountType,@associateID,@accountTitle,@accountDescription,@accountCreatedOn,@accountCreatedBy,@accountLastUpdated,@accountLastUpdatedBy,@accountLedger,@accountActual,@accountDefaultVersaAccount,@accountIsBudgetDependent,@accountIsActive,@accountIsVisible, @accountIsTransactable, @accountSystemIndex)

	if (@accountParent<>0 and not @accountParent is null)
	Begin
		update fin_Accounts set accountIsTransactable=2 where accountId=@accountParent -- mark account as control
	End
End
if @Flg=2
Begin
update fin_Accounts set accountPrefix=@accountPrefix, accountNo=@accountNo, accountLevel=@accountLevel, accountParent=@accountParent, accountType=@accountType,associateID=@associateID,accountTitle=@accountTitle,accountDescription=@accountDescription,accountCreatedOn=@accountCreatedOn,accountCreatedBy=@accountCreatedBy,accountLastUpdated=@accountLastUpdated,accountLastUpdatedBy=@accountLastUpdatedBy,accountLedger=@accountLedger,accountActual=@accountActual,accountDefaultVersaAccount=@accountDefaultVersaAccount,accountIsBudgetDependent=@accountIsBudgetDependent,accountIsActive=@accountIsActive,accountIsVisible=@accountIsVisible, accountIsTransactable=@accountIsTransactable, accountSystemIndex=@accountSystemIndex where accountID=@accountID 
End
if @Flg=3
Begin
delete from fin_Accounts where accountID=@accountID 
End
if @Flg=4
Begin
select * from fin_Accounts order by accountTitle asc
End
if @Flg=5
Begin
select * from fin_Accounts where accountID=@accountID
End
if @Flg=6
Begin
select * from fin_Accounts where associateID=@associateID order by accountTitle asc
End
if @Flg=7
Begin
	select * from fin_Accounts where accountID<>@accountID order by accountTitle asc
End
if @Flg=8
Begin
	select * from fin_Accounts where accountType=@accountType order by accountPrefix+accountNo asc
End
if @Flg=9
Begin
select * from fin_Accounts where accountParent=@accountParent
End
if @Flg=10
Begin
select top(1) * from fin_Accounts where accountPrefix=@accountPrefix order by accountId desc
End
End