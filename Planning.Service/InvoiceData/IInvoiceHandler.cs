using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Service.InvoiceData
{
    public interface IInvoiceHandler<in T>
        where T : Invoice, new()
    {
        void LoadFromXml(string FileName, T Invoice);
        void Save(T Invoice);
    }
}
