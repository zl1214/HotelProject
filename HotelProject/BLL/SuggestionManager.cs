using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
   public class SuggestionManager
    {
        private SuggestionService service = new SuggestionService();
        public int AddSuggestion(Suggestion suggestion)
        {
            return service.AddSuggestion(suggestion);
        }
    }
}
