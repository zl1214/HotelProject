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

        //按照id,类别分页查询新闻
        public TableModel<object> SelectNews(int? newId, int? newCategory, int page, int limit)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                var list = from n in db.News select new { n.NewsId, n.NewsTitle, n.PublishTime, n.NewsCategory.CategoryName,n.CategoryId };
                if (newId==null&&newCategory!=null)
                {
                    list = from n in list where n.CategoryId == newCategory select n;
                }
                else if (newId != null && newCategory != null)
                {
                    list = from n in list where n.CategoryId == newCategory&&n.NewsId==newId select n;
                }
                else if (newId != null && newCategory == null)
                {
                    list = from n in list where n.NewsId == newId select n;
                }
                TableModel<object> table = new TableModel<object>();
                table.count = list.Count();
                table.data = list.OrderBy(s=>s.NewsId).Skip((page-1)*limit).Take(limit).ToList<object>();
                return table;
            }
        }
    }
}
