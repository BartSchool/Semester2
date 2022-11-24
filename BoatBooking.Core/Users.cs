using BoatBookingCore.Interface;
using BoatBookingCore.Dto;

namespace BoatBookingCore
{
    public class Users
    {
        // 1. wat is een C# interface? 2. Hoe kan ik die hier gebruikeN?
        public List<User> userList;

        public Users(IDataBaseUsers db)
        {
            userList = new List<User>();
            foreach (UserDto dto in db.users)
                userList.Add(new User(dto));
        }
    }
}
