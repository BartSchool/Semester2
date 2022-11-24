using BoatBookingCore.Dto;
using BoatBookingCore.Interface;
using Microsoft.Data.SqlClient;

namespace BoatbookingDAL;

public class DbBoats : IDbBoats
{
    private readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=Bootbooking; Trusted_Connection=True";

    public List<BoatDto> BoatList { get => GetBoatsFromDataBase(); set => throw new NotImplementedException(); }

    private void addBoatToDb(string name, string type)
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
    private void addBoatToDb(string name, string type, string Authorised)
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
    private void addBoatToDb(string name, string type, int? weightMin, int? weightMax)
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
    private void addBoatToDb(string name, string type, int? weightMin, int? weightMax, string? Authorised)
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

    private List<BoatDto> GetBoatsFromDataBase()
    {
        List<BoatDto> list = new List<BoatDto>();
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


                list.Add(new BoatDto(name, type, max, min, authorised));
            }
        connection.Close();

        return list;
    }
    private List<BoatDto> GetBoatsFromDataBase(string Name)
    {
        List<BoatDto> boatList = new List<BoatDto>();

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


                boatList.Add(new BoatDto(name, type, max, min, authorised));
            }
        connection.Close();

        return boatList;
    }
    private List<BoatDto> GetBoatsFromDataBase(int id)
    {
        List<BoatDto> boatList = new List<BoatDto>();

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


                boatList.Add(new BoatDto(name, type, max, min, authorised));
            }
        connection.Close();

        return boatList;
    }

    private List<string> getBoatTypes()
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

    public bool IsCertificateCorrect(BoatDto boat)
    {
        return DoesStringContainRightCertificates(boat.Authorizations);
    }

    public bool IsBoatTypeCorrect(BoatDto boat)
    {
        List<string> types = getBoatTypes();
        if (types.Contains(boat.Type))
            return true;
        return false;
    }

    public bool DoesBoatExist(BoatDto boat)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(" SELECT * FROM Boats where name = '" + boat.Name + "'", connection);
        var reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            connection.Close();
            return true;
        }

        connection.Close();
        return false;
    }

    public void RemoveBoat(BoatDto boat)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(" DELETE FROM Boats WHERE Name = '" + boat.Name + "' and Type = '" + boat.Type + "'", connection);
        var reader = command.ExecuteReader();

        connection.Close();
    }

    public void AddBoat(BoatDto boat)
    {
        if (boat.Authorizations == null)
        {
            if (boat.WeightMin == null)
                addBoatToDb(boat.Name, boat.Type);
            else
                addBoatToDb(boat.Name, boat.Type, boat.WeightMin, boat.WeightMax);
        }
        else
        {
            if (boat.WeightMin == null)
                addBoatToDb(boat.Name, boat.Type, boat.Authorizations);
            else
                addBoatToDb(boat.Name, boat.Type, boat.WeightMin, boat.WeightMax, boat.Authorizations);
        }
    }
}
