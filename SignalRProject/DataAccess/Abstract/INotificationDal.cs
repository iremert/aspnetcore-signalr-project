﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface INotificationDal:IGenericDal<Notification>
    {
        public int NotificationCountByStatusFalse();
        public List<Notification> GetAllNotificationByFalse();
        public void NotificationStatusChangeToTrue(int id);
        public void NotificationStatusChangeToFalse(int id);
    }
}
