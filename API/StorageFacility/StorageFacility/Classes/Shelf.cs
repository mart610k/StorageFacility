using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Classes
{
    public class Shelf
    {
        private string  name;

        public string  Name
        {
            get { return name; }
            set { name = value; }
        }
        private string rackName;

        public string RackName
        {
            get { return rackName; }
            set { rackName = value; }
        }

        public Shelf(string name, string rackName)
        {
            Name = name;
            RackName = rackName;
        }

    }
}
