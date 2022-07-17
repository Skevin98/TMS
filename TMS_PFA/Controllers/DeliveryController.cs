using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Models;
using TMS_PFA.Repositories;
using TMS_PFA.Services;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService deliveryService;
        private readonly IUserRepository<Client> clientRepo;
        private readonly IUserRepository<Driver> driverRepo;
        private readonly UserManager<Account> userManager;


        public DeliveryController(IDeliveryService deliveryService, IUserRepository<Client> clientRepo, IUserRepository<Driver> driverRepo, UserManager<Account> userManager)
        {
            this.deliveryService = deliveryService;
            this.userManager = userManager;
            this.clientRepo = clientRepo;
            this.driverRepo = driverRepo;
        }

        // GET: DeliveryController
        [Authorize(Roles="Manager,Client,Driver")]
        public ActionResult Index([FromRoute] Guid? id)
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
                    return View(deliveryService.GetDeliveryByDriver(DId));
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
                    return View(deliveryService.GetDeliveryByClient(CId));
                }
            }
            if (id!=null)
            {
                return View(deliveryService.GetDeliveryByOrder((Guid)id));
            }
            return View(deliveryService.GetAllDelivery());
        }

        // GET: DeliveryController/Details/5
        
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DeliveryController/Create
        [Authorize(Roles = "Manager, Driver")]
        [HttpGet("[controller]/[action]/{PurchaseId?}",Name = "Create")]
        public ActionResult Create([FromRoute]Guid? PurchaseId)
        {
            if (PurchaseId == null)
            {
                return View("Create", deliveryService.GetEditDelivery(null));
            }
            EditDeliveryViewModel viewModel = deliveryService.GetEditDelivery(null);
            viewModel.PurchaseId = (Guid)PurchaseId;
            Console.WriteLine("CreateView " + viewModel.PurchaseId);

            Console.WriteLine("AAAAA");

            return View("Create", viewModel);

            
            //return View("Create", new EditDeliveryViewModel { PurchaseId = (Guid)id });
        }

        // POST: DeliveryController/Create
        [Authorize(Roles = "Manager,Driver")]
        //[HttpPost("{PurchaseId?}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] EditDeliveryViewModel del)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Console.WriteLine("Create " + del.Id);
                    var result = deliveryService.GetDeliveryById(del.Id);
                    Console.WriteLine("*** " + result.Id);
                    if (result.Id.Equals(Guid.Empty))
                    {
                        Console.WriteLine("---");
                        Console.WriteLine("---" + result.Id);
                        deliveryService.AddDelivery(del);
                    }
                    else
                    {
                        Console.WriteLine("+++");

                        Console.WriteLine(del.Id);

                        Console.WriteLine(del.SelectedDriver);
                        Console.WriteLine(del.SelectedVehicle);
                        deliveryService.UpdateDelivery(del);
                    }
                    
                    
                    
                }
                else
                {
                    
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeliveryController/Edit/5
        [Authorize(Roles = "Manager,Driver")]
        public ActionResult Edit(Guid id)
        {
            return View("Create", deliveryService.GetEditDelivery(id) );
        }

        // POST: DeliveryController/Edit/5
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

        // GET: DeliveryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeliveryController/Delete/5
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
