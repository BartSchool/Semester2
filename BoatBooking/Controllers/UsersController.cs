using BoatBookingCore;
using BoatbookingDAL;
using BoatBookingView.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoatBooking.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            UserViewModel viewModel = new UserViewModel();
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
            else if (new Users(new DbUsers()).DoesUserExist(viewModel.UserName))
                ModelState.AddModelError("name", "User name allready exists");

            // certificates error
            if (viewModel.Certificates != null)
                if (!new Users(new DbUsers()).AreCertificatesRight(viewModel.Certificates))
                    ModelState.AddModelError("Certificates", "please fill in correct certificates");

            if (!ModelState.IsValid)
                return View(viewModel);

            new Users(new DbUsers()).AddUser(viewModel.UserName, viewModel.IsAdmin, viewModel.Certificates);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveUser(UserViewModel viewModel)
        {
            new Users(new DbUsers()).RemoveUser(viewModel.User);
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
            if (!viewModel.NewIsAdmin && viewModel.IsAdmin)
                if (new Users(new DbUsers()).IsLastAdmin())
                    ModelState.AddModelError("admin", "There must always be one admin");

            // certificates error
            if (viewModel.NewCertificates != null)
                if (!new Users(new DbUsers()).AreCertificatesRight(viewModel.NewCertificates))
                    ModelState.AddModelError("Certificates", "please fill in correct certificates");

            if (!ModelState.IsValid)
                return View(viewModel);

            new User(new DbUsers()).EditUser(new User(viewModel.UserName, viewModel.NewIsAdmin, viewModel.NewCertificates));

            return RedirectToAction("Index");
        }
    }
}