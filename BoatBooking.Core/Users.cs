using BoatbookingDAL;
using BoatbookingDAL.DTO_s;

namespace BoatBookingCore
{
    public class Users
    {
        private DbUsers _db = new DbUsers();
        private List<User> users;

        public List<User> GetUsers()
        {
            List<UserDto> usersDto = _db.GetUsersFromDataBase();
            foreach (UserDto user in usersDto)
                users.Add(new User(user));

            return users;
        }

        public void AddUser(string n, bool a, string c)
        {
            if (c != null)
                _db.addUserToDb(n, a, c);
            else
                _db.addUserToDb(n, a);
        }

        public void RemoveUser(int? id)
        {
            _db.removeUserFromDb((int)id);
        }

        public bool AreCertificatesRight(string c)
        {
            if (_db.GetCertificatesFromDb().Contains(c))
                return true;
            return false;
        }

        public bool DoesUserExist(string name)
        {
            return _db.DoesUserExistInDataBase(name);
        }

        public bool IsLastAdmin()
        {
            if (_db.HowManyAdminsAreThere() == 1)
                return true;
            return false;
        }
    }
}
