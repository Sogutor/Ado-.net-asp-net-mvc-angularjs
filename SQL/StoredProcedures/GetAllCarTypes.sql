CREATE PROCEDURE [dbo].[GetAllCarTypes]
AS
	SELECT 		
		model.Name,model.Name,
		mark.Name as MarkName,mark.Id as MarkId
	FROM 
		(SELECT * FROM CarMarks) as mark		
	LEFT JOIN
		(SELECT * FROM CarModels) as model
	ON (mark.ModelId = model.Id)
RETURN 0