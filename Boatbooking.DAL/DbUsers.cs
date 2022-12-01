using BoatBookingCore.Interface;
using BoatBookingCore.Dto;
using Microsoft.Data.SqlClient;

namespace BoatbookingDAL;

public class DbUsers : IDataBaseUsers, IUser
{
    private readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=Bootbooking; Trusted_Connection=True";

    public List<UserDto> users { get => GetUsersFromDataBase(); }

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
    public UserDto GetUserFromDataBase(int Id)
    {
        UserDto user;

        using var connection = new SqlConnection(connectionString);

        connection.Open();

        var command = new SqlCommand(" SELECT * FROM Users WHERE id = " + Id, connection);
        var reader = command.ExecuteReader();
        reader.Read();
        string certificates;
        int id = reader.GetInt32(0);
        string name = reader.GetString(1);
        bool isAdmin = reader.GetBoolean(3);
        if (!reader.IsDBNull(4))
        {
            certificates = reader.GetString(4);
            user = new UserDto(id, name, isAdmin, certificates);
        }
        else
        {
            user = new UserDto(id, name, isAdmin);
        }

        connection.Close();
        return user;
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
        char[] chars = certificate.ToCharArray();
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

        return true;
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

    public bool AreCertificatesRight(string certificates)
    {
        return DoesStringContainRightCertificates(certificates);
    }

    public bool DoesUserExist(string name)
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
