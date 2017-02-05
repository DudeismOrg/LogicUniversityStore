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
    public string ItemId { get; set; }

    [DataMember]
    public string SupplierId { get; set; }

    [DataMember]
    public string ItemName { get; set; }

    [DataMember]
    public string Description { get; set; }
}