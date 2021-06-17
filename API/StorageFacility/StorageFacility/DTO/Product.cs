using System;
using System.Text.RegularExpressions;

namespace StorageFacility.DTO
{
    public class Product
    {

        public Product(string barcode, string productName)
        {
            if (!Regex.IsMatch(barcode, "^[0-9]{13}$"))
            {
                throw new FormatException("Barcode format was not valid!");
            }

            Barcode = ulong.Parse(barcode);
            Name = productName;
        }

        public string Name { get; private set; }

        public ulong Barcode { get; private set; }

    }
}