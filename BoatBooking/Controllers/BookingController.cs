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

    public IActionResult AddReservation(ReservationViewModel model)
    {
        return View(model);
    }

    [HttpPost]
    public IActionResult SubmitReservation(ReservationViewModel viewModel)
    {
        viewModel.startDateTime = new DateTime(viewModel.date.Year, viewModel.date.Month, viewModel.date.Day, viewModel.startTime.Hour, viewModel.startTime.Minute, viewModel.startTime.Second);
        viewModel.endDateTime = new DateTime(viewModel.date.Year, viewModel.date.Month, viewModel.date.Day, viewModel.endTime.Hour, viewModel.endTime.Minute, viewModel.endTime.Second);
        viewModel.Reservations.AddReservation(new ReservationDto(0, viewModel.boat, viewModel.user, (DateTime)viewModel.startDateTime, (DateTime)viewModel.endDateTime));
        return RedirectToAction("Index");
    }
}