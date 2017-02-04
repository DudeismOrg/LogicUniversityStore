using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for DisbursementItemRequest
/// </summary>
[DataContract]
public class DisbursementItemRequest
{
    [DataMember]
    public int DisbursedQty { get; set; }

    [DataMember]
    public int ItemId { get; set; }
}