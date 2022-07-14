using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TMS_PFA.Models;
using TMS_PFA.Repositories;
using TMS_PFA.Services;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Controllers
{
    public class AccountController : Controller
    {

        private readonly IClientService clientService;

        private readonly IDriverService driverService;

        private readonly UserManager<Account> userManager;

        public readonly SignInManager<Account> signInManager;

        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(IDriverService driverService, IClientService clientService,UserManager<Account> userManager, SignInManager<Account> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.driverService = driverService;
            this.clientService = clientService;

            this.userManager.Options.SignIn.RequireConfirmedAccount = false;
        }

        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        [AllowAnonymous]
        public ActionResult RegisterClient()
        {
            return View("RegisterClient", new ClientViewModel { Role = "Client"} );
        }

        // POST: AccountController/Create
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterClient([FromForm] ClientViewModel clientViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string r = "";
                    if (clientViewModel.Role == "Client")
                    {
                        r = "Client";
                    }
                    else
                    {
                        ModelState.AddModelError("", "erreur");
                        return View();
                    }

                    Account account = new Account
                    {
                        Email = clientViewModel.Email,
                        UserName = clientViewModel.Name,
                        PhoneNumber = clientViewModel.PhoneNumber,
                    };

                    var result = await userManager.CreateAsync(account, clientViewModel.Password);



                    if (result.Succeeded)
                    {
                        var role = await roleManager.FindByNameAsync(r);
                        if (role != null)
                            await userManager.AddToRoleAsync(account, role.Name);
                        //await signInManager.SignInAsync(account, true);

                        var temp = await userManager.GetUserIdAsync(account);
                        Console.WriteLine("id : "+temp);
                        if (temp != null)
                        {
                            clientViewModel.AccountId = temp;

                            clientService.AddClient(clientViewModel);
                        }
                        return RedirectToAction("Index", "Client");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                }
                return View();
            }

            catch
            {
                return View();
            }
        }


        [Authorize(Roles = "Manager")]
        public ActionResult RegisterDriver()
        {
            return View("RegisterDriver",new DriverViewModel { Role = "Driver" });
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterDriver([FromForm] DriverViewModel driverViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string r = "";
                    if (driverViewModel.Role == "Driver")
                    {
                        r = "Driver";
                    }
                    else
                    {
                        ModelState.AddModelError("", "erreur");
                        return View();
                    }

                    Account account = new Account
                    {
                        Email = driverViewModel.Email,
                        UserName = driverViewModel.Name,
                        PhoneNumber = driverViewModel.PhoneNumber,
                    };

                    var result = await userManager.CreateAsync(account, driverViewModel.Password);



                    if (result.Succeeded)
                    {
                        var role = await roleManager.FindByNameAsync(r);
                        if (role != null)
                            await userManager.AddToRoleAsync(account, role.Name);

                    
                        var temp = await userManager.GetUserIdAsync(account);
                        //var temp = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                        Console.WriteLine(temp);
                        
                        if (temp != null)
                        {
                            driverViewModel.AccountId = temp;
                            driverService.AddDriver(driverViewModel);

                        }
                        return RedirectToAction("Index", "Driver");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                }
                return View();
            }

            catch
            {
                return View();
            }
        }


        public ActionResult Login()
        {
            //Creation d'un admin
            //var manager = new Account
            //{
            //    UserName = "Admin01",
            //    NormalizedUserName = "ADMIN01",
            //    PhoneNumber = "0011223344",
            //    Email = "email.mail.com"
            //};
            //string passwordHash = "Ab@12345678";
            //try
            //{
            //    var result = await userManager.CreateAsync(manager, passwordHash);
            //    if (result.Succeeded)
            //    {
            //        Console.WriteLine("Admin créé");
            //        await userManager.AddToRoleAsync(manager, "Manager");
            //    }
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine("Admin creation : "+e);
            //}

            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Account");
            }
                return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                //AppUser user = userManager.FindByEmailAsync(loginViewModel.Email).Result;
                //if (user != null)
                //{
                var result = await signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);
                

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Account");
                }
                //}
                ModelState.AddModelError("", "Can't login user");
            }
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
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

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
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
