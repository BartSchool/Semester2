using System.Data.SqlClient;
using VPT.Core.Classes;
using VPT.Core.Dto_s;
using VPT.Core.Interfaces;

namespace VPT.Dal;

public class DalReservations : IReservationCollection
{
    public List<DtoReservation> Reservationlist { get => GetReservations(); set => GetReservations(); }
    private readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=VPT; Trusted_Connection=True";

    private List<DtoReservation> GetReservations()
    {
        List<DtoReservation> list = new List<DtoReservation>();
        List<int> GroupID = new();
        List<int> EventID = new();
        List<DateTime> time = new();

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "SELECT EventID, GroupID, ReservationTime FROM Events"
            , connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                EventID.Add(reader.GetInt32(0));
                GroupID.Add(reader.GetInt32(1));
                time.Add(reader.GetDateTime(2));

            }
        connection.Close();

        for (int i = 0; i < GroupID.Count; i++)
            list.Add(new(new DtoGroup(GetVisitorsFromGroupId(GroupID[i]), GroupID[i]), time[i], GetEventFromID(EventID[i])));

        return list;
    }

    private List<DtoPerson> GetVisitorsFromGroupId(int id)
    {
        List<DtoPerson> visitors = new List<DtoPerson>();

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "SELECT Name, BirthDate FROM Visitors WHERE GroupID = " + id
            , connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                string name = reader.GetString(0);
                DateOnly BirthDate = DateOnly.FromDateTime(reader.GetDateTime(1));

                visitors.Add(new(name, BirthDate));
            }
        connection.Close();

        return visitors;
    }

    private DtoEvent GetEventFromID(int id)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "SELECT name, EventStart, RegisterClose, AvailableSpaces FROM Visitors WHERE EventID = " + id
            , connection);
        var reader = command.ExecuteReader();

        if (reader != null)
        {
            string name = reader.GetString(0);
            DateTime start = reader.GetDateTime(1);
            DateTime close = reader.GetDateTime(2);
            int spaces = reader.GetInt32(3);
            connection.Close();
            return new DtoEvent(close, start, spaces, name);
        }
        else
        {
            connection.Close();
            return new DtoEvent(DateTime.MaxValue, DateTime.MaxValue, -1, "couldnt find event with id" + id);
        }
    }

    public void addReservation(DtoReservation reservation)
    {
        int groupID = addGroup(reservation.group.personlist);
    }

    private int addGroup(List<DtoPerson> visitors)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "INSERT INTO Groups"
            , connection);
        var reader = command.ExecuteReader();
        return 0;
    }

    private void addVisitor(DtoPerson visitor)
    {

    }

    public void removeReservation(DtoReservation reservation)
    {
        throw new NotImplementedException();
    }
}
