using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for SupplierResponse
/// </summary>
[DataContract]
public class SupplierResponse
{
    public SupplierResponse()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    [DataMember]
    public int SupplierId { get; set; }

    [DataMember]
    public string SupplierCode { get; set; }

    [DataMember]
    public string SupplierName { get; set; }

    [DataMember]
    public List<SupplierItemResponse> SupplierItems { get; set; }
}