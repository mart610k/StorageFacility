using System;
using System.Collections.Generic;
using System.Text;

namespace StorageFacility.Class
{
    class Shelf
    {
        private string name;

        public string Name
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
