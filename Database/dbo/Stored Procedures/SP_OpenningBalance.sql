
Create procedure [dbo].[SP_OpenningBalance](
	@accountID int, @fromDate datetime, @deptId int=null--, @openningBalance money=null output
) as
Begin

	--Select ThisBalance.accountId, Max(debitAmount), Max(creditAmount) From (
	--	select 'Openning Balance' as Title, sum(IsNull(transAmount, 0)) as debitAmount, 0 as creditAmount, @accountId as accountId from fin_Transactions where 
	--		transDrAccount=@accountID and transStatus<>3 and transGroupId in (select transGroupId from fin_TransGroups where transGroupCreatedOn<@fromDate)
	--	union
	--	select 'Openning Balance' as Title, 0 as debitAmount, sum(isNull(transAmount, 0)) as creditAmount, @accountId as accountId from fin_Transactions where 
	--		transCrAccount=@accountID and transStatus<>3 and transGroupId in (select transGroupId from fin_TransGroups where transGroupCreatedOn<@fromDate)
	--		) as ThisBalance
	--group by ThisBalance.accountId

	Declare @openningBalance money;
	Set @openningBalance = (

	Select IsNull((Max(debitAmount) - Max(creditAmount)), 0) as OpenningBalance From (
		select 'Openning Balance' as Title, sum(IsNull(transAmount, 0)) as debitAmount, 0 as creditAmount, @accountId as accountId from fin_Transactions where 
			transDrAccount=@accountID and transStatus<>3 and transGroupId in (select transGroupId from fin_TransGroups where transGroupCreatedOn<@fromDate)
		union
		select 'Openning Balance' as Title, 0 as debitAmount, sum(isNull(transAmount, 0)) as creditAmount, @accountId as accountId from fin_Transactions where 
			transCrAccount=@accountID and transStatus<>3 and transGroupId in (select transGroupId from fin_TransGroups where transGroupCreatedOn<@fromDate)
			) as ThisBalance
	group by ThisBalance.accountId

	)

	return @openningBalance

End