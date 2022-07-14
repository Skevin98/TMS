using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Models;
using TMS_PFA.Repositories;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IRepository<PurchaseOrder> repository;

        public PurchaseOrderService(IRepository<PurchaseOrder> repository)
        {
            this.repository = repository;
        }

        public void AddOrder(PurchaseOrderViewModel ord)
        {
            PurchaseOrder order = new PurchaseOrder
            {
                Id = ord.Id,
                Type = ord.Type,
                Date = ord.Date,
                Weight = ord.Weight,
                Height = ord.Height,
                Width = ord.Width,
                Quantity = ord.Quantity,
                Destination = ord.Destination,
                Details = ord.Details,
                ClienId = ord.ClienId
            };
            repository.Add(order);
        }

        public void DeleteOrder(PurchaseOrderViewModel ord)
        {
            throw new NotImplementedException();
        }

        public IList<PurchaseOrderViewModel> GetAllOrder()
        {
            IList<PurchaseOrder> orders = repository.GetAll().Result;
            return BindOrderList(orders);
        }

        public IList<PurchaseOrderViewModel> GetOrderByClient(Guid CId)
        {
            IList<PurchaseOrder> allOrders = repository.GetAll().Result;
            IList<PurchaseOrder> orders = new List<PurchaseOrder>();
            foreach (PurchaseOrder ord in allOrders)
            {
                if (ord.ClienId.Equals(CId))
                {
                    orders.Add(ord);
                }
            }
            return BindOrderList(orders);
        }

        private IList<PurchaseOrderViewModel> BindOrderList(IList<PurchaseOrder> orders)
        {
            IList<PurchaseOrderViewModel> purchaseOrderViewModels = new List<PurchaseOrderViewModel>();
            foreach (PurchaseOrder ord in orders)
            {
                purchaseOrderViewModels.Add(new PurchaseOrderViewModel
                {
                    Id = ord.Id,
                    Type = ord.Type,
                    Date = ord.Date,
                    Weight = ord.Weight,
                    Height = ord.Height,
                    Width = ord.Width,
                    Quantity = ord.Quantity,
                    Destination = ord.Destination,
                    Details = ord.Details,
                    ClienId = ord.ClienId
                });
            }
            return purchaseOrderViewModels;
        }

        public PurchaseOrderViewModel GetOrderById(Guid id)
        {
            PurchaseOrder order = repository.GetById(id).Result;
            if (order == null)
            {
                return new PurchaseOrderViewModel();
            }
            PurchaseOrderViewModel ord = new PurchaseOrderViewModel
            {
                Id = order.Id,
                Type = order.Type,
                Date = order.Date,
                Weight = order.Weight,
                Height = order.Height,
                Width = order.Width,
                Quantity = order.Quantity,
                Destination = order.Destination,
                Details = order.Details,
                ClienId = order.ClienId
            };
            return ord;
        }

        public void UpdateOrder(PurchaseOrderViewModel ord)
        {
            throw new NotImplementedException();
        }

       
    }
}
