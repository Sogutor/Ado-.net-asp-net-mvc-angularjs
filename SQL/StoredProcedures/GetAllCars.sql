CREATE PROCEDURE [dbo].[GetAllCars]
AS
	SELECT cars.Id,cars.MobilePhone,cars.CarNumber,cars.CustomerName,
		model.Name as Model,
		mark.Name as Mark
	FROM 
		(SELECT * FROM Cars) cars
	LEFT JOIN
		(SELECT * FROM CarModels) as model
	ON (cars.ModelId = model.Id)
	LEFT JOIN
		(SELECT * FROM CarMarks) as mark
	ON (cars.MarkId = mark.Id)
RETURN 0