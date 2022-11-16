using BoatBookingCore;
using Microsoft.Data.SqlClient;

namespace BoatbookingDAL
{
    internal class DbUsers
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

        public List<User> GetUsersFromDataBase()
        {
            List<User> users = new List<User>();

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
                        users.Add(new User(id, name, isAdmin, certificates));
                    }
                    else
                    {
                        users.Add(new User(id, name, isAdmin));
                    }
                }

            connection.Close();
            return users;
        }

        public List<User> GetUsersFromDataBase(string Name)
        {
            List<User> users = new List<User>();

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
        public List<User> GetUsersFromDataBase(int Id)
        {
            List<User> users = new List<User>();

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

                    users.Add(new User(id, name, isAdmin));
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

        /*public bool AreWerRemovingLastAdmin(AddUserViewModel vm)
        {
            EditUser(vm);
            if (AreThereAdmins())
            {
                ReverseEditUser(vm);
                return false;
            }
            ReverseEditUser(vm);
            return true;

        }
        public bool AreThereAdmins()
        {
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Users WHERE IsAdmin = 1", connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }

        public void EditUser(AddUserViewModel vm)
        {
            int intAdmin = 0;
            if (vm.NewIsAdmin)
                intAdmin = 1;
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand("UPDATE Users " +  
                "SET IsAdmin = " + intAdmin + ", Certificates = '" + vm.NewCertificates + "' " +
                "WHERE Name = '" + vm.UserName + "'", connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }
        public void ReverseEditUser(AddUserViewModel vm)
        {
            int intAdmin = 0;
            if (vm.IsAdmin)
                intAdmin = 1;
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand("UPDATE Users " +
                "SET IsAdmin = " + intAdmin + ", Certificates = '" + vm.Certificates + "' " +
                "WHERE Name = '" + vm.UserName + "'", connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }*/
    }
}
