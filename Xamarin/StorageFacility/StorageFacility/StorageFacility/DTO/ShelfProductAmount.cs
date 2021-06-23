namespace StorageFacility.DTO
{

    /// <summary>
    /// Contains information about a product, the shelf and the amount on.
    /// </summary>
    public class ShelfProductAmount
    {

        public ShelfProductAmount(Shelf shelf, Product product, byte amount)
        {
            Shelf = shelf;
            Product = product;
            Amount = amount;
        }

        public Shelf Shelf { get; private set; }
        public Product Product { get; private set; }
        public string data
        {
            get
            {
                return Product.Name + " On " + Shelf.NameWithRack;
            }
        }
        public byte Amount { get; private set; }
    }
}
