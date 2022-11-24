using BoatBookingCore.Interface;
using BoatBookingCore.Dto;

namespace BoatBookingCore;

public class Boats
{
    public List<Boat> BoatList { get; private set; }
    private IDbBoats _boats;

    public Boats(IDbBoats db)
    {
        _boats = db;
        BoatList = new List<Boat>();

        foreach (BoatDto dto in _boats.BoatList)
            BoatList.Add(new Boat(dto));
    }

    public void AddBoat(string name, string type, int? weightMax, int? weightMin, string? certificates)
    {
        BoatDto boat = new BoatDto(name, type, weightMax, weightMin, certificates);
        _boats.AddBoat(boat);
    }

    public void RemoveBoat(Boat boat)
    {
        BoatDto boatDto = new BoatDto(boat.Name, boat.Type, boat.WeightMin, boat.WeightMax, boat.Authorizations);
        _boats.RemoveBoat(boatDto);
    }

    public bool doesBoatExist(string name, string type, int? weightMax, int? weightMin, string? certificates)
    {
        BoatDto Dto = new BoatDto(name, type, weightMax, weightMin, certificates);
        return _boats.DoesBoatExist(Dto);
    }

    public bool IsBoatTypeCorrect(string name, string type, int? weightMax, int? weightMin, string? certificates)
    {
        BoatDto Dto = new BoatDto(name, type, weightMax, weightMin, certificates);
        return _boats.IsBoatTypeCorrect(Dto);
    }

    public bool IsCertificatesRight(string name, string type, int? weightMax, int? weightMin, string? certificates)
    {
        BoatDto Dto = new BoatDto(name, type, weightMax, weightMin, certificates);
        return _boats.IsCertificateCorrect(Dto);
    }
}
