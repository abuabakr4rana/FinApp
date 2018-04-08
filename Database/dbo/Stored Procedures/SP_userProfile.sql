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