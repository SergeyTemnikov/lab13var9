//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lab13var9.MyDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductsStrucutres
    {
        public int Id { get; set; }
        public Nullable<int> Id_Products { get; set; }
        public Nullable<int> Id_Structure { get; set; }
    
        public virtual Products Products { get; set; }
        public virtual Structures Structures { get; set; }
    }
}
