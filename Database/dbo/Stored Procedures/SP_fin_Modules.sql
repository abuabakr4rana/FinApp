Create Procedure [dbo].[SP_fin_Modules](
@moduleId int =null,
@moduleTitle varchar (100)=null,
@moduleDescription varchar (500)=null,
@moduleIsOffial bit =null,
@CField1 varchar (50)=null,
@CField2 varchar (50)=null,
@CField3 varchar (50)=null,
@CField4 varchar (50)=null,
@Flg int) as Begin 
if @Flg=1
Begin
Declare @lastID int
Set @lastID=IsNull((select max(moduleId) from fin_Modules), 0)
Set @moduleId=@lastID+1

insert into fin_Modules output inserted.moduleId values(@moduleId, @moduleTitle,@moduleDescription,@moduleIsOffial,@CField1,@CField2,@CField3,@CField4) 
End
if @Flg=2
Begin
update fin_Modules set moduleTitle=@moduleTitle,moduleDescription=@moduleDescription,moduleIsOffial=@moduleIsOffial,CField1=@CField1,CField2=@CField2,CField3=@CField3,CField4=@CField4 where moduleId=@moduleId 
End
if @Flg=3
Begin
delete from fin_Modules where moduleId=@moduleId 
End
if @Flg=4
Begin
select * from fin_Modules 
End
if @Flg=5
Begin
select * from fin_Modules where moduleId=@moduleId
End

End