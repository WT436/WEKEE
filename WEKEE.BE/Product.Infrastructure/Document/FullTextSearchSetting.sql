USE [Authorization];
 CREATE FULLTEXT CATALOG New_Catalog AS DEFAULT;
CREATE FULLTEXT INDEX ON [Resource]
([name],[description],[types_rsc] TYPE COLUMN FileExtension LANGUAGE 1033)
KEY INDEX [PK__Resource__3213E83FB3983A2E]
ON New_Catalog
WITH STOPLIST = SYSTEM 

SELECT FullTextServiceProperty('IsFullTextInstalled')