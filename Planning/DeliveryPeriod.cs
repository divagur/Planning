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
    
    public partial class DeliveryPeriod
    {
        public int Id { get; set; }
        public Nullable<int> CustomPostId { get; set; }
        public Nullable<int> WarehouseId { get; set; }
        public Nullable<int> DeliveryDay { get; set; }
    
        public virtual CustomPost CustomPosts { get; set; }
        public virtual Warehouse Warehouses { get; set; }
    }
}