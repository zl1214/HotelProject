using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [MaxLength(10)]
        [Required]
        public string StudentName { get; set; }
        [MaxLength(2)]
        public String Gender { get; set; }
      

        public StudentClass StudentClass { get; set; }
    }
}
