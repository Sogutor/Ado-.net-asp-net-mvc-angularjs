CREATE PROCEDURE [dbo].[InsertCar]
	@Id int,
	@CustomerName text,
	@CarNumber text,
	@MobilePhone text,
	@Mark int,
	@Model int
AS
	INSERT INTO Cars (CustomerName, CarNumber, MobilePhone, MarkId, ModelId)
	VALUES (@CustomerName, @CarNumber, @MobilePhone, @Mark, @Model)