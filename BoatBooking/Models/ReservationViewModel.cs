using BoatBookingCore;
using BoatbookingDAL;

namespace BoatBookingView.Models;

public class ReservationViewModel
{
    public Reservations Reservations { get; private set; }
    public string boat { get; set; }
    public string user { get; set; }
    public DateTime date { get; set; }
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    public DateTime? startDateTime { get; set; }
    public DateTime? endDateTime { get; set; }


    public ReservationViewModel()
	{
		Reservations = new Reservations(new DbReservations());
    }
}
