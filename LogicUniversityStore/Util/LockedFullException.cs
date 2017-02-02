using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Util
{
    public class LockedFullException: Exception
    {
        public LockedFullException(String message) : base(message)
        {
            
        }
    }
}