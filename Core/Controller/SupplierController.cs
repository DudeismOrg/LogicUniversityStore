using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Controller
{
    public class SupplierController
    {
        public SupplierItemDao supplierItemDao { get; set; }

        public SupplierController()
        {
            supplierItemDao = new SupplierItemDao();
        }

        public List<Supplier> getAllSuppliers()
        {
            return supplierItemDao.GetAllSupliers();
        }
    }
}
