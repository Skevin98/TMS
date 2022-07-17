using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class PurchaseOrderController : Controller
    {
        private readonly IPurchaseOrderService orderService;
        private readonly IUserRepository<Client> clientRepo;
        private readonly IUserRepository<Driver> driverRepo;
        private readonly UserManager<Account> userManager;

        public PurchaseOrderController(IPurchaseOrderService orderService, IUserRepository<Client> clientRepo, IUserRepository<Driver> driverRepo, UserManager<Account> userManager)
        {
            this.userManager = userManager;
            this.orderService = orderService;
            this.clientRepo = clientRepo;
            this.driverRepo = driverRepo;
        }
        // GET: OrderController
        public ActionResult Index()
        {
            if (User.IsInRole("Client"))
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
                    return View(orderService.GetOrderByClient(CId));
                }
            }
            else if (User.IsInRole("Driver"))
            {
                string accountId = userManager.GetUserId(User);
                //Console.WriteLine("XXX : "+accountId);
                var DId = driverRepo.GetByAccoundId(accountId).Result.Id;
                if (DId == null)
                {
                    //Console.WriteLine("XXX");
                    return View();
                }
                else
                {
                    return View(orderService.GetOrderByDriver(DId));
                }
            }
            return View(orderService.GetAllOrder());
     
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        [Authorize(Roles ="Manager,Client")]
        public ActionResult Create()
        {


            if (User.IsInRole("Client"))
            {
                string accountId = userManager.GetUserId(User);
                //Console.WriteLine("XXX : "+accountId);
                var CId = clientRepo.GetByAccoundId(accountId).Result.Id;
                if (CId == null)
                {
                    //Console.WriteLine("XXX");
                    return View("Create", new PurchaseOrderViewModel());
                }
                else
                {
                    //Console.WriteLine("°°°°° : " + CId);
                    return View("Create", new PurchaseOrderViewModel { ClientId = CId });
                }
                

            }
            else
            {
                return View("Create", new PurchaseOrderViewModel ());
            }
            
        }

        // POST: OrderController/Create
        [Authorize(Roles = "Manager,Client")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] PurchaseOrderViewModel ord)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orderService.AddOrder(ord);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
