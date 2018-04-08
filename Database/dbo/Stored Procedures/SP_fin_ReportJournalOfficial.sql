CREATE Procedure [dbo].[SP_fin_ReportJournalOfficial](@fromDate datetime, @toDate datetime, @recordNoFrom int, @recordNoTo int)
AS
BEGIN
--	Select *,(Convert(varchar, IsNull(transGroupPrefixNo, 0)) + transGroupPrefixString + Convert(varchar, IsNull(transGroupForeNumber, 0))) as voucharNo from fin_TransGroups where transGroupIsOfficial=1 and transGroupCreatedOn between @fromDate and @toDate order by transGroupCreatedOn desc
	Declare @maxRows int
	Set @maxRows = (Select Count(transGroupId) from fin_TransGroups where Not transGroupStatus=3 and transGroupCreatedOn between @fromDate and @toDate)
	Select *, @maxRows as MaxRows from (Select *, replace(Convert(varchar(50),cast(transGroupOfficialTotalAmount as money), 1), '.00','') as TotalAmountFormatted, (Convert(varchar, IsNull(transGroupPrefixNo, 0)) + transGroupPrefixString + Convert(varchar, IsNull(transGroupForeNumber, 0))) as voucharNo, ROW_NUMBER() Over(order by transGroupCreatedOn desc) as RowNo from fin_TransGroups where not transGroupStatus=3 and transGroupIsOfficial=1 and transGroupCreatedOn between @fromDate and @toDate) as Results where RowNo<@recordNoTo and RowNo>=@recordNoFrom
END