using BoatBooking.Class;

namespace BoatBooking.Models
{
    public class BoathouseViewModel
    {
        public Boat? Boat { get; set; }
        public List<Boat>? boats { get; set; }

        public BoathouseViewModel()
        {
            Boat = new Boat("", "");
        }
    }
}
