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
    
    public partial class Structures
    {
        public int Id_Structure { get; set; }
        public string Structure_Name { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public Nullable<int> Id_Product { get; set; }
    
        public virtual Products Products { get; set; }
    }
}