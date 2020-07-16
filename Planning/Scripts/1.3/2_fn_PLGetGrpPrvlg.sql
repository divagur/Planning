
DROP FUNCTION [fn_GetPrvlg]

go

CREATE FUNCTION fn_GetPrvlg 
(	
	@UserLogin varchar(50)
)
RETURNS TABLE 
AS
RETURN 
(
	select f.id, f.name, max(cast(ugp.is_view as int)) is_view, sum(cast(ugp.is_append as int)) is_append, sum(cast(ugp.is_edit as int)) is_edit, sum(cast(ugp.is_delete as int)) is_delete
	from functions f
		left join 
		(user_grp_prvlg ugp 
		inner join 
		user_group_lnk ugl on (ugp.grp_id = ugl.group_id )
		inner join 
		users u on (ugl.user_id = u.id)
		) on (f.id = ugp.func_id)
	where
		u.login = @UserLogin
	group by f.id, f.name
)
GO
