using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Models;
using TMS_PFA.Repositories;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IRepository<Delivery> repository;


        private readonly IVehicleService vehicleService;

        private readonly IDriverService driverService;

        public DeliveryService(IRepository<Delivery> repository, IVehicleService vehicleService, IDriverService driverService)
        {
            this.repository = repository;

            this.vehicleService = vehicleService;

            this.driverService = driverService;
        }
        public void AddDelivery(EditDeliveryViewModel del)
        {
            Delivery delivery = new Delivery
            {
                Id = del.Id,
                Status = del.Status,
                Details = del.Details,
                EstimatedReceiptDate = del.EstimatedReceiptDate,
                Progression = del.Progression,
                PurchaseId = del.PurchaseId,
                VehicleId = del.SelectedVehicle,
                DriverId = del.SelectedDriver,

            };
            repository.Add(delivery);
        }

        public void DeleteDelivery(DeliveryViewModel del)
        {
            throw new NotImplementedException();
        }

        public IList<DeliveryViewModel> GetAllDelivery()
        {
            IList<Delivery> deliveries = repository.GetIncludes(df => df.DeliveryForm);
            return BindDeliveryList(deliveries);
        }

        private IList<DeliveryViewModel> BindDeliveryList(IList<Delivery> deliveries)
        {
            IList<DeliveryViewModel> deliveryViewModels = new List<DeliveryViewModel>();
            foreach (Delivery delivery in deliveries)
            {
                deliveryViewModels.Add(new DeliveryViewModel
                {
                    Id = delivery.Id,
                    Status = delivery.Status,
                    Details = delivery.Details,
                    EstimatedReceiptDate = delivery.EstimatedReceiptDate,
                    Progression = delivery.Progression,
                    PurchaseId = delivery.PurchaseId,
                    VehicleId = delivery.VehicleId,
                    DriverId = delivery.DriverId,
                    DeliveryFormId = delivery.DeliveryForm != null ? delivery.DeliveryForm.Id : Guid.Empty
                });
            }
            return deliveryViewModels;
        }

        public IList<DeliveryViewModel> GetDeliveryByClient(Guid CId)
        {
            IList<Delivery> allDeliveries = repository.GetIncludes( p=>p.PurchaseOrder,d=>d.Driver,v=>v.Vehicle, df => df.DeliveryForm);
            IList<Delivery> deliveries = new List<Delivery>();
            foreach (Delivery del in allDeliveries)
            {
                if (del.PurchaseOrder.ClientId.Equals(CId))
                {
                    deliveries.Add(del);
                }
            }
            return BindDeliveryList(deliveries);
        }

        public IList<DeliveryViewModel> GetDeliveryByDriver(Guid DId)
        {
            IList<Delivery> allDeliveries = repository.GetIncludes(p => p.PurchaseOrder, d => d.Driver, v => v.Vehicle, df => df.DeliveryForm);
            IList<Delivery> deliveries = new List<Delivery>();
            foreach (Delivery del in allDeliveries)
            {
                if (del.DriverId.Equals(DId))
                {
                    deliveries.Add(del);
                }
            }
            return BindDeliveryList(deliveries);
        }

        public DeliveryViewModel GetDeliveryById(Guid id)
        {
            Console.WriteLine("Del by id : " + id);
            Delivery delivery = repository.GetById(id).Result;
            if (delivery == null)
            {
                return new DeliveryViewModel();
            }
            else
            {
                
                DeliveryViewModel del = new DeliveryViewModel
                {
                    Id = delivery.Id,
                    Status = delivery.Status,
                    Details = delivery.Details,
                    EstimatedReceiptDate = delivery.EstimatedReceiptDate,
                    Progression = delivery.Progression,
                    PurchaseId = delivery.PurchaseId,
                    VehicleId = delivery.VehicleId,
                    DriverId = delivery.DriverId
                };


                return del;
            }
        }

        public async Task UpdateDelivery(EditDeliveryViewModel del)
        {
            Delivery delivery = repository.GetById(del.Id).Result;

            if (delivery != null)
            {
               
                delivery.Status = del.Status;
                delivery.Details = del.Details;
                delivery.EstimatedReceiptDate = del.EstimatedReceiptDate;
                delivery.Progression = del.Progression;
                delivery.PurchaseId = del.PurchaseId;
                delivery.VehicleId = del.SelectedVehicle;
                delivery.DriverId = del.SelectedDriver;
                await repository.Update(delivery);

            }

            
        }

        public IList<DeliveryViewModel> GetDeliveryByVehicle(Guid VId)
        {
            IList<Delivery> allDeliveries = repository.GetAll().Result;
            IList<Delivery> deliveries = new List<Delivery>();
            foreach (Delivery del in allDeliveries)
            {
                if (del.VehicleId.Equals(VId))
                {
                    deliveries.Add(del);
                }
            }
            return BindDeliveryList(deliveries);
        }

        public EditDeliveryViewModel GetEditDelivery(Guid? id)
        {
            EditDeliveryViewModel viewModel = new EditDeliveryViewModel();
            if (id != null)
            {
                Console.WriteLine("DS : " + id);
                Delivery delivery = repository.GetById((Guid)id).Result;
                viewModel.Id = delivery.Id;
                viewModel.Status = delivery.Status;
                viewModel.Details = delivery.Details;
                viewModel.EstimatedReceiptDate = delivery.EstimatedReceiptDate;
                viewModel.Progression = delivery.Progression;
                viewModel.PurchaseId = delivery.PurchaseId;
                viewModel.SelectedVehicle = delivery.VehicleId;
                viewModel.SelectedDriver = delivery.DriverId;
            }

            Console.WriteLine("DS2 : " + viewModel.Id);

            viewModel.Drivers = driverService.GetAvailableDriver(id);
            viewModel.Vehicles = vehicleService.GetAvailableVehicle(id);

            return viewModel;
            
        }

        public IList<DeliveryViewModel> GetDeliveryByOrder(Guid OId)
        {
            IList<Delivery> allDeliveries = repository.GetAll().Result;
            IList<Delivery> deliveries = new List<Delivery>();
            foreach (Delivery del in allDeliveries)
            {
                if (del.PurchaseId.Equals(OId))
                {
                    deliveries.Add(del);
                }
            }
            return BindDeliveryList(deliveries);
        }
    }
}
