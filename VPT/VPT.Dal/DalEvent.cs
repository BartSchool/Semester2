using System.Data.SqlClient;
using VPT.Core.Dto_s;
using VPT.Core.Interfaces;

namespace VPT.Dal;

public class Dalevent : IEventCollection
{
    private readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=VPT; Trusted_Connection=True";

    public List<DtoEvent> EventList { get => GetEventsFromDb(); set => GetEventsFromDb(); }

    private List<DtoEvent> GetEventsFromDb()
    {
        List<DtoEvent> list = new();

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "SELECT name, EventStart, RegisterClose, AvailableSpaces FROM Events"
            , connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                string name = reader.GetString(0);
                DateTime eventStart = reader.GetDateTime(1);
                DateTime registerClose = reader.GetDateTime(2);
                int spaces = reader.GetInt32(3);

                list.Add(new(registerClose, eventStart, spaces, name));
            }

        return list;
    }

    public void AddEvent(DtoEvent @event)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "IF not exists (SELECT EventStart, RegisterClose, AvailableSpaces, name FROM Events " +
            "WHERE name ='" + @event.name + "') " +
            "BEGIN " +
            "INSERT INTO Events(name, EventStart, RegisterClose, AvailableSpaces) " +
            "VALUES ('" + @event.name + "','" + @event.eventStart + "','" + @event.lastRegisterTime + "'," + @event.spaces + ") " +
            "END",
            connection);
        var reader = command.ExecuteReader();

        connection.Close();
    }

    public void RemoveEvent(DtoEvent @event)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(" DELETE FROM Events WHERE name = '" + @event.name + "'", connection);
        var reader = command.ExecuteReader();

        connection.Close();
    }
}