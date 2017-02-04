using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for RetreivalResponse
/// </summary>
[DataContract]
public class RetreivalResponse
{
    public RetreivalResponse()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    [DataMember]
    public string DeptName { get; set; }

    [DataMember]
    public string ItemName { get; set; }

    [DataMember]
    public string Quantity { get; set; }

}