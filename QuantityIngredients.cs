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
    
    public partial class QuantityIngredients
    {
        public int ID_QuantityIngredients { get; set; }
        public int Quantity { get; set; }
        public Nullable<int> Sushi_ID { get; set; }
        public Nullable<int> Ingredient_ID { get; set; }
    
        public virtual StorageIngredients StorageIngredients { get; set; }
        public virtual Sushi Sushi { get; set; }
    }
}
