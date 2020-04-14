CREATE PROCEDURE [dbo].[InsertCar]
	@CustomerName text,
	@CarNumber text,
	@MobilePhone text
AS
	INSERT INTO Cars (CustomerName, CarNumber, MobilePhone)
	VALUES (@CustomerName, @CarNumber, @MobilePhone)