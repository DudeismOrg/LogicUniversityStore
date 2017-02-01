using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for RequisitionRequest
/// </summary>
[DataContract]
public class RequisitionRequest
{
    public RequisitionRequest()
    {
        //
        // TODO: Add constructor logic here
        //
    }   
    [DataMember]
    public string Number { get; set; }
    [DataMember]
    public int CreatedBy { get; set; } //requstedby
    [DataMember]
    public DateTime CreatedDate { get; set; } //reqdate
    [DataMember]
    public RequisitionStatus Status { get; set; }
    [DataMember]
    public int DepartmentId { get; set; }
    [DataMember]
    public string Remarks { get; set; }
    [DataMember]
    public List<RequisitionItemRequest> Items { get; set; }
}