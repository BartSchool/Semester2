namespace BoatBookingCore.Dto;

public class UserDto
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public bool IsAdmin { get; set; }
    public string? Certificates { get; set; }

    public UserDto(string name, bool isAdmin, string certificates)
    {
        Name = name;
        Password = name;
        IsAdmin = isAdmin;
        Certificates = certificates;
    }

    public UserDto(int id, string name, bool isAdmin, string certificates) 
    {
        Id = id;
        Name = name;
        Password = name;
        IsAdmin = isAdmin;
        Certificates = certificates;
    }

    public UserDto(int id, string name, bool isAdmin)
    {
        Id = id;
        Name = name;
        Password = name;
        IsAdmin = isAdmin;
        Certificates = "";
    }
}
