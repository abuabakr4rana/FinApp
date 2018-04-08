
CREATE Procedure [dbo].[SP_fin_Vendors](
@vendorId int=null,
@vendorCode varchar(5)=null,
@vendorTitle nvarchar(50)=null,
@vendorURL varchar(300)=null,
@vendorDescription nvarchar(500)=null,
@vendorProductType int=null,
@vendorAddressLine1 nvarchar(500)=null,
@vendorAddressLine2 nvarchar(500)=null,
@vendorCity nvarchar(100)=null,
@vendorZip nvarchar(10)=null,
@vendorState nvarchar(50)=null,
@vendorStateShortcode nvarchar(5)=null,
@vendorCountry nvarchar(50)=null,
@vendorCountryShortcode nvarchar(5)=null,
@vendorIsActive bit=null,
@vendorEmail nvarchar(100)=null,
@vendorEmailAlt nvarchar(100)=null,
@vendorPhone nvarchar(15)=null,
@vendorPhoneAlt nvarchar(15)=null,
@vendorMinQty int=null,
@vendorMaxQty int=null,
@vendorOrderIntimationEmal nvarchar(100)=null,
@vendorSampleIntimationEmail nvarchar(100)=null,
@vendorFTP nvarchar(100)=null,
@vendorFtpUsername nvarchar(100)=null,
@vendorFtpPassword nvarchar(100)=null,
@vendorSendOnFtp bit=null,
@vendorFirstName nvarchar(50)=null,
@vendorLastName nvarchar(50)=null,
@vendorAccountId int=null,
@vendorCreatedOn datetime=null,
@vendorCreatedBy int=null,
@vendorCreatedIP varchar(50)=null,
@Flg int) as Begin 
if @Flg=1
Begin

Declare @existCount int 
Set @existCount = (Select count(vendorId) from fin_Vendors where vendorId=@vendorId)

	if @existCount = 0
	Begin
	Declare @lastID int
	Set @lastID=IsNull((select max(vendorId) from fin_Vendors), 0)
	Set @vendorId=@lastID+1

	insert into fin_Vendors output inserted.vendorId values(@vendorId,@vendorCode,@vendorURL,@vendorTitle,@vendorDescription,@vendorProductType,
	@vendorAddressLine1,@vendorAddressLine2,@vendorCity,@vendorZip,@vendorState,@vendorStateShortcode,@vendorCountry,@vendorCountryShortcode,
	@vendorIsActive,@vendorEmail,@vendorEmailAlt,@vendorPhone,@vendorPhoneAlt,@vendorMinQty,@vendorMaxQty,@vendorOrderIntimationEmal,
	@vendorSampleIntimationEmail,@vendorFTP,@vendorFtpUsername,@vendorFtpPassword,@vendorSendOnFtp,@vendorFirstName,@vendorLastName, @vendorAccountId,
	@vendorCreatedOn,@vendorCreatedBy,@vendorCreatedIP)
	
	End
	Else
	Begin
		Set @Flg=2
	End

End
if @Flg=2
Begin
update fin_Vendors set vendorCode=@vendorCode,vendorURL=@vendorURL,vendorTitle=@vendorTitle,vendorDescription=@vendorDescription,
vendorProductType=@vendorProductType,vendorAddressLine1=@vendorAddressLine1,vendorAddressLine2=@vendorAddressLine2,vendorCity=@vendorCity,
vendorZip=@vendorZip,vendorState=@vendorState,vendorStateShortcode=@vendorStateShortcode,vendorCountry=@vendorCountry,
vendorCountryShortcode=@vendorCountryShortcode,vendorIsActive=@vendorIsActive,vendorEmail=@vendorEmail,
vendorEmailAlt=@vendorEmailAlt,vendorPhone=@vendorPhone,vendorPhoneAlt=@vendorPhoneAlt,vendorMinQty=@vendorMinQty,
vendorMaxQty=@vendorMaxQty,vendorOrderIntimationEmal=@vendorOrderIntimationEmal,vendorSampleIntimationEmail=@vendorSampleIntimationEmail,
vendorFTP=@vendorFTP,vendorFtpUsername=@vendorFtpUsername,vendorFtpPassword=@vendorFtpPassword,vendorSendOnFtp=@vendorSendOnFtp,
vendorFirstName=@vendorFirstName,vendorLastName=@vendorLastName, vendorAccountId=@vendorAccountId,
vendorCreatedOn=@vendorCreatedOn, vendorCreatedBy=@vendorCreatedBy, vendorCreatedIP=@vendorCreatedIP
 where vendorId=@vendorId 
End
if @Flg=3
Begin
delete from fin_Vendors where vendorId=@vendorId 
End
if @Flg=4
Begin
select * from fin_Vendors 
End
if @Flg=5
Begin
select * from fin_Vendors where vendorId=@vendorId
End
if @Flg=6
Begin
	select * from fin_Vendors where vendorURL=@vendorURL
End
if @Flg=7
Begin
	select * from fin_Vendors where vendorAccountId=@vendorAccountId
End
End