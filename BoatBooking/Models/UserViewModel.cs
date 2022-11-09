using BoatBooking.Class;

namespace BoatBooking.Models
{
    public class UserViewModel
    {
        public List<User>? users { get; set; }
        public User User { get; set; }

        public UserViewModel()
        {
            User = new User(1, "test");
        }
    }
}
