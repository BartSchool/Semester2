using BoatBookingCore.Dto;

namespace BoatBookingCore
{
    public class User
    {
        // volgende stap: ipv DbUsers, maka je IDbUsers (staat in core) -> geef de IDbUser mee in de constructor
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
    }
}
