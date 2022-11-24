using BoatBookingCore.Dto;

namespace BoatBookingCore.Interface;

public interface IDataBaseUsers
{
    List<UserDto> users { get; }

    bool AreCertificatesRight(string certificates);
    bool DoesUserExist(string name);
    void RemoveUser(UserDto user);
    void AddUser(UserDto user);
    bool IsLastAdmin();
}
