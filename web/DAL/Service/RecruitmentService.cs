using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using System.Data.Entity;
using System.Transactions;

namespace DAL
{
   public  class RecruitmentService
    {
        //按照时间倒序分页查询招聘信息
        public TableModel<Recruitment> GetAllRecruitment(int page,int limit)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                var list = from r in db.Recruitment select r;
                TableModel<Recruitment> table = new TableModel<Recruitment>();
                table.count = list.Count();
                table.data = list.OrderByDescending(s=>s.PublishTime).Skip((page-1)*limit).Take(limit).ToList<Recruitment>();
                return table;
            }
        }

        //按照id查询招聘详细信息
        public Recruitment GetRecruitmentById(int postId)
        {

            using (HotelDBEntities db=new HotelDBEntities())
            {
                return (from r in db.Recruitment where r.PostId == postId select r).FirstOrDefault();
            }
        }

        //添加招聘信息
        public int AddRecruitment(Recruitment rec)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                db.Entry<Recruitment>(rec).State = EntityState.Added;
                return db.SaveChanges();
            }
        }

        //批量删除招聘信息
        public int DeleteRecruitment(int[] postId)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                for (int i = 0; i < postId.Length; i++)
                {
                    Recruitment rec = new Recruitment() { PostId = postId[i] };
                    db.Entry<Recruitment>(rec).State = EntityState.Deleted;
                }
                return db.SaveChanges();
            }
        }

        //修改招聘信息
        public int ModifyRecruitment(Recruitment rec)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                Recruitment obj = new Recruitment();
                obj.PostId = rec.PostId;
                db.Recruitment.Attach(obj);
                obj.PostName = rec.PostName;
                obj.PostType = rec.PostType;
                obj.PostPlace = rec.PostPlace;
                obj.PostDesc = rec.PostDesc;
                obj.PostRequire = rec.PostRequire;
                obj.Experience = rec.Experience;
                obj.EduBackground = rec.EduBackground;
                obj.RequireCount = rec.RequireCount;
                obj.Manager = rec.Manager;
                obj.PhoneNumber = rec.PhoneNumber;
                obj.Email = rec.Email;
                obj.PublishTime = rec.PublishTime;
                return db.SaveChanges();
            }
        }

        //展示从Excel中导入的数据
        public TableModel<Recruitment> ShowDataFromExcel(string filePath)
        {
            DataSet ds = new NPOIGetDataFromExcel().GetDataFromExcel(filePath);
            DataTable dt = ds.Tables[0];
            List<Recruitment> list = new List<Recruitment>();
            foreach (DataRow row in dt.Rows)
            {              
                    list.Add(new Recruitment()
                    {
                        PostName = row["职位"].ToString(),
                        PostType = row["类别"].ToString(),
                        PostPlace = row["工作地点"].ToString(),
                        PostDesc = row["职位描述"].ToString(),
                        PostRequire = row["职位要求"].ToString(),
                        Experience = row["经验"].ToString(),
                        EduBackground = row["学历"].ToString(),
                        RequireCount = Convert.ToInt32(row["招聘人数"]),
                        Email = row["邮箱"].ToString(),
                        Manager = row["联系人"].ToString(),
                        PhoneNumber = row["电话"].ToString(),
                        PublishTime = Convert.ToDateTime(row["发布时间"])
                    });                              
            }
            TableModel<Recruitment> table = new TableModel<Recruitment>();
            table.code = 0;
            table.count = list.Count;
            table.data = list;
            return table;
        }

        //基于事务将Excel中的数据导入到数据库中
        public int InputDataToDB(string filePath)
        {
            DataSet ds = new NPOIGetDataFromExcel().GetDataFromExcel(filePath);
            DataTable dt = ds.Tables[0];
            using (HotelDBEntities db=new HotelDBEntities())
            {
                using (var cusTransaction=new TransactionScope())
                {
                    try
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            db.Recruitment.Add(new Recruitment()
                            {
                                PostName = row["职位"].ToString(),
                                PostType = row["类别"].ToString(),
                                PostPlace = row["工作地点"].ToString(),
                                PostDesc = row["职位描述"].ToString(),
                                PostRequire = row["职位要求"].ToString(),
                                Experience = row["经验"].ToString(),
                                EduBackground = row["学历"].ToString(),
                                RequireCount = Convert.ToInt32(row["招聘人数"]),
                                Email = row["邮箱"].ToString(),
                                Manager = row["联系人"].ToString(),
                                PhoneNumber = row["电话"].ToString(),
                                PublishTime = Convert.ToDateTime(row["发布时间"])
                            });                           
                        }
                       int res=db.SaveChanges();
                       cusTransaction.Complete();
                       return res;
                    }
                    catch (Exception ex)
                    {
                        Transaction.Current.Rollback();
                        throw ex;
                    }                   
                }
            }
        }
    }
}
