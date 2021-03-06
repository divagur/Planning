USE [Planning]
GO
/****** Object:  StoredProcedure [dbo].[SP_PL_ForceMergeLVSttribute]    Script Date: 01.06.2020 22:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[SP_PL_ForceMergeLVAttribute]
	@ShpID int
as
begin

	declare @Mai	T_PL_MergeLVAttributeInput;
	declare @Ret	int;
	declare @LdgIDs	T_PL_ID;
	
	insert into @LdgIDs(ID)
	values(@ShpID);

	insert into @Mai (aui_LVBase, aui_LVID, aui_In, aui_UseOrdAttr, aui_AttrLVID, aui_AttrVal, aui_ShOrdID)
	exec SP_PL_UnpivotAttributes @LdgIDs;

	exec @ret = SP_PL_MergeLVAttribute @mai;

	return @ret;

end
