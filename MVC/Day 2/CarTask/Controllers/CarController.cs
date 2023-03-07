using CarTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarTask.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult GetAllCars()
        {
            ViewBag.CarsList = CarList.List;
            return View();
        }

        public ActionResult SelectCarById(int Id)
        {
            ViewBag.SelectedCar = CarList.List.FirstOrDefault(c => c.Num == Id);
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            ViewBag.SelectedCar = CarList.List.FirstOrDefault(c => c.Num == Id);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int Id, string Color, string Model, string Manufacture)
        {
            Car SelectedCar = CarList.List.FirstOrDefault(c => c.Num == Id);

            SelectedCar.Color = Color;
            SelectedCar.Model = Model;
            SelectedCar.Manufacture = Manufacture;

            return RedirectToAction("GetAllCars");
        }

        public ActionResult Delete(int Id)
        {
            CarList.List.RemoveAll(c => c.Num == Id);
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
            Car NewCar = new Car() {  Num = Id, Color = Color, Model = Model, Manufacture = Manufacture };
            CarList.List.Add(NewCar);
            return RedirectToAction("GetAllCars");
        }
    }
}