using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly VehiclesService vehiclesService;
        public VehiclesController(VehiclesService vehiclesService)
        {
            this.vehiclesService = vehiclesService;
        }
        // GET: ProductsController
        public ActionResult Vehicles()
        {
            return View(vehiclesService.Get());
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = vehiclesService.Get(id);
            if (vehicles == null)
            {
                return NotFound();
            }
            return View(vehicles);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicles vehicles)
        {
            if (ModelState.IsValid)
            {
                vehiclesService.Create(vehicles);
                return RedirectToAction(nameof(Vehicles));
            }
            return View(vehicles);
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = vehiclesService.Get(id);
            if (vehicles == null)
            {
                return NotFound();
            }
            return View(vehicles);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Vehicles vehicles)
        {
            if (id != vehicles.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                vehiclesService.Update(id, vehicles);
                return RedirectToAction(nameof(Vehicles));
            }
            else
            {
                return View(vehicles);
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = vehiclesService.Get(id);
            if (worker == null)
            {
                return NotFound();
            }
            return View(worker);
        }

        // POST: ProductsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var vehicles = vehiclesService.Get(id);

                if (vehicles == null)
                {
                    return NotFound();
                }

                vehiclesService.Remove(vehicles.Id);

                return RedirectToAction(nameof(Vehicles));
            }
            catch
            {
                return View();
            }
        }
    }
}
