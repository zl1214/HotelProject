﻿using System;
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

        //获取所有新闻
        public TableModel<News> GetAllNews(int? newCategory, int page, int limit)
        {
            return service.SelectNews(newCategory,page,limit);
        }

        //根据新闻Id获取新闻
        public News SelectNewsById(int newId)
        {
            return service.SelectNewsById(newId);
        }

        //添加新闻
        public int AddNews(News news)
        {
            return service.AddNews(news);
        }

        //修改新闻
        public int UpdateNews(News news)
        {
            return service.ModifyNews(news);
        }

        //删除新闻
        public int DeleteNews(int[] num)
        {
            return service.DeleteNews(num);
        }
    }
}
