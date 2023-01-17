using Microsoft.AspNetCore.Mvc;
using VPT.Dal;
using VPT.view.Models;

namespace VPT.view.Controllers;

public class EventController : Controller
{
    public IActionResult Index()
    {
        EventViewModel vm = new EventViewModel();
        vm._events = new(new Dalevent());
        vm.removeEvent = new(DateTime.MinValue, DateTime.MinValue, 0, "new");
        return View(vm);
    }

    [HttpPost]
    public IActionResult RemoveEvent(EventViewModel vm)
    {
        vm._events = new(new Dalevent());
        vm._events.removeEvent(new(vm.start, vm.end, vm.amount, vm.name));
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult AddEvent()
    {
        AddEventViewModel vm = new();
        DateTime now = DateTime.Now;
        vm.start = now.AddMonths(2);
        vm.end = now.AddMonths(1);
        vm.start = new DateTime((vm.start.Ticks / TimeSpan.TicksPerMinute) * TimeSpan.TicksPerMinute);
        vm.end = new DateTime((vm.end.Ticks / TimeSpan.TicksPerMinute) * TimeSpan.TicksPerMinute);
        return View(vm);
    }

    [HttpPost]
    public IActionResult AddEvent(AddEventViewModel vm)
    {
        vm._events = new(new Dalevent());
        vm._events.addEvent(new(vm.end, vm.start, vm.spaces, vm.name));
        return RedirectToAction("Index");
    }
}
