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

        //查询OrderStatus为0的全部订单
        public TableModel<DishesBook> GetAllDishesBook(int page,int limit, string hotelName, string customerName)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
               var list = from d in db.DishesBook where d.OrderStatus==0 || d.OrderStatus == -1 select d;
                if (hotelName !=null && hotelName!="")
                {
                    list = from d in list where d.HotelName == hotelName select d;
                }
                if (customerName !=null && customerName != "")
                {
                    list = from d in list where d.CustomerName.Contains(customerName) select d;
                }
                TableModel<DishesBook> table = new TableModel<DishesBook>();
                table.count = list.Count();
                table.data = list.OrderByDescending(s=>s.OrderStatus).Skip((page-1)*limit).Take(limit).ToList<DishesBook>();
                return table;
            }
        }

        //取消订单（OrderStatus=1）/关闭订单（OrderStatus=-1）
        public int UpdateDishesBook(DishesBook obj)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                DishesBook book = new DishesBook();
                book.BookId = obj.BookId;
                db.DishesBook.Attach(book);
                book.OrderStatus = obj.OrderStatus;
                return db.SaveChanges();
            }
        }
    }
   

        
}
