using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for RetreivalRequest
/// </summary>
[DataContract]
public class RetreivalRequest
{
    public RetreivalRequest()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int UserId { get; set; }
    public List<int> RequisitionItemIds { get; set; }
}