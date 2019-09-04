using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
   public class DishesManager
    {
        private DishesSercive service = new DishesSercive();

        public List<Dishes> GetAllDishes(int? categoryId)
        {
            return service.GetAllDishes(categoryId);
        }
    }
}
