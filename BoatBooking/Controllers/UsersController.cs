using BoatBooking.Class;
using BoatBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoatBooking.Controllers
{
    public class UsersController : Controller
    {
        private DataBase _dataBase = new DataBase();

        public IActionResult Index()
        {
            UserViewModel viewModel = new UserViewModel();
            viewModel.users = _dataBase.GetUsersFromDataBase();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(AddUserViewModel viewModel)
        {
            // name error
            if (viewModel.UserName == null)
                ModelState.AddModelError("name", "A name is required");
            else if (_dataBase.DoesUserExistInDataBase(viewModel.UserName))
                ModelState.AddModelError("name", "User name allready exists");

            // certificates error
            if (viewModel.Certificates != null)
                if (!_dataBase.DoesStringContainRightCertificates(viewModel.Certificates))
                    ModelState.AddModelError("Certificates", "please fill in correct certificates");

            if (!ModelState.IsValid)
                return View(viewModel);

            _dataBase.addUserToDb(viewModel.UserName, viewModel.IsAdmin, viewModel.Certificates);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveUser(UserViewModel viewModel)
        {
            _dataBase.removeUserFromDb(viewModel.User.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUser(UserViewModel viewModel)
        {
            AddUserViewModel addUserVM = new AddUserViewModel() {
                UserName = viewModel.User.Name,
                IsAdmin = viewModel.User.IsAdmin,
                Certificates = viewModel.User.Certificates
            };

            return View(addUserVM);
        }

        [HttpPost]
        public IActionResult EditUser(AddUserViewModel viewModel)
        {
            // admin error
            if (_dataBase.AreWerRemovingLastAdmin(viewModel))
                ModelState.AddModelError("admin", "There must always be one admin");

            // certificates error
            if (viewModel.NewCertificates != null)
                if (!_dataBase.DoesStringContainRightCertificates(viewModel.NewCertificates))
                    ModelState.AddModelError("Certificates", "please fill in correct certificates");

            if (!ModelState.IsValid)
                return View(viewModel);

            _dataBase.EditUser(viewModel);
            return RedirectToAction("Index");
        }
    }
}
