using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Classes
{
    public class Product
    {
        private ulong barcode;

        public ulong Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Product(ulong barcode, string name)
        {
            Barcode = barcode;
            Name = name;
        }
    }
}
