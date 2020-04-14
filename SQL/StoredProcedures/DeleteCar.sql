CREATE PROCEDURE [dbo].[DeleteCar]
	@Id int
AS
	DELETE FROM Cars WHERE Id=@Id;