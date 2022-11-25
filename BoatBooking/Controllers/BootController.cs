using BoatBookingView.Models;
using BoatBookingCore;
using Microsoft.AspNetCore.Mvc;
using BoatbookingDAL;

namespace BoatBookingView.Controllers;

public class BootController : Controller
{
    public IActionResult Index()
    {
        BoathouseViewModel viewModel = new BoathouseViewModel();
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult AddBoat()
    {
        AddBoatViewModel viewModel = new AddBoatViewModel();
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult AddBoat(AddBoatViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            // Specification patterns!! fluentvalidations
            // name errors
            if (viewModel.name == null)
                ModelState.AddModelError("name", "a name is required");
            else if (new Boats(new DbBoats()).doesBoatExist(viewModel.name))
                ModelState.AddModelError("name", "Boat allready exists");

            // type errors
            if (viewModel.type == null)
                ModelState.AddModelError("type", "a type is required");
            else if (!new Boats(new DbBoats()).IsBoatTypeCorrect(viewModel.type))
                ModelState.AddModelError("type", viewModel.type + " is not an accepted boat type");

            // weight errors
            if (viewModel.minWeight != null && viewModel.maxWeight == null)
                ModelState.AddModelError("weight", "please fill in a maximum weight");
            else if (viewModel.minWeight == null && viewModel.maxWeight != null)
                ModelState.AddModelError("weight", "please fill in a minimum weight");

            // certificates error
            if (viewModel.authorised != null)
                if (!new Boats(new DbBoats()).IsCertificatesRight(viewModel.authorised))
                    ModelState.AddModelError("Certificates", "please fill in correct certificates");

            if (!ModelState.IsValid)
                return View(viewModel);

            new Boats(new DbBoats()).AddBoat(viewModel.name, viewModel.type, viewModel.minWeight, viewModel.maxWeight, viewModel.authorised);
        }
                
        return RedirectToAction("Index");
    }

    public IActionResult RemoveBoat(BoathouseViewModel b)
    {
        b.boats.RemoveBoat(b.Boat.Name, b.Boat.Type);
        return RedirectToAction("Index");
    }

    public IActionResult AddReservation()
    {
        return View();
    }
}
