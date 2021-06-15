using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Exceptions
{
    public class UserNotAuthorizedException : Exception
    {
        public UserNotAuthorizedException(string message) : base(message)
        {
        }
    }
}
