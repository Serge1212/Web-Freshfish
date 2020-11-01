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
    public class WorkerController : Controller
    {
        private readonly WorkerService workerService;
        public WorkerController(WorkerService workerService)
        {
            this.workerService = workerService;
        }
        // GET: ProductsController
        public ActionResult Worker()
        {
            return View(workerService.Get());
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = workerService.Get(id);
            if (worker == null)
            {
                return NotFound();
            }
            return View(worker);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Worker worker)
        {
            if (ModelState.IsValid)
            {
                workerService.Create(worker);
                return RedirectToAction(nameof(Worker));
            }
            return View(worker);
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = workerService.Get(id);
            if (worker == null)
            {
                return NotFound();
            }
            return View(worker);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Worker worker)
        {
            if (id != worker.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                workerService.Update(id, worker);
                return RedirectToAction(nameof(Worker));
            }
            else
            {
                return View(worker);
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = workerService.Get(id);
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
                var worker = workerService.Get(id);

                if (worker == null)
                {
                    return NotFound();
                }

                workerService.Remove(worker.Id);

                return RedirectToAction(nameof(Worker));
            }
            catch
            {
                return View();
            }
        }
    }
}
