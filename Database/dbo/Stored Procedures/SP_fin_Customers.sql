

CREATE Procedure [dbo].[SP_fin_Customers](
@customerId int=null,
@customerCode varchar(5)=null,
@customerTitle nvarchar(50)=null,
@customerURL varchar(300)=null,
@customerDescription nvarchar(500)=null,
@customerProductType int=null,
@customerAddressLine1 nvarchar(500)=null,
@customerAddressLine2 nvarchar(500)=null,
@customerCity nvarchar(100)=null,
@customerZip nvarchar(10)=null,
@customerState nvarchar(50)=null,
@customerStateShortcode nvarchar(5)=null,
@customerCountry nvarchar(50)=null,
@customerCountryShortcode nvarchar(5)=null,
@customerIsActive bit=null,
@customerEmail nvarchar(100)=null,
@customerEmailAlt nvarchar(100)=null,
@customerPhone nvarchar(15)=null,
@customerPhoneAlt nvarchar(15)=null,
@customerMinQty int=null,
@customerMaxQty int=null,
@customerOrderIntimationEmal nvarchar(100)=null,
@customerSampleIntimationEmail nvarchar(100)=null,
@customerFTP nvarchar(100)=null,
@customerFtpUsername nvarchar(100)=null,
@customerFtpPassword nvarchar(100)=null,
@customerSendOnFtp bit=null,
@customerFirstName nvarchar(50)=null,
@customerLastName nvarchar(50)=null,
@customerAccountId	int=null,
@customerCreatedOn datetime = null,
@customerCreatedBy int=null,
@customerCreatedIP varchar(50)=null,
@Flg int) as Begin 
if @Flg=1
Begin

Declare @existCount int 
Set @existCount = (Select count(customerId) from fin_Customers where customerId=@customerId)

	if @existCount = 0
	Begin
	Declare @lastID int
	Set @lastID=IsNull((select max(customerId) from fin_Customers), 0)
	Set @customerId=@lastID+1

	insert into fin_Customers output inserted.customerId values(@customerId,@customerCode,@customerURL,@customerTitle,@customerDescription,@customerProductType,
	@customerAddressLine1,@customerAddressLine2,@customerCity,@customerZip,@customerState,@customerStateShortcode,@customerCountry,@customerCountryShortcode,
	@customerIsActive,@customerEmail,@customerEmailAlt,@customerPhone,@customerPhoneAlt,@customerMinQty,@customerMaxQty,@customerOrderIntimationEmal,
	@customerSampleIntimationEmail,@customerFTP,@customerFtpUsername,@customerFtpPassword,
	@customerSendOnFtp,@customerFirstName,@customerLastName, @customerAccountId, @customerCreatedOn, 
	@customerCreatedBy, @customerCreatedIP)
	
	End
	Else
	Begin
		Set @Flg=2
	End

End
if @Flg=2
Begin
update fin_Customers set customerCode=@customerCode,customerURL=@customerURL,customerTitle=@customerTitle,customerDescription=@customerDescription,
customerProductType=@customerProductType,customerAddressLine1=@customerAddressLine1,customerAddressLine2=@customerAddressLine2,customerCity=@customerCity,
customerZip=@customerZip,customerState=@customerState,customerStateShortcode=@customerStateShortcode,customerCountry=@customerCountry,
customerCountryShortcode=@customerCountryShortcode,customerIsActive=@customerIsActive,customerEmail=@customerEmail,
customerEmailAlt=@customerEmailAlt,customerPhone=@customerPhone,customerPhoneAlt=@customerPhoneAlt,customerMinQty=@customerMinQty,
customerMaxQty=@customerMaxQty,customerOrderIntimationEmal=@customerOrderIntimationEmal,customerSampleIntimationEmail=@customerSampleIntimationEmail,
customerFTP=@customerFTP,customerFtpUsername=@customerFtpUsername,customerFtpPassword=@customerFtpPassword,customerSendOnFtp=@customerSendOnFtp,
customerFirstName=@customerFirstName,customerLastName=@customerLastName, customerAccountId=@customerAccountId,
customerCreatedOn=@customerCreatedOn, customerCreatedBy=@customerCreatedBy, customerCreatedIP=@customerCreatedIP
 where customerId=@customerId 
End
if @Flg=3
Begin
delete from fin_Customers where customerId=@customerId 
End
if @Flg=4
Begin
select * from fin_Customers 
End
if @Flg=5
Begin
select * from fin_Customers where customerId=@customerId
End
if @Flg=6
Begin
	select * from fin_Customers where customerURL=@customerURL
End
if @Flg=7
Begin
	select * from fin_Customers where customerAccountId=@customerAccountId
End
End