namespace BoatBookingCore.Dto;

public class ReservationDto
{
    public int Id { get; private set; }
    public Boat Boat { get; private set; }
    public User User { get; private set; }
    public List<User> Occupants { get; private set; }
    public DateTime TimeStart { get; private set; }
    public DateTime TimeEnd { get; private set; }

    public ReservationDto(Boat boat, User user, DateTime timeStart, DateTime timeEnd)
    {
        Occupants = new List<User>();
        Boat = boat;
        User = user;
        TimeStart = timeStart;
        TimeEnd = timeEnd;
        Occupants.Add(user);
    }

    public ReservationDto(Boat boat, User user, DateTime timeStart, DateTime timeEnd, List<User> occupants) : this(boat, user, timeStart, timeEnd)
    {
        Occupants = occupants;
    }

    public ReservationDto(int id, Boat boat, User user, DateTime timeStart, DateTime timeEnd) : this(boat, user, timeStart, timeEnd)
    {
        Id = id;
    }

    public ReservationDto(int id, Boat boat, User user, DateTime timeStart, DateTime timeEnd, List<User> occupants) : this(id, boat, user, timeStart, timeEnd)
    {
        Occupants = occupants;
    }
}
