using BoatBookingCore;
using BoatbookingDAL;

namespace BoatBookingView.Models;

public class ReservationViewModel
{
    public Reservations Reservations { get; private set; }
    public Boat boat { get; set; }
    public User user { get; set; }
    public DateTime? startTime { get; set; }
    public DateTime? endTime { get; set; }

    public ReservationViewModel()
	{
		Reservations = new Reservations(new DbReservations());
        boat = new Boat("new", "new");
        user = new User("new", false, "new");
	}
}
