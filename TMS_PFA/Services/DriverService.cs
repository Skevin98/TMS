using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Models;
using TMS_PFA.Repositories;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Services
{
    public class DriverService : IDriverService
    {
        private readonly IRepository<Driver> repository;
        private readonly IUserRepository<Driver> driverRepo;

        public DriverService(IRepository<Driver> repository, IUserRepository<Driver> driverRepo)
        {
            this.repository = repository;
            this.driverRepo = driverRepo;
        }
        public void AddDriver(DriverViewModel drv)
        {
            Driver driver = new Driver();
            driver.Id = drv.Id;
            driver.FirstName = drv.FirstName;
            driver.LastName = drv.Name;
            driver.Birth = drv.Birth;
            driver.Sexe = drv.Sexe;
            driver.Salary = drv.Salary;
            driver.HiringDate = drv.HiringDate;
            driver.Nid = drv.Nid;
            driver.LicenseId = drv.LicenseId;
            driver.LicenseType = drv.LicenseType;
            driver.AccountId = drv.AccountId;
            repository.Add(driver);
        }

        public void DeleteDriver(DriverViewModel drv)
        {
            throw new NotImplementedException();
        }

        public IList<DriverViewModel> GetAllDriver()
        {
            IList<Driver> drivers = repository.GetAll().Result;
            return BindDriverList(drivers);
        }

        private IList<DriverViewModel> BindDriverList(IList<Driver> drivers)
        {
            IList<DriverViewModel> driverViewModels = new List<DriverViewModel>();

            foreach (Driver drv in drivers)
            {
                driverViewModels.Add(new DriverViewModel
                {
                    Id = drv.Id,
                    FirstName = drv.FirstName,
                    Name = drv.LastName,
                    Birth = drv.Birth,
                    Sexe = drv.Sexe,
                    Salary = drv.Salary,
                    HiringDate = drv.HiringDate,
                    Nid = drv.Nid,
                    LicenseId = drv.LicenseId,
                    LicenseType = drv.LicenseType,
                    AccountId = drv.AccountId
                });
            }
            return driverViewModels;
        }

        public DriverViewModel GetDrivertById(Guid id)
        {
            Driver driver = repository.GetById(id).Result;
            if (driver == null)
            {
                return new DriverViewModel();
            }
            DriverViewModel drv = new DriverViewModel
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                Name = driver.LastName,
                Birth = driver.Birth,
                Sexe = driver.Sexe,
                Salary = driver.Salary,
                HiringDate = driver.HiringDate,
                Nid = driver.Nid,
                LicenseId = driver.LicenseId,
                LicenseType = driver.LicenseType,
                AccountId = driver.AccountId
            };

            return (drv);
        }

        public EditDriverViewModel GetEditDriver(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDriver(DriverViewModel drv)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem> GetAvailableDriver(Guid? id)
        {

            IList<Driver> temp = repository.GetIncludes(del => del.Deliveries);
            
            IList<Driver> AvDrivers = new List<Driver>();
            foreach (Driver drv in temp)
            {
                Console.WriteLine(drv.Deliveries.Count);
                if (drv.Deliveries.Exists(x => x.Id != id && x.Status.ToString().Equals("InProgress")))
                {
                    continue;
                    
                }

                AvDrivers.Add(drv);
            }
            List<SelectListItem> drivers = AvDrivers.OrderBy(d => d.LastName)
                        .Select(d =>
                        new SelectListItem
                        {
                            Value = d.Id.ToString(),
                            Text = d.LastName + ' ' + d.FirstName
                        }).ToList();

            return new SelectList(drivers, "Value", "Text");
        }
    }
}
