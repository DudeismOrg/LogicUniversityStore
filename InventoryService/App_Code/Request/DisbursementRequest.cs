using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for DisbursementRequest
/// </summary>
[DataContract]
public class DisbursementRequest
{
    public DisbursementRequest()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    [DataMember]
    public string Key { get; set; }

    [DataMember]
    public string DisbId { get; set; }

    [DataMember]
    public string ReceivedBy { get; set; }

    [DataMember]
    public List<DisbursementItemRequest> Items { get; set; }
}