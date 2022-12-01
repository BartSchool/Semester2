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
        BoatList = new();
        GetBoats();
    }

    private void GetBoats()
    {
        BoatList = new();
        foreach (BoatDto dto in _boats.BoatList)
            BoatList.Add(new Boat(dto));
        sortList();
    }

    private void sortList()
    {
        BoatList.Sort(delegate (Boat x, Boat y) {
            return x.Name.CompareTo(y.Name);
        });
        BoatList.Sort(delegate (Boat x, Boat y) {
            return x.Type.CompareTo(y.Type);
        });
    }

    public void AddBoat(string name, string type, int? weightMax, int? weightMin, string? certificates)
    {
        if (doesBoatExist(name)) throw new Exception("Boat allready exists");
        if (!IsBoatTypeCorrect(type)) throw new Exception("Type is not correct");
        if (certificates != null && certificates.Length > 0)
            if (!IsCertificatesRight(certificates)) throw new Exception("certificates are not correct");

        BoatDto boat = new BoatDto(name, type, weightMax, weightMin, certificates);
        _boats.AddBoat(boat);
        GetBoats();
    }

    public void RemoveBoat(string name, string type)
    {
        _boats.RemoveBoat(name, type);

        GetBoats();
    }

    public bool doesBoatExist(string name)
    {
        return _boats.DoesBoatExist(name);
    }

    public bool IsBoatTypeCorrect(string type)
    {
        return _boats.IsBoatTypeCorrect(type);
    }

    public bool IsCertificatesRight(string certificates)
    {
        return _boats.IsCertificateCorrect(certificates);
    }
}
