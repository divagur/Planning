using System;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class SupplierDataAdapter : IDataAdaper
    {
        public string Table { get => "suppliers"; }

        public string GetSaveSql(EditState editState)
        {
           switch (editState) 
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (name,code,is_active) values(@{nameof(Supplier.Name)},@{nameof(Supplier.Code)}, @{nameof(Supplier.IsActive)})";
                case EditState.Edit:
                    return $@"update {Table} set name = @{nameof(Supplier.Name)},code = @{nameof(Supplier.Code)}, is_active = @{nameof(Supplier.IsActive)}
                            where id = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }

            return String.Empty;    
        }

        public string GetSelectItemSql()
        {
            return $@"select id as {nameof(Supplier.Id)}, name as {nameof(Supplier.Name)}, code as {nameof(Supplier.Code)}, is_active as {nameof(Supplier.IsActive)} from {Table}";
        }
    }
}
