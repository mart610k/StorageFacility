﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Classes
{
    public interface IAuthService
    {
        bool UserAllowed(string name);

    }
}
