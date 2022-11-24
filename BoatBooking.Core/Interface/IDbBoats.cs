using BoatBookingCore.Dto;

namespace BoatBookingCore.Interface;

public interface IDbBoats
{
    List<BoatDto> BoatList { get; }

    bool IsCertificateCorrect(BoatDto boat);
    bool IsBoatTypeCorrect(BoatDto boat);
    bool DoesBoatExist(BoatDto boat);
    void RemoveBoat(BoatDto boat);
    void AddBoat(BoatDto boat);
}