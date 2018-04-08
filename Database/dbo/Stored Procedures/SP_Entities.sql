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