//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Planning
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShipmentOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShipmentOrder()
        {
            this.ShipmentOrderParts = new HashSet<ShipmentOrderPart>();
        }
    
        public int Id { get; set; }
        public string OrderId { get; set; }
        public Nullable<int> ShipmentId { get; set; }
        public string OrderType { get; set; }
        public string Comment { get; set; }
        public Nullable<bool> IsBinding { get; set; }
        public Nullable<int> ManualLoad { get; set; }
        public Nullable<int> ManualUnload { get; set; }
        public Nullable<int> PalletAmount { get; set; }
        public Nullable<int> BindingId { get; set; }
        public Nullable<int> LVOrderId { get; set; }
        public string lv_order_code { get; set; }
        public Nullable<int> shipping_places_number { get; set; }
        public Nullable<decimal> order_weight { get; set; }
    
        public virtual Shipment Shipment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShipmentOrderPart> ShipmentOrderParts { get; set; }
    }
}
