using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for RequisitionItemRequest
/// </summary>
[DataContract]
public class RequisitionItemRequest
{
    [DataMember]
    public int NeededQuantity { get; set; }

    [DataMember]
    public int ItemId { get; set; }
}