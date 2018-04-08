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