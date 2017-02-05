using Core.Dao;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicUniversityStore.Dao;
using Core.Controller;
using LogicUniversityStore.Util;

namespace LogicUniversityStore.Controller
{
    public class DisbursementController
    {
        UserDao userDao { get; set; }
        DisbursementDao disbDao { get; set; }
        public DisbursementController()
        {
            userDao = new UserDao();
            disbDao = new DisbursementDao();
        }

        public List<Disbursement> GetDisbursements(int deptId)
        {
            return new DisbursementDao().GetDisbursements(deptId);
        }

        public bool ProcessDisbursement(int disbId, string key, int receivedBy, List<Tuple<int, int>> itemQtys)
        {
            bool result = true;
            LogicUniStoreModel dbContext = new LogicUniStoreModel();
            dbContext.Database.Connection.Open();
            using (var txn = dbContext.Database.BeginTransaction())
            {
                DisbursementDao disbDao = new DisbursementDao(dbContext);

                if (disbDao.ValidateDisbKey(disbId, key))
                {
                    disbDao.AcceptDisbursement(disbId, receivedBy);
                    disbDao.UpdateDisbusedQuantity(disbId, itemQtys);
                }
                else
                    result = false;
                txn.Commit();
            }
            dbContext.Database.Connection.Close();
            return result;
        }

        public List<Department> GetAllDepartments()
        {
            return userDao.getAllDepartments();
        }

        public List<Requisition> GetAllShipedRequsitionByDept(int deptId)
        {
            return disbDao.getShipedReqByDept(deptId);
        }

        public void GenerateDisbursement(int retrId, LUUser user)
        {
            List<Disbursement> dibursements = disbDao.GenerateDisbursebents(retrId);
            foreach(Disbursement dis in dibursements)
            {
                Core.Controller.NotificationController ctl = new NotificationController();
                ctl.CreateNotification(
                    user.UserID, string.Format("The Items has been Shipped {0}. Disbursement key =", dis.Key), NotificationStatus.Created, Roles.HOD, dis.DepartmentID.Value
                    );
                ctl.CreateNotification(
                    user.UserID, string.Format("The Items has been Shipped {0}. Disbursement key =", dis.Key), NotificationStatus.Created, Roles.REP, dis.DepartmentID.Value
                    );


                string toEmailIdsHOD = new UserController().GetToEmailIds(Roles.HOD, dis.DepartmentID.Value); //To which role the email should be sent
                string toEmailIdsREPS = new UserController().GetToEmailIds(Roles.HOD, dis.DepartmentID.Value);
                ctl.SendEmail("vasu4dworld@gmail.com", toEmailIdsHOD, "Items for requsition has been shiped", "The disbursement key while receiving item is : " + dis.Key);
                ctl.SendEmail("vasu4dworld@gmail.com", toEmailIdsREPS, "Items for requsition has been shiped", "The disbursement key while receiving item is : " + dis.Key);
            }
        }

        public List<RequisitionItem> GetShipedReqItmsByReqId(int reqIdInt)
        {
            return disbDao.GetShipedReqItmsByReqId(reqIdInt);
        }

        public void saveDeliveredStatusToReq(int reqItemID, int deliverdQuantity)
        {
            disbDao.saveDeliveredStatusToReq(reqItemID, deliverdQuantity);
        }

        public void SaveRequsitionAsDelivered(int reqIdInt)
        {
            disbDao.SaveRequsitionAsDelivered(reqIdInt);
        }
    }
}
