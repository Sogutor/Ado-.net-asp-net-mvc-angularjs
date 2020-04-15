CREATE PROCEDURE [dbo].[UpdateCar]
	@Id int,
	@CustomerName text,
	@CarNumber text,
	@MobilePhone text,
	@Mark int,
	@Model int
AS
	UPDATE Cars SET CustomerName=@CustomerName, CarNumber=@CarNumber,
	MobilePhone=@MobilePhone,MarkId=@Mark,ModelId=@Model
	WHERE Id=@Id