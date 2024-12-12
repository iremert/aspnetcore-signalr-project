using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface INotificationService:IGenericService<Notification>
    {
        public void NotificationStatusChangeToFalse(int id);
        public void NotificationStatusChangeToTrue(int id);
        public int NotificationCountByStatusFalse();
        public List<Notification> GetAllNotificationsByFalse();
    }
}
