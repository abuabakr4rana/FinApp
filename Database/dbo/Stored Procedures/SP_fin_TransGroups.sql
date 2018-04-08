
CREATE Procedure [dbo].[SP_fin_TransGroups](
@transGroupID int=null,
@transGroupTitle nvarchar(300)=null,
@transGroupCreatedOn datetime=null,
@transGroupCreatedBy int=null,
@transGroupTotalAmount decimal(18, 2)=null,
@transGroupOfficialTotalAmount decimal(18, 2)=NULL,
@transTransCount int=null,
@transGroupPrefixNo int=null,
@transGroupPrefixString nvarchar(5)=null,
@transGroupForeNumber int=null,
@transGroupStatus int=null,
@transGroupApprovedBy int = null, 
@transGroupApprovedOn datetime = null, 
@transGroupReviewedBy int = null,
@transGroupReviewedOn datetime = null,
@transLinkedToGroup int=null,
@transGroupIsOfficial int=null,
@transGroupRefId varchar(100)=null,
@transCField1 varchar(250)=null,
@transCField2 varchar(250)=null,
@transCField3 varchar(250)=null,
@transCField4 varchar(250)=null,
@Flg int) as Begin 
if @Flg=1
Begin
Declare @lastID int
Set @lastID=IsNull((select max(transGroupID) from fin_TransGroups), 0)
Set @transGroupID=@lastID+1
--insert into fin_TransGroups output inserted.transGroupID values(@transGroupID, @transGroupTitle,@transGroupCreatedOn,@transGroupCreatedBy,
--@transGroupTotalAmount,@transGroupOfficialTotalAmount,@transTransCount,@transGroupPrefixNo,@transGroupPrefixString,@transGroupForeNumber, @transGroupStatus, @transGroupApprovedBy, @transGroupApprovedOn, @transGroupReviewedBy, @transGroupReviewedOn, @transLinkedToGroup, @transGroupIsOfficial, @transGroupRefId, @transCField1, @transCField2, @transCField3, @transCField4) 

insert into fin_TransGroups values(@transGroupID, @transGroupTitle,@transGroupCreatedOn,@transGroupCreatedBy,
@transGroupTotalAmount,@transGroupOfficialTotalAmount,@transTransCount,@transGroupPrefixNo,@transGroupPrefixString,@transGroupForeNumber, @transGroupStatus, @transGroupApprovedBy, @transGroupApprovedOn, @transGroupReviewedBy, @transGroupReviewedOn, @transLinkedToGroup, @transGroupIsOfficial, @transGroupRefId, @transCField1, @transCField2, @transCField3, @transCField4) 
select @transGroupId

End
if @Flg=2
Begin
update fin_TransGroups set transGroupTitle=@transGroupTitle,transGroupCreatedOn=@transGroupCreatedOn,transGroupCreatedBy=@transGroupCreatedBy,transGroupTotalAmount=@transGroupTotalAmount,
transTransCount=@transTransCount,transGroupPrefixNo=@transGroupPrefixNo,transGroupPrefixString=@transGroupPrefixString,
transGroupForeNumber=@transGroupForeNumber,transGroupStatus=@transGroupStatus, transGroupApprovedBy=@transGroupApprovedBy,transGroupApprovedOn=@transGroupApprovedOn, transGroupReviewedBy=@transGroupReviewedBy,
 transGroupReviewedOn=@transGroupReviewedOn, transLinkedToGroup=@transLinkedToGroup, transGroupIsOfficial=@transGroupIsOfficial, transGroupOfficialTotalAmount=@transGroupOfficialTotalAmount, transGroupRefId=@transGroupRefId, transCField1=@transCField1, transCField2=@transCField2, transCField3=@transCField3,transCField4=@transCField4  where transGroupID=@transGroupID 
End
if @Flg=3
Begin
update fin_TransGroups set transGroupStatus=3 where transGroupID=@transGroupID  --delete from fin_TransGroups where transGroupID=@transGroupID
update fin_Transactions set transStatus=3 where transGroupID=@transGroupID --delete from fin_Transactions where transGroupID=@transGroupID
update fin_Transactions set transStatus=3  where transGroupID in 
	(select transGroupID from fin_TransGroups where transLinkedToGroup=@transGroupID)
	--delete from fin_Transactions where transGroupID in 
	--(select transGroupID from fin_TransGroups where transLinkedToGroup=@transGroupID)
update fin_TransGroups set transGroupStatus=3 where transLinkedToGroup=@transGroupID -- delete from fin_TransGroups where transLinkedToGroup=@transGroupID


End
if @Flg=4
Begin
select * from fin_TransGroups where not transGroupStatus=3
End
if @Flg=5
Begin
select * from fin_TransGroups where not transGroupStatus=3 and transGroupID=@transGroupID
End
if @Flg=6
Begin
select IsNull(max(transGroupForeNumber), 0) as maxForeNo from fin_TransGroups 
		where not transGroupStatus=3 and transGroupPrefixNo=@transGroupPrefixNo and transGroupPrefixString=@transGroupPrefixString and
		Convert(varchar(3), datepart(mm, transGroupCreatedOn)) + ' ' + Convert(varchar(5), datepart(YYYY, transGroupCreatedOn)) = Convert(varchar(3), datepart(mm, @transGroupCreatedOn)) + ' ' + Convert(varchar(5), datepart(YYYY, @transGroupCreatedOn))
End
if @Flg=7 -- Called from SP_Fin_Transactions
Begin
	update fin_TransGroups set transGroupStatus=3 where transGroupID in (select transGroupID from fin_TransGroups where transLinkedToGroup=0) --delete from fin_Transactions where transGroupID in (select transGroupID from fin_TransGroups where transLinkedToGroup=0)
	update fin_TransGroups set transGroupStatus=3 where transLinkedToGroup=0 --delete from fin_TransGroups where transLinkedToGroup=0
End
End


--exec SP_fin_TransGroups @transGroupPrefixNo=3, @transGroupPrefixString=BPV, @transGroupCreatedOn='', @Flg=6


--Declare @transGroupCreatedOn datetime
--Set @transGroupCreatedOn=CURRENT_TIMESTAMP

--select IsNull(max(transGroupForeNumber), 0) as maxForeNo from fin_TransGroups 
--	where transGroupPrefixNo=3 and transGroupPrefixString='BPV' and
--		Convert(varchar(3), datepart(mm, transGroupCreatedOn)) + ' ' + Convert(varchar(5), datepart(YYYY, transGroupCreatedOn)) = Convert(varchar(3), datepart(mm, @transGroupCreatedOn)) + ' ' + Convert(varchar(5), datepart(YYYY, @transGroupCreatedOn))