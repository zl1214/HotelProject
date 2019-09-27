using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
   public class SysAdminsService
    {
        public SysAdmins Login(SysAdmins objAdmin)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                SysAdmins obj = (from a in db.SysAdmins where a.LoginId == objAdmin.LoginId && a.LoginPwd == objAdmin.LoginPwd select a).FirstOrDefault();
                return obj;
            }
            
        }
    }
}
