using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class DepositorAttributeAdapter : IDataAdaper
    {
        public string Table { get => "lv_attr"; }

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (she_id,lva_in,lva_attr_lv_id,
                                                    lva_use_ord_attr,lva_DB,lva_field,
                                                    pl_dep_id,pl_elem_id) 
                                values(@{nameof(DepositorAttribute.SheId)}, @{nameof(DepositorAttribute.LvaIn)},@{nameof(DepositorAttribute.LvaAttrLvId)},
                                        @{nameof(DepositorAttribute.LvaUseOrdAttr)},@{nameof(DepositorAttribute.LvaDB)},@{nameof(DepositorAttribute.LvaField)},
                                        @{nameof(DepositorAttribute.PlDepId)},@{nameof(DepositorAttribute.PlElemId)})";
                case EditState.Edit:
                    return $@"update {Table} set she_id = @{nameof(DepositorAttribute.SheId)},lva_in = @{nameof(DepositorAttribute.LvaIn)},
                                                lva_attr_lv_id = @{nameof(DepositorAttribute.LvaAttrLvId)},
                                                lva_use_ord_attr = @{nameof(DepositorAttribute.LvaUseOrdAttr)},
                                                lva_DB = @{nameof(DepositorAttribute.LvaDB)},lva_field = @{nameof(DepositorAttribute.LvaField)},
                                                pl_dep_id = @{nameof(DepositorAttribute.PlDepId)},pl_elem_id = @{nameof(DepositorAttribute.PlElemId)}
                            where id = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }

            return String.Empty;
        }

        public string GetSelectItemSql()
        {
            return $@"select id as {nameof(DepositorAttribute.Id)},she_id as {nameof(DepositorAttribute.SheId)},lva_in as {nameof(DepositorAttribute.LvaIn)},
                             lva_attr_lv_id as {nameof(DepositorAttribute.LvaAttrLvId)}, lva_use_ord_attr as {nameof(DepositorAttribute.LvaUseOrdAttr)},
                             lva_DB as {nameof(DepositorAttribute.LvaDB)},lva_field as {nameof(DepositorAttribute.LvaField)},
                             pl_dep_id as {nameof(DepositorAttribute.PlDepId)},pl_elem_id as {nameof(DepositorAttribute.PlElemId)}                         
                      from {Table}";
        }
    }
}
