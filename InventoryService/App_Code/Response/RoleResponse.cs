using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for RoleResponse
/// </summary>
[DataContract]
public class RoleResponse
{
    public RoleResponse()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    [DataMember]
    public string RoleCode { get; set; }

    [DataMember]
    public string RoleName { get; set; }
}