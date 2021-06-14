using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Classes
{
    public class AuthService : IAuthService
    {
        public bool UserAllowed(string name)
        {
            return true;
        }
    }
}
