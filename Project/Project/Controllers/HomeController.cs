using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly RepairshopService _repService;

        public HomeController(RepairshopService repService)
        {
            _repService = repService;
        }

        public IActionResult Index()
        {
            return View(_repService.GetAllMechanics());
        }

        public IActionResult DisplayAddNewMechanic()
        {
            return View(new MechanicModel());
        }

        public IActionResult SubmitNewMechanic(MechanicModel model)
        {
            try
            {
                _repService.AddNewMechanic(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("DisplayAddNewMechanic", model);
            }
        }

        public IActionResult DeleteMechanic(MechanicModel model)
        {
            _repService.DeleteMechanic(model);
            return RedirectToAction("Index");
        }

        public IActionResult DisplayUpdateMechanic(MechanicModel model)
        {
            return View(model);
        }

        public IActionResult SubmitUpdate(MechanicModel model)
        {
            try
            {
                _repService.UpdateMechanic(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("DisplayUpdateMechanic", model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
