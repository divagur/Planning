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
    
    public partial class CustomPost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomPost()
        {
            this.DeliveryPeriods = new HashSet<DeliveryPeriod>();
            this.shipments = new HashSet<Shipment>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public string Code { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryPeriod> DeliveryPeriods { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipment> shipments { get; set; }
    }
}
