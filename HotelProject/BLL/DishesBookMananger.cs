using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
   public class DishesBookMananger
    {
        private DishesBookService book = new DishesBookService();
        //菜品预订
        public int DishesBook(DishesBook dishes)
        {
            return book.AddDishesBook(dishes);
        }
    }
}
