using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for DisbursementResponse
/// </summary>
[DataContract]
public class DisbursementResponse
{
    public DisbursementResponse()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    [DataMember]
    public string ReqNum { get; set; }

    [DataMember]
    public string DisbursementNum { get; set; }

    [DataMember]
    public String DisbursementId { get; set; }

    [DataMember]
    public string RequestedDate { get; set; }

    [DataMember]
    public string ReqId { get; set; }

}