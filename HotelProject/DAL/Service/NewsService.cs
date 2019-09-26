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
                    News news = new News() { NewsId= newId [i]};
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
                News obj = new News();
                obj.NewsId = news.NewsId;                          
                db.News.Attach(obj);
                obj.CategoryId = news.CategoryId;
                obj.NewsTitle = news.NewsTitle;
                obj.NewsContents = news.NewsContents;
                return db.SaveChanges();
            }
        }

        //按照类别，时间倒序分页查询新闻
        public TableModel<News> SelectNews(int? newCategory, int page, int limit)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                var list = (from n in db.News  select new { n.NewsId, n.NewsTitle, n.PublishTime, n.CategoryId, n.NewsContents, n.NewsCategory.CategoryName }).ToList();
                if (newCategory!=null)
                {
                    list = (from n in list where n.CategoryId == newCategory select n).ToList();
                }
                List<News> newsList = new List<News>();
                foreach (var item in list)
                {
                    newsList.Add(
                         new News()
                        {
                            NewsId = item.NewsId,
                            NewsTitle = item.NewsTitle,
                            PublishTime = item.PublishTime,
                            CategoryId = item.CategoryId,
                            NewsCategory = new NewsCategory() { CategoryName = item.CategoryName },
                            NewsContents = item.NewsContents
                        });
                }               
                TableModel<News> table = new TableModel<News>();
                table.count = newsList.Count();
                table.data = newsList.OrderByDescending(s=>s.PublishTime).Skip((page-1)*limit).Take(limit).ToList<News>();
                return table;
            }
        }

        //按照id查询新闻详细信息
        public News SelectNewsById(int newId)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                var list= (from n in db.News where n.NewsId == newId select new { n.NewsId, n.NewsTitle, n.PublishTime,n.CategoryId, n.NewsContents,n.NewsCategory.CategoryName }).FirstOrDefault();
                News objnews = new News()
                {
                    NewsId = list.NewsId,
                    NewsTitle = list.NewsTitle,
                    PublishTime = list.PublishTime,
                    CategoryId =list.CategoryId,
                    NewsCategory=new NewsCategory() {CategoryName=list.CategoryName },
                    NewsContents=list.NewsContents
                };
                return objnews;
            }
        }
    }
}
