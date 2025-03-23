﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class TransportViewDataAdapter : IDataAdaper
    {
        public string Table => "transport_view";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (name) 
                                    values(
                                            @{nameof(TransportView.Name)}
                                        )";
                case EditState.Edit:
                    return $@"update {Table} set name = @{nameof(TransportView.Name)}
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
	                    id as {nameof(TransportView.Id)}, name as {nameof(TransportView.Name)}
                    from 
	                    {Table}
                    ";
        }
    }
}
