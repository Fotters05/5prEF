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
    
    public partial class StorageIngredients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StorageIngredients()
        {
            this.QuantityIngredients = new HashSet<QuantityIngredients>();
        }
    
        public int ID_Ingredient { get; set; }
        public string IngredientName { get; set; }
        public int PriceFor50Gram { get; set; }
        public Nullable<int> Supplier_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuantityIngredients> QuantityIngredients { get; set; }
        public virtual Suppliers Suppliers { get; set; }
    }
}
