using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class ShipmentInvoiceDataAdapter : IDataAdaper
    {
        public string Table => "shipment_invoices";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (shp_id,create_date,actual_date,number,invoice_type,source_code,recipient_code,delivery_type)
                                values(@{nameof(ShipmentInvoice.ShpId)},@{nameof(ShipmentInvoice.CreateDate)},@{nameof(ShipmentInvoice.ActualDate)},
                                        @{nameof(ShipmentInvoice.Number)},@{nameof(ShipmentInvoice.InvoiceType)},@{nameof(ShipmentInvoice.SourceCode)},
                                        @{nameof(ShipmentInvoice.RecipientCode)},@{nameof(ShipmentInvoice.DeliveryType)})";
                    break;
                case EditState.Edit:
                    return $@"update {Table} set shp_id = @{nameof(ShipmentInvoice.ShpId)}, create_date = @{nameof(ShipmentInvoice.CreateDate)},
                                            actual_date = @{nameof(ShipmentInvoice.ActualDate)},number = @{nameof(ShipmentInvoice.Number)},
                                            invoice_type = @{nameof(ShipmentInvoice.InvoiceType)}, source_code = @{nameof(ShipmentInvoice.SourceCode)},
                                            recipient_code = @{nameof(ShipmentInvoice.RecipientCode)}, delivery_type = @{nameof(ShipmentInvoice.DeliveryType)}
                            where id = @Id";
                    break;
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
                    break;
            }

            return String.Empty;
        }



        public string GetSelectItemSql()
        {
            //return $@"select id as {nameof(DelayReasons.Id)}, name as {nameof(DelayReasons.Name)} from delay_reasons";

            return $@"
                    select 
                            id as {nameof(ShipmentInvoice.Id)}, shp_id as {nameof(ShipmentInvoice.ShpId)}, 
                                  create_date as {nameof(ShipmentInvoice.CreateDate)}, actual_date as {nameof(ShipmentInvoice.ActualDate)},
                                  number as {nameof(ShipmentInvoice.Number)}, invoice_type as {nameof(ShipmentInvoice.InvoiceType)},
                                  source_code as {nameof(ShipmentInvoice.SourceCode)}, recipient_code as {nameof(ShipmentInvoice.RecipientCode)},
                                  delivery_type as {nameof(ShipmentInvoice.DeliveryType)}
	                    
                    from 
	                    {Table}
                    ";
        }
    }
}
