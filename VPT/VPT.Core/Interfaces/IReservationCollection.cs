using VPT.Core.Dto_s;

namespace VPT.Core.Interfaces;

public interface IReservationCollection
{
    List<DtoReservation> Reservationlist { get; }

    void addReservation(DtoReservation reservation);
    void removeReservation(DtoReservation reservation);
}
