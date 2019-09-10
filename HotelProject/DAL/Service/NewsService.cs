using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
   public class NewsService
    {
        //添加新闻
        public int AddNews(News news)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                db.Entry<News>(news).State =EntityState.Added;
                return db.SaveChanges();
            }
        }

        //批量删除新闻
        public int DeleteNews(int[] newId)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                for (int i = 0; i < newId.Length; i++)
                {
                    News news = new News() { NewsId=i};
                    db.Entry<News>(news).State = EntityState.Deleted;                    
                }
                return db.SaveChanges();
            }
        }

        //修改新闻
        public int ModifyNews(News news)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                db.Entry<News>(news).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        //按照类别，时间倒序分页查询新闻
        public TableModel<object> SelectNews(int? newCategory, int page, int limit)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                var list = from n in db.News select new { n.NewsId, n.NewsTitle, n.PublishTime, n.NewsCategory.CategoryName,n.CategoryId,n.NewsContents };
                if (newCategory!=null)
                {
                    list = from n in list where n.CategoryId == newCategory select n;
                }
                
                TableModel<object> table = new TableModel<object>();
                table.count = list.Count();
                table.data = list.OrderByDescending(s=>s.PublishTime).Skip((page-1)*limit).Take(limit).ToList<object>();
                return table;
            }
        }

        //按照id查询新闻详细信息
        public News SelectNewsById(int newId)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                return (from n in db.News where n.NewsId == newId select n).FirstOrDefault();
            }
        }
    }
}
