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