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
                    return $@"INSERT INTO {Table} (name) values(@{nameof(Function.Name)})";
                case EditState.Edit:
                    return $@"update {Table} id = @{nameof(Function.Id)}, name = @{nameof(Function.Name)}
                            where id = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }

            return String.Empty;
        }

        public string GetSelectItemSql()
        {
            return $@"select {Table}.id as {nameof(Function.Id)}, name as {nameof(Function.Name)} from {Table}";
        }
    }
    }
}
