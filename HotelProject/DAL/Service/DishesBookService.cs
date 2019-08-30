using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;

namespace DAL
{
    public class DishesBookService
    {
        //添加订单（OrderStatus=0）
        public int AddDishesBook(DishesBook dishesBook)
        {
            dishesBook.OrderStatus = 0;
            using (HotelDBEntities db=new HotelDBEntities())
            {
                db.Entry<DishesBook>(dishesBook).State =EntityState.Added;
                return db.SaveChanges();
            }
        }

        //查询OrderStatus为0或1的全部订单
        public TableModel<DishesBook> GetAllDishesBook()
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                List<DishesBook> list = (from d in db.DishesBook where d.OrderStatus==0||d.OrderStatus==1 select d).ToList<DishesBook>();
                TableModel<DishesBook> table = new TableModel<DishesBook>();
                table.count = list.Count();
                table.data = list;
                return table;
            }
        }

        //订单通过（OrderStatus=1）/关闭订单（OrderStatus=-1）
        public int UpdateDishesBook(int dishesId,int orderStatus)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                DishesBook book = new DishesBook();
                book.OrderStatus = orderStatus;
                db.DishesBook.Attach(book);
                return db.SaveChanges();
            }
        }
    }
   

        
}
