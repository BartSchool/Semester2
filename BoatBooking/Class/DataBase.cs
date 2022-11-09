using BoatBooking.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BoatBooking.Class
{
    public class DataBase
    {
        private string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=Bootbooking; Trusted_Connection=True";

        // BOATS
        public void addBoatToDb(string name, string type)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(
                "IF not exists (SELECT * FROM Boats WHERE Name = '" + name + "') " +
                "BEGIN " +
                "INSERT INTO Boats(name, type, weightMax, weightMin, Authorizations) " +
                "VALUES ('" + name + "','" + type + "', null, null, null) " +
                "END",
                connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }
        public void addBoatToDb(string name, string type, string Authorised)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(
                "IF not exists (SELECT * FROM Boats WHERE Name = '" + name + "') " +
                "BEGIN " +
                "INSERT INTO Boats(name, type, weightMax, weightMin, Authorizations) " +
                "VALUES ('" + name + "','" + type + "', null, null, '" + Authorised + "') " +
                "END",
                connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }
        public void addBoatToDb(string name, string type, int? weightMin, int? weightMax)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(
                "IF not exists (SELECT * FROM Boats WHERE Name = '" + name + "') " +
                "BEGIN " +
                "INSERT INTO Boats(name, type, weightMax, weightMin, Authorizations) " +
                "VALUES ('" + name + "','" + type + "'," + weightMin + "," + weightMax + ", null) " +
                "END",
                connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }
        public void addBoatToDb(string name, string type, int? weightMin, int? weightMax, string? Authorised)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(
                "IF not exists (SELECT * FROM Boats WHERE Name = '" + name + "') " +
                "BEGIN " +
                "INSERT INTO Boats(name, type, weightMax, weightMin, Authorizations) " +
                "VALUES ('" + name + "','" + type + "'," + weightMin + "," + weightMax + ",'" + Authorised + "') " +
                "END",
                connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }
        public void removeBoatFromDb(string name, string type)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(" DELETE FROM Boats WHERE Name = '" + name + "' and Type = '" + type + "'", connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }

        public List<Boat> GetBoatsFromDataBase()
        {
            List<Boat> boatList = new List<Boat>();

            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Boats", connection);
            var reader = command.ExecuteReader();

            if (reader != null)
                while (reader.Read())
                {
                    string name = reader.GetString(1);

                    string type = reader.GetString(2);

                    int? max = null;
                    if (!reader.IsDBNull(3))
                        max = reader.GetInt32(3);

                    int? min = null;
                    if (!reader.IsDBNull(4))
                        min = reader.GetInt32(4);

                    string? authorised = null;
                    if (!reader.IsDBNull(5))
                        authorised = reader.GetString(5);


                    boatList.Add(new Boat(name, type, max, min, authorised));
                }
            connection.Close();

            return boatList;
        }
        public List<Boat> GetBoatsFromDataBase(string Name)
        {
            List<Boat> boatList = new List<Boat>();

            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Boats WHERE name = " + Name, connection);
            var reader = command.ExecuteReader();

            if (reader != null)
                while (reader.Read())
                {
                    string name = reader.GetString(1);

                    string type = reader.GetString(2);

                    int? max = null;
                    if (!reader.IsDBNull(3))
                        max = reader.GetInt32(3);

                    int? min = null;
                    if (!reader.IsDBNull(4))
                        min = reader.GetInt32(4);

                    string? authorised = null;
                    if (!reader.IsDBNull(5))
                        authorised = reader.GetString(5);


                    boatList.Add(new Boat(name, type, max, min, authorised));
                }
            connection.Close();

            return boatList;
        }
        public List<Boat> GetBoatsFromDataBase(int id)
        {
            List<Boat> boatList = new List<Boat>();

            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Boats WHERE id = " + id, connection);
            var reader = command.ExecuteReader();

            if (reader != null)
                while (reader.Read())
                {
                    string name = reader.GetString(1);

                    string type = reader.GetString(2);

                    int? max = null;
                    if (!reader.IsDBNull(3))
                        max = reader.GetInt32(3);

                    int? min = null;
                    if (!reader.IsDBNull(4))
                        min = reader.GetInt32(4);

                    string? authorised = null;
                    if (!reader.IsDBNull(5))
                        authorised = reader.GetString(5);


                    boatList.Add(new Boat(name, type, max, min, authorised));
                }
            connection.Close();

            return boatList;
        }
        
        public List<string> getBoatTypes()
        {
            List<string> boatTypes = new List<string>();
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(" SELECT * FROM boatTypes", connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                boatTypes.Add(reader.GetString(0));
            }

            connection.Close();
            return boatTypes;
        }

        public bool DoesBoatExistInDataBase(string name)
        {
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Boats where name = '" + name + "'", connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                connection.Close();
                return true;
            }

            connection.Close();
            return false;
        }
        // BOATS

        // USERS
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
                "VALUES ('" + name + "','" + name + "'," + isAdminInt + ",'"+ certificates + "') " +
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
        public bool AreWerRemovingLastAdmin(AddUserViewModel vm)
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
        }
        // USERS

        // CERTIFICATES
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
        public bool DoesStringContainRightCertificates(string certificate)
        {
            List<string> correct = GetCertificatesFromDb();
            bool result = true;

            char[] chars = certificate.ToCharArray();
            List<string> cert = new List<string>();
            string test = "";

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i]!=',')
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
        // CERTIFICATES

        //RESERVATIONS

        //RESERVATIONS
    }
}
