using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for RequisitionItemResponse
/// </summary>
[DataContract]
public class RequisitionItemResponse
{
    public RequisitionItemResponse()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    [DataMember]
    public string ItemName { get; set; }

    [DataMember]
    public int Quantity { get; set; }

    [DataMember]
    public string DeptName { get; set; }
}