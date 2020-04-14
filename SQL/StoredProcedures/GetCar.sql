CREATE PROCEDURE [dbo].[GetCar]
	@Id int
AS
	SELECT * FROM Cars WHERE Id = @Id