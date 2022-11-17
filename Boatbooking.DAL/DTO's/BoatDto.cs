namespace BoatbookingDAL.DTO_s
{
    public class BoatDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int? WeightMax { get; set; }
        public int? WeightMin { get; set; }
        public string? Authorizations { get; set; }

        public BoatDto(string name, string type) 
        {
            Name = name;
            Type = type;
        }

        public BoatDto(string name, string type, int? weightMax, int? weightMin, string? authorizations) : this(name, type)
        {
            WeightMax = weightMax;
            WeightMin = weightMin;
            Authorizations = authorizations;
        }
    }
}
