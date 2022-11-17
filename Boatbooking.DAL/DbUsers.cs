using BoatbookingDAL.DTO_s;
using Microsoft.Data.SqlClient;

namespace BoatbookingDAL
{
    public class DbUsers
    {
        private readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=Bootbooking; Trusted_Connection=True";

        public void addUserToDb(string name, bool isAdmin, string certificates)
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
        public void addUserToDb(string name, bool isAdmin)
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
        public void addUserToDb(string name)
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
        public void removeUserFromDb(int id)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(" DELETE FROM Users WHERE ID = " + id, connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }

        public void removeUserFromDb(string name)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(" DELETE FROM Users WHERE Name = " + name, connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }

        public List<UserDto> GetUsersFromDataBase()
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
        public List<UserDto> GetUsersFromDataBase(string Name)
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

                    users.Add(new User(id, name, isAdmin));
                }

            connection.Close();
            return users;
        }
        public List<UserDto> GetUsersFromDataBase(int Id)
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

        public bool DoesUserExistInDataBase(string name)
        {
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Users where name = '" + name + "'", connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                connection.Close();
                return true;
            }

            connection.Close();
            return false;
        }

        public int HowManyAdminsAreThere()
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
        public List<string> GetCertificatesFromDb()
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
    }
}
