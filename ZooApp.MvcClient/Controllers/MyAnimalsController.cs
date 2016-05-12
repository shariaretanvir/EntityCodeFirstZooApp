using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.Services;
using ZooApp.ViewModels;

namespace ZooApp.MvcClient.Controllers
{
    public class MyAnimalsController : Controller
    {
        AnimalService animalService = new AnimalService();
        // GET: MyAnimals
        public ActionResult Index()
        {
            var viewAnimals = animalService.GetAll();
            return View(viewAnimals);
        }

        public ActionResult Details(int id)
        {
            ViewAnimal animal = animalService.Get(id);
            return View(animal);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            bool saved = animalService.Save(animal);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Animal animal = animalService.GetDbModel(id);
            return View(animal);
        }
        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            bool saved = animalService.Update(animal);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Animal model = animalService.GetDbModel(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Animal animal)
        {
            bool saved = animalService.Delete(animal);
            return RedirectToAction("Index");
        }
    }
}