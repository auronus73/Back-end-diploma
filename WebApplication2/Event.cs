//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity.EntityFramework;


    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            this.Rewards = new HashSet<Reward>();
        }
    [Key]

        public int event_id { get; set; }
        public string title { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public int number_of_house { get; set; }
        public string level { get; set; }
        public System.DateTime date { get; set; }
        public int value { get; set; }
        public string source { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reward> Rewards { get; set; }
    }
}