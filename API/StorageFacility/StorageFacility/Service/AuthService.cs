using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Service
{
    public class AuthService : IAuthService
    {
        /// <summary>
        /// Bool on UserAllowed, supposed to check if user is allowed access
        /// Not needed for Version 1, but Version 2
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool UserAllowed(string name)
        {
            return true;
        }
    }
}
