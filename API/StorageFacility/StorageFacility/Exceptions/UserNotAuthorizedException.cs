using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Exceptions
{
    public class UserNotAuthorizedException : Exception
    {
        /// <summary>
        /// User isn't authorised so return a message
        /// Meant for Version 2
        /// </summary>
        /// <param name="message"></param>
        public UserNotAuthorizedException(string message) : base(message)
        {
        }
    }
}
