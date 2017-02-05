using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for AckRequisitionRequest
/// </summary>
[DataContract]
public class AckRequisitionRequest
{
    public AckRequisitionRequest()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    [DataMember]
    public string ReqId { get; set; }

    [DataMember]
    public string Remarks { get; set; }

    [DataMember]
    public string Status { get; set; }

    [DataMember]
    public string AcknowledgedBy { get; set; }
}