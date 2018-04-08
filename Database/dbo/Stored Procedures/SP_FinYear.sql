-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_FinYear] (
	@finyrID	int = null,
	@startDate	datetime = null,
	@endDate	datetime = null,
	@status	bit = null,
	@inputDate	datetime = null,
	@Flg		int )
AS
BEGIN
if @Flg=1
Begin
	Declare @lastID int
	Set @lastID=IsNull((select max(finyrID) from [dbo].FinYear), 0)
	Set @finyrID=@lastID+1
	
	insert into FinYear(finyrID, startDate, endDate, status) values(@finyrID, @startDate, @endDate, @status)
	 
End

if @Flg=2
Begin
	update FinYear set startDate = @startDate, endDate = @endDate, status = @status Where finyrID = @finyrID;
End

if @Flg=3
Begin
	delete FinYear Where finyrID = @finyrID;
End

if @Flg=4
Begin
	select * from FinYear
End

if @Flg=5
Begin
	select * from Finyear where finyrID=@finyrID
End

if @Flg=6
Begin
	select * from FinYear as f Where (@inputDate Between startDate and endDate) and [status]=@status
End

END