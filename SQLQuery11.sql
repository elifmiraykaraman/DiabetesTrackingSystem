CREATE TABLE dbo.recommendation_rules (
  rule_id        INT IDENTITY PRIMARY KEY,
  min_glucose    INT     NULL,
  max_glucose    INT     NULL,
  symptom_ids    VARCHAR(100) NULL,  -- örneðin "1,3,7"
  diet_type_id   INT     NULL,
  exercise_type_id INT   NULL,
  priority       INT     NOT NULL    -- hangi sýrayla çalýþtýrýlacak
);
