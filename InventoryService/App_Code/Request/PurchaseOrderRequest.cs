using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for PurchaseOrderRequest
/// </summary>
[DataContract]
public class PurchaseOrderRequest
{
    public PurchaseOrderRequest()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    [DataMember]
    public int SupplierId { get; set; }

    [DataMember]
    public int CreatedyBy { get; set; }

    [DataMember]
    public List<POItemRequest> Items { get; set; }

}