using System;
using System.Text.RegularExpressions;

namespace StorageFacility.DTO
{
    /// <summary>
    /// Contains information about a product.
    /// </summary>
    public class Product
    {

        public Product(string barcode, string name)
        {
            if (!Regex.IsMatch(barcode, "^[0-9]{13}$"))
            {
                throw new FormatException("Barcode format was not valid!");
            }

            Barcode = ulong.Parse(barcode);
            Name = name;
        }

        public string Name { get; private set; }

        public ulong Barcode { get; private set; }

    }
}