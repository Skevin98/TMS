using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Models;
using TMS_PFA.Repositories;
using TMS_PFA.Services;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Controllers
{
    public class DeliveryFormController : Controller
    {
        private readonly IDeliveryFormService formService;
        private readonly UserManager<Account> userManager;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IUserRepository<Client> clientRepo;
        private readonly IUserRepository<Driver> driverRepo;

        public DeliveryFormController(IDeliveryFormService formService, IUserRepository<Client> clientRepo, IUserRepository<Driver> driverRepo, UserManager<Account> userManager, IWebHostEnvironment hostEnvironment)
        {
            this.formService = formService;
            this.userManager = userManager;
            this.hostEnvironment = hostEnvironment;
            this.clientRepo = clientRepo;
            this.driverRepo = driverRepo;
        }
        // GET: DeliveryFormController
        public ActionResult Index()
        {
            if (User.IsInRole("Driver"))
            {
                string accountId = userManager.GetUserId(User);
                //Console.WriteLine("XXX : "+accountId);
                var driver = driverRepo.GetByAccoundId(accountId).Result;
                if (driver == null)
                {
                    //Console.WriteLine("XXX");

                    return View();
                }
                else
                {
                    var DId = driver.Id;
                    return View(formService.GetDeliveryFormByDriver(DId));
                }
            }
            else if (User.IsInRole("Client"))
            {
                string accountId = userManager.GetUserId(User);
                //Console.WriteLine("XXX : "+accountId);
                var CId = clientRepo.GetByAccoundId(accountId).Result.Id;
                if (CId == null)
                {
                    //Console.WriteLine("XXX");
                    return View();
                }
                else
                {
                    return View(formService.GetDeliveryFormByClient(CId));
                }
            }
            return View(formService.GetAllDeliveryForm());
        }

        // GET: DeliveryFormController/Details/5
        public ActionResult Details([FromRoute] Guid? id)
        {
            if (id != null)
            {
                DeliveryFormViewModel viewModel = formService.GetDeliveryFormById((Guid)id);
                if (viewModel != null)
                {
                    return View(viewModel);
                }
                
            }
            return View();
        }

        // GET: DeliveryFormController/Create
        [Authorize(Roles = "Manager,Driver")]
        public ActionResult Create([FromRoute] Guid? id)
        {
            if (id == null)
            {
                return View("Create", new DeliveryFormViewModel());
            }
            return View("Create", new DeliveryFormViewModel { DeliveryId = (Guid)id });
        }

        // POST: DeliveryFormController/Create
        [Authorize(Roles = "Manager,Driver")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] DeliveryFormViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string wwwRootPath = hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(viewModel.ImageFile.FileName);
                    string extension = Path.GetExtension(viewModel.ImageFile.FileName);
                    viewModel.ImageName = fileName = fileName + DateTime.Now.ToString("yyyymmdd") + extension;
                    string path = Path.Combine(wwwRootPath + "/Images/DeliveryForms/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await viewModel.ImageFile.CopyToAsync(fileStream);
                    }
                    formService.AddDeliveryForm(viewModel);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeliveryFormController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeliveryFormController/Edit/5
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

        // GET: DeliveryFormController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeliveryFormController/Delete/5
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
