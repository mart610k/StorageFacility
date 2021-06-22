namespace StorageFacility.DTO
{
    public class Shelf
    {
        /// <summary>
        /// Shelf and it's responding rack
        /// </summary>
        /// <param name="name"></param>
        /// <param name="rackName"></param>
        public Shelf(string name, string rackName)
        {
            Name = name;
            RackName = rackName;
        }
        
        public string Name { private set; get; }

        public string RackName { get; private set; }
    }
}