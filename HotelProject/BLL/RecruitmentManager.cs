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

        //按照时间倒序分页查询招聘信息
        public TableModel<Recruitment> GetAllRecruitment(int page, int limit)
        {
            return service.GetAllRecruitment(page,limit);
        }

        //按照id查询招聘详细信息
        public Recruitment GetRecruitmentById(int postId)
        {
            return service.GetRecruitmentById(postId);
        }

        //添加招聘信息
        public int AddRecruitment(Recruitment rec)
        {
            return service.AddRecruitment(rec);
        }

        //批量删除招聘信息
        public int DeleteRecruitment(int[] postId)
        {
            return service.DeleteRecruitment(postId);
        }

        //修改招聘信息
        public int ModifyRecruitment(Recruitment rec)
        {
            return service.ModifyRecruitment(rec);
        }
    }
}
