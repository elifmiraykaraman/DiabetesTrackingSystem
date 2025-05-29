USE DiyabetDB;
GO


CREATE TABLE dbo.daily_glucose_averages (
  avg_id            INT IDENTITY PRIMARY KEY,
  patient_id        INT NOT NULL REFERENCES dbo.users(user_id),
  measurement_date  DATE NOT NULL,
  average_level     DECIMAL(5,2) NOT NULL
);
