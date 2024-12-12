using BusinessLogic.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public List<Notification> GetAllNotifications()
        {
            return _notificationDal.GetAll();
        }

        public List<Notification> GetAllNotificationsByFalse()
        {
            return _notificationDal.GetAllNotificationByFalse();
            
        }

        public int NotificationCountByStatusFalse()
        {
            return _notificationDal.NotificationCountByStatusFalse();
        }

        public void NotificationStatusChangeToFalse(int id)
        {
            _notificationDal.NotificationStatusChangeToFalse(id);   
        }

        public void NotificationStatusChangeToTrue(int id)
        {
            _notificationDal.NotificationStatusChangeToTrue(id);
        }

        public void TDelete(Notification t)
        {
            _notificationDal.Delete(t);
        }

        public List<Notification> TGetAll()
        {
            return _notificationDal.GetAll();   
        }

        public List<Notification> TGetAllWithFilter(Expression<Func<Notification, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Notification TGetById(int id)
        {
            return _notificationDal.GetById(id);    
        }

        public void TInsert(Notification t)
        {
            _notificationDal.Insert(t);
        }

        public void TUpdate(Notification t)
        {
            _notificationDal.Update(t); 
        }
    }
}
