SELECT TOP (1000) [measurement_id]
      ,[patient_id]
      ,[measurement_time]
      ,[measurement_window]
      ,[glucose_level]
      ,[created_at]
  FROM [DiyabetDB].[dbo].[glucose_measurements]
