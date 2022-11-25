namespace BoatBookingCore.Dto;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
    public string Certificates { get; set; }

    public UserDto(string name, bool isAdmin)
    {
        IsAdmin = isAdmin;
        Name = name;
        Password = name;
    }

    public UserDto(string name, bool isAdmin, string certificates) : this(name, isAdmin)
    {
        Certificates = certificates;
    }

    public UserDto(int id, string name, bool isAdmin, string certificates) : this(id, name, isAdmin)
    {
        Certificates = certificates;
    }

    public UserDto(int id, string name, bool isAdmin) : this(name, isAdmin)
    {
        Id = id;
        Certificates = "";
    }
}
