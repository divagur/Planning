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
    
    public partial class MovementLog
    {
        public int DmlId { get; set; }
        public string DmlType { get; set; }
        public System.DateTime DmlDate { get; set; }
        public string DmlUserName { get; set; }
        public string DmlCompName { get; set; }
        public int MovementId { get; set; }
        public System.DateTime MDate { get; set; }
        public Nullable<int> TimeSlotId { get; set; }
        public Nullable<int> Priority { get; set; }
        public string Comment { get; set; }
        public Nullable<int> DelayReasonsId { get; set; }
        public string DelayComment { get; set; }
        public string Performer { get; set; }
        public bool DefCustomer { get; set; }
        public bool SpCondition { get; set; }
        public Nullable<System.TimeSpan> SpecialTime { get; set; }
    }
}