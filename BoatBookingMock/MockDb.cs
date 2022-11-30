using BoatBookingCore.Dto;
using BoatBookingCore.Interface;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace BoatBookingMock
{
    public class MockDb : IDataBaseUsers, IDbBoats
    {
        public List<UserDto> users { get; set; }

        public List<BoatDto> BoatList { get; set; }

        private List<string> certificates = new List<string>() { "sk1", "sk2", "sk3", };
        private List<string> types = new() { "c4x+", "1x" };

        public MockDb()
        {
            users = GetUsers();
            BoatList = GetBoats();
        }

        private List<UserDto> GetUsers()
        {
            List<UserDto> dto = new();
            return dto;
        }

        private List<BoatDto> GetBoats()
        {
            List<BoatDto> dto = new();
            return dto;
        }

        public void AddUser(UserDto user)
        {
            users.Add(user);
        }

        public bool AreCertificatesRight(string test)
        {
            if (certificates.Contains(test))
                return true;
            return false;
        }

        public bool DoesUserExist(string name)
        {
            foreach (UserDto user in users)
                if (user.Name == name)
                    return true;
            return false;
        }

        public bool IsLastAdmin()
        {
            int count = 0;
            foreach(UserDto user in users)
                if (user.IsAdmin)
                    count++;
            if (count == 1)
                return true;
            return false;
        }

        public void RemoveUser(UserDto user)
        {
            for (int i = 0; i < users.Count(); i++)
                if (users[i].Name == user.Name && users[i].IsAdmin == user.IsAdmin && users[i].Certificates == user.Certificates)
                    users.RemoveAt(i);
        }

        public bool IsCertificateCorrect(string test)
        {
            if (certificates.Contains(test))
                return true;
            return false;
        }

        public void RemoveBoat(string name, string type)
        {
            for (int i = 0; i < BoatList.Count; i++)
                if (BoatList[i].Name == name && BoatList[i].Type == type)
                    BoatList.RemoveAt(i);
        }

        public bool IsBoatTypeCorrect(string type)
        {
            if (types.Contains(type))
                return true;
            return false;
        }

        public bool DoesBoatExist(string name)
        {
            foreach (BoatDto boat in BoatList)
                if (boat.Name == name)
                    return true;
            return false;
        }

        public void AddBoat(BoatDto boat)
        {
            BoatList.Add(new(boat.Name, boat.Type, boat.WeightMin, boat.WeightMax, boat.Authorizations));
        }
    }
}