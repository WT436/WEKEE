USE ProductDB

GO
CREATE TYPE page_list_search AS TABLE
(
  ValuesSearch NVARCHAR(MAX),
  PropertySearch NVARCHAR(MAX)
)
GO
CREATE PROC DBO.SELECT_ALL_CONDITIONAL_FULL 
			@page_list_search AS dbo.page_list_search READONLY,
			@PropertyOrder AS VARCHAR(MAX),
			@ValueOrderBy AS NVARCHAR(MAX),
			@PageIndex AS INT,
			@PageSize AS INT
AS
BEGIN
	SELECT * 
	FROM CategoryProduct		
	
END
GO;
	SELECT 
		CP.id,
		CP.nameCategory,
		CP.urlCategory,
		CP.iconCategory ,	
		CP.levelCategory,
		CP.categoryMain,
		(SELECT nameCategory FROM CategoryProduct where id = CP.categoryMain) AS categoryMainName,
		CP.numberOrder,
		CP.isEnabled,
		CP.CreatedOnUtc,
		CP.UpdatedOnUtc
	FROM CategoryProduct AS CP
	WHERE nameCategory LIKE '%S%'
	  AND urlCategory LIKE '%S%'
	ORDER BY id ASC
	OFFSET ((2 - 1) * 2) ROWS
	FETCH NEXT 2 ROWS ONLY;
GO;

DECLARE @query nvarchar(max) = 'SELECT * 
	FROM CategoryProduct
	WHERE nameCategory LIKE ''%s%''
	  AND urlCategory LIKE ''%S%''
	ORDER BY id ASC
		OFFSET ((1 - 1) * 5) ROWS
	FETCH NEXT 5 ROWS ONLY;
	';
EXEC (@query);