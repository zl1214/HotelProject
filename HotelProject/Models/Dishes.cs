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
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Dishes
    {
        public int DishesId { get; set; }
        public string DishesName { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public int? CategoryId { get; set; }

        [NotMapped]
        public string DishesImg { get { return this.DishesId.ToString() + ".PNG"; }}       

        public virtual DishesCategory DishesCategory { get; set; }
    }
}
