using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Services;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly IReceiptService receiptService;
        private readonly IWebHostEnvironment hostEnvironment;

        public ReceiptController(IReceiptService receiptService, IWebHostEnvironment hostEnvironment)
        {
            this.receiptService = receiptService;
            this.hostEnvironment = hostEnvironment;
        }
        // GET: ReceiptController
        public ActionResult Index()
        {
            return View(receiptService.GetAllReceipt());
        }

        // GET: ReceiptController/Details/5
        public ActionResult Details([FromRoute]Guid id)
        {
            if (id != null)
            {
                ReceiptViewModel viewModel = receiptService.GetReceiptById((Guid)id);
                if (viewModel != null)
                {
                    return View(viewModel);
                }

            }
            return View();
        }

        // GET: ReceiptController/Create
        [Authorize(Roles = "Manager,Driver")]
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
        [Authorize(Roles ="Manager, Driver")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] ReceiptViewModel receipt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string wwwRootPath = hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(receipt.ImageFile.FileName);
                    string extension = Path.GetExtension(receipt.ImageFile.FileName);
                    receipt.ImageName = fileName = fileName + DateTime.Now.ToString("yyyymmdd") + extension;
                    string path = Path.Combine(wwwRootPath + "/Images/Receipts/", fileName);
                    using (var fileStream = new FileStream(path,FileMode.Create))
                    {
                        await receipt.ImageFile.CopyToAsync(fileStream);
                    }


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
