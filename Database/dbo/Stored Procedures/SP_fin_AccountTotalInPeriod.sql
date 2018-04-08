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