using Microsoft.AspNetCore.Mvc;

namespace BoatBooking.Controllers;

public class BookingController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AddReservation()
    {
        return View();
    }
}