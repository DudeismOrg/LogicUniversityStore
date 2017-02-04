using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

/// <summary>
/// Summary description for ManageRoleRequest
/// </summary>
[DataContract]
public class ManageRoleRequest
{

    public ManageRoleRequest()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    [DataMember]
    public int UserId { get; set; }

    [DataMember]
    public string RoleCode { get; set; }
}