using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfNotificationRepository : GenericRepository<Notification>,INotificationDal
    {
        public EfNotificationRepository(SignalRContext context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            var context = new SignalRContext();
            return context.Notifications.Where(x=>x.Status==false).ToList();
        }

        public int NotificationCountByStatusFalse()
        {
            var context = new SignalRContext();
            return context.Notifications.Where(x=>x.Status==false).Count();
        }

        public void NotificationStatusChangeToFalse(int id)
        {
            var context = new SignalRContext();
            var deger = context.Notifications.Find(id);
            deger.Status = false;
            context.SaveChanges();
        }

        public void NotificationStatusChangeToTrue(int id)
        {
            var context=new SignalRContext();
            var deger = context.Notifications.Find(id);
            deger.Status = true;
            context.SaveChanges();  
            
        }
    }
}
