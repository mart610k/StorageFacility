namespace StorageFacility.DTO
{
    public class Product
    {

        public Product(string barcode, string productName)
        {
            Barcode = barcode;
            Name = productName;
        }

        public string Name { get; private set; }

        public ulong Barcode { get; private set; }

    }
}