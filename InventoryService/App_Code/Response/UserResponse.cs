using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for UserResponse
/// </summary>
[DataContract]
public class UserResponse
{
    public UserResponse()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public UserResponse(int UserID, string FirstName, string Email, string LastName, int DepartmentID, string DepartmentName, int RoleID, string RoleName)
    {
        this.UserID = UserID;
        this.FirstName = FirstName;
        this.Email = Email;
        this.LastName = LastName;
        this.DepartmentID = DepartmentID;
        this.DepartmentName = DepartmentName;
        this.RoleID = RoleID;
        this.RoleName = RoleName;
    }

    [DataMember]
    public int UserID { get; set; }

    [DataMember]
    public string FirstName { get; set; }

    [DataMember]
    public string LastName { get; set; }

    [DataMember]
    public int RoleID { get; set; }

    [DataMember]
    public string RoleName { get; set; }

    [DataMember]
    public string Email { get; set; }

    [DataMember]
    public int? DepartmentID { get; set; }

    [DataMember]
    public string DepartmentName { get; set; }
}