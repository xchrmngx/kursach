//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kursach
{
    using System;
    using System.Collections.Generic;
    
    public partial class history
    {
        public int id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> test_id { get; set; }
        public string result { get; set; }
        public Nullable<int> score { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    
        public virtual test test { get; set; }
        public virtual users users { get; set; }
    }
}
