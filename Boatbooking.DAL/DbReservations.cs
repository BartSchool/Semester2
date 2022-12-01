using BoatBookingCore;
using BoatBookingCore.Dto;
using BoatBookingCore.Interface;
using Microsoft.Data.SqlClient;

namespace BoatbookingDAL;

public class DbReservations : IDbReservations
{
    private readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=Bootbooking; Trusted_Connection=True";
    public List<ReservationDto> reservationList { get => GetReservations(); }

    private List<ReservationDto> GetReservations()
    {
        List<ReservationDto> reservationList = new List<ReservationDto>();
        List<Tuple<int,int,DateTime,DateTime>> reservationids = new();

        using var connection = new SqlConnection(connectionString);

        connection.Open();

        var command = new SqlCommand(" SELECT * FROM Reservations", connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                reservationids.Add(new Tuple<int, int, DateTime, DateTime>(reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetDateTime(4)));
            }
        connection.Close();

        foreach (Tuple<int, int, DateTime, DateTime> reservationid in reservationids)
        {
            reservationList.Add(new ReservationDto(new Boat(new DbBoats().GetBoatFromDataBase(reservationid.Item1)), new User(new DbUsers().GetUserFromDataBase(reservationid.Item2)), reservationid.Item3, reservationid.Item4));
        }

        return reservationList;
    }

    public void AddReservation(Boat boat, User user, DateTime startTime, DateTime endTime)
    {
        using var connection = new SqlConnection(connectionString);

        connection.Open();

        var command = new SqlCommand("INSERT INTO Reservations(boatID, userID, timeStart, timeEnd)\n VALUES "+
            "((SELECT id FROM Boats WHERE Name = " + boat.Name + " AND WHERE type = " + boat.Type + ")," + 
            "(SELECT id FROM Users WHERE Name = " + user.Name + " AND WHERE Certificates = " + user.Certificates + ")," +
            startTime + " , " + endTime + " )", connection);
        var reader = command.ExecuteReader();
    }

    public void RemoveReservation(Reservation reservation)
    {
        using var connection = new SqlConnection(connectionString);
        
        connection.Open();

        var command = new SqlCommand("DELETE FROM Reservations WHERE boatID = (" +
            "SELECT id FROM Boats WHERE Name = " + reservation.Boat.Name + " AND WHERE type =" + reservation.Boat.Type + ")" +
            "AND WHERE userID = (SELECT id FROM Users WHERE name = " + reservation.User.Name + " AND WHERE Certificates = " + reservation.User.Certificates + ")" +
            "AND WHERE timeStart = " + reservation.TimeStart + " AND WHERE timeEnd = " + reservation.TimeEnd, connection);
    }
}