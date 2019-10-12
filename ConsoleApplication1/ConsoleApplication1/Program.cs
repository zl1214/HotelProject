using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EFDB db=new EFDB())
            {
                db.Database.Log = Console.Write;
                db.Student.Add(new Student() { StudentName="zhang"});
                db.SaveChanges();
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
