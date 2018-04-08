
Create Procedure [dbo].[SP_CatchErrors] (
	@ErrMsg text output,
	@ErrPath varchar(250) output)
as
Begin
	insert into CatchErrors values(@ErrMsg, @ErrPath, CURRENT_TIMESTAMP)
End