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
    public class ReceiptController : Controller
    {
        private readonly IReceiptService receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
            

        }
        // GET: ReceiptController
        public ActionResult Index()
        {
            return View(receiptService.GetAllReceipt());
        }

        // GET: ReceiptController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReceiptController/Create
        [Authorize(Roles = "Manager")]
        //[HttpGet("{id}", Name = "Create")]
        public ActionResult Create([FromRoute] Guid? id)
        {
            Console.WriteLine("°°° " + id);
            if (id==null)
            {
                return View("Create", new ReceiptViewModel { });
            }
            else
            {
                return View("Create", new ReceiptViewModel { PurchaseId = (Guid)id });
            }
            
        }

        // POST: ReceiptController/Create
        [Authorize(Roles ="Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ReceiptViewModel receipt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    receiptService.AddReceipt(receipt);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReceiptController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReceiptController/Edit/5
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

        // GET: ReceiptController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReceiptController/Delete/5
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
