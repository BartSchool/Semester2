namespace BoatBooking.Class
{
    public class Reservation
    {
        public int Id { get; set; }
        public Boat Boat { get; set; }
        public User User { get; set; }
        public List<User> Occupants = new List<User>();
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

        public Reservation(int id, Boat boat, User user, DateTime timeStart, DateTime timeEnd, List<User> occupants)
        {
            Id = id;
            Boat = boat;
            User = user;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            Occupants = occupants;
        }

        public Reservation(int id, Boat boat, User user, DateTime timeStart, DateTime timeEnd)
        {
            Id = id;
            Boat = boat;
            User = user;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            Occupants.Add(user);
        }
    }
}
