using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RequisitionResponse
/// </summary>
public class RequisitionResponse
{
    public RequisitionResponse()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string DepartmentName { get; set; }

    public string DepartmentCode { get; set; }

    public string CreatedBy { get; set; }

    public int UserId { get; set; }

    public string ApprovedBy { get; set; }

    public string ApprovedDate { get; set; }

    public string RequisitionNum { get; set; }
    
    public string RequisitionDate { get; set; }

    public List<RequisitionItemResponse> ReqItems { get; set; }
}