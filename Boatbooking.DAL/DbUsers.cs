using BoatBookingCore.Interface;
using BoatBookingCore.Dto;
using Microsoft.Data.SqlClient;
using BoatBookingCore;
using System.Xml.Linq;

namespace BoatbookingDAL
{
    public class DbUsers : IDataBaseUsers
    {
        private readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=Bootbooking; Trusted_Connection=True";

        public List<UserDto> users { get => GetUsersFromDataBase(); set => throw new NotImplementedException(); }

        private void addUserToDb(string name, bool isAdmin, string certificates)
        {
            using var connection = new SqlConnection(connectionString);
            int isAdminInt = 0;
            if (isAdmin)
                isAdminInt = 1;

            connection.Open();

            var command = new SqlCommand(
                "IF not exists (SELECT * FROM Users WHERE Name = '" + name + "') " +
                "BEGIN " +
                "INSERT INTO Users(Name, Password, IsAdmin, Certificates) " +
                "VALUES ('" + name + "','" + name + "'," + isAdminInt + ",'" + certificates + "') " +
                "END",
                connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }
        private void addUserToDb(string name, bool isAdmin)
        {
            using var connection = new SqlConnection(connectionString);
            int isAdminInt = 0;
            if (isAdmin)
                isAdminInt = 1;

            connection.Open();

            var command = new SqlCommand(
                "IF not exists (SELECT * FROM Users WHERE Name = '" + name + "') " +
                "BEGIN " +
                "INSERT INTO Users(Name, Password, IsAdmin) " +
                "VALUES ('" + name + "','" + name + "'," + isAdminInt + ") " +
                "END",
                connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }
        private void addUserToDb(string name)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(
                "IF not exists (SELECT * FROM Users WHERE Name = '" + name + "') " +
                "BEGIN " +
                "INSERT INTO Users(Name, Password, IsAdmin) " +
                "VALUES ('" + name + "','" + name + "', 0) " +
                "END",
                connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }

        private List<UserDto> GetUsersFromDataBase()
        {
            List<UserDto> users = new List<UserDto>();

            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Users", connection);
            var reader = command.ExecuteReader();

            if (reader != null)
                while (reader.Read())
                {
                    string certificates;
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    bool isAdmin = reader.GetBoolean(3);
                    if (!reader.IsDBNull(4))
                    {
                        certificates = reader.GetString(4);
                        users.Add(new UserDto(id, name, isAdmin, certificates));
                    }
                    else
                    {
                        users.Add(new UserDto(id, name, isAdmin));
                    }
                }

            connection.Close();
            return users;
        }
        private List<UserDto> GetUsersFromDataBase(string Name)
        {
            List<UserDto> users = new List<UserDto>();

            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Users where Name = " + Name, connection);
            var reader = command.ExecuteReader();

            if (reader != null)
                while (reader.Read())
                {
                    bool isAdmin = false;
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    int isAdminread = reader.GetInt16(3);
                    if (isAdminread == 1)
                        isAdmin = true;

                    users.Add(new UserDto(id, name, isAdmin));
                }

            connection.Close();
            return users;
        }
        private List<UserDto> GetUsersFromDataBase(int Id)
        {
            List<UserDto> users = new List<UserDto>();

            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Users where ID = " + Id, connection);
            var reader = command.ExecuteReader();

            if (reader != null)
                while (reader.Read())
                {
                    bool isAdmin = false;
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    int isAdminread = reader.GetInt16(3);
                    if (isAdminread == 1)
                        isAdmin = true;

                    users.Add(new UserDto(id, name, isAdmin));
                }

            connection.Close();
            return users;
        }

        private int HowManyAdminsAreThere()
        {
            using var connection = new SqlConnection(connectionString);
            int admins = 0;

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Users WHERE IsAdmin = 1", connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                admins++;
            }
            connection.Close();
            return admins;
        }

        public void EditUser(UserDto user)
        {
            int intAdmin = 0;
            if (user.IsAdmin)
                intAdmin = 1;
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand("UPDATE Users " +  
                "SET IsAdmin = " + intAdmin + ", Certificates = '" + user.Certificates + "' " +
                "WHERE Name = '" + user.Name + "'", connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }

        private bool DoesStringContainRightCertificates(string certificate)
        {
            List<string> correct = GetCertificatesFromDb();
            bool result = true;

            char[] chars = certificate.ToCharArray();
            List<string> cert = new List<string>();
            string test = "";

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] != ',')
                    test += chars[i];
                else
                {
                    if (!correct.Contains(test))
                        return false;
                    test = "";
                }
            }
            if (!correct.Contains(test))
                return false;

            return result;
        }
        private List<string> GetCertificatesFromDb()
        {
            List<string> list = new List<String>();

            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM certificates", connection);
            var reader = command.ExecuteReader();

            if (reader != null)
                while (reader.Read())
                {
                    string a = reader.GetString(0);

                    list.Add(a);
                }
            connection.Close();

            return list;
        }

        public bool AreCertificatesRight(UserDto user)
        {
            return DoesStringContainRightCertificates(user.Certificates);
        }

        public bool DoesUserExist(UserDto user)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Users where name = '" + user.Name + "'", connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                connection.Close();
                return true;
            }

            connection.Close();
            return false;
        }

        public void RemoveUser(UserDto user)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(" DELETE FROM Users WHERE ID = " + user.Id, connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }

        public void AddUser(UserDto user)
        {
            if (user.Certificates == null)
                addUserToDb(user.Name, user.IsAdmin);
            else
                addUserToDb(user.Name, user.IsAdmin, user.Certificates);
        }

        public bool IsLastAdmin()
        {
            if (HowManyAdminsAreThere() == 1)
                return true;
            return false;
        }
    }
}
