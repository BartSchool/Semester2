using BoatBookingCore.Dto;
using BoatBookingCore.Interface;

namespace BoatBookingCore;

public class Reservations
{
    public List<Reservation> reservations { get; private set; }
	IDbReservations _db;

	public Reservations(IDbReservations db)
	{
		_db = db;
		reservations = new();
		GetReservations();
	}

	private void GetReservations()
	{
		reservations = new();
		foreach (ReservationDto dto in _db.reservationList)
			reservations.Add(new Reservation(dto));
	}

	public void RemoveReservation(Reservation reservation)
	{
		_db.RemoveReservation(reservation);
		GetReservations();
	}

	public void AddReservation(ReservationDto reservation)
	{
		_db.AddReservation(reservation.Boat, reservation.User, reservation.TimeStart, reservation.TimeEnd);
        GetReservations();
    }
}
