using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Models;
using TMS_PFA.Repositories;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Services
{
    public class DeliveryFormService : IDeliveryFormService
    {
        private readonly IRepository<DeliveryForm> repository;

        public DeliveryFormService(IRepository<DeliveryForm> repository)
        {
            this.repository = repository;
        }
        public void AddDeliveryForm(DeliveryFormViewModel del)
        {
            DeliveryForm deliveryForm = new DeliveryForm
            {
                Id = del.Id,
                ReceiptDate = del.ReceiptDate,
                DestinationAddress = del.DestinationAddress,
                Price = del.Price,
                DeliveryId = del.DeliveryId
            };
            repository.Add(deliveryForm);
        }

        public void DeleteDeliveryForm(DeliveryFormViewModel del)
        {
            throw new NotImplementedException();
        }

        public IList<DeliveryFormViewModel> GetAllDeliveryForm()
        {
            IList<DeliveryForm> deliveryForms = repository.GetAll().Result;
            return BindDeliveryFormList(deliveryForms);
        }

        private IList<DeliveryFormViewModel> BindDeliveryFormList(IList<DeliveryForm> deliveryForms)
        {
            IList<DeliveryFormViewModel> deliveryFormViewModels = new List<DeliveryFormViewModel>();
            foreach (DeliveryForm delivery in deliveryForms)
            {
                deliveryFormViewModels.Add(new DeliveryFormViewModel
                {
                    Id = delivery.Id,
                    ReceiptDate = delivery.ReceiptDate,
                    DestinationAddress = delivery.DestinationAddress,
                    Price = delivery.Price,
                    DeliveryId = delivery.DeliveryId
                });
            }
            return deliveryFormViewModels;
        }

        public IList<DeliveryFormViewModel> GetDeliveryFormByClient(Guid CId)
        {
            IList<DeliveryForm> allDeliveries = repository.GetIncludes(d => d.Delivery.PurchaseOrder);
            IList<DeliveryForm> deliveries = new List<DeliveryForm>();
            foreach (DeliveryForm del in allDeliveries)
            {
                if (del.Delivery.PurchaseOrder.ClienId.Equals(CId))
                {
                    deliveries.Add(del);
                }
            }
            return BindDeliveryFormList(deliveries);
        }



        public IList<DeliveryFormViewModel> GetDeliveryFormByDriver(Guid DId)
        {
            IList<DeliveryForm> allDeliveries = repository.GetIncludes(d => d.Delivery);
            IList<DeliveryForm> deliveries = new List<DeliveryForm>();
            foreach (DeliveryForm del in allDeliveries)
            {
                if (del.Delivery.DriverId.Equals(DId))
                {
                    deliveries.Add(del);
                }
            }
            return BindDeliveryFormList(deliveries);
        }

        public DeliveryFormViewModel GetDeliveryFormById(Guid id)
        {
            DeliveryForm delivery = repository.GetById(id).Result;
            if (delivery == null)
            {
                return new DeliveryFormViewModel();
            }
            else
            {
                DeliveryFormViewModel del = new DeliveryFormViewModel
                {
                    Id = delivery.Id,
                    ReceiptDate = delivery.ReceiptDate,
                    DestinationAddress = delivery.DestinationAddress,
                    Price = delivery.Price,
                    DeliveryId = delivery.DeliveryId
                };

                return del;
            } 
        }

        public Task UpdateDeliveryForm(DeliveryFormViewModel del)
        {
            throw new NotImplementedException();
        }
    }
}
