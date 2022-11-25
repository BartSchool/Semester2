using BoatBookingCore;

namespace BoatBookingView.Models;

public class ReservationViewModel
{
    public List<Reservation> reservations { get; set; }

    public ReservationViewModel()
    {
        reservations = new List<Reservation>();
    }
}
