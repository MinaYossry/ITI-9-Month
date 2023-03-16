using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CarController : Controller
    {
        public ActionResult GetAllCars()
        {
            ViewBag.CarsList = CarList.List;
            return View();
        }

        public ActionResult SelectCarById(int Id)
        {
            ViewBag.SelectedCar = CarList.List.FirstOrDefault(c => c.Id == Id);
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            ViewBag.SelectedCar = CarList.List.FirstOrDefault(c => c.Id == Id);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int Id, string Color, string Model, string Manufacture)
        {
            Car SelectedCar = CarList.List.FirstOrDefault(c => c.Id == Id);

            SelectedCar.Color = Color;
            SelectedCar.Model = Model;
            SelectedCar.Manufacture = Manufacture;

            return RedirectToAction("GetAllCars");
        }

        public ActionResult Delete(int Id)
        {
            CarList.List.RemoveAll(c => c.Id == Id);
            return RedirectToAction("GetAllCars");

        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int Id, string Color, string Model, string Manufacture)
        {
            Car NewCar = new Car() { Id = Id, Color = Color, Model = Model, Manufacture = Manufacture };
            CarList.List.Add(NewCar);
            return RedirectToAction("GetAllCars");
        }
    }
}
