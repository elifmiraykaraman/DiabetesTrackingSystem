SELECT dc.name AS ConstraintName
  FROM sys.default_constraints dc
  JOIN sys.columns c
    ON c.default_object_id = dc.object_id
  JOIN sys.tables t
    ON t.object_id = c.object_id
 WHERE t.name = 'users'
   AND c.name = 'created_at';
