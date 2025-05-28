// RecommendationService.cs
using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace DiabetesTracker.Services
{
    public struct Recommendation
    {
        public int RuleId { get; set; }
        public int DietTypeId { get; set; }
        public int? ExerciseTypeId { get; set; }
        public string Diet { get; set; }
        public string Exercise { get; set; }
    }

    public class RecommendationService
    {
        private readonly string _connString;

        public RecommendationService()
        {
            var cs = ConfigurationManager.ConnectionStrings["DiabetesConn"];
            if (cs == null)
                throw new InvalidOperationException(
                    "app.config içinde DiabetesConn adında bir connectionStrings öğesi bulunamadı.");
            _connString = cs.ConnectionString;
        }

        public Recommendation? GetRecommendation(int glucose, IEnumerable<int> symptomIds)
        {
            var symptomCsv = string.Join(",", symptomIds);
            var sql = @"
DECLARE @g FLOAT = @gl;
DECLARE @s VARCHAR(200) = @csv;

WITH matching_rules AS (
    SELECT
      rr.rule_id,
      rr.diet_type_id,
      rr.exercise_type_id,
      dt.name AS Diet,
      ISNULL(et.name,'Yok') AS Exercise
    FROM dbo.recommendation_rules rr
    JOIN dbo.diet_types dt ON dt.diet_type_id = rr.diet_type_id
    LEFT JOIN dbo.exercise_types et ON et.exercise_type_id = rr.exercise_type_id
    WHERE @g BETWEEN rr.min_glucose AND rr.max_glucose
),
rule_symptom_counts AS (
    SELECT
      rs.rule_id,
      COUNT(*) AS RequiredCount,
      SUM(CASE WHEN ss.value IS NOT NULL THEN 1 ELSE 0 END) AS MatchedCount
    FROM dbo.rule_symptoms rs
    LEFT JOIN STRING_SPLIT(@s, ',') ss ON TRY_CAST(ss.value AS INT) = rs.symptom_type_id
    GROUP BY rs.rule_id
)
SELECT TOP 1
    mr.rule_id,
    mr.diet_type_id,
    mr.exercise_type_id,
    mr.Diet,
    mr.Exercise
FROM matching_rules mr
JOIN rule_symptom_counts rc ON mr.rule_id = rc.rule_id
WHERE rc.MatchedCount = rc.RequiredCount
ORDER BY mr.rule_id;";

            using var conn = new SqlConnection(_connString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@gl", glucose);
            cmd.Parameters.AddWithValue("@csv", symptomCsv);
            conn.Open();

            using var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                return new Recommendation
                {
                    RuleId = rdr.GetInt32(0),
                    DietTypeId = rdr.GetInt32(1),
                    ExerciseTypeId = rdr.IsDBNull(2) ? (int?)null : rdr.GetInt32(2),
                    Diet = rdr.GetString(3),
                    Exercise = rdr.GetString(4)
                };
            }
            return null;
        }
    }
}