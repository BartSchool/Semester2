using BoatBookingCore;
using BoatbookingDAL;

namespace BoatBookingView.Models
{
    public class UserViewModel
    {
        public Users users;
        public User User { get; set; }

        public UserViewModel()
        {
            users = new Users(new DbUsers());
            User = new User(new DbUsers());
        }
    }
}
