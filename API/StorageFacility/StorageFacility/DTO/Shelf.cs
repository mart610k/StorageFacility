namespace StorageFacility.DTO
{
    public class Shelf
    {
        public Shelf(string shelfName, string rackName)
        {
            Name = shelfName;
            RackName = rackName;
        }
        
        public string Name { private set; get; }

        public string RackName { get; private set; }
    }
}