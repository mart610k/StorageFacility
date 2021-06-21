namespace StorageFacility.DTO
{
    public class Shelf
    {
        public Shelf(string name, string rackName)
        {
            Name = name;
            RackName = rackName;
        }
        
        public string Name { private set; get; }

        public string RackName { get; private set; }
    }
}