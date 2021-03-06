USE [Planning]
GO
/****** Object:  StoredProcedure [dbo].[sp_LVAttrList]    Script Date: 29.09.2020 8:43:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[sp_LVAttrList] 
	@DepId	int,
	@ShpIn int = 0
	
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
	@FieldList varchar(50),
	@ViewName varchar(24),
	@LVBase	nvarchar(128) = NULL,
	 @DepLVID int;

	select @LVBase = lv_base from depositors where id = @DepId
	
	if (@LVBase is not null)
	begin
		if (@ShpIn = 0)
		begin
			set @FieldList = 'spa_ID, spa_Name, spa_TypeID, TypeName'
			set @ViewName = 'dbo.V_ShipmentAttributes'
		end
		else if (@ShpIn = 1)
		begin
			set @FieldList = 'rat_ID, rat_Name, rat_TypeID, Typename'
			set @ViewName = 'dbo.V_ReceiptAttributes'
		end
		set @Sql = N'select '+@FieldList+
					' from '+@LVBase+'.'+@ViewName +
					' where LanguageID = 4 and LanguageID1 = 4'
		insert into @Ret(spa_ID, spa_Name, spa_TypeId, spa_TypeName)
		exec sp_executesql @Sql,N'@LVBase nvarchar(128)', @LVBase;

	end


	select spa_ID, spa_Name, spa_TypeId, spa_TypeName
	from @Ret
	order by spa_ID;

END
