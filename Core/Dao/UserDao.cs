using Core.Model;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicUniversityStore.Dao
{
    public class UserDao
    {
        LogicUniStoreModel db;

        public UserDao()
        {
            db = new LogicUniStoreModel();
        }

        public UserDao(LogicUniStoreModel context)
        {
            db = context;
        }

        public LUUser ValidateUser(string username, string password)
        {
            return db.LUUsers.Where(user => user.UserName == username && user.Password == password).FirstOrDefault();
        }

        public List<LUUser> GetUsersByDeptCode(string deptCode)
        {
            return db.LUUsers.Where(user => user.Department.DepartmentCode == deptCode).ToList();
        }

        public string GetUserNameByUserId(int userId)
        {
            string name = string.Empty;
            var emp = db.LUUsers.Where(user => user.UserID == userId).FirstOrDefault();
            if (emp != null)
            {
                name = string.Format("{0} {1}", emp.FirstName, emp.LastName);
            }
            return name;
        }

        public List<Role> GetRolesByDeptType(string deptType)
        {
            return db.Roles.Where(r => r.DepType == deptType).ToList();
        }
    }
}
