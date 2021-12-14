using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsService _carsService;

        public CarsController(CarsService carsService)
        {
            _carsService = carsService;
        }
        public IActionResult AllCars()
        {
            return View(_carsService.GetAllCars());
        }

        public IActionResult DisplayAddNewCar(CarModel model = null)
        {
            return View(model);
        }

        public IActionResult SubmitNewCar(CarModel model)
        {
            try
            {
                _carsService.AddNewCar(model);
                return RedirectToAction("AllCars");
            }
            catch
            {
                return RedirectToAction("DisplayAddNewCar", model);
            }
        }

        public IActionResult DeleteCar(CarModel model)
        {
            _carsService.DeleteCar(model);
            return RedirectToAction("AllCars");
        }

        public IActionResult DisplayUpdateCar(CarModel model)
        {
            return View(model);
        }

        public IActionResult SubmitUpdate(CarModel model)
        {
            try
            {
                _carsService.UpdateCar(model);
                return RedirectToAction("AllCars");
            }
            catch
            {
                return RedirectToAction("DisplayUpdateCar", model);
            }
        }
    }
}
