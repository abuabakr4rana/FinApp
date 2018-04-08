
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