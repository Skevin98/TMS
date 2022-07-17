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
    public class VehicleService : IVehicleService
    {
        private readonly IRepository<Vehicle> repository;

        public VehicleService(IRepository<Vehicle> repository)
        {
            this.repository = repository;
        }
        public void AddVehicle(VehicleViewModel vhc)
        {
            Vehicle vehicle = new Vehicle
            {
                NumberPlate = vhc.NumberPlate,
                Type = vhc.Type,
                Weight = vhc.Weight,
                Height = vhc.Height,
                Width = vhc.Width,
                PurchaseDate = vhc.PurchaseDate,
                Capacity = vhc.Capacity,
                TankCapacity = vhc.TankCapacity,
                Mileage = vhc.Mileage,
                Insurance = vhc.Insurance,
                TechnicalVisit = vhc.TechnicalVisit

            };

            try
            {
                repository.Add(vehicle);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void DeleteVehicle(VehicleViewModel vhc)
        {
            throw new NotImplementedException();
        }

        public IList<VehicleViewModel> GetAllVehicle()
        {
            IList<Vehicle> vehicules = repository.GetAll().Result;
            return BindDriverList(vehicules);
        }

        private IList<VehicleViewModel> BindDriverList(IList<Vehicle> vehicules)
        {
            IList<VehicleViewModel> vehicleViewModels = new List<VehicleViewModel>();

            foreach (Vehicle vhc in vehicules)
            {
                vehicleViewModels.Add(new VehicleViewModel
                {
                    NumberPlate = vhc.NumberPlate,
                    Type = vhc.Type,
                    Weight = vhc.Weight,
                    Height = vhc.Height,
                    Width = vhc.Width,
                    PurchaseDate = vhc.PurchaseDate,
                    Capacity = vhc.Capacity,
                    TankCapacity = vhc.TankCapacity,
                    Mileage = vhc.Mileage,
                    Insurance = vhc.Insurance,
                    TechnicalVisit = vhc.TechnicalVisit
                });
            }

            return vehicleViewModels;
            }

        public EditDriverViewModel GetEditVehicle(Guid? id)
        {
            throw new NotImplementedException();
        }

        public VehicleViewModel GetVehicleById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateVehicle(VehicleViewModel vhc)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem> GetAvailableVehicle(Guid? id)
        {

            IList<Vehicle> temp = repository.GetIncludes(del => del.Deliveries);
            
            IList<Vehicle> AvVehicles = new List<Vehicle>();
            foreach (Vehicle vhc in temp)
            {

                if (vhc.Deliveries.Exists(x => x.Id != id && x.Status.ToString().Equals("InProgress")))
                {

                    continue;
                    
                }

                AvVehicles.Add(vhc);
            }
            List<SelectListItem> vehicles = AvVehicles.OrderBy(v => v.NumberPlate)
                        .Select(v =>
                        new SelectListItem
                        {
                            Value = v.Id.ToString(),
                            Text = v.NumberPlate.ToString() +" "+ v.Type
                        }).ToList();

            return new SelectList(vehicles, "Value", "Text");
        }
    }
}
