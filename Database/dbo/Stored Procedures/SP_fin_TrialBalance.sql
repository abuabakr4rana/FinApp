
CREATE Procedure [dbo].[SP_fin_TrialBalance] (@fromDate datetime=null, @toDate datetime=null, @systemIndex int)

as

DECLARE @TrialBalance TABLE
(
  accountID int, 
  accountTitle nvarchar(250),
  debit decimal(18, 2),
  credit decimal(18, 2)
)

if @fromDate is Null
	Begin
		if @systemIndex=1 -- Unofficial
			Begin
				insert into @TrialBalance (accountID, accountTitle, debit, credit)
				select max(transCrAccount) as accountID, max(crAccountTitle) as crAccountTitle,'0' as debit, sum(transAmount) as credit from vw_Transactions where transSystemRestrict=0 and not transStatus=3 group by transCrAccount
			End
		else
			Begin
				insert into @TrialBalance (accountID, accountTitle, debit, credit)
				select max(transCrAccount) as accountID, max(crAccountTitle) as crAccountTitle,'0' as debit, sum(transAmount) as credit from vw_Transactions where not transStatus=3 and transSystemIndex=2 and transCrAccount in (select accountID from fin_Accounts where accountSystemIndex in (1, 2)) group by transCrAccount
			End
	End
else
	Begin
		if @systemIndex=1 -- Unofficial
			Begin
				insert into @TrialBalance (accountID, accountTitle, debit, credit)
				select max(transCrAccount) as accountID, max(crAccountTitle) as crAccountTitle,'0' as debit, sum(transAmount) as credit from vw_Transactions where transSystemRestrict=0 and not transStatus=3 and transGroupCreatedOn>=@fromDate and transSystemIndex=@systemIndex group by transCrAccount
			End
		else
			Begin
				insert into @TrialBalance (accountID, accountTitle, debit, credit)
				select max(transCrAccount) as accountID, max(crAccountTitle) as crAccountTitle,'0' as debit, sum(transAmount) as credit from vw_Transactions where not transStatus=3 and transGroupCreatedOn>=@fromDate and transSystemIndex=2 and transCrAccount in (select accountID from fin_Accounts where accountSystemIndex in (1, 2)) group by transCrAccount
			End
	End

if @toDate is Null
	Begin
		if @systemIndex=1 --Unofficial
			Begin
				insert into @TrialBalance (accountID, accountTitle, debit, credit)
				select max(transDrAccount) as accountID,max(accountTitle) as drAccountTitle, sum(transAmount) as debit, '0' as credit from vw_Transactions where transSystemRestrict=0 and  not transStatus=3 group by transDrAccount
			End
		else
			Begin
				insert into @TrialBalance (accountID, accountTitle, debit, credit)
				select max(transDrAccount) as accountID,max(accountTitle) as drAccountTitle, sum(transAmount) as debit, '0' as credit from vw_Transactions where not transStatus=3 and transSystemIndex=2 and transDrAccount in (select accountID from fin_Accounts where accountSystemIndex in (1, 2)) group by transDrAccount
			End
	End
else
	Begin
		if @systemIndex=1 -- Unofficial
			Begin
				insert into @TrialBalance (accountID, accountTitle, debit, credit)
				select max(transDrAccount) as accountID,max(accountTitle) as drAccountTitle, sum(transAmount) as debit, '0' as credit from vw_Transactions where transSystemRestrict=0 and not transStatus=3 and transGroupCreatedOn<=@toDate group by transDrAccount
			End
		else
			Begin
				insert into @TrialBalance (accountID, accountTitle, debit, credit)
				select max(transDrAccount) as accountID,max(accountTitle) as drAccountTitle, sum(transAmount) as debit, '0' as credit from vw_Transactions where not transStatus=3 and transGroupCreatedOn<=@toDate and transSystemIndex=2 and transDrAccount in (select accountID from fin_Accounts where accountSystemIndex in (1, 2)) group by transDrAccount
			End

	End



select max(accountID) as accountID, max(accountTitle) as accountTitle, 
replace(Convert(varchar(50),cast(max(debit) as money), 1), '.00','') as debit, 
replace(Convert(varchar(50),cast(max(credit) as money), 1), '.00','') as credit, 
max(debit) - max(credit) as debitDiff, max(debit) - max(credit) as creditDiff
 from @TrialBalance where accountID Is Not Null group by accountID order by accountTitle asc