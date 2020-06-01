USE [Planning]
GO


ALTER PROCEDURE [dbo].[sp_LVAttrList] 
	@DepId	int
	
AS
BEGIN

declare @Ret table
	(
		spa_ID			int,
		spa_Name		nvarchar(64),
		spa_TypeId		int,
		spa_TypeName	nvarchar(255)

	);


	declare @Sql	nvarchar(max),
	@LVBase	nvarchar(128) = NULL,
	 @DepLVID int;

	select @LVBase = lv_base from depositors where id = @DepId
	
	if (@LVBase is not null)
	begin

		set @Sql = N'select spa_ID, spa_Name, spa_TypeID, TypeName 
					from '+@LVBase+'.dbo.V_ShipmentAttributes 
					where LanguageID = 4 and LanguageID1 = 4'
		insert into @Ret(spa_ID, spa_Name, spa_TypeId, spa_TypeName)
		exec sp_executesql @Sql,N'@LVBase nvarchar(128)', @LVBase;

	end


	select spa_ID, spa_Name, spa_TypeId, spa_TypeName
	from @Ret
	order by spa_ID;

END
GO


