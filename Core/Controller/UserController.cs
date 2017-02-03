using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Model;
using LogicUniversityStore.Model;
using LogicUniversityStore.Dao;

namespace Core.Controller
{
    public class UserController
    {

        public LUUser ValidateUser(string username, string password)
        {
            return new UserDao().ValidateUser(username, password);
        }

        public string GetUserNameByUserId(int userId)
        {
            return new UserDao().GetUserNameByUserId(userId);
        }

        public List<LUUser> GetUsersByDeptCode(int deptId)
        {
            return new UserDao().GetUsersByDeptCode(deptId);
        }

        public List<Role> GetRolesByDeptType(string deptType)
        {
            return new UserDao().GetRolesByDeptType(deptType);
        }

        public LUUser GetUserProfileByUserId(int userId)
        {
            return new UserDao().GetUserProfileByUserId(userId);
        }

        public bool UpdateUserRole(int userId, string roleCode)
        {
            return new UserDao().UpdateUserRole(userId, roleCode);
        }
    }
}
