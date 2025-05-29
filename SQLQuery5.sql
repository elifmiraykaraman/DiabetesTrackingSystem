SELECT kc.name, c.name AS column_name
FROM sys.key_constraints kc
JOIN sys.index_columns ic
  ON kc.parent_object_id = ic.object_id
 AND kc.unique_index_id  = ic.index_id
JOIN sys.columns c
  ON ic.object_id = c.object_id
 AND ic.column_id = c.column_id
WHERE kc.parent_object_id = OBJECT_ID('dbo.users')
  AND kc.type = 'UQ';
