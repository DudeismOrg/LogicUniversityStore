using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Dao
{

    public class ItemDao
    {
        public LogicUniStoreModel db = new LogicUniStoreModel();

        public Item GetItem(int id)
        {
            return db.Items.Find(id);
        }
    }
}