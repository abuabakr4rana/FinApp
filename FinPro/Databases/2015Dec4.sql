/****** Object:  StoredProcedure [dbo].[SP_CatchErrors]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[SP_CatchErrors] (
	@ErrMsg text output,
	@ErrPath varchar(250) output)
as
Begin
	insert into CatchErrors values(@ErrMsg, @ErrPath, CURRENT_TIMESTAMP)
End




GO
/****** Object:  StoredProcedure [dbo].[SP_Coder]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Coder] as Select * from fin_ChequePrinting

GO
/****** Object:  StoredProcedure [dbo].[SP_Entities]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_Entities](
@entityId int =null,
@entityType int =null,
@entityTitle nvarchar (100)=null,
@entityDescription varchar (500)=null,
@entityFirstName nvarchar (60)=null,
@entityLastName nvarchar (60)=null,
@entityEmail varchar (50)=null,
@entityAltEmail varchar (50)=null,
@entityAddress nvarchar (1000)=null,
@entityCity nvarchar (200)=null,
@entityZip varchar (10)=null,
@entityCountry int =null,
@entityState varchar (50)=null,
@entityPhone varchar (20)=null,
@entityAltPhone varchar (20)=null,
@entityMobile varchar (20)=null,
@entityAltMobile varchar (20)=null,
@entityFax varchar (20)=null,
@entityAltFax varchar (20)=null,
@entityStatus tinyint =null,
@entityAccountId int =null,
@entityAccountTitle varchar (150)=null,
@entityCreatedOn datetime =null,
@entityCreatedBy int =null,
@entityLastUpdatedBy int =null,
@entityLastUpdateOn datetime =null,
@Flg int) as Begin 
if @Flg=1
Begin
Declare @lastID int
Set @lastID=IsNull((select max(entityId) from fin_Entities), 0)
Set @entityId=@lastID+1

insert into fin_Entities output inserted.entityId values(@entityId, @entityType,@entityTitle,@entityDescription,@entityFirstName,@entityLastName,@entityEmail,@entityAltEmail,@entityAddress,@entityCity,@entityZip,@entityCountry,@entityState,@entityPhone,@entityAltPhone,@entityMobile,@entityAltMobile,@entityFax,@entityAltFax,@entityStatus,@entityAccountId,@entityAccountTitle,@entityCreatedOn,@entityCreatedBy,@entityLastUpdatedBy,@entityLastUpdateOn)
End
if @Flg=2
Begin
update fin_Entities set entityType=@entityType,entityTitle=@entityTitle,entityDescription=@entityDescription,entityFirstName=@entityFirstName,entityLastName=@entityLastName,entityEmail=@entityEmail,entityAltEmail=@entityAltEmail,entityAddress=@entityAddress,entityCity=@entityCity,entityZip=@entityZip,entityCountry=@entityCountry,entityState=@entityState,entityPhone=@entityPhone,entityAltPhone=@entityAltPhone,entityMobile=@entityMobile,entityAltMobile=@entityAltMobile,entityFax=@entityFax,entityAltFax=@entityAltFax,entityStatus=@entityStatus,entityAccountId=@entityAccountId,entityAccountTitle=@entityAccountTitle,entityCreatedOn=@entityCreatedOn,entityCreatedBy=@entityCreatedBy,entityLastUpdatedBy=@entityLastUpdatedBy,entityLastUpdateOn=@entityLastUpdateOn where entityId=@entityId 
End
if @Flg=3
Begin
delete from fin_Entities where entityId=@entityId 
End
if @Flg=4
Begin
select * from fin_Entities 
End
if @Flg=5
Begin
select * from fin_Entities where entityId=@entityId
End

End

GO
/****** Object:  StoredProcedure [dbo].[SP_EntityTypes]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_EntityTypes](
@entityType int =null,
@entityTypeTitle varchar (50)=null,
@Flg int) as Begin 
if @Flg=1
Begin
Declare @lastID int
Set @lastID=IsNull((select max(entityType) from fin_gen_entityTypes), 0)
Set @entityType=@lastID+1

insert into fin_gen_entityTypes output inserted.entityType values(@entityType, @entityTypeTitle) 
End
if @Flg=2
Begin
update fin_gen_entityTypes set entityTypeTitle=@entityTypeTitle where entityType=@entityType 
End
if @Flg=3
Begin
delete from fin_gen_entityTypes where entityType=@entityType 
End
if @Flg=4
Begin
select * from fin_gen_entityTypes 
End
if @Flg=5
Begin
select * from fin_gen_entityTypes where entityType=@entityType
End

End

GO
/****** Object:  StoredProcedure [dbo].[SP_fin_AccountCategories]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

GO
/****** Object:  StoredProcedure [dbo].[SP_fin_Accounts]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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


GO
/****** Object:  StoredProcedure [dbo].[SP_fin_AccountTotalInPeriod]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_fin_AccountTotalInPeriod] (@accountId int, @fromDate datetime=null, @toDate datetime=null, @systemIndex int)

as
Declare	@rtAmount int
Declare @drAmount int
Declare @crAmount int
Begin
	if @systemIndex = 0
	Begin
		
		
		Set @drAmount = (select IsNull(sum(transAmount), 0) as transAmount from fin_Transactions where (transDrAccount=@accountId) and Not transSystemRestrict=1 and Not transStatus=3 and (transCreatedOn>=@fromDate and transCreatedOn<=@toDate))
		Set @crAmount = (select IsNull(sum(transAmount), 0) as transAmount from fin_Transactions where (transCrAccount=@accountId) and Not transSystemRestrict=1 and Not transStatus=3 and (transCreatedOn>=@fromDate and transCreatedOn<=@toDate))
		
		set @rtAmount = @drAmount - @crAmount
		
		--if @rtAmount<0
		--Begin
		--	set @rtAmount = @rtAmount * -1
		--End

		select @rtAmount
	End
	else
	Begin

		Set @drAmount = (select IsNull(sum(transAmount), 0) as transAmount from fin_Transactions where (transDrAccount=@accountId) and transSystemIndex=2 and Not transStatus=3 and (transCreatedOn>=@fromDate and transCreatedOn<=@toDate))
		Set @crAmount = (select IsNull(sum(transAmount), 0) as transAmount from fin_Transactions where (transCrAccount=@accountId) and transSystemIndex=2 and Not transStatus=3 and (transCreatedOn>=@fromDate and transCreatedOn<=@toDate))
		
		set @rtAmount = @drAmount - @crAmount
		
		--if @rtAmount<0
		--Begin
		--	set @rtAmount = @rtAmount * -1
		--End

		select @rtAmount
		
	End
End


GO
/****** Object:  StoredProcedure [dbo].[SP_fin_Attachments]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_fin_Attachments](
@attachmentId int=null,
@attachmentOriginalFileName nvarchar(100)=null,
@attachmentMaskedFileName nvarchar(100)=null,
@transGroupID int=null,
@Flg int) as Begin 
if @Flg=1
Begin
Declare @lastID int
Set @lastID=IsNull((select max(attachmentId) from fin_Attachments), 0)
Set @attachmentId=@lastID+1
insert into fin_Attachments output inserted.attachmentId values(@attachmentId, @attachmentOriginalFileName,@attachmentMaskedFileName,@transGroupID) 
End
if @Flg=2
Begin
update fin_Attachments set attachmentOriginalFileName=@attachmentOriginalFileName,attachmentMaskedFileName=@attachmentMaskedFileName,transGroupID=@transGroupID where attachmentId=@attachmentId 
End
if @Flg=3
Begin
delete from fin_Attachments where attachmentId=@attachmentId 
End
if @Flg=4
Begin
select * from fin_Attachments 
End
if @Flg=5
Begin
select * from fin_Attachments where attachmentId=@attachmentId
End
if @Flg=6
Begin
	select * from fin_Attachments where transGroupID=@transGroupID
End
End

GO
/****** Object:  StoredProcedure [dbo].[SP_fin_ChequePrinting]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_fin_ChequePrinting](
@chequeId int =null,
@bankId int =null,
@chequeTitle nvarchar (200)=null,
@chequeAmount nvarchar (1000)=null,
@chequeAmountFig decimal (18 , 1 )=null,
@chequeDate datetime =null,
@chequeNo varchar (20)=null,
@chequeReceivedBy varchar (50)=null,
@chequeReceiverPhone varchar (15)=null,
@chequeReceiverIDCard varchar (15)=null,
@chequeCreatedBy int =null,
@chequeCreatedOn datetime =null,
@chequeStatus tinyint =null,
@Flg int) as Begin 
if @Flg=1
Begin
Declare @lastID int
Set @lastID=IsNull((select max(chequeId) from fin_ChequePrinting), 0)
Set @chequeId=@lastID+1

insert into fin_ChequePrinting output inserted.chequeId values(@bankId,@chequeTitle,@chequeAmount,@chequeAmountFig,@chequeDate,@chequeNo,@chequeReceivedBy,@chequeReceiverPhone,@chequeReceiverIDCard,@chequeCreatedBy,@chequeCreatedOn,@chequeStatus) 
End
if @Flg=2
Begin
update fin_ChequePrinting set bankId=@bankId,chequeTitle=@chequeTitle,chequeAmount=@chequeAmount,chequeAmountFig=@chequeAmountFig,chequeDate=@chequeDate,chequeNo=@chequeNo,chequeReceivedBy=@chequeReceivedBy,chequeReceiverPhone=@chequeReceiverPhone,chequeReceiverIDCard=@chequeReceiverIDCard,chequeCreatedBy=@chequeCreatedBy,chequeCreatedOn=@chequeCreatedOn,chequeStatus=@chequeStatus where chequeId=@chequeId 
End
if @Flg=3
Begin
delete from fin_ChequePrinting where chequeId=@chequeId 
End
if @Flg=4
Begin
select * from fin_ChequePrinting 
End
if @Flg=5
Begin
select * from fin_ChequePrinting where chequeId=@chequeId
End

End

GO
/****** Object:  StoredProcedure [dbo].[SP_fin_Departments]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_fin_Departments](
@deptId int =null,
@deptTitle nvarchar (100)=null,
@deptCode varchar (5)=null,
@deptDescription varchar (500)=null,
@Flg int) as Begin 
if @Flg=1
Begin
Declare @lastID int
Set @lastID=IsNull((select max(deptId) from fin_Departments), 0)
Set @deptId=@lastID+1
insert into fin_Departments output inserted.deptId values(@deptId, @deptTitle,@deptCode,@deptDescription) 
End
if @Flg=2
Begin
update fin_Departments set deptTitle=@deptTitle,deptCode=@deptCode,deptDescription=@deptDescription where deptId=@deptId 
End
if @Flg=3
Begin
delete from fin_Departments where deptId=@deptId 
End
if @Flg=4
Begin
select *, IsNull(deptDescription, 'N / A') as deptDesc from fin_Departments 
End
if @Flg=5
Begin
select * from fin_Departments where deptId=@deptId
End

End

GO
/****** Object:  StoredProcedure [dbo].[SP_fin_Modules]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_fin_Modules](
@moduleId int =null,
@moduleTitle varchar (100)=null,
@moduleDescription varchar (500)=null,
@moduleIsOffial bit =null,
@CField1 varchar (50)=null,
@CField2 varchar (50)=null,
@CField3 varchar (50)=null,
@CField4 varchar (50)=null,
@Flg int) as Begin 
if @Flg=1
Begin
Declare @lastID int
Set @lastID=IsNull((select max(moduleId) from fin_Modules), 0)
Set @moduleId=@lastID+1

insert into fin_Modules output inserted.moduleId values(@moduleId, @moduleTitle,@moduleDescription,@moduleIsOffial,@CField1,@CField2,@CField3,@CField4) 
End
if @Flg=2
Begin
update fin_Modules set moduleTitle=@moduleTitle,moduleDescription=@moduleDescription,moduleIsOffial=@moduleIsOffial,CField1=@CField1,CField2=@CField2,CField3=@CField3,CField4=@CField4 where moduleId=@moduleId 
End
if @Flg=3
Begin
delete from fin_Modules where moduleId=@moduleId 
End
if @Flg=4
Begin
select * from fin_Modules 
End
if @Flg=5
Begin
select * from fin_Modules where moduleId=@moduleId
End

End

GO
/****** Object:  StoredProcedure [dbo].[SP_fin_Preselected_Vouchar_Accounts]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[SP_fin_Preselected_Vouchar_Accounts](
	@moduleId int,
	@moduleParameterId int,
	@moduleIsOfficial bit
) as
Begin
	select * from fin_AdditionalAutoTrans where autoTransSeparateID=0 and autoTransIsPredefinedItem=1 and additionalTransId in (select additionalTransId from fin_ModuleItems 
		where moduleId=@moduleId and addtionalTransIsOfficial=@moduleIsOfficial and moduleIParameterId=@moduleParameterId) order by autoTransIsDebit desc
End


GO
/****** Object:  StoredProcedure [dbo].[SP_fin_ReportJournalOfficial]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_fin_ReportJournalOfficial](@fromDate datetime, @toDate datetime, @recordNoFrom int, @recordNoTo int)
AS
BEGIN
--	Select *,(Convert(varchar, IsNull(transGroupPrefixNo, 0)) + transGroupPrefixString + Convert(varchar, IsNull(transGroupForeNumber, 0))) as voucharNo from fin_TransGroups where transGroupIsOfficial=1 and transGroupCreatedOn between @fromDate and @toDate order by transGroupCreatedOn desc
	Declare @maxRows int
	Set @maxRows = (Select Count(transGroupId) from fin_TransGroups where Not transGroupStatus=3 and transGroupCreatedOn between @fromDate and @toDate)
	Select *, @maxRows as MaxRows from (Select *, replace(Convert(varchar(50),cast(transGroupOfficialTotalAmount as money), 1), '.00','') as TotalAmountFormatted, (Convert(varchar, IsNull(transGroupPrefixNo, 0)) + transGroupPrefixString + Convert(varchar, IsNull(transGroupForeNumber, 0))) as voucharNo, ROW_NUMBER() Over(order by transGroupCreatedOn desc) as RowNo from fin_TransGroups where not transGroupStatus=3 and transGroupIsOfficial=1 and transGroupCreatedOn between @fromDate and @toDate) as Results where RowNo<@recordNoTo and RowNo>=@recordNoFrom
END

GO
/****** Object:  StoredProcedure [dbo].[SP_fin_ReportJournalUnofficial]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_fin_ReportJournalUnofficial](@fromDate datetime, @toDate datetime, @recordNoFrom int, @recordNoTo int)
AS
BEGIN
	Declare @maxRows int
	Set @maxRows = (Select Count(transGroupId) from fin_TransGroups where Not transGroupStatus=3 and transGroupCreatedOn between @fromDate and @toDate)
	Select *, @maxRows as MaxRows from (Select *, replace(Convert(varchar(50),cast(transGroupTotalAmount as money), 1), '.00','') as TotalAmountFormatted, (Convert(varchar, IsNull(transGroupPrefixNo, 0)) + transGroupPrefixString + Convert(varchar, IsNull(transGroupForeNumber, 0))) as voucharNo, ROW_NUMBER() Over(order by transGroupCreatedOn desc) as RowNo from fin_TransGroups where not transGroupStatus=3 and transGroupCreatedOn between @fromDate and @toDate) as Results where RowNo<@recordNoTo and RowNo>=@recordNoFrom
END

GO
/****** Object:  StoredProcedure [dbo].[SP_fin_SelectVouchar]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_fin_SelectVouchar](@transGroupID int, @isOfficial bit=null) as 
Begin
	if @isOfficial is null
	Begin
		select ROW_NUMBER() Over (order by transId asc) as  itemNo, *, replace(Convert(varchar(50),cast(creditAmount as money), 1), '.00','') as creditAmountFormatted, replace(Convert(varchar(50),cast(debitAmount as money), 1), '.00','') as debitAmountFormatted from (
		select *, transCrAccount as accountId, transNarration as [description], transAmount as creditAmount, null as debitAmount, null as drAccountTitle, crAccountTitle as creditAccountTitle, transSystemRestrict as chkShowOff, 0 as additionalTransId from vw_Transactions where Not TransStatus=3 and transDrAccount is null and transGroupID=@transGroupID
		Union
		select *, transDrAccount as accountId, transNarration as [description], null as creditAmount, transAmount as debitAmount, accountTitle as drAccountTitle, null as creditAccountTitle, transSystemRestrict as chkShowOff, 0 as additionalTransId from vw_Transactions where Not transStatus=3 and transCrAccount is null and transGroupID=@transGroupID
		) as Transactions
	End
	else if @isOfficial=0
	Begin
		select ROW_NUMBER() Over (order by transId asc) as  itemNo, *, replace(Convert(varchar(50),cast(creditAmount as money), 1), '.00','') as creditAmountFormatted, replace(Convert(varchar(50),cast(debitAmount as money), 1), '.00','') as debitAmountFormatted  from (
		select *, transCrAccount as accountId, transNarration as [description], transAmount as creditAmount, null as debitAmount, null as drAccountTitle, crAccountTitle as creditAccountTitle, transSystemRestrict as chkShowOff, 0 as additionalTransId from vw_Transactions where Not transStatus=3 and  transDrAccount is null and transGroupID=@transGroupID and transSystemRestrict=0
		Union
		select *, transDrAccount as accountId, transNarration as [description], null as creditAmount, transAmount as debitAmount, accountTitle as drAccountTitle, null as creditAccountTitle, transSystemRestrict as chkShowOff, 0 as additionalTransId from vw_Transactions where Not transStatus=3 and transCrAccount is null and transGroupID=@transGroupID and transSystemRestrict=0
		) as Transactions
	End
	else
	Begin
		select ROW_NUMBER() Over (order by transId asc) as  itemNo, *, replace(Convert(varchar(50),cast(creditAmount as money), 1), '.00','') as creditAmountFormatted, replace(Convert(varchar(50),cast(debitAmount as money), 1), '.00','') as debitAmountFormatted from (
		select *, transCrAccount as accountId, transNarration as [description], transAmount as creditAmount, null as debitAmount, null as drAccountTitle, crAccountTitle as creditAccountTitle, transSystemRestrict as chkShowOff, 0 as additionalTransId from vw_Transactions where Not TransStatus=3 and transDrAccount is null and transGroupID=@transGroupID and transSystemIndex=2
		Union
		select *, transDrAccount as accountId, transNarration as [description], null as creditAmount, transAmount as debitAmount, accountTitle as drAccountTitle, null as creditAccountTitle, transSystemRestrict as chkShowOff, 0 as additionalTransId from vw_Transactions where Not transStatus=3 and transCrAccount is null and transGroupID=@transGroupID and transSystemIndex=2
		) as Transactions
	End
End

GO
/****** Object:  StoredProcedure [dbo].[SP_fin_SelectVoucharForReport]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_fin_SelectVoucharForReport](@transGroupID int, @isOfficial bit=null) as 
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

GO
/****** Object:  StoredProcedure [dbo].[SP_fin_Transactions]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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





GO
/****** Object:  StoredProcedure [dbo].[SP_fin_TransGroups]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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




GO
/****** Object:  StoredProcedure [dbo].[SP_fin_TrialBalance]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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



GO
/****** Object:  StoredProcedure [dbo].[SP_LedgerReport]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_LedgerReport] (@accountID int, @fromDate datetime, @toDate datetime, @deptId int=null)
AS
BEGIN
  DECLARE @tempTable TABLE (
	rowNo int,
    transID int,
    refID int,
    TransNarration varchar(500),
    CreatedOn datetime,
    accountID int,
    DebitAmount money,
    CreditAmount money,
    DiffAmount decimal(18, 2),
	DiffAmountString varchar(50),
	transGroupID int,
	transGroupRefId varchar(200),
	transVoucharNo varchar(30)
  )

  if @deptId is Null
  Begin
  INSERT INTO @tempTable
    SELECT
		ROW_NUMBER() OVER(ORDER BY CreatedOn asc) as rowNo,
      transID AS TransID,
      RefID AS RefID,
      (TransNarration) AS TransNarration,
      DATEADD(D, 0, DATEDIFF(D, 0, CreatedOn)) AS CreatedOn,
      (accountID) AS accountID,
      (DebitAmount) AS DebitAmount,
      (CreditAmount) AS CreditAmount,
      (DebitAmount - CreditAmount) AS DiffAmount,
	  '' as DiffAmountString, transGroupID as transGroupID,
	  transGroupRefId as transGroupRefId, transVoucharNo as transVoucharNo
    FROM (SELECT
      transId,
      transRefID AS RefID,
      (transNarration) AS TransNarration,
      transGroupCreatedOn AS CreatedOn,
      (transDrAccount) AS AccountID,
      (transAmount) AS DebitAmount,
      0 AS CreditAmount, transGroupID, transGroupRefId, Convert(varchar(10), transGroupPrefixNo) + transGroupPrefixString + Convert(varchar(10), transGroupForeNumber) as transVoucharNo
    FROM vw_Transactions
    WHERE not transStatus=3 and transDrAccount = @accountID
    AND (transGroupCreatedOn between @fromDate and @toDate)
    AND transAmount > 0 and transSystemRestrict=0
    UNION
    SELECT
      transID,
      transRefID AS RefID,
      (transNarration) AS TransNarration,
      transGroupCreatedOn AS CreatedOn,
      (transCrAccount) AS AccountID,
      0 AS DebitAmount,
      (transAmount) AS CreditAmount, transGroupID, transGroupRefId, Convert(varchar(10), transGroupPrefixNo) + transGroupPrefixString + Convert(varchar(10), transGroupForeNumber) as transVoucharNo
    FROM vw_Transactions
    WHERE not transStatus=3 and  transCrAccount = @accountID
    AND (transGroupCreatedOn between @fromDate and @toDate)
    AND transAmount > 0 and transSystemRestrict=0) 
	
	AS accountSummary
	order by CreatedOn asc
  End
  Else
  Begin
  INSERT INTO @tempTable
    SELECT
		ROW_NUMBER() OVER(ORDER BY CreatedOn asc) as rowNo,
      transID AS TransID,
      RefID AS RefID,
      (TransNarration) AS TransNarration,
      DATEADD(D, 0, DATEDIFF(D, 0, CreatedOn)) AS CreatedOn,
      (accountID) AS accountID,
      (DebitAmount) AS DebitAmount,
      (CreditAmount) AS CreditAmount,
      (DebitAmount - CreditAmount) AS DiffAmount,
	  '' as DiffAmountString, transGroupID as transGroupID, transGroupRefId as transGroupRefId, transVoucharNo as transVoucharNo
    FROM (SELECT
      transId,
      transRefID AS RefID,
      (transNarration) AS TransNarration,
      transGroupCreatedOn AS CreatedOn,
      (transDrAccount) AS AccountID,
      (transAmount) AS DebitAmount,
      0 AS CreditAmount, transGroupID, transGroupRefId, Convert(varchar(10), transGroupPrefixNo) + transGroupPrefixString + Convert(varchar(10), transGroupForeNumber) as transVoucharNo
    FROM vw_Transactions
    WHERE not transStatus=3 and  transDrAccount = @accountID
    AND (transGroupCreatedOn between @fromDate and @toDate)
    AND transAmount > 0 and transSystemRestrict=0
	And deptId=@deptId
    UNION
    SELECT
      transID,
      transRefID AS RefID,
      (transNarration) AS TransNarration,
      transGroupCreatedOn AS CreatedOn,
      (transCrAccount) AS AccountID,
      0 AS DebitAmount,
      (transAmount) AS CreditAmount, transGroupID, transGroupRefId, Convert(varchar(10), transGroupPrefixNo) + transGroupPrefixString + Convert(varchar(10), transGroupForeNumber) as transVoucharNo
    FROM vw_Transactions
    WHERE not transStatus=3 and  transCrAccount = @accountID
    AND (transGroupCreatedOn between @fromDate and @toDate)
    AND transAmount > 0 and transSystemRestrict=0 AND deptId=@deptId ) 
	
	AS accountSummary
	order by CreatedOn asc
  End
  
Select *  from (
  SELECT
    Max(t1.transID) AS transID,
    MAX(t1.refID) AS RefID,
    MAX(t1.TransNarration) AS Narration,
    MAX(t1.CreatedOn) AS CreatedOn,
    MAX(t1.accountID) AS accountID,
	Max(t1.transGroupID) as transGroupID,
	replace(Convert(varchar(50),cast(MAX(t1.DebitAmount) as money), 1), '.00','') as DebitAmount,
    --MAX(t1.DebitAmount) AS DebitAmount,
    --MAX(t1.CreditAmount) AS CreditAmount,
	replace(Convert(varchar(50),cast(MAX(t1.CreditAmount) as money), 1), '.00','') as CreditAmount,
    MAX(t1.DiffAmount) AS DiffAmount,
	SUM(t2.DiffAmount) AS TotalAmount,
	Max(t1.transGroupRefId) as transGroupRefId,
	Max(t1.transVoucharNo) as transVoucharNo,
	Case When SUM(t2.DiffAmount) < 0 Then '(' + replace(Convert(varchar(50),cast(SUM(t2.DiffAmount) * -1 as money), 1), '.00','') + ')'
		Else  replace(Convert(varchar(50),cast(SUM(t2.DiffAmount) as money), 1), '.00','') 
	End as DiffAmountString
    --SUM(t2.DiffAmount) AS TotalAmount
  FROM @tempTable t1
  INNER JOIN @tempTable t2
    ON t1.rowNo >= t2.rowNo
  GROUP BY t1.rowNo
  --ORDER BY t1.rowNo
  ) as thisTable

END

GO
/****** Object:  StoredProcedure [dbo].[SP_OfficialLedgerReport]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OfficialLedgerReport] (@accountID int, @fromDate datetime, @toDate datetime, @deptId int=null)
AS
BEGIN
  DECLARE @tempTable TABLE (
	rowNo int,
    transID int,
    refID int,
    TransNarration varchar(500),
    CreatedOn datetime,
    accountID int,
    DebitAmount money,
    CreditAmount money,
    DiffAmount decimal(18, 2),
	DiffAmountString varchar(50),
	transGroupID int,
	transGroupRefId varchar(200),
	transVoucharNo varchar(30)
  )


  if @deptId is Null
  Begin
  INSERT INTO @tempTable
    SELECT
		ROW_NUMBER() OVER(ORDER BY CreatedOn asc) as rowNo,
      transID AS TransID,
      RefID AS RefID,
      (TransNarration) AS TransNarration,
      DATEADD(D, 0, DATEDIFF(D, 0, CreatedOn)) AS CreatedOn,
      (accountID) AS accountID,
      (DebitAmount) AS DebitAmount,
      (CreditAmount) AS CreditAmount,
      (DebitAmount - CreditAmount) AS DiffAmount,
	  '' as DiffAmountString, transGroupID as transGroupID, transGroupRefId as transGroupRefId, transVoucharNo as transVoucharNo
    FROM (SELECT
      transId,
      transRefID AS RefID,
      (transNarration) AS TransNarration,
      transGroupCreatedOn AS CreatedOn,
      (transDrAccount) AS AccountID,
      (transAmount) AS DebitAmount,
      0 AS CreditAmount, transGroupID, transGroupRefId, Convert(varchar(10), transGroupPrefixNo) + transGroupPrefixString + Convert(varchar(10), transGroupForeNumber) as transVoucharNo
    FROM vw_Transactions
    WHERE not transStatus=3 and  transDrAccount = @accountID
    AND (transGroupCreatedOn between @fromDate and @toDate)
    AND transAmount > 0 and transSystemIndex=2
    UNION
    SELECT
      transID,
      transRefID AS RefID,
      (transNarration) AS TransNarration,
      transGroupCreatedOn AS CreatedOn,
      (transCrAccount) AS AccountID,
      0 AS DebitAmount,
      (transAmount) AS CreditAmount, transGroupID, transGroupRefId, Convert(varchar(10), transGroupPrefixNo) + transGroupPrefixString + Convert(varchar(10), transGroupForeNumber) as transVoucharNo
    FROM vw_Transactions
    WHERE not transStatus=3 and  transCrAccount = @accountID
    AND (transGroupCreatedOn between @fromDate and @toDate)
    AND transAmount > 0 and transSystemIndex=2) AS accountSummary order by CreatedOn asc
  End
  Else
  Begin
  INSERT INTO @tempTable
    SELECT
		ROW_NUMBER() OVER(ORDER BY CreatedOn asc) as rowNo,
      transID AS TransID,
      RefID AS RefID,
      (TransNarration) AS TransNarration,
      DATEADD(D, 0, DATEDIFF(D, 0, CreatedOn)) AS CreatedOn,
      (accountID) AS accountID,
      (DebitAmount) AS DebitAmount,
      (CreditAmount) AS CreditAmount,
      (DebitAmount - CreditAmount) AS DiffAmount,
	  '' as DiffAmountString, transGroupID as transGroupID, transGroupRefId as transGroupRefId, transVoucharNo as transVoucharNo
    FROM (SELECT
      transId,
      transRefID AS RefID,
      (transNarration) AS TransNarration,
      transGroupCreatedOn AS CreatedOn,
      (transDrAccount) AS AccountID,
      (transAmount) AS DebitAmount,
      0 AS CreditAmount, transGroupID, transGroupRefId, Convert(varchar(10), transGroupPrefixNo) + transGroupPrefixString + Convert(varchar(10), transGroupForeNumber) as transVoucharNo
    FROM vw_Transactions
    WHERE not transStatus=3 and  transDrAccount = @accountID
    AND (transGroupCreatedOn between @fromDate and @toDate)
    AND transAmount > 0 and transSystemIndex=2
	And deptId=@deptId
    UNION
    SELECT
      transID,
      transRefID AS RefID,
      (transNarration) AS TransNarration,
      transGroupCreatedOn AS CreatedOn,
      (transCrAccount) AS AccountID,
      0 AS DebitAmount,
      (transAmount) AS CreditAmount, transGroupID, transGroupRefId, Convert(varchar(10), transGroupPrefixNo) + transGroupPrefixString + Convert(varchar(10), transGroupForeNumber) as transVoucharNo
    FROM vw_Transactions
    WHERE not transStatus=3 and  transCrAccount = @accountID
    AND (transGroupCreatedOn between @fromDate and @toDate)
    AND transAmount > 0 and transSystemIndex=2 and deptId=@deptId) AS accountSummary order by CreatedOn asc
  End
  
Select *  from (
  SELECT
    Max(t1.transID) AS transID,
    MAX(t1.refID) AS RefID,
    MAX(t1.TransNarration) AS Narration,
    MAX(t1.CreatedOn) AS CreatedOn,
    MAX(t1.accountID) AS accountID,
	Max(t1.transGroupID) as transGroupID,
	replace(Convert(varchar(50),cast(MAX(t1.DebitAmount) as money), 1), '.00','') as DebitAmount,
    --MAX(t1.DebitAmount) AS DebitAmount,
    --MAX(t1.CreditAmount) AS CreditAmount,
	replace(Convert(varchar(50),cast(MAX(t1.CreditAmount) as money), 1), '.00','') as CreditAmount,
    MAX(t1.DiffAmount) AS DiffAmount,
	SUM(t2.DiffAmount) AS TotalAmount,
	Max(t1.transGroupRefId) as transGroupRefId,
	Max(t1.transVoucharNo) as transVoucharNo,
	Case When SUM(t2.DiffAmount) < 0 Then '(' + replace(Convert(varchar(50),cast(SUM(t2.DiffAmount) * -1 as money), 1), '.00','') + ')'
		Else  replace(Convert(varchar(50),cast(SUM(t2.DiffAmount) as money), 1), '.00','') 
	End as DiffAmountString
    --SUM(t2.DiffAmount) AS TotalAmount
  FROM @tempTable t1
  INNER JOIN @tempTable t2
    ON t1.rowNo >= t2.rowNo
  GROUP BY t1.rowNo
  --ORDER BY t1.rowNo
  ) as thisTable

END

--BEGIN
--  DECLARE @tempTable TABLE (
--	rowNo int,
--    transID int,
--    refID int,
--    TransNarration varchar(500),
--    CreatedOn datetime,
--    accountID int,
--    DebitAmount decimal(18, 2),
--    CreditAmount decimal(18, 2),
--    DiffAmount decimal(18, 2)
--  )
--  INSERT INTO @tempTable
--    SELECT
--		ROW_NUMBER() OVER(ORDER BY transID DESC) as rowNo,
--      transID AS TransID,
--      RefID AS RefID,
--      (TransNarration) AS TransNarration,
--      DATEADD(D, 0, DATEDIFF(D, 0, CreatedOn)) AS CreatedOn,
--      (accountID) AS accountID,
--      (DebitAmount) AS DebitAmount,
--      (CreditAmount) AS CreditAmount,
--      (DebitAmount - CreditAmount) AS DiffAmount
--    FROM (SELECT
--      transId,
--      transRefID AS RefID,
--      (transNarration) AS TransNarration,
--      transCreatedOn AS CreatedOn,
--      (transDrAccount) AS AccountID,
--      (transAmount) AS DebitAmount,
--      0 AS CreditAmount
--    FROM vw_Transactions
--    WHERE transDrAccount = @accountID
--    AND (transCreatedOn between @fromDate and @toDate)
--    AND transAmount > 0 and transSystemIndex=2
--    UNION
--    SELECT
--      transID,
--      transRefID AS RefID,
--      (transNarration) AS TransNarration,
--      transCreatedOn AS CreatedOn,
--      (transCrAccount) AS AccountID,
--      0 AS DebitAmount,
--      (transAmount) AS CreditAmount
--    FROM vw_Transactions
--    WHERE transCrAccount = @accountID
--    AND (transCreatedOn between @fromDate and @toDate)
--    AND transAmount > 0 and transSystemIndex=2) AS accountSummary order by CreatedOn asc

-- Select * from (
--  SELECT
--    Max(t1.transID) AS transID,
--    MAX(t1.refID) AS RefID,
--    MAX(t1.TransNarration) AS Narration,
--    MAX(t1.CreatedOn) AS CreatedOn,
--    MAX(t1.accountID) AS accountID,
--    MAX(t1.DebitAmount) AS DebitAmount,
--    MAX(t1.CreditAmount) AS CreditAmount,
--    max(t1.DiffAmount) AS DiffAmount,
--    SUM(t2.DiffAmount) AS TotalAmount
--  FROM @tempTable t1
--  INNER JOIN @tempTable t2
--    ON t1.rowNo >= t2.rowNo
--  GROUP BY t1.rowNo
--  --ORDER BY t1.rowNo
--  ) as thisTable

--END

GO
/****** Object:  StoredProcedure [dbo].[SP_OpenningBalance]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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


GO
/****** Object:  StoredProcedure [dbo].[SP_userProfile]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_userProfile](
@userID int=null,
@userFirstName nvarchar(50)=null,
@userMiddleName nvarchar(50)=null,
@userLastName nvarchar(50)=null,
@userEmail nvarchar(100)=null,
@userIsOfficial bit=null,
@userIsActive bit=null,
@Flg int) as Begin 
if @Flg=1
Begin
Declare @lastID int
Set @lastID=IsNull((select max(userID) from userProfile), 0)
Set @userID=@lastID+1
insert into userProfile output inserted.userID values(@userID, @userFirstName,@userMiddleName,@userLastName,@userEmail,@userIsOfficial,@userIsActive) 
End
if @Flg=2
Begin
update userProfile set userFirstName=@userFirstName,userMiddleName=@userMiddleName,userLastName=@userLastName,userEmail=@userEmail,userIsOfficial=@userIsOfficial,userIsActive=@userIsActive where userID=@userID 
End
if @Flg=3
Begin
delete from userProfile where userID=@userID 
End
if @Flg=4
Begin
select * from userProfile 
End
if @Flg=5
Begin
select * from userProfile where userID=@userID
End
if @Flg=6
Begin
select * from userProfile where userEmail=@userEmail
End
End

GO
/****** Object:  StoredProcedure [dbo].[SP_WashOff]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SP_WashOff] as 
Truncate table fin_Accounts
Truncate Table fin_AdditionalAutoTrans
Truncate table fin_AdditionalAutoTransGroup
Truncate table fin_Attachments
Truncate table fin_ChequePrinting
Truncate table fin_Transactions
Truncate table fin_TransGroups

GO
/****** Object:  Table [dbo].[CatchErrors]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CatchErrors](
	[EID] [int] IDENTITY(1,1) NOT NULL,
	[ErrMsg] [text] NOT NULL,
	[ErrRoot] [varchar](250) NOT NULL,
	[ErrTime] [datetime] NOT NULL,
 CONSTRAINT [PK_CatchErrors] PRIMARY KEY CLUSTERED 
(
	[EID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fin_AccountCategories]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fin_AccountCategories](
	[accCatID] [int] NOT NULL,
	[accCatTitle] [varchar](50) NOT NULL,
	[accCatDescription] [varchar](max) NULL,
 CONSTRAINT [PK_fin_AccountCategories] PRIMARY KEY CLUSTERED 
(
	[accCatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fin_Accounts]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fin_Accounts](
	[accountID] [int] NOT NULL,
	[accountPrefix] [varchar](20) NULL,
	[accountNo] [varchar](20) NULL,
	[accountLevel] [tinyint] NULL,
	[accountParent] [int] NULL,
	[accountType] [tinyint] NULL,
	[associateID] [int] NULL,
	[accountTitle] [nvarchar](150) NOT NULL,
	[accountDescription] [nvarchar](500) NULL,
	[accountCreatedOn] [datetime] NOT NULL,
	[accountCreatedBy] [int] NULL,
	[accountLastUpdated] [datetime] NULL,
	[accountLastUpdatedBy] [int] NULL,
	[accountLedger] [decimal](18, 2) NOT NULL,
	[accountActual] [decimal](18, 2) NOT NULL,
	[accountDefaultVersaAccount] [int] NULL,
	[accountIsBudgetDependent] [bit] NOT NULL,
	[accountIsActive] [bit] NOT NULL,
	[accountIsVisible] [bit] NOT NULL,
	[accountIsTransactable] [tinyint] NOT NULL,
	[accountSystemIndex] [tinyint] NULL,
 CONSTRAINT [PK_fin_Accounts_1] PRIMARY KEY CLUSTERED 
(
	[accountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fin_AdditionalAutoTrans]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fin_AdditionalAutoTrans](
	[autoTransID] [int] NOT NULL,
	[additionalTransId] [int] NOT NULL,
	[autoTransAccountId] [int] NOT NULL,
	[autoTransIsDebit] [bit] NULL,
	[autoTransAmountMultiplier] [decimal](18, 2) NOT NULL,
	[autoTransIsOfficial] [bit] NOT NULL,
	[autoTransNarration] [varchar](150) NOT NULL,
	[autoTransIsSeparateVouchar] [bit] NOT NULL,
	[autoTransSeparateID] [int] NULL,
	[autoTransIsPredefinedItem] [bit] NULL,
 CONSTRAINT [PK_fin_AdditionalAutoTrans] PRIMARY KEY CLUSTERED 
(
	[autoTransID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fin_AdditionalAutoTransGroup]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fin_AdditionalAutoTransGroup](
	[atgID] [int] NOT NULL,
	[transGroupTitle] [varchar](300) NOT NULL,
	[transGroupPrefixNo] [int] NOT NULL,
	[transGroupPrefixString] [varchar](5) NOT NULL,
	[transGroupForeNumber] [int] NOT NULL,
 CONSTRAINT [PK_fin_AdditionalAutoTransGroup] PRIMARY KEY CLUSTERED 
(
	[atgID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fin_Attachments]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fin_Attachments](
	[attachmentId] [int] NOT NULL,
	[attachmentOriginalFileName] [varchar](100) NOT NULL,
	[attachmentMaskedFileName] [varchar](100) NOT NULL,
	[transGroupID] [int] NOT NULL,
 CONSTRAINT [PK_fin_Attachments] PRIMARY KEY CLUSTERED 
(
	[attachmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fin_Branches]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fin_Branches](
	[branchId] [int] NOT NULL,
	[branchTitle] [varchar](50) NOT NULL,
 CONSTRAINT [PK_fin_Branches] PRIMARY KEY CLUSTERED 
(
	[branchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fin_ChequePrinting]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fin_ChequePrinting](
	[chequeId] [int] IDENTITY(1,1) NOT NULL,
	[bankId] [int] NOT NULL,
	[chequeTitle] [nvarchar](100) NOT NULL,
	[chequeAmount] [nvarchar](500) NOT NULL,
	[chequeAmountFig] [decimal](18, 1) NOT NULL,
	[chequeDate] [datetime] NULL,
	[chequeNo] [varchar](20) NULL,
	[chequeReceivedBy] [varchar](50) NULL,
	[chequeReceiverPhone] [varchar](15) NULL,
	[chequeReceiverIDCard] [varchar](15) NULL,
	[chequeCreatedBy] [int] NULL,
	[chequeCreatedOn] [datetime] NULL,
	[chequeStatus] [tinyint] NULL,
 CONSTRAINT [PK_fin_ChequePrinting] PRIMARY KEY CLUSTERED 
(
	[chequeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fin_Departments]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fin_Departments](
	[deptId] [int] NOT NULL,
	[deptTitle] [nvarchar](50) NOT NULL,
	[deptCode] [varchar](5) NOT NULL,
	[deptDescription] [varchar](500) NULL,
 CONSTRAINT [PK_fin_Departments] PRIMARY KEY CLUSTERED 
(
	[deptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fin_Entities]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fin_Entities](
	[entityId] [int] NOT NULL,
	[entityType] [int] NOT NULL,
	[entityTitle] [nvarchar](50) NOT NULL,
	[entityDescription] [varchar](500) NULL,
	[entityFirstName] [nvarchar](30) NULL,
	[entityLastName] [nvarchar](30) NULL,
	[entityEmail] [varchar](50) NULL,
	[entityAltEmail] [varchar](50) NULL,
	[entityAddress] [nvarchar](500) NULL,
	[entityCity] [nvarchar](100) NULL,
	[entityZip] [varchar](10) NULL,
	[entityCountry] [int] NULL,
	[entityState] [varchar](50) NULL,
	[entityPhone] [varchar](20) NULL,
	[entityAltPhone] [varchar](20) NULL,
	[entityMobile] [varchar](20) NULL,
	[entityAltMobile] [varchar](20) NULL,
	[entityFax] [varchar](20) NULL,
	[entityAltFax] [varchar](20) NULL,
	[entityStatus] [tinyint] NOT NULL,
	[entityAccountId] [int] NOT NULL,
	[entityAccountTitle] [varchar](150) NOT NULL,
	[entityCreatedOn] [datetime] NOT NULL,
	[entityCreatedBy] [int] NOT NULL,
	[entityLastUpdatedBy] [int] NOT NULL,
	[entityLastUpdateOn] [datetime] NOT NULL,
 CONSTRAINT [PK_fin_Entities] PRIMARY KEY CLUSTERED 
(
	[entityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fin_gen_entityTypes]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fin_gen_entityTypes](
	[entityType] [int] NOT NULL,
	[entityTypeTitle] [varchar](50) NOT NULL,
 CONSTRAINT [PK_fin_gen_entityTypes] PRIMARY KEY CLUSTERED 
(
	[entityType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fin_ModuleItems]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fin_ModuleItems](
	[additionalTransId] [int] NOT NULL,
	[moduleId] [int] NOT NULL,
	[additionalTransTitle] [varchar](50) NOT NULL,
	[addtionalTransAmountDependent] [bit] NOT NULL,
	[additionalTransAmount] [decimal](18, 2) NULL,
	[additionalTransDescription] [varchar](100) NULL,
	[addtionalTransIsOfficial] [bit] NULL,
	[moduleIParameterId] [int] NULL,
 CONSTRAINT [PK_fin_ModuleItems] PRIMARY KEY CLUSTERED 
(
	[additionalTransId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fin_Modules]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fin_Modules](
	[moduleId] [int] NOT NULL,
	[moduleTitle] [varchar](100) NOT NULL,
	[moduleDescription] [varchar](500) NULL,
	[moduleIsOffial] [bit] NOT NULL,
	[CField1] [varchar](50) NULL,
	[CField2] [varchar](50) NULL,
	[CField3] [varchar](50) NULL,
	[CField4] [varchar](50) NULL,
 CONSTRAINT [PK_fin_Modules] PRIMARY KEY CLUSTERED 
(
	[moduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fin_Transactions]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fin_Transactions](
	[transID] [int] NOT NULL,
	[transSystemIndex] [tinyint] NOT NULL,
	[transParticipantID] [int] NULL,
	[transRefID] [nvarchar](50) NULL,
	[transAttachedFiles] [nvarchar](500) NULL,
	[transInvoiceID] [int] NULL,
	[transDrAccount] [int] NULL,
	[transCrAccount] [int] NULL,
	[transNarration] [nvarchar](250) NOT NULL,
	[transAmount] [decimal](18, 2) NOT NULL,
	[transCreatedOn] [datetime] NOT NULL,
	[transCreatedBy] [int] NOT NULL,
	[transUpdatedOn] [datetime] NULL,
	[transUpdatedBy] [int] NULL,
	[transStatus] [tinyint] NOT NULL,
	[transSystemRestrict] [bit] NOT NULL,
	[transGroupID] [int] NULL,
	[transIsCompound] [bit] NOT NULL,
	[transType] [int] NULL,
	[deptId] [int] NULL,
 CONSTRAINT [PK_fin_Transactions] PRIMARY KEY CLUSTERED 
(
	[transID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[fin_TransGroups]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fin_TransGroups](
	[transGroupID] [int] NOT NULL,
	[transGroupTitle] [nvarchar](300) NOT NULL,
	[transGroupCreatedOn] [datetime] NOT NULL,
	[transGroupCreatedBy] [int] NOT NULL,
	[transGroupTotalAmount] [decimal](18, 2) NOT NULL,
	[transGroupOfficialTotalAmount] [decimal](18, 2) NULL,
	[transTransCount] [int] NOT NULL,
	[transGroupPrefixNo] [int] NULL,
	[transGroupPrefixString] [nvarchar](5) NULL,
	[transGroupForeNumber] [int] NULL,
	[transGroupStatus] [tinyint] NOT NULL,
	[transGroupApprovedBy] [int] NULL,
	[transGroupApprovedOn] [datetime] NULL,
	[transGroupReviewedBy] [int] NULL,
	[transGroupReviewedOn] [datetime] NULL,
	[transLinkedToGroup] [int] NULL,
	[transGroupIsOfficial] [int] NOT NULL,
	[transGroupRefId] [nvarchar](100) NULL,
	[transCField1] [varchar](250) NULL,
	[transCField2] [varchar](250) NULL,
	[transCField3] [varchar](250) NULL,
	[transCField4] [varchar](250) NULL,
 CONSTRAINT [PK_fin_TransGroups] PRIMARY KEY CLUSTERED 
(
	[transGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[userProfile]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[userProfile](
	[userID] [int] NOT NULL,
	[userFirstName] [nvarchar](50) NOT NULL,
	[userMiddleName] [nvarchar](50) NULL,
	[userLastName] [nvarchar](50) NOT NULL,
	[userEmail] [varchar](100) NOT NULL,
	[userIsOfficial] [bit] NOT NULL,
	[userIsActive] [bit] NOT NULL,
 CONSTRAINT [PK_userProfile] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[vw_Entities]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Entities]
AS
SELECT        dbo.fin_Entities.*, dbo.fin_gen_entityTypes.entityTypeTitle
FROM            dbo.fin_Entities INNER JOIN
                         dbo.fin_gen_entityTypes ON dbo.fin_Entities.entityType = dbo.fin_gen_entityTypes.entityType


GO
/****** Object:  View [dbo].[vw_page_transactions]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_page_transactions]
AS
SELECT        dbo.fin_TransGroups.*, dbo.userProfile.userFirstName, dbo.userProfile.userLastName
FROM            dbo.fin_TransGroups INNER JOIN
                         dbo.userProfile ON dbo.fin_TransGroups.transGroupCreatedBy = dbo.userProfile.userID


GO
/****** Object:  View [dbo].[vw_Transactions]    Script Date: 12/4/2015 1:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Transactions]
AS
SELECT        dbo.fin_Transactions.transID, dbo.fin_Transactions.transSystemIndex, dbo.fin_Transactions.transParticipantID, dbo.fin_Transactions.transRefID, dbo.fin_Transactions.transAttachedFiles, 
                         dbo.fin_Transactions.transInvoiceID, dbo.fin_Transactions.transDrAccount, dbo.fin_Transactions.transCrAccount, dbo.fin_Transactions.transNarration, dbo.fin_Transactions.transAmount, 
                         dbo.fin_Transactions.transCreatedOn, dbo.fin_Transactions.transCreatedBy, dbo.fin_Transactions.transUpdatedOn, dbo.fin_Transactions.transUpdatedBy, dbo.fin_Transactions.transStatus, 
                         dbo.fin_Transactions.transSystemRestrict, dbo.fin_Transactions.transGroupID, dbo.fin_Transactions.transIsCompound, dbo.fin_Transactions.transType, dbo.fin_TransGroups.transGroupTitle, 
                         dbo.fin_TransGroups.transGroupCreatedOn, dbo.fin_TransGroups.transGroupCreatedBy, dbo.fin_TransGroups.transGroupTotalAmount, dbo.fin_TransGroups.transTransCount, 
                         dbo.fin_TransGroups.transLinkedToGroup, dbo.fin_TransGroups.transGroupReviewedOn, dbo.fin_TransGroups.transGroupReviewedBy, dbo.fin_TransGroups.transGroupApprovedOn, 
                         dbo.fin_TransGroups.transGroupApprovedBy, dbo.fin_TransGroups.transGroupStatus, dbo.fin_TransGroups.transGroupForeNumber, dbo.fin_TransGroups.transGroupPrefixString, 
                         dbo.fin_TransGroups.transGroupPrefixNo, dbo.fin_Accounts.accountTitle, fin_Accounts_1.accountTitle AS crAccountTitle, dbo.fin_Transactions.deptId, dbo.fin_Departments.deptCode, 
                         dbo.fin_TransGroups.transGroupRefId
FROM            dbo.fin_Transactions INNER JOIN
                         dbo.fin_TransGroups ON dbo.fin_Transactions.transGroupID = dbo.fin_TransGroups.transGroupID INNER JOIN
                         dbo.fin_Departments ON dbo.fin_Transactions.deptId = dbo.fin_Departments.deptId LEFT OUTER JOIN
                         dbo.fin_Accounts ON dbo.fin_Transactions.transDrAccount = dbo.fin_Accounts.accountID LEFT OUTER JOIN
                         dbo.fin_Accounts AS fin_Accounts_1 ON dbo.fin_Transactions.transCrAccount = fin_Accounts_1.accountID


GO
ALTER TABLE [dbo].[fin_Accounts] ADD  CONSTRAINT [DF_fin_Accounts_accountIsBudgetDependent]  DEFAULT ((0)) FOR [accountIsBudgetDependent]
GO
ALTER TABLE [dbo].[fin_Accounts] ADD  CONSTRAINT [DF_fin_Accounts_accountIsActive]  DEFAULT ((1)) FOR [accountIsActive]
GO
ALTER TABLE [dbo].[fin_Accounts] ADD  CONSTRAINT [DF_fin_Accounts_accountIsVisible]  DEFAULT ((1)) FOR [accountIsVisible]
GO
ALTER TABLE [dbo].[fin_Accounts] ADD  CONSTRAINT [DF_fin_Accounts_accountIsTransactable]  DEFAULT ((1)) FOR [accountIsTransactable]
GO
ALTER TABLE [dbo].[fin_Transactions] ADD  CONSTRAINT [DF_fin_Transactions_transSystemRestrict]  DEFAULT ((0)) FOR [transSystemRestrict]
GO
ALTER TABLE [dbo].[fin_Transactions] ADD  CONSTRAINT [DF_fin_Transactions_transIsCompound]  DEFAULT ((0)) FOR [transIsCompound]
GO
ALTER TABLE [dbo].[fin_TransGroups] ADD  CONSTRAINT [DF_fin_TransGroups_transGroupIsOfficial]  DEFAULT ((0)) FOR [transGroupIsOfficial]
GO
ALTER TABLE [dbo].[fin_AdditionalAutoTrans]  WITH CHECK ADD  CONSTRAINT [FK_fin_AdditionalAutoTrans_fin_ModuleItems] FOREIGN KEY([additionalTransId])
REFERENCES [dbo].[fin_ModuleItems] ([additionalTransId])
GO
ALTER TABLE [dbo].[fin_AdditionalAutoTrans] CHECK CONSTRAINT [FK_fin_AdditionalAutoTrans_fin_ModuleItems]
GO
ALTER TABLE [dbo].[fin_Entities]  WITH CHECK ADD  CONSTRAINT [FK_fin_Entities_fin_gen_entityTypes] FOREIGN KEY([entityType])
REFERENCES [dbo].[fin_gen_entityTypes] ([entityType])
GO
ALTER TABLE [dbo].[fin_Entities] CHECK CONSTRAINT [FK_fin_Entities_fin_gen_entityTypes]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "fin_Entities"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fin_gen_entityTypes"
            Begin Extent = 
               Top = 6
               Left = 274
               Bottom = 122
               Right = 444
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Entities'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Entities'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "fin_TransGroups"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 211
               Right = 257
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "userProfile"
            Begin Extent = 
               Top = 6
               Left = 295
               Bottom = 183
               Right = 475
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_page_transactions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_page_transactions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "fin_Transactions"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 323
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "fin_TransGroups"
            Begin Extent = 
               Top = 6
               Left = 268
               Bottom = 206
               Right = 487
            End
            DisplayFlags = 280
            TopColumn = 14
         End
         Begin Table = "fin_Departments"
            Begin Extent = 
               Top = 6
               Left = 1087
               Bottom = 196
               Right = 1260
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fin_Accounts"
            Begin Extent = 
               Top = 6
               Left = 525
               Bottom = 260
               Right = 768
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fin_Accounts_1"
            Begin Extent = 
               Top = 6
               Left = 806
               Bottom = 293
               Right = 1049
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 36
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Transactions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'        Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Transactions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Transactions'
GO
