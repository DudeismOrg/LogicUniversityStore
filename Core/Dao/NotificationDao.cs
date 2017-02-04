using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dao
{
    public class NotificationDao
    {
        public LogicUniStoreModel db;

        public NotificationDao()
        {
            db = new LogicUniStoreModel();
        }

        public void CreateNotification(Notification objNot)
        {
            db.Notifications.Add(objNot);
        }

        public void ClearNotification(int userId, int notId, NotificationStatus status)
        {
            Notification not = db.Notifications.Where(v => v.NotificationID == notId).FirstOrDefault();
            not.status = status.ToString();
            not.ReciverUserID = userId;
            db.SaveChanges();
        }
    }
}
