using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Services;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Controllers
{
    public class DriverController : Controller
    {
        private readonly IDriverService driverService;

        public DriverController(IDriverService driverService)
        {
            this.driverService = driverService;
        }
        // GET: DriverController
        public ActionResult Index()
        {
            return View(driverService.GetAllDriver());
        }

        // GET: DriverController/Details/5
        public ActionResult Details(Guid id)
        {
            return View("Index",driverService.GetDrivertById(id));
        }

        // GET: DriverController/Create
        [Authorize("Manager")]
        public ActionResult Create()
        {
            return View("Create",new DriverViewModel());
        }

        // POST: DriverController/Create
        [Authorize("Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] DriverViewModel driverViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    driverService.AddDriver(driverViewModel);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DriverController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DriverController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DriverController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DriverController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
