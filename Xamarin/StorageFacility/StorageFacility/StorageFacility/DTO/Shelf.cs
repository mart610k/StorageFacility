namespace StorageFacility.DTO
{
    /// <summary>
    /// Contains information about a shelf and the rack its attached to
    /// </summary>
    public class Shelf
    {

        public Shelf(string name, string rackName)
        {
            Name = name;
            RackName = rackName;
        }

        public string Name { get; private set; }

        public string RackName { get; private set; }

        public string NameWithRack { get { return Name + " (" + RackName + ")"; } }
    }
}