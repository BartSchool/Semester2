using BoatBookingCore.Dto;

namespace BoatBookingCore.Interface;

public interface IDbBoats
{
    List<BoatDto> BoatList { get; }

    bool IsCertificateCorrect(string certificates);
    void RemoveBoat(string name, string type);
    bool IsBoatTypeCorrect(string type);
    bool DoesBoatExist(string name);
    void AddBoat(BoatDto boat);
}