﻿CREATE Procedure [dbo].[SP_fin_SelectVoucharForReport](@transGroupID int, @isOfficial bit=null) as 
Begin
	if @isOfficial=0
	Begin
		select ROW_NUMBER() Over (order by transId asc) as  itemNo, *, replace(Convert(varchar(50),cast(creditAmount as money), 1), '.00','') as creditAmountFormatted, replace(Convert(varchar(50),cast(debitAmount as money), 1), '.00','') as debitAmountFormatted, IsNull(deptCode, 'N / A') as deptCode  from (
		select *, transCrAccount as accountId, transNarration as [description], transAmount as creditAmount, null as debitAmount, null as drAccountTitle, crAccountTitle as creditAccountTitle, transSystemRestrict as chkShowOff from vw_Transactions where Not transStatus=3 and transDrAccount is null and transGroupID=@transGroupID and transSystemRestrict=0
		Union
		select *, transDrAccount as accountId, transNarration as [description], null as creditAmount, transAmount as debitAmount, accountTitle as drAccountTitle, null as creditAccountTitle, transSystemRestrict as chkShowOff from vw_Transactions where Not transStatus=3 and transCrAccount is null and transGroupID=@transGroupID and transSystemRestrict=0
		) as Transactions
	End
	else if @isOfficial is null
	Begin
		select ROW_NUMBER() Over (order by transId asc) as  itemNo, *, replace(Convert(varchar(50),cast(creditAmount as money), 1), '.00','') as creditAmountFormatted, replace(Convert(varchar(50),cast(debitAmount as money), 1), '.00','') as debitAmountFormatted, IsNull(deptCode, 'N / A') as deptCode from (
		select *, transCrAccount as accountId, transNarration as [description], transAmount as creditAmount, null as debitAmount, null as drAccountTitle, crAccountTitle as creditAccountTitle, transSystemRestrict as chkShowOff from vw_Transactions where Not transStatus=3 and transDrAccount is null and transGroupID=@transGroupID
		Union
		select *, transDrAccount as accountId, transNarration as [description], null as creditAmount, transAmount as debitAmount, accountTitle as drAccountTitle, null as creditAccountTitle, transSystemRestrict as chkShowOff from vw_Transactions where Not transStatus=3 and transCrAccount is null and transGroupID=@transGroupID
		) as Transactions
	End
	else
	Begin
		select ROW_NUMBER() Over (order by transId asc) as  itemNo, *, replace(Convert(varchar(50),cast(creditAmount as money), 1), '.00','') as creditAmountFormatted, replace(Convert(varchar(50),cast(debitAmount as money), 1), '.00','') as debitAmountFormatted, IsNull(deptCode, 'N / A') as deptCode from (
		select *, transCrAccount as accountId, transNarration as [description], transAmount as creditAmount, null as debitAmount, null as drAccountTitle, crAccountTitle as creditAccountTitle, transSystemRestrict as chkShowOff from vw_Transactions where Not transStatus=3 and transDrAccount is null and transGroupID=@transGroupID and transSystemIndex=2
		Union
		select *, transDrAccount as accountId, transNarration as [description], null as creditAmount, transAmount as debitAmount, accountTitle as drAccountTitle, null as creditAccountTitle, transSystemRestrict as chkShowOff from vw_Transactions where Not transStatus=3 and transCrAccount is null and transGroupID=@transGroupID and transSystemIndex=2
		) as Transactions
	End
End