using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversityStore.Util;

namespace LogicUniversityStore.Dao
{
    public class PurchaseOrderDao
    {
        public LogicUniStoreModel db = new LogicUniStoreModel();

        public PurchaseOrderDao()
        {
            
        }

        internal List<PurchaseOrder> findPoByBatchId(int batchId)
        {
            return db.PurchaseOrders.Where(z => z.POBatchID == batchId && z.POStatus == PurchaseOrderStatus.Requested.ToString() && z.DONumber == "").ToList();
        }

        internal List<PurchaseOrder> findPoBySupplierId(int suplierId)
        {
            return db.PurchaseOrders.Where(z => z.SupplierID == suplierId && z.POStatus == PurchaseOrderStatus.Requested.ToString() && z.DONumber == "").ToList();
        }

        internal PurchaseOrder getPoById(int poId)
        {
            return db.PurchaseOrders.Where(l => l.PurchaseOrderID == poId).FirstOrDefault();
        }

        internal void SaveDOInPO(int currentPOId, string doNumber)
        {
            PurchaseOrder po = db.PurchaseOrders.Where(t => t.PurchaseOrderID == currentPOId).FirstOrDefault();
            po.DONumber = doNumber;
            po.POStatus = PurchaseOrderStatus.Delivered.ToString();
            db.SaveChanges();
        }
    }
}