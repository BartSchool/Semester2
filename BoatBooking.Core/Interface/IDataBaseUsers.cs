using BoatBookingCore.Dto;

namespace BoatBookingCore.Interface
{
    public interface IDataBaseUsers
    {
        List<UserDto> users { get; set; }

        bool AreCertificatesRight(UserDto user);
        bool DoesUserExist(UserDto user);
        void RemoveUser(UserDto user);
        void AddUser(UserDto user);
        bool IsLastAdmin();
    }
}
