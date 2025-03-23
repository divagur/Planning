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
                    return $@"INSERT INTO {Table} (shp_id,create_date,actual_date,number,invoice_type,customs_code, supplier_code,recipient_code,delivery_type,
                                            container_number,truck_number,trailer_number,driver,supplier_delivery_day, status, error)
                                values(@{nameof(ShipmentInvoice.ShpId)},@{nameof(ShipmentInvoice.CreateDate)},@{nameof(ShipmentInvoice.ActualDate)},
                                        @{nameof(ShipmentInvoice.Number)},@{nameof(ShipmentInvoice.InvoiceType)},@{nameof(ShipmentInvoice.CustomsCode)},
                                        @{nameof(ShipmentInvoice.SupplierCode)},
                                        @{nameof(ShipmentInvoice.RecipientCode)},@{nameof(ShipmentInvoice.DeliveryType)},
                                        @{nameof(ShipmentInvoice.ContainerNumber)}, @{nameof(ShipmentInvoice.TruckNumber)},
                                        @{nameof(ShipmentInvoice.TrailerNumber)}, @{nameof(ShipmentInvoice.Driver)},
                                        @{nameof(ShipmentInvoice.SupplierDeliveryDay)},
                                        @{nameof(ShipmentInvoice.Status)}, @{nameof(ShipmentInvoice.Error)})";
                case EditState.Edit:
                    return $@"update {Table} set shp_id = @{nameof(ShipmentInvoice.ShpId)}, create_date = @{nameof(ShipmentInvoice.CreateDate)},
                                            actual_date = @{nameof(ShipmentInvoice.ActualDate)},number = @{nameof(ShipmentInvoice.Number)},
                                            invoice_type = @{nameof(ShipmentInvoice.InvoiceType)}, customs_code = @{nameof(ShipmentInvoice.CustomsCode)},
                                            supplier_code = @{nameof(ShipmentInvoice.SupplierCode)},
                                            recipient_code = @{nameof(ShipmentInvoice.RecipientCode)}, delivery_type = @{nameof(ShipmentInvoice.DeliveryType)},
                                            container_number =  @{nameof(ShipmentInvoice.ContainerNumber)}, truck_number =  @{nameof(ShipmentInvoice.TruckNumber)}, 
                                            trailer_number =  @{nameof(ShipmentInvoice.TrailerNumber)}, driver =  @{nameof(ShipmentInvoice.Driver)}, 
                                            supplier_delivery_day =  @{nameof(ShipmentInvoice.SupplierDeliveryDay)},status =  @{nameof(ShipmentInvoice.Status)},
                                            error =  @{nameof(ShipmentInvoice.Error)}

                            where id = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
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
                                  customs_code  as {nameof(ShipmentInvoice.CustomsCode)}, supplier_code  as {nameof(ShipmentInvoice.SupplierCode)}, 
                                  recipient_code as {nameof(ShipmentInvoice.RecipientCode)},
                                  delivery_type as {nameof(ShipmentInvoice.DeliveryType)},
                                  container_number as {nameof(ShipmentInvoice.ContainerNumber)}, truck_number as {nameof(ShipmentInvoice.TruckNumber)}, 
                                  trailer_number as {nameof(ShipmentInvoice.TrailerNumber)}, driver as {nameof(ShipmentInvoice.Driver)}, 
                                  supplier_delivery_day as {nameof(ShipmentInvoice.SupplierDeliveryDay)},
                                  status as {nameof(ShipmentInvoice.Status)}, error as {nameof(ShipmentInvoice.Error)}
	                    
                    from 
	                    {Table}
                    ";
        }
    }
}
