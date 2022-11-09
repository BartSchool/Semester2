namespace BoatBooking.Class
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string Certificates { get; set; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
            Password = name;
            IsAdmin = false;
            Certificates = "";
        }

        public User(int id, string name, bool isAdmin)
        {
            Id = id;
            Name = name;
            Password =  name;
            IsAdmin = isAdmin;
            Certificates = "";
        }

        public User(int id, string name, bool isAdmin, string certificates)
        {
            Id = id;
            Name = name;
            Password = name;
            IsAdmin = isAdmin;
            Certificates = certificates;
        }
    }
}
