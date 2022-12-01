using BoatBookingCore.Dto;

namespace BoatBookingCore.Interface;

public interface IDbReservations
{
    List<ReservationDto> reservationList { get; }

    void RemoveReservation(Reservation reservation);
    void AddReservation(Boat boat, User user, DateTime startTime, DateTime endTime);
}
