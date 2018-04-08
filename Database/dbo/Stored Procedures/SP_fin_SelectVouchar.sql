CREATE Procedure [dbo].[SP_fin_SelectVouchar](@transGroupID int, @isOfficial bit=null) as 
Begin
	select ROW_NUMBER() Over (order by transId asc) as  itemNo, *, replace(Convert(varchar(50),cast(amount as money), 1), '.00','') as debitAmountFormatted from (
		select *, transCrAccount as crAccountId, null as drAccountId, transNarration as [description], transAmount as amount, null as drAccountTitle, crAccountTitle as creditAccountTitle, transSystemRestrict as chkShowOff, 0 as additionalTransId from vw_Transactions where Not TransStatus=3 and transDrAccount is null and transGroupID=@transGroupID
		Union
		select *, null as crAccountId, transDrAccount as drAccountId, transNarration as [description], transAmount as amount, accountTitle as drAccountTitle, null as creditAccountTitle, transSystemRestrict as chkShowOff, 0 as additionalTransId from vw_Transactions where Not transStatus=3 and transCrAccount is null and transGroupID=@transGroupID
		) as Transactions
	--if @isOfficial is null
	--Begin
	--	select ROW_NUMBER() Over (order by transId asc) as  itemNo, *, replace(Convert(varchar(50),cast(creditAmount as money), 1), '.00','') as creditAmountFormatted, replace(Convert(varchar(50),cast(debitAmount as money), 1), '.00','') as debitAmountFormatted from (
	--	select *, transCrAccount as accountId, transNarration as [description], transAmount as creditAmount, null as debitAmount, null as drAccountTitle, crAccountTitle as creditAccountTitle, transSystemRestrict as chkShowOff, 0 as additionalTransId from vw_Transactions where Not TransStatus=3 and transDrAccount is null and transGroupID=@transGroupID
	--	Union
	--	select *, transDrAccount as accountId, transNarration as [description], null as creditAmount, transAmount as debitAmount, accountTitle as drAccountTitle, null as creditAccountTitle, transSystemRestrict as chkShowOff, 0 as additionalTransId from vw_Transactions where Not transStatus=3 and transCrAccount is null and transGroupID=@transGroupID
	--	) as Transactions
	--End
	--else if @isOfficial=0
	--Begin
	--	select ROW_NUMBER() Over (order by transId asc) as  itemNo, *, replace(Convert(varchar(50),cast(creditAmount as money), 1), '.00','') as creditAmountFormatted, replace(Convert(varchar(50),cast(debitAmount as money), 1), '.00','') as debitAmountFormatted  from (
	--	select *, transCrAccount as accountId, transNarration as [description], transAmount as creditAmount, null as debitAmount, null as drAccountTitle, crAccountTitle as creditAccountTitle, transSystemRestrict as chkShowOff, 0 as additionalTransId from vw_Transactions where Not transStatus=3 and  transDrAccount is null and transGroupID=@transGroupID and transSystemRestrict=0
	--	Union
	--	select *, transDrAccount as accountId, transNarration as [description], null as creditAmount, transAmount as debitAmount, accountTitle as drAccountTitle, null as creditAccountTitle, transSystemRestrict as chkShowOff, 0 as additionalTransId from vw_Transactions where Not transStatus=3 and transCrAccount is null and transGroupID=@transGroupID and transSystemRestrict=0
	--	) as Transactions
	--End
	--else
	--Begin
	--	select ROW_NUMBER() Over (order by transId asc) as  itemNo, *, replace(Convert(varchar(50),cast(creditAmount as money), 1), '.00','') as creditAmountFormatted, replace(Convert(varchar(50),cast(debitAmount as money), 1), '.00','') as debitAmountFormatted from (
	--	select *, transCrAccount as accountId, transNarration as [description], transAmount as creditAmount, null as debitAmount, null as drAccountTitle, crAccountTitle as creditAccountTitle, transSystemRestrict as chkShowOff, 0 as additionalTransId from vw_Transactions where Not TransStatus=3 and transDrAccount is null and transGroupID=@transGroupID and transSystemIndex=2
	--	Union
	--	select *, transDrAccount as accountId, transNarration as [description], null as creditAmount, transAmount as debitAmount, accountTitle as drAccountTitle, null as creditAccountTitle, transSystemRestrict as chkShowOff, 0 as additionalTransId from vw_Transactions where Not transStatus=3 and transCrAccount is null and transGroupID=@transGroupID and transSystemIndex=2
	--	) as Transactions
	--End
End