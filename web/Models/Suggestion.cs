//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Suggestion
    {
        public int SuggestionId { get; set; }
        public string CustomerName { get; set; }
        public string ConsumeDesc { get; set; }
        public string SuggestionDesc { get; set; }
        public Nullable<System.DateTime> SuggestionTime { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? StatusId { get; set; }
    }
}
