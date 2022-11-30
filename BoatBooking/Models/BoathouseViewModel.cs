using BoatBookingCore;
using BoatbookingDAL;

namespace BoatBookingView.Models;

public class BoathouseViewModel
{
    public Boat Boat { get; set; }
    public Boats boats { get; set; }

    public BoathouseViewModel()
    {
        boats = new Boats(new DbBoats());
        Boat = new Boat("test", "test");
    }
}
