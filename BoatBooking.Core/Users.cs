using BoatBookingCore.Interface;
using BoatBookingCore.Dto;

namespace BoatBookingCore;


public class Users
{
    public List<User> userList;
    private IDataBaseUsers _users;

    public Users(IDataBaseUsers db)
    {
        userList = new List<User>();
        _users = db;

        foreach (UserDto dto in _users.users)
            userList.Add(new User(dto));
    }

    public void AddUser(string name, bool IsAdmin, string Certificates)
    {
        UserDto user = new UserDto(name, IsAdmin, Certificates);
        _users.AddUser(user);
    }

    public void RemoveUser(User user)
    {
        UserDto Dto = new UserDto((int)user.Id, user.Name, user.IsAdmin, user.Certificates);
        _users.RemoveUser(Dto);
    }

    public bool DoesUserExist(string name)
    {
        return _users.DoesUserExist(name);
    }

    public bool AreCertificatesRight(string certificates)
    {
        return _users.AreCertificatesRight(certificates);
    }

    public bool IsLastAdmin()
    {
        return _users.IsLastAdmin();
    }
}