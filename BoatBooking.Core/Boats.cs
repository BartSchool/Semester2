using BoatBookingCore.Interface;
using BoatBookingCore.Dto;

namespace BoatBookingCore
{
    public class Boats
    {
        public List<Boat> BoatList { get; set; }

        public Boats(IDbBoats db)
        {
            BoatList = new List<Boat>();
            foreach (BoatDto dto in db.BoatList)
                BoatList.Add(new Boat(dto));
        }
    }
}
