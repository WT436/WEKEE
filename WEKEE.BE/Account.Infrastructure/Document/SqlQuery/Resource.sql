
USE [Authorization];

DECLARE @array nvarchar(MAX) = '[1,22,15]'
SELECT VALUE FROM OPENJSON(@array)

-- --------------------------------------------------------
SELECT DISTINCT [Resource].* 
FROM [Resource]
--JOIN [UserLogin] on [UserLogin].[id] = [Resource].[create_by]
--WHERE

	  --CAST([Resource].[id] AS VARCHAR(MAX)) LIKE '%2%'		       OR
	  --CAST([Resource].[name] AS VARCHAR(MAX)) LIKE '%33%'   	       OR
   --   CAST([Resource].[is_active] AS VARCHAR(MAX)) LIKE '%43%'		   OR
   --   CAST([Resource].[types_rsc] AS VARCHAR(MAX)) LIKE '%2%'		   OR
   --   CAST([Resource].[description] AS VARCHAR(MAX)) LIKE '%2%'		   OR
   --   CAST([UserLogin].[user_name] AS VARCHAR(MAX)) LIKE '%3fdasda%'     OR
   --        [Resource].[created_at] = '2021-12-12 06:32:10.9533'   OR
   --        [Resource].[updated_at] = '2021-12-12 06:32:10.9533'
ORDER BY id DESC OFFSET 1 ROWS FETCH NEXT 10 ROWS ONLY  