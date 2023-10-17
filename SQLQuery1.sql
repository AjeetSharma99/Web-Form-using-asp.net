/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [empid]
      ,[name]
      ,[mobile]
      ,[age]
  FROM [mvc5689_12923].[dbo].[tblemployee]
  sp_helptext employee_get
  select * from tblemployee