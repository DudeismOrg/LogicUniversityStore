using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicUniversityStore.Controller
{
   public  class ClerkMainController
    {
        public RequisitionItemDao RequisitionItemDao { get; set; }

        public ClerkMainController()
        {
            LogicUniStoreModel db = new LogicUniStoreModel();
            RequisitionItemDao = new RequisitionItemDao(db);
        }

        public Dictionary< Item,double> GetFrequentOrderedReqItem()
        {
            Dictionary<Item, double> res = new Dictionary<Item, double>();
            var count = RequisitionItemDao.db.RequisitionItems.GroupBy(x => x.SupplierItem.ItemID);
            DateTime dt = new DateTime();
            double total = RequisitionItemDao.db.RequisitionItems.Count();
            count.OrderBy(x => x.Count());
            int i = 0;
            Item it;
            foreach (var item in count)
            {
                if (i > 4) break;
                it =  RequisitionItemDao.db.Items.Find(item.Key);
                res.Add( it, ((double)(item.Count()) / total)*100);
                i++;
            }

            return res;
        }
    }
}
