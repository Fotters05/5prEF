//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Praktika5
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sushi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sushi()
        {
            this.QuantityIngredients = new HashSet<QuantityIngredients>();
            this.SushiQuant = new HashSet<SushiQuant>();
        }
    
        public int ID_Sushi { get; set; }
        public string SushiName { get; set; }
        public int PriceForOneRoll { get; set; }
        public string Descriptions { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuantityIngredients> QuantityIngredients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SushiQuant> SushiQuant { get; set; }
    }
}
