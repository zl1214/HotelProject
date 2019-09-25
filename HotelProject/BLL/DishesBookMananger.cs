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

        //获取所有的状态为0的订单
        public TableModel<DishesBook> GetAllDishesBook(int page, int limit, string hotelName, string customerName)
        {
            return book.GetAllDishesBook(page,limit, hotelName, customerName);
        }

        //更新订单状态
        public int UpdateDishesBook(DishesBook obj)
        {
            return book.UpdateDishesBook(obj);
        }
    }
}
