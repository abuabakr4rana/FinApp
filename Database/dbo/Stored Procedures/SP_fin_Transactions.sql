
CREATE Procedure [dbo].[SP_fin_Transactions](
@transID int=null,
@transSystemIndex int=null,
@transParticipantID int=null,
@transRefID nvarchar(50)=null,
@transAttachedFiles nvarchar(500)=null,
@transInvoiceID int=null,
@transDrAccount int=null,
@transCrAccount int=null,
@transNarration nvarchar(250)=null,
@transAmount decimal(18, 2)=null,
@transStatus tinyint=null,
@transCreatedOn datetime=null,
@transCreatedBy int=null,
@transUpdatedOn datetime=null,
@transUpdatedBy int=null,
@transSystemRestrict bit=null,
@transGroupID int=null,
@transGroupIDOld int=null,
@transIsCompound bit=null,
@transType int=null,
@deptId int=null,
@Flg int) as Begin 
if @Flg=1
Begin
Declare @lastID int
Set @lastID = IsNull((Select max(transID) from fin_Transactions), 0)
Set @transID  = @lastID + 1
insert into fin_Transactions output inserted.transID values(@transID, @transSystemIndex, @transParticipantID, @transRefID, @transAttachedFiles,@transInvoiceID, 
@transDrAccount,@transCrAccount,@transNarration,@transAmount,@transCreatedOn,@transCreatedBy,@transUpdatedOn, @transUpdatedBy, @transStatus, 
@transSystemRestrict, @transGroupID, @transIsCompound, @transType, @deptId)

	if not @transCrAccount is null
	Begin
		update fin_Accounts set accountIsTransactable=1 where accountId=@transCrAccount
	End
	else
	Begin
		update fin_Accounts set accountIsTransactable=1 where accountId=@transDrAccount
	End


End
if @Flg=2
Begin
update fin_Transactions set transSystemIndex=@transSystemIndex, transParticipantID=@transParticipantID, transRefID=@transRefID, transAttachedFiles=@transAttachedFiles, 
transInvoiceID=@transInvoiceID, transDrAccount=@transDrAccount,transCrAccount=@transCrAccount,transNarration=@transNarration,
transAmount=@transAmount,transCreatedOn=@transCreatedOn,transCreatedBy=@transCreatedBy, transUpdatedOn=@transUpdatedOn, 
transUpdatedBy=@transUpdatedBy, transStatus=@transStatus, transSystemRestrict=@transSystemRestrict, transGroupID=@transGroupID, 
transIsCompound=@transIsCompound, transType=@transType, deptId=@deptId where transID=@transID

	if not @transCrAccount is null
	Begin
		update fin_Accounts set accountIsTransactable=1 where accountId=@transCrAccount
	End
	else
	Begin
		update fin_Accounts set accountIsTransactable=1 where accountId=@transDrAccount
	End

End
if @Flg=3
Begin
update fin_Transactions set transStatus=3 where transID=@transID --delete from fin_Transactions where transID=@transID 
End
if @Flg=4
Begin
select * from fin_Transactions where Not transStatus=3
End
if @Flg=5
Begin
select * from fin_Transactions where transID=@transID and Not transStatus=3
End
if @Flg=6
Begin
select * from fin_Transactions where transDrAccount=@transDrAccount and transCreatedOn<=@transCreatedOn and Not transStatus=3
End
if @Flg=7
Begin
	update fin_Transactions set transStatus=3 where transParticipantID=@transParticipantID and transRefID=@transRefID --Delete from fin_Transactions where transParticipantID=@transParticipantID and transRefID=@transRefID
End
if @Flg=8
Begin
	update fin_Transactions set transStatus=3 where transGroupID=@transGroupID --delete from fin_Transactions where transGroupID=@transGroupID
End
if @Flg=9 -- Total Debit
Begin
	select sum(transAmount) as transAmount from fin_Transactions where Not transStatus=3 and transGroupID=@transGroupID and not transDrAccount is Null and transCrAccount is Null
End
if @Flg=10 -- Total Credit
Begin
	select sum(transAmount) as transAmount from fin_Transactions where Not transStatus=3 and transGroupID=@transGroupID and not transCrAccount is Null and transDrAccount is Null
End
if @Flg=11
Begin
	update fin_Transactions set transStatus=3 where transCreatedBy=@transCreatedBy and transGroupID=0 --delete from fin_Transactions where transCreatedBy=@transCreatedBy and transGroupID=0
	update fin_Transactions set transStatus=3 where  transCreatedBy=@transCreatedBy and transGroupID=-1 --delete from fin_Transactions where transCreatedBy=@transCreatedBy and transGroupID=-1
	exec SP_fin_TransGroups @Flg=7
End
if @Flg=12
Begin
	update fin_Transactions set transGroupID=@transGroupID where Not transStatus=3 and transCreatedBy=@transCreatedBy and transGroupID=@transGroupIDOld
	update fin_TransGroups set transGroupForeNumber=@transGroupID, transLinkedToGroup=@transGroupID where Not transGroupStatus=3 and transLinkedToGroup=@transGroupIDOld
End
if @Flg=13
Begin
	select ROW_NUMBER() Over (Order by transId) as itemNo, * from fin_Transactions where Not transStatus=3 and transGroupID=@transGroupID
End
if @Flg=14 -- Vouchar Data Source
Begin
	select ROW_NUMBER() Over (Order by transId) as itemNo, * from fin_Transactions where Not transStatus=3 and transGroupID<2000
End
End