using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.DTO
{
    public class ShelfProductAmount
    {
        public Shelf Shelf { get; private set; }
        public Product Product { get; private set; }

        public byte productAmount { get; private set; }
    }
}
