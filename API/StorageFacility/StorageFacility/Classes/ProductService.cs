using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Classes
{
    public class ProductService : IProductService
    {
        IDatabaseConnection databaseConnection;

        public ProductService(IDatabaseConnection databaseConnection)
        {
            this.databaseConnection = databaseConnection;
        }


        public bool Register(ulong barcode, string name)
        {
            throw new NotImplementedException();
        }
    }
}
