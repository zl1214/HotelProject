using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
   public class RecruitmentManager
    {
        private RecruitmentService service = new RecruitmentService();
        public TableModel<Recruitment> GetAllRecruitment()
        {
            return service.GetAllRecruitment();
        }


        public Recruitment GetRecruitmentById(int postId)
        {
            return service.GetRecruitmentById(postId);
        }
    }
}
