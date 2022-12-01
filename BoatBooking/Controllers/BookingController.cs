using BoatBookingCore.Dto;
using BoatBookingView.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoatBooking.Controllers;

public class BookingController : Controller
{
    public IActionResult Index()
    {
        ReservationViewModel viewModel = new ReservationViewModel();
        return View(viewModel);
    }

    public IActionResult AddReservation(ReservationViewModel viewModel)
    {
        if (viewModel.startTime == null) throw new Exception("Need an start time");
        if (viewModel.endTime == null) throw new Exception("Need an end time");
        viewModel.Reservations.AddReservation(new ReservationDto(0, viewModel.boat, viewModel.user, (DateTime)viewModel.startTime, (DateTime)viewModel.endTime));
        return RedirectToAction("Index");
    }
}