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

        public TableModel<Suggestion> GetAllSuggestion(int page, int limit, int statusId)
        {
            return service.GetAllSuggestion(page,limit, statusId);
        }

        public int GetAllSuggesById(int statusId)
        {
            return service.GetAllSuggesById(statusId);
        }

        public int UpdateStatusId(Suggestion sug)
        {
            return service.UpdateStatusId(sug);
        }
    }
}
