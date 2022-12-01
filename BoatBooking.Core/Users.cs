using BoatBookingCore.Interface;
using BoatBookingCore.Dto;

namespace BoatBookingCore;


public class Users
{
    public List<User> userList;
    private IDataBaseUsers _users;

    public Users(IDataBaseUsers db)
    {
        userList = new();
        _users = db;
        GetUsers();
    }

    private void GetUsers()
    {
        userList = new();
        foreach (UserDto dto in _users.users)
            userList.Add(new(dto));
        SortList();
    }

    private void SortList()
    {
        userList.Sort(delegate (User x, User y) {
            return x.Name.CompareTo(y.Name);
        });
        userList.Sort(delegate (User x, User y) {
            return y.IsAdmin.CompareTo(x.IsAdmin);
        });
    }

    public void AddUser(string name, bool IsAdmin, string Certificates)
    {
        if (DoesUserExist(name)) throw new Exception("User allready exists");
        if (AreCertificatesRight(Certificates)) throw new Exception("Certificates are wrong");

        UserDto user = new UserDto(name, IsAdmin, Certificates);
        _users.AddUser(user);

        GetUsers();
    }

    public void RemoveUser(User user)
    {
        if (user.IsAdmin && IsLastAdmin()) throw new Exception("There must allways be one admin");

        UserDto Dto = new UserDto(user.Id, user.Name, user.IsAdmin, user.Certificates);
        _users.RemoveUser(Dto);

        GetUsers();
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