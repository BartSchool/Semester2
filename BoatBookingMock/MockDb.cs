using BoatBookingCore.Dto;
using BoatBookingCore.Interface;

namespace BoatBookingMock
{
    public class MockDb : IDataBaseUsers
    {
        public List<UserDto> users { get => GetUsers(); }

        public List<UserDto> GetUsers()
        {
            List<UserDto> dto = new List<UserDto>();
            return dto;
        }

        public void AddUser(UserDto user)
        {
            users.Add(user);
        }

        public bool AreCertificatesRight(string certificates)
        {
            throw new NotImplementedException();
        }

        public bool DoesUserExist(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsLastAdmin()
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(UserDto user)
        {
            
        }
    }
}