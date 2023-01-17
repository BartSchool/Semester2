using VPT.Core.Dto_s;
using VPT.Core.Interfaces;

namespace VPT.MockData;

internal class MockVisitors : IReservationCollection
{
    public List<DtoReservation> Reservationlist { get; set; }

    public MockVisitors()
    {
        Reservationlist = new List<DtoReservation>();
    }

    public void addReservation(DtoReservation reservation)
    {
        Reservationlist.Add(reservation);
    }

    public void removeReservation(DtoReservation reservation)
    {
        foreach (var item in Reservationlist)
            if(item.group == reservation.group && item.Event == reservation.Event && item.time == reservation.time)
                Reservationlist.Remove(item);
    }
}
