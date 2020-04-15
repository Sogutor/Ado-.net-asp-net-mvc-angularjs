CREATE PROCEDURE [dbo].[GetAllCarTypes]
AS
	SELECT 		
		model.Name,model.Id,
		mark.Name as MarkName,mark.Id as MarkId
	FROM 
		(SELECT * FROM CarMarks) as mark		
	LEFT JOIN
		(SELECT * FROM CarModels) as model
	ON (mark.Id = model.MarkId)
RETURN 0