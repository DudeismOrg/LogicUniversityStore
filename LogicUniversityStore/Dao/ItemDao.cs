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

        public Item GetItem(String itemName)
        {
            return db.Items.Where(x => x.ItemName.Equals(itemName)).FirstOrDefault();
        }

        public List<Item> GetAllItems()
        {
            return db.Items.ToList();
        }

    }
}