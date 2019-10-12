using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   public class StudentClass
    {
        [Key]
        public int ClassId { get; set; }
        [MaxLength(10)]
        public string ClassName { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}
