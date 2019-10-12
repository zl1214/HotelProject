using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   public class EFDB:DbContext
    {
        public EFDB():base("name=EFDB")
        {
            Database.SetInitializer<EFDB>(new DropCreateDatabaseIfModelChanges<EFDB>());
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<StudentClass> StudentClass { get; set; }
    }
}
