namespace BoatBookingCore
{
    public class Boat
    {
        public string Name { get; set; }
        public string type { get; set; }
        public int? WeightMax { get; set; }
        public int? WeightMin { get; set; }
        public string? authorizations { get; set; }

        public Boat(string name, string type)
        {
            Name = name;
            this.type = type;
            WeightMax = null;
            WeightMin = null;
            this.authorizations = null;
        }

        public Boat( string name, string type, int? weightMax, int? weightMin, string? authorizations)
        {
            Name = name;
            this.type = type;
            WeightMax = weightMax;
            WeightMin = weightMin;
            this.authorizations = authorizations;
        }
    }
}
