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

    public int SupplierId { get; set; }

    public string SupplierCode { get; set; }

    public string SupplierName { get; set; }
}