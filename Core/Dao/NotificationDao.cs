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

        public NotificationDao(LogicUniStoreModel db)
        {
            this.db = db;
        }

        public void CreateNotification(Notification objNot)
        {
            db.Notifications.Add(objNot);
            db.SaveChanges();
        }

        public void ClearNotification(int userId, int notId, NotificationStatus status)
        {
            Notification not = db.Notifications.Where(v => v.NotificationID == notId).FirstOrDefault();
            not.status = status.ToString();
            not.ReciverUserID = userId;
            db.SaveChanges();
        }

        public List<Notification> GetNotificationsByRoleCode(string roleCode)
        {
            return db.Notifications.Where(not => not.ReceiverRole.RoleCode == roleCode && not.status == NotificationStatus.Created.ToString()).ToList();
        }

        public List<Notification> GetNotificationsByRoleCodeAndType(string roleCode, string notType)
        {
            return db.Notifications.Where(not => not.ReceiverRole.RoleCode == roleCode && not.status == NotificationStatus.Created.ToString()
            && not.Type == notType).ToList();
        }
    }
}
