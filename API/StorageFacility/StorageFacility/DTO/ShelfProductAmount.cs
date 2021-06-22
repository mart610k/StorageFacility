using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.DTO
{
    public class ShelfProductAmount
    {
        /// <summary>
        /// Product on a specific shelf, with a specific amount
        /// </summary>
        /// <param name="shelf"></param>
        /// <param name="product"></param>
        /// <param name="amount"></param>
        public ShelfProductAmount(Shelf shelf, Product product, byte amount)
        {
            Shelf = shelf;
            Product = product;
            Amount = amount;
        }

        public Shelf Shelf { get; private set; }
        
        public Product Product { get; private set; }

        public byte Amount { get; private set; }
    }
}
