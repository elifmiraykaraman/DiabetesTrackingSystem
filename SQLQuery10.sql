SELECT TOP (1000) [recommendation_id]
      ,[patient_id]
      ,[recommendation_date]
      ,[insulin_dose_ml]
      ,[created_at]
  FROM [DiyabetDB].[dbo].[insulin_recommendations]
  SELECT *
FROM dbo.doctor_recommendations;
