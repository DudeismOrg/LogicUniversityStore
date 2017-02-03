using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for RequisitionResponse
/// </summary>
[DataContract]
public class RequisitionResponse
{
    public RequisitionResponse()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    [DataMember]
    public string DepartmentName { get; set; }
    [DataMember]
    public string DepartmentCode { get; set; }
    [DataMember]
    public string CreatedBy { get; set; }
    [DataMember]
    public int UserId { get; set; }
    [DataMember]
    public string ApprovedBy { get; set; }
    [DataMember]
    public string ApprovedDate { get; set; }
    [DataMember]
    public string RequisitionNum { get; set; }
    [DataMember]
    public string RequisitionDate { get; set; }
    [DataMember]
    public List<RequisitionItemResponse> ReqItems { get; set; }
}