using BoatBooking.Class;
using BoatBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BoatBooking.Controllers
{
    public class BootController : Controller
    {
        private DataBase _dataBase = new DataBase();

        public IActionResult Index()
        {
            BoathouseViewModel viewModel = new BoathouseViewModel();
            viewModel.boats = _dataBase.GetBoatsFromDataBase();
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
                // name errors
                if (viewModel.name == null)
                    ModelState.AddModelError("name", "a name is required");
                else if (_dataBase.DoesBoatExistInDataBase(viewModel.name))
                    ModelState.AddModelError("name", "Boat allready exists");

                // type errors
                if (viewModel.type == null)
                    ModelState.AddModelError("type", "a type is required");
                else if (!_dataBase.getBoatTypes().Contains(viewModel.type))
                    ModelState.AddModelError("type", viewModel.type + " is not an accepted boat type");

                // weight errors
                if (viewModel.minWeight != null && viewModel.maxWeight == null)
                    ModelState.AddModelError("weight", "please fill in a maximum weight");
                else if (viewModel.minWeight == null && viewModel.maxWeight != null)
                    ModelState.AddModelError("weight", "please fill in a minimum weight");

                // certificates error
                if (viewModel.authorised != null)
                    if (!_dataBase.DoesStringContainRightCertificates(viewModel.authorised))
                        ModelState.AddModelError("Certificates", "please fill in correct certificates");

                if (!ModelState.IsValid)
                    return View(viewModel);

                if (viewModel.minWeight == null && viewModel.authorised == null)
                    _dataBase.addBoatToDb(viewModel.name, viewModel.type);
                else if (viewModel.minWeight == null && viewModel.authorised != null)
                    _dataBase.addBoatToDb(viewModel.name, viewModel.type, viewModel.authorised);
                else if (viewModel.authorised == null && viewModel.minWeight != null)
                    _dataBase.addBoatToDb(viewModel.name, viewModel.type, viewModel.minWeight, viewModel.maxWeight);
                else
                    _dataBase.addBoatToDb(viewModel.name, viewModel.type, viewModel.minWeight, viewModel.maxWeight, viewModel.authorised);
            }
                    
            return RedirectToAction("Index");
        }

        public IActionResult RemoveBoat(BoathouseViewModel b)
        {
            _dataBase.removeBoatFromDb(b.Boat.Name, b.Boat.type);
            return RedirectToAction("Index");
        }

        public IActionResult AddReservation()
        {
            return View();
        }
    }
}
