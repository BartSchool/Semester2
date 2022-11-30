using BoatBookingCore.Dto;
using System.Data;

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
        if (dto.Name.Length == 0) throw new ArgumentOutOfRangeException("name");
        if (dto.Type.Length == 0) throw new ArgumentOutOfRangeException("type");

        Name = dto.Name;
        Type = dto.Type;
        WeightMax = dto.WeightMax;
        WeightMin = dto.WeightMin;
        Authorizations = dto.Authorizations;
    }

    public Boat(string name, string type )
    {
        if (name.Length == 0) throw new ArgumentOutOfRangeException("name");
        if (type.Length == 0) throw new ArgumentOutOfRangeException("type");

        Name = name;
        Type = type;
        WeightMax = null;
        WeightMin = null;
        Authorizations = "";
    }
}
