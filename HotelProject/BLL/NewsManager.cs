using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
   public class NewsManager
    {
        private NewsService service = new NewsService();

        public TableModel<object> GetAllNews(int? newCategory, int page, int limit)
        {
            return service.SelectNews(newCategory,page,limit);
        }

        public News SelectNewsById(int newId)
        {
            return service.SelectNewsById(newId);
        }
    }
}
