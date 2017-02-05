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
    public string DisbursedQty { get; set; }

    [DataMember]
    public string ItemId { get; set; }
}