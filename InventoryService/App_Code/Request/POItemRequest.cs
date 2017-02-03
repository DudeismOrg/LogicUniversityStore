using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for POItemRequest
/// </summary>
[DataContract]
public class POItemRequest
{
    public POItemRequest()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    [DataMember]
    public int ItemId { get; set; }

    [DataMember]
    public int Quantity { get; set; }

}