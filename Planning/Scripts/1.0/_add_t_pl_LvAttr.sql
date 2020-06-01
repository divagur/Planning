

-- Create the data type
CREATE TYPE dbo.T_PL_LvAtrr AS TABLE 
(
	spa_ID int,
	spa_Name varchar(64),
	spa_TypeId int,
	spa_TypeName varchar(255)
)
GO
