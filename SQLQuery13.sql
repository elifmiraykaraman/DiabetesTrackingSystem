USE DiyabetDB;
GO

CREATE TABLE dbo.glucose_measurements (
  measurement_id    INT IDENTITY PRIMARY KEY,
  patient_id        INT NOT NULL 
      CONSTRAINT FK_glucose_measurements_patients 
      REFERENCES dbo.users(user_id),
  measurement_time  DATETIME NOT NULL,
  glucose_level     DECIMAL(5,2) NOT NULL
);
