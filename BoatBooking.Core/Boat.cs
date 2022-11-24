using BoatBookingCore.Dto;

namespace BoatBookingCore;

public class Boat
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int? WeightMax { get; set; }
    public int? WeightMin { get; set; }
    public string? Authorizations { get; set; }

    public Boat(BoatDto dto)
    {
        Name = dto.Name;
        Type = dto.Type;
        WeightMax = dto.WeightMax;
        WeightMin = dto.WeightMin;
        Authorizations = dto.Authorizations;
    }

    public Boat(string name, string type )
    {
        Name = name;
        Type = type;
        WeightMax = null;
        WeightMin = null;
        Authorizations = "";
    }
}
