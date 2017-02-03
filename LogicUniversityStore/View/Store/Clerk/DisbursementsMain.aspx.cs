using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStore.Model;
using LogicUniversityStore.Controller;
using LogicUniversityStore.Dao;
using LogicUniversityStore.Util;

namespace LogicUniversityStore.View.Store.Clerk
{
    public partial class DisbursementsMain : System.Web.UI.Page
    {
        public List<Requisition> requisition { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            requisition = new List<Requisition>();
            if (!IsPostBack)
            {
                DisbursementController disbursControl = new DisbursementController();
                List<Model.Department> depts = new List<Model.Department>();
                depts.Add(new Model.Department()
                {
                    DepartmentID = 0,
                    DepartmentName = "-- Select One Department --"
                });
                depts.AddRange(disbursControl.GetAllDepartments());
                DdlDepartment.DataSource = depts;
                DdlDepartment.DataBind();
            }
        }

        protected void DdlDepartment_Change(object sender, EventArgs e)
        {
            DisbursementController disbursControl = new DisbursementController();
            if (Convert.ToInt32(DdlDepartment.SelectedValue) != 0)
            {
                int DeptId = Convert.ToInt32(DdlDepartment.SelectedValue);
                //requisition = disbursControl.GetAllShipedRequsitionByDept(DeptId);
            }
        }
    }
}