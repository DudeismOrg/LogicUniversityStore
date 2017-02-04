using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Util
{
    public class AckRequisition
    {

        public int ReqId { get; set; }


        public string Remarks { get; set; }


        public string Status { get; set; }


        public int AcknowledgedBy { get; set; }
    }
}
