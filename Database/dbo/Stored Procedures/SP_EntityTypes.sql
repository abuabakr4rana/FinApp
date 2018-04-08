Create Procedure [dbo].[SP_EntityTypes](
@entityType int =null,
@entityTypeTitle varchar (50)=null,
@Flg int) as Begin 
if @Flg=1
Begin
Declare @lastID int
Set @lastID=IsNull((select max(entityType) from fin_gen_entityTypes), 0)
Set @entityType=@lastID+1

insert into fin_gen_entityTypes output inserted.entityType values(@entityType, @entityTypeTitle) 
End
if @Flg=2
Begin
update fin_gen_entityTypes set entityTypeTitle=@entityTypeTitle where entityType=@entityType 
End
if @Flg=3
Begin
delete from fin_gen_entityTypes where entityType=@entityType 
End
if @Flg=4
Begin
select * from fin_gen_entityTypes 
End
if @Flg=5
Begin
select * from fin_gen_entityTypes where entityType=@entityType
End

End