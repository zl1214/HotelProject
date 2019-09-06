using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
   public  class RecruitmentService
    {
        public TableModel<Recruitment> GetAllRecruitment()
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                var list = from r in db.Recruitment select r;
                TableModel<Recruitment> table = new TableModel<Recruitment>();
                table.count = list.Count();
                table.data = list.ToList<Recruitment>();
                return table;
            }
        }

        public Recruitment GetRecruitmentById(int postId)
        {

            using (HotelDBEntities db=new HotelDBEntities())
            {
                return (from r in db.Recruitment where r.PostId == postId select r).FirstOrDefault();
            }
        }
    }
}
