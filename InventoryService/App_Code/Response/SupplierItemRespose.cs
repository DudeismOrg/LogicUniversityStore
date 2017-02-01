using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for SupplierItemRespose
/// </summary>
[DataContract]
public class SupplierItemResponse
{
    public SupplierItemResponse()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    [DataMember]
    public int ItemId { get; set; }

    [DataMember]
    public int SupplierId { get; set; }

    [DataMember]
    public string ItemCode { get; set; }
}