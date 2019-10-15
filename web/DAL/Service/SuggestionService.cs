using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class SuggestionService
    {
        //添加投诉
        public int AddSuggestion(Suggestion suggestion)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                db.Suggestion.Add(suggestion);
                return db.SaveChanges();
            }
        }

        //按照状态分页查询
        public TableModel<Suggestion> GetAllSuggestion(int page, int limit, int statusId)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var list = from s in db.Suggestion  select s;
                if (statusId == 0)
                {
                    list = from s in list where s.StatusId == 0 select s;
                }               
               else if (statusId == 1)
                {
                    list = from s in list where s.StatusId == 1 select s;
                }
               else if (statusId == 2)
                {
                    list = from s in list where s.StatusId == 2 select s;
                }
                TableModel<Suggestion> table = new TableModel<Suggestion>();
                table.code = 0;
                table.msg = "";
                table.count = list.ToList<Suggestion>().Count();
                table.data = list.OrderByDescending(s=>s.SuggestionTime).Skip((page-1)*limit).Take(limit).ToList<Suggestion>();
                return table;
            }
        }

        //按照状态查询总数
        public int GetAllSuggesById(int statusId)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                var list = from s in db.Suggestion where s.StatusId == statusId select s;
                return list.Count();
            }
        }

        //修改状态
        public int UpdateStatusId(Suggestion sug)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                Suggestion s = new Suggestion() { SuggestionId=sug.SuggestionId};
                db.Suggestion.Attach(s);
                s.StatusId = sug.StatusId;
                return db.SaveChanges();
            }
        }
    }
}
