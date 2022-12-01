using BoatBookingCore.Dto;

namespace BoatBookingCore;

public class Reservation
{
    public int Id { get; private set; }
    public Boat Boat { get; private set; }
    public User User { get; private set; }
    public List<User> Occupants { get; private set; }
    public DateTime TimeStart { get; private set; }
    public DateTime TimeEnd { get; private set; }

    public Reservation(int id, Boat boat, User user, DateTime timeStart, DateTime timeEnd)
    {
        Occupants = new();
        Id = id;
        Boat = boat;
        User = user;
        TimeStart = timeStart;
        TimeEnd = timeEnd;
        Occupants.Add(user);
    }

    public Reservation(int id, Boat boat, User user, DateTime timeStart, DateTime timeEnd, List<User> occupants) : this(id, boat, user, timeStart, timeEnd)
    {
        Occupants = occupants;
    }

    public Reservation(ReservationDto dto)
    {
        Id = dto.Id;
        Boat = dto.Boat;
        User = dto.User;
        TimeStart = dto.TimeStart;
        TimeEnd = dto.TimeEnd;
        Occupants = dto.Occupants;
    }
}
