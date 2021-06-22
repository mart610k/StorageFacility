using System;
using System.Text.RegularExpressions;

namespace StorageFacility.DTO
{
    public class Product
    {
        /// <summary>
        /// Product Name and Barcode 
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="name"></param>
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