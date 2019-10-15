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

        //获取菜品列表
        public List<Dishes> GetAllDishes(int? categoryId)
        {
            return service.GetAllDishes(categoryId);
        }

        //添加菜品返回菜品id
        public int ReturuDishesId(Dishes dish)
        {
            return service.ReturuDishesId(dish);
        }

        //根据菜品id获取菜品信息
        public Dishes GetDishesById(int dishesId)
        {
            return service.GetDishesById(dishesId);
        }

        //根据菜品id更新菜品
        public int ModifyDish(Dishes dishe)
        {
            return service.ModifyDishes(dishe);
        }

        //根据菜品id删除菜品
        public int DeleteDish(int disheId)
        {
            return service.DeleteDisheById(disheId);
        }
    }
}
