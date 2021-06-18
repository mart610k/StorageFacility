using System;
using System.Collections.Generic;
using System.Text;

namespace StorageFacility.Class
{
    class Product
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string barcode;

        public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }

        public Product(string name, string barcode)
        {
            Name = name;
            Barcode = barcode;
        }
    }
}
