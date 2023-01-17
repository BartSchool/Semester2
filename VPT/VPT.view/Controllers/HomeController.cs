using Microsoft.AspNetCore.Mvc;
using VPT.Dal;
using VPT.view.Models;

namespace VPT.view.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        HomeViewModel vm = new HomeViewModel();
        vm.EventCollection = new(new Dalevent());
        return View(vm);
    }

    [HttpPost]
    public IActionResult AddReservation(HomeViewModel vm)
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}