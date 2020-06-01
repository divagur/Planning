USE [Planning]
GO


CREATE PROCEDURE [dbo].[sp_PLAttrList] 
	@DepId	int
AS
BEGIN

declare @Ret table
	(
		Id			int,
		spa_ID		int,
		spa_Name	nvarchar(64),
		PLFieldId int,
		PLField		nvarchar(255)
	);


	declare @Sql	nvarchar(max),
	@LVBase	nvarchar(128),
	 @DepLVID int;

	 select @LVBase = lv_base from depositors where id = @DepId

	if (@LVBase is not null)
	begin

		set @Sql = N'select la.id, vsa.spa_ID, vsa.spa_Name,se.id PLFiledId, se.field_name PLField
					from	lv_attr la 
							inner join '+@LVBase+'.dbo.V_ShipmentAttributes vsa on (vsa.spa_ID = la.lva_attr_lv_id and la.lva_in = 0)
							inner join shipment_element se on (la.pl_elem_id = se.id)
					where vsa.LanguageID = 4 and vsa.LanguageID1 = 4'
		insert into @Ret(Id, spa_ID, spa_Name,PLFieldId, PLField)
		exec sp_executesql @Sql,N'@LVBase nvarchar(128)', @LVBase;

	end


	select Id, spa_ID, spa_Name, PLFieldId, PLField
	from @Ret
	order by spa_ID;

END
GO


