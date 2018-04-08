
CREATE Procedure [dbo].[SP_fin_Preselected_Vouchar_Accounts](
	@moduleId int,
	@moduleParameterId int,
	@moduleIsOfficial bit
) as
Begin
	select * from fin_AdditionalAutoTrans where autoTransSeparateID=0 and autoTransIsPredefinedItem=1 and additionalTransId in (select additionalTransId from fin_ModuleItems 
		where moduleId=@moduleId and addtionalTransIsOfficial=@moduleIsOfficial and moduleIParameterId=@moduleParameterId) order by autoTransIsDebit desc
End