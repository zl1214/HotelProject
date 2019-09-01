using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;

namespace DAL
{
   public class DishesSercive
    {
        //根据类别获取所有的菜品信息
        public TableModel<object> GetAllDishes(int? categoryId)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                var list = (from d in db.Dishes select d).ToList();
                if (categoryId!=null)
                {
                    list = (from s in list where s.CategoryId == categoryId select s).ToList();
                }
                TableModel<object> table = new TableModel<object>();
                table.count = list.Count();
                table.data = list.ToList<object>();
                return table;
            }
        }

        //菜品添加
        public int AddDishes(Dishes dishes)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                db.Dishes.Add(dishes);
                return db.SaveChanges();
            }
        }

        //修改菜品
        public int ModifyDishes(Dishes dishes)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                db.Entry<Dishes>(dishes).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        //批量删除菜品
        public int DeleteDishes(int[] num)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                for (int i = 0; i < num.Length; i++)
                {
                    Dishes obj = new Dishes() {
                        DishesId = i
                    };
                    db.Entry<Dishes>(obj).State = EntityState.Deleted;
                }
                return db.SaveChanges();
            }
        }
        
        //根据菜品Id获取菜品信息
        public Dishes GetDishesById(int dishesId)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                return (from d in db.Dishes where d.DishesId == dishesId select d).FirstOrDefault();
            }
        }
    }
}
