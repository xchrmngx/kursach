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
    
    public partial class questions
    {
        public int id { get; set; }
        public Nullable<int> test_id { get; set; }
        public Nullable<int> question_id { get; set; }
        public string question { get; set; }
        public string variant1 { get; set; }
        public string variant2 { get; set; }
        public string variant3 { get; set; }
        public string answer { get; set; }
    
        public virtual test test { get; set; }
    }
}
