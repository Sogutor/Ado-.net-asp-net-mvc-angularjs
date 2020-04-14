CREATE PROCEDURE [dbo].[UpdateCar]
	@Id int,
	@CustomerName text,
	@CarNumber text,
	@MobilePhone text
AS
	UPDATE Cars SET CustomerName=@CustomerName, CarNumber=@CarNumber, MobilePhone=@MobilePhone
	WHERE Id=@Id