using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class CustomPostDataAdapter : IDataAdaper
    {
        public string Table => "custom_posts";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (code, name, descr) 
                                    values(
                                            @{nameof(CustomPost.Code)},@{nameof(CustomPost.Name)},@{nameof(CustomPost.Descr)}
                                        )";
                case EditState.Edit:
                    return $@"update {Table} set code = @{nameof(CustomPost.Code)},name = @{nameof(CustomPost.Name)},
                                            descr = @{nameof(CustomPost.Descr)}
                        where id = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }

            return String.Empty;
        }

        public string GetSelectItemSql()
        {
            return $@"
                    select 
	                    id as {nameof(CustomPost.Id)}, code as {nameof(CustomPost.Code)},name as {nameof(CustomPost.Name)},
                        descr as {nameof(CustomPost.Descr)}
                    from 
	                    {Table}
                    ";
        }
    }
}
