using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for UserRequest
/// </summary>
[DataContract]
public class UserRequest
{
    [DataMember]
    public string UserName { get; set; }

    [DataMember]
    public string Password { get; set; }

}