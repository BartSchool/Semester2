using BoatbookingDAL.DTO_s;
using BoatbookingDAL;

namespace BoatBookingCore
{
    public class User
    {
        private DbUsers _db; // volgende stap: ipv DbUsers, maka je IDbUsers (staat in core) -> geef de IDbUser mee in de constructor
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string Certificates { get; set; }

        public User(UserDto u)
        {
            Id = u.Id;
            Name = u.Name;
            Password = u.Name;
            IsAdmin = u.IsAdmin;
            Certificates = u.Certificates;
        }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
            Password = name;
            IsAdmin = false;
            Certificates = "";
        }

        public User(int id, string name, bool isAdmin) : this(id, name)
        {
            IsAdmin = isAdmin;
        }

        public User(int id, string name, bool isAdmin, string certificates) : this(id, name)
        {
            IsAdmin = isAdmin;
            Certificates = certificates;
        }

        public void editUser()
        {
            _db.EditUser(new UserDto(Name, IsAdmin, Certificates));
        }
    }
}
