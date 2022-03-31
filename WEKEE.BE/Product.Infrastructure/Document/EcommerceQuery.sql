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
		CP.id AS ID,
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

SELECT * 
FROM CategoryProduct AS C
WHERE FREETEXT(C.*,'SEARCH')


     SELECT                                                                                           
  		CP.id                 AS 'Id',                                                                
  		CP.nameCategory       AS 'NameCategory',                                                      
  		CP.urlCategory        AS 'UrlCategory',                                                       
  		CP.iconCategory      AS 'IconCategory',                                                      
  		CP.levelCategory     AS 'LevelCategory',                                                     
  		CP.categoryMain      AS 'CategoryMain',                                                      
  		(SELECT nameCategory FROM CategoryProduct where id = CP.categoryMain) AS 'CategoryMainName',  
  		CP.numberOrder        AS 'NumberOrder',                                                       
  		CP.isEnabled          AS 'IsEnabled',                                                         
  		CP.CreatedOnUtc       AS 'CreatedOnUtc',                                                      
  		CP.UpdatedOnUtc       AS 'UpdatedOnUtc '                                                      
  	FROM CategoryProduct      AS CP                                                                
  	WHERE nameCategory LIKE '%S%'                                                                   
  	  AND urlCategory LIKE '%S%'                                                                    
  	ORDER BY id ASC                                                                                 
  	OFFSET((2 - 1) * 2) ROWS   

   SELECT                                                                                           
  		CP.id                 AS 'Id',  
		CP.[key]			  AS 'Key',
		CP.GroupSpecification AS 'GroupSpecification',
        CP.CategoryProductId  AS 'CategoryProductId',
		CP.CreateBy			  AS 'CreateBy',
  		CP.CreatedOnUtc       AS 'CreatedOnUtc',                                                    
  		CP.UpdatedOnUtc       AS 'UpdatedOnUtc '                                                    
  	FROM SpecificationAttribute      AS CP   
	--WHERE [key] LIKE '%S%'                                                                   
  	 -- AND urlCategory LIKE '%S%'      
  ORDER BY Id ASC 
  OFFSET((20 - 1) * 20) ROWS                                                                        
  FETCH NEXT 1 ROWS ONLY                                                                                                                                                                                                                           
