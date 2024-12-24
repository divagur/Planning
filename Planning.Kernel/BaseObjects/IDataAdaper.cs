using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Kernel
{
    public  interface IDataAdaper
    {
        string Table {  get;}
        string GetSelectItemSql();

        string GetSaveSql(EditState editState);
    }
}
