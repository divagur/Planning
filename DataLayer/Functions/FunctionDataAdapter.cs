using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class FunctionDataAdapter : IDataAdaper
    {
        public string Table => "functions";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (name, code) values(@{nameof(Function.Name)},@{nameof(Function.Code)})";
                case EditState.Edit:
                    return $@"update {Table}  name = @{nameof(Function.Name)},code = @{nameof(Function.Code)}
                            where id = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }

            return String.Empty;
        }

        public string GetSelectItemSql()
        {
            return $@"select {Table}.id as {nameof(Function.Id)}, name as {nameof(Function.Name)}, code as {nameof(Function.Code)} from {Table}";
        }
    }    
}
