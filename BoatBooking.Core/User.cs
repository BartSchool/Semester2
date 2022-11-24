using BoatBookingCore.Dto;
using BoatBookingCore.Interface;

namespace BoatBookingCore;

public class User
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public bool IsAdmin { get; set; }
    public string? Certificates { get; set; }
    IUser? _user;

    public User(IUser db)
    {
        _user = db;
    }

    public User(UserDto Dto)
    {
        Id = Dto.Id;
        Name = Dto.Name;
        Password = Dto.Name;
        IsAdmin = Dto.IsAdmin;
        Certificates = Dto.Certificates;
    }

    public User(string name, bool isAdmin, string certificates)
    {
        Name = name;
        Password = name;
        IsAdmin = isAdmin;
        Certificates = certificates;
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

    public void EditUser(User user)
    {
        UserDto dto = new UserDto(user.Name, user.IsAdmin, user.Certificates);
        _user.EditUser(dto);
    }
}
