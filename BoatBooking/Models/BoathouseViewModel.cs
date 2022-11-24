using BoatBookingCore;
using BoatBookingCore.Interface;

namespace BoatBookingView.Models
{
    public class BoathouseViewModel
    {
        public Boat Boat { get; set; }
        public IDbBoats boats { get; set; }

        public BoathouseViewModel()
        {
            boats = new Boats();
            Boat = new Boat("", "");
        }
    }
}
