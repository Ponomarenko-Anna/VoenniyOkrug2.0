//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VoenniyOkrug.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Obiedinenie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Obiedinenie()
        {
            this.Obiedinenie_chast = new HashSet<Obiedinenie_chast>();
        }
    
        public int id { get; set; }
        public Nullable<int> tip { get; set; }
        public string nazvanie { get; set; }
    
        public virtual Tip_obiedineniya Tip_obiedineniya { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Obiedinenie_chast> Obiedinenie_chast { get; set; }
    }
}
