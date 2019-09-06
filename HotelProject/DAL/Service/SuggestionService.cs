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

        public int AddSuggestion(Suggestion suggestion)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                db.Suggestion.Add(suggestion);
                return db.SaveChanges();
            }
        }
    }
}
